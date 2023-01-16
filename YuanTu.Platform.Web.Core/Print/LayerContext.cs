using Abp.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using YuanTu.Platform.Dto;

namespace YuanTu.Platform.Print
{
    public class LayerContext : IDisposable
    {
        protected List<Layer> m_header = new List<Layer>();
        protected List<Layer> m_footer = new List<Layer>();
        protected List<Layer> m_body = new List<Layer>();
        protected bool contaiPages = false;
        protected string ytpageCount = "ytpageCount";

        /// <summary>
        /// 纸张大小
        /// </summary>
        public PSize PageSize { get; set; }

        /// <summary>
        /// 打印纸张模式
        /// </summary>
        public string PageSizeMode { get; set; }

        /// <summary>
        /// 是否横向打印
        /// </summary>
        public bool Landscape { get; set; }

        /// <summary>
        /// 内边距
        /// </summary>
        public PPadding Padding { get; set; } = PPadding.Empty;

        /// <summary>
        /// 是否固定大小
        /// </summary>
        public bool Fixed { get; set; }

        /// <summary>
        /// 图层
        /// </summary>
        public List<Layer> Layers { get; set; }

        /// <summary>
        /// 纸张来源
        /// </summary>
        public PaperSourceKind PaperSourceKind { get; set; }

        private Graphics m_mesGraphics = null;
        public Graphics MesGraphics
        {
            get
            {
                if (m_mesGraphics == null)
                {
                    m_mesGraphics = Graphics.FromImage(new Bitmap(10, 10));
                }
                return m_mesGraphics;
            }
        }

        int maxH = 0;

        public List<byte[]> Print(PrintDto dto)
        {
            string dataSource = dto.Source;
            
            var ds = JObject.Parse("{}");
            try
            {
                ds = JObject.Parse(dataSource);
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException($"数据源入参不是合法的Json格式,{ex.Message}");
            }

            if (!string.IsNullOrEmpty(dto.BeforeScript))
            {
                CodeUnit.RunFunc(dto.BeforeScript, new Dictionary<string, object>() { { "ds", ds } });
            }
            SortLayers(ds);

            // 判断是否报告打印机
            if (PageSizeMode == "A4" || PageSizeMode == "A5")
            {
                return PrintReport(ds);
            }
            else
            {
                var res = new List<byte[]>();
                res.Add(PrintReceipt());
                return res;
            }
        }

        byte[] PrintReceipt()
        {
            var buffer = new byte[0];

            MemoryStream ms = new MemoryStream();

            // 初始化位图
            Bitmap map = new Bitmap(PageSize.Width, PageSize.Height);
            Graphics graphics = Graphics.FromImage(map);
            graphics.FillRectangle(Brushes.White, 0, 0, PageSize.Width, PageSize.Height);

            var layers = new List<Layer>();
            layers.AddRange(m_header);
            layers.AddRange(m_body);
            layers.AddRange(m_footer);

            CalcLayers(graphics, null, layers);
            if (layers.Count == 0)
            {
                map = new Bitmap(PageSize.Width, PageSize.Height);
            }
            else
            {
                map = new Bitmap(PageSize.Width, layers.Max(v => v.Bound.Bottom + v.Padding.Bottom));
            }
            graphics = Graphics.FromImage(map);
            graphics.FillRectangle(Brushes.White, 0, 0, map.Width, map.Height);

            foreach (var layer in layers)
            {
                PrintLayer(layer, graphics);
            }

            map.Save(ms, ImageFormat.Png);

            buffer = ms.ToArray();

            ms.Close();

            map.Dispose();

            return buffer;
        }

        List<byte[]> PrintReport(JToken ds)
        {
            var res = new List<byte[]>();

            byte[] buffer = new byte[0];

            Bitmap map = new Bitmap(PageSize.Width, PageSize.Height);

            Graphics graphics = Graphics.FromImage(map);
            try
            {
                graphics.FillRectangle(Brushes.White, 0, 0, PageSize.Width, PageSize.Height);

                CalcLayers(graphics, null, m_header);
                CalcLayers(graphics, null, m_footer);
                maxH = PageSize.Height;
                if (m_footer.Count > 0)
                {
                    maxH = m_footer.Min(v => v.Bound.Top - v.Padding.Top);
                }
                map.Dispose();

                if (m_header.Where(v => v.Bound.Bottom > PageSize.Height).Count() > 0)
                {
                    throw new UserFriendlyException("报文头高度超过纸张高度会导致死循环，请确认是否忘记设置报文体属性！");
                }

                var pageIndex = 1;
                if (contaiPages)
                {
                    ds[ytpageCount] = GetPages();
                }

                List<Bitmap> bitmaps = new List<Bitmap>();
                while (true)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (var bitmap = new Bitmap(PageSize.Width, PageSize.Height))
                        {
                            graphics = Graphics.FromImage(bitmap);

                            graphics.FillRectangle(Brushes.White, 0, 0, PageSize.Width, PageSize.Height);

                            ds["ytpageIndex"] = pageIndex;

                            // 计算打印
                            var page = new List<Layer>();
                            page.AddRange(m_header);
                            page.AddRange(m_body);
                            page.AddRange(m_footer);

                            CalcLayers(graphics, null, page);

                            foreach (var layer in m_header)
                            {
                                PrintLayer(layer, graphics);
                            }

                            PrintBody(m_body, graphics, maxH);

                            foreach (var layer in m_footer)
                            {
                                PrintLayer(layer, graphics);
                            }

                            bitmaps.Add(bitmap);

                            // 合并图片
                            bitmap.Save(ms, ImageFormat.Png);
                            bitmap.Dispose();
                        }
                        res.Add(ms.ToArray());

                        ms.Close();
                    }
                    pageIndex++;

                    if (m_body.Count == 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                graphics.Dispose();
            }
            
            return res;
        }

        public int GetPages()
        {
            var pageCount = 0;
            var body = JsonConvert.DeserializeObject<List<Layer>>(JsonConvert.SerializeObject(m_body));

            while (true)
            {
                MemoryStream ms = new MemoryStream();

                var bitmap = new Bitmap(PageSize.Width, PageSize.Height);

                var graphics = Graphics.FromImage(bitmap);

                // 计算打印
                var page = new List<Layer>();
                page.AddRange(m_header);
                page.AddRange(body);
                page.AddRange(m_footer);

                CalcLayers(graphics, null, page);

                PrintBody(body, graphics, maxH, false,body);

                pageCount++;

                if (body.Count == 0)
                {
                    break;
                }
            }

            return pageCount;
        }

        public void SortLayers(JToken ds)
        {
            foreach (var layer in Layers.OrderBy(v=>v.Zindex))
            {
                // 判断不打印条件
                if (!RunVif(layer, ds))
                {
                    continue;
                }

                if (string.IsNullOrEmpty(layer.Field))
                {
                    if (layer.LayerType == LayerType.Panel)
                    {
                        layer.Source = ds;
                    }
                }
                else
                {
                    if (layer.Field.ToLower().Contains(ytpageCount.ToLower()))
                    {
                        contaiPages = true;
                    }
                    layer.Source = ds[layer.Field];
                }

                switch (layer.Source?.Type)
                {
                    case JTokenType.Array:
                        for (var p = 0; p < layer.Source.Count(); p++)
                        {
                            var dl = layer.Source[p];

                            if (layer.IsBody)
                            {
                                m_body.Add(RecureLayers(layer, dl));
                            }
                            else
                            {
                                if (layer.Dock == DockStyle.Bottom)
                                {
                                    m_footer.Add(RecureLayers(layer, dl));
                                }
                                else if (layer.Dock != DockStyle.Fill && layer.Dock != DockStyle.Bottom)
                                {
                                    m_header.Add(RecureLayers(layer, dl));
                                }
                            }
                        }
                        break;
                    default:
                        if (layer.IsBody)
                        {
                            m_body.Add(RecureLayers(layer, ds));
                        }
                        else
                        {
                            if (layer.Dock == DockStyle.Bottom)
                            {
                                m_footer.Add(RecureLayers(layer, ds));
                            }
                            else if (layer.Dock != DockStyle.Fill && layer.Dock != DockStyle.Bottom)
                            {
                                m_header.Add(RecureLayers(layer, ds));
                            }
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// 递归添加图层
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        protected Layer RecureLayers(Layer layer, JToken ds)
        {
            var target = JsonConvert.DeserializeObject<Layer>(JsonConvert.SerializeObject(layer));
            target.Source = ds;

            if (layer.Layers != null && layer.Layers.Count > 0)
            {
                target.Layers.Clear();

                foreach (var item in layer.Layers)
                {
                    if (string.IsNullOrEmpty(item.Field))
                    {
                        if (item.LayerType == LayerType.Panel)
                        {
                            item.Source = ds;
                        }

                        if (item.Layers != null && item.Layers.Count > 0)
                        {
                            target.Layers.Add(RecureLayers(item, ds));
                        }
                        else
                        {
                            var clone = JsonConvert.DeserializeObject<Layer>(JsonConvert.SerializeObject(item));
                            clone.Source = ds;
                            target.Layers.Add(clone);
                        }
                    }
                    else
                    {
                        if (item.Field.ToLower().Contains(ytpageCount.ToLower()))
                        {
                            contaiPages = true;
                        }

                        var dl = ds[item.Field];
                        if (dl != null)
                        {
                            switch (dl.Type)
                            {
                                case JTokenType.Array:
                                    for (var p = 0; p < dl.Count(); p++)
                                    {
                                        // 判断不打印条件
                                        if (!RunVif(item, ds))
                                        {
                                            continue;
                                        }

                                        if (item.Layers != null && item.Layers.Count > 0)
                                        {
                                            target.Layers.Add(RecureLayers(item, dl[p]));
                                        }
                                        else
                                        {
                                            var clone = JsonConvert.DeserializeObject<Layer>(JsonConvert.SerializeObject(item));
                                            clone.Source = dl[p];
                                            target.Layers.Add(clone);
                                        }
                                    }
                                    break;
                                default:
                                    // 判断不打印条件
                                    if (!RunVif(item, ds))
                                    {
                                        continue;
                                    }

                                    if (item.Layers != null && item.Layers.Count > 0)
                                    {
                                        target.Layers.Add(RecureLayers(item, dl));
                                    }
                                    else
                                    {
                                        if (item.LayerType == LayerType.Text && item.PageSplit)
                                        {
                                            var texts = item.MeasureString(MesGraphics, dl.Value<string>());
                                            var zindex = layer.Layers.Max(v => v.Zindex) + 1;
                                            foreach (var text in texts)
                                            {
                                                var clone = JsonConvert.DeserializeObject<Layer>(JsonConvert.SerializeObject(item));
                                                clone.Text = text.Item;
                                                clone.Field = "";
                                                if (item.Dock == DockStyle.Fill)
                                                {
                                                    clone.Dock = DockStyle.Top;
                                                }
                                                clone.Data = text.Item;
                                                clone.Zindex = zindex++;
                                                target.Layers.Add(clone);
                                            }
                                        }
                                        else
                                        {
                                            var clone = JsonConvert.DeserializeObject<Layer>(JsonConvert.SerializeObject(item));
                                            clone.Source = dl;
                                            target.Layers.Add(clone);
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            // 判断不打印条件
                            if (!RunVif(item, ds))
                            {
                                continue;
                            }

                            if (item.Layers != null && item.Layers.Count > 0)
                            {
                                target.Layers.Add(RecureLayers(item, ds));
                            }
                            else
                            {
                                var clone = JsonConvert.DeserializeObject<Layer>(JsonConvert.SerializeObject(item));
                                if (clone.LayerType != LayerType.Panel)
                                {
                                    clone.Source = ds;
                                }

                                target.Layers.Add(clone);
                            }
                        }
                    }
                }
            }

            return target;
        }

        /// <summary>
        /// 计算图层定位
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="parent"></param>
        /// <param name="layers"></param>
        protected void CalcLayers(Graphics graphics, Layer parent, List<Layer> layers)
        {
            PPoint absLocation = new PPoint(0, 0);

            var top = absLocation.Top + Padding.Top;
            var left = absLocation.Left + Padding.Left;

            var right = PageSize.Width - Padding.Right;
            var bottom = PageSize.Height - Padding.Bottom;

            if (parent != null)
            {
                absLocation = new PPoint(parent.AbspLocation.Left + parent.Location.Left, parent.AbspLocation.Top + parent.Location.Top);

                top = absLocation.Top + parent.Padding.Top;
                left = absLocation.Left + parent.Padding.Left;

                right = absLocation.Left + parent.Size.Width - parent.Padding.Right;
                bottom = absLocation.Top + parent.Size.Height - parent.Padding.Bottom;
            }
            else
            {
                absLocation = new PPoint(0, 0);
            }

            foreach (var layer in layers.OrderBy(v => v.Dock == DockStyle.Fill).ThenBy(v => v.Zindex).ToList())
            {
                layer.AbspLocation = absLocation;
                // 
                switch (layer.Dock)
                {
                    case DockStyle.None:
                        break;
                    case DockStyle.Left:
                        layer.Location = new PPoint(left - absLocation.Left, top - absLocation.Top);
                        break;
                    case DockStyle.Top:
                        layer.Location = new PPoint(left - absLocation.Left, top - absLocation.Top);
                        break;
                    case DockStyle.Right:
                        layer.Location = new PPoint(right - layer.Size.Width - absLocation.Left, top - absLocation.Top);
                        break;
                    case DockStyle.Bottom:
                        layer.Location = new PPoint(left - absLocation.Left, bottom - layer.Size.Height - absLocation.Top);
                        break;
                    default:
                        //layer.AbspLocation = new PPoint(left - absLocation.Left, top - absLocation.Top);
                        layer.Size = new PSize(right - left, bottom - top);
                        break;
                }

                /******************************计算打印范围******************************/
                // 停靠模式
                if (layer.Dock != DockStyle.None)
                {
                    if (layer.LayerType == LayerType.Panel)
                    {
                        if (layer.Layers != null && layer.Layers.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(layer.Field))
                            {
                                if (layer.Source != null)
                                {
                                    if (layer.Layers != null && layer.Layers.Count > 0)
                                    {
                                        CalcLayers(graphics, layer, layer.Layers);
                                    }
                                }
                            }
                            else
                            {
                                if (layer.Layers != null && layer.Layers.Count > 0)
                                {
                                    CalcLayers(graphics, layer, layer.Layers);
                                }
                            }
                        }

                        // 判断是否隐藏
                        if (!string.IsNullOrEmpty(layer.Vif))
                        {
                            layer.Visible = false;
                        }
                    }
                }
                else
                {
                    // 非停靠模式
                    if (layer.Layers != null && layer.Layers.Count > 0)
                    {
                        CalcLayers(graphics, layer, layer.Layers);
                    }
                }
                /******************************计算打印范围******************************/

                if (layer.LayerType == LayerType.Text && layer.Autosize)
                {
                    var hh = layer.Size.Height;

                    if (layer.PreSize != PSize.Empty)
                    {
                        hh = layer.PreSize.Height;
                    }

                    var wd = layer.MeasureString(graphics, layer.Data).Count * layer.Font.Size * layer.LineHeight + hh % (layer.Font.Size * layer.LineHeight);
                    if (layer.Size.Height < wd)
                    {
                        if (layer.PreSize == PSize.Empty)
                        {
                            layer.PreSize = new PSize(layer.Size.Width, layer.Size.Height);
                        }

                        layer.Size = new PSize(layer.Size.Width, (int)Math.Round((decimal)wd));

                        if (parent != null && parent.Size.Height < wd)
                        {
                            parent.Size = new PSize(parent.Size.Width, (int)Math.Round((decimal)wd));
                        }
                    }
                }

                layer.AbspLocation = absLocation;

                // 
                switch (layer.Dock)
                {
                    case DockStyle.None:
                        break;
                    case DockStyle.Left:
                        //layer.Location = new PPoint(left - absLocation.Left, top - absLocation.Top);
                        left += layer.Size.Width;
                        break;
                    case DockStyle.Top:
                        //layer.Location = new PPoint(left - absLocation.Left, top - absLocation.Top);
                        top += layer.Size.Height;
                        break;
                    case DockStyle.Right:
                        //layer.Location = new PPoint(right - layer.Size.Width - absLocation.Left, top - absLocation.Top);
                        right -= layer.Size.Width;
                        break;
                    case DockStyle.Bottom:
                        //layer.Location = new PPoint(left - absLocation.Left, bottom - layer.Size.Height - absLocation.Top);
                        bottom -= layer.Size.Height;
                        break;
                    default:
                        if (PageSizeMode == "A4" || PageSizeMode == "A5")
                        {
                            //if (layer.Size.Height > bottom - top)
                            //{
                            //    layer.Size = new PSize(right - left, bottom - top);
                            //}
                        }
                        //layer.AbspLocation = new PPoint(left - absLocation.Left, top - absLocation.Top);
                        break;
                }

                if (layer.LayerType == LayerType.Panel && layer.Autosize && layer.Layers.Count == 0)
                {
                    layer.Size = new PSize(0, 0);
                }
            }

            // 计算父图层大小
            if (parent == null)
            {
                if ((PageSizeMode != "A4" && PageSizeMode != "A5"))
                {
                    var heighest = layers.Where(v => v.Visible).OrderByDescending(v => v.AbspLocation.Top + v.Location.Top + v.Size.Height).FirstOrDefault();
                    if (heighest != null)
                    {
                        PageSize = new PSize(PageSize.Width, heighest.Size.Height + heighest.Location.Top + Padding.Bottom);
                    }
                }
            }
            else if (parent.Autosize)
            {
                var heighest = parent.Layers.Where(v => v.Visible).OrderByDescending(v => v.AbspLocation.Top + v.Location.Top + v.Size.Height).FirstOrDefault();

                parent.Size = new PSize(parent.Size.Width,parent.Padding.Top +  heighest.Size.Height + heighest.Location.Top + heighest.Padding.Bottom + parent.Padding.Bottom);

                // 计算子集宽高
                CalcChildrenLayers(parent);
            }
        }

        /// <summary>
        /// 重新计算子图层定位
        /// </summary>
        /// <param name="parent"></param>
        protected void CalcChildrenLayers(Layer parent)
        {
            var top = parent.Padding.Top;
            var left = parent.Padding.Left;
            var right = parent.Size.Width - parent.Padding.Right;
            var bottom = parent.Size.Height - parent.Padding.Bottom;

            foreach (var layer in parent.Layers.Where(v => v.Dock != DockStyle.None).OrderBy(v=> v.Dock == DockStyle.Fill).ThenBy(v => v.Zindex))
            {
                if (layer.Autosize)
                {
                    if (layer.Dock == DockStyle.Left)
                    {
                        layer.Size = new PSize(layer.Size.Width, bottom - top);

                        left = left + layer.Size.Width;
                        //if (layer.Size.Height < bottom - top)
                        //{
                        //}
                    }

                    if (layer.Dock == DockStyle.Right)
                    {
                        layer.Size = new PSize(layer.Size.Width, bottom - top);

                        right = right - layer.Size.Width;
                        //if (layer.Size.Height < bottom - top)
                        //{
                        //}
                    }

                    if (layer.Dock == DockStyle.Top)
                    {
                        layer.Size = new PSize(right - left, layer.Size.Height);

                        bottom = top + layer.Size.Height;
                    }

                    if (layer.Dock == DockStyle.Bottom)
                    {
                        layer.Size = new PSize(right - left, layer.Size.Height);

                        bottom = bottom - layer.Size.Height;
                        //if (layer.Size.Height < bottom - top)
                        //{
                        //    layer.Size = new PSize(layer.Size.Height, right - left);

                        //    bottom = bottom - layer.Size.Height;
                        //}
                    }

                    if (layer.Dock == DockStyle.Fill)
                    {
                        layer.Size = new PSize(right - left, bottom - top);
                    }
                }
            }
        }

        /// <summary>
        /// 打印报告体
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="graphics"></param>
        /// <returns>是否分页</returns>
        bool PrintBody(List<Layer> layers, Graphics graphics, int maxHeight, bool print = true, List<Layer> body = null)
        {
            var res = false;
            var hasleft = false;
            List<Layer> removed = new List<Layer>();

            foreach (var layer in layers)
            {
                if (layer.LayerType == LayerType.Panel)
                {
                    if (layer.Dock == DockStyle.Left)
                        hasleft = true;
                    if (layer.Layers != null && layer.Layers.Count > 0)
                    {
                        res = PrintBody(layer.Layers, graphics, maxHeight, print, body);

                        // 判断高度
                        if (layer.Bound.Bottom + layer.Padding.Bottom > maxHeight)
                        {
                            if (layer.Layers.Where(v => v.LayerType == LayerType.Panel).Count() == 0)
                            {
                                res = true;
                                if (!hasleft)
                                {
                                    break;
                                }
                            }
                        }

                        if (res)
                        {
                            if (hasleft)
                            {
                                continue;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    // 判断高度
                    if (layer.Bound.Bottom + layer.Padding.Bottom > maxHeight)
                    {
                        res = true;
                        break;
                    }
                }

                if (print)
                {
                    this.PrintLayer(layer, graphics);
                }

                removed.Add(layer);
            }

            foreach (var ll in removed)
            {
                // 仅针对左边容器右边文本换页情况下
                if ((ll.Dock == DockStyle.Left || ll.Dock == DockStyle.Right) && res && layers.Count(v => v.PageSplit) > 0)
                {
                    if (ll.LayerType == LayerType.Text)
                    {
                        ll.Text = "";
                    }
                    continue;
                }

                if (body == null)
                {
                    RemoveLayerInBody(m_body, ll);
                }
                else
                {
                    RemoveLayerInBody(body, ll);
                }
            }

            return res;
        }

        /// <summary>
        /// 移除已打印图层
        /// </summary>
        /// <param name="layers"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        bool RemoveLayerInBody(List<Layer> layers, Layer layer)
        {
            Layer removeLayer = null;
            foreach (var item in layers)
            {
                if (item == layer)
                {
                    removeLayer = item;
                    break;
                }

                if (item.Layers != null && item.Layers.Count > 0)
                {
                    if (RemoveLayerInBody(item.Layers, layer))
                    {
                        break;
                    }
                }
            }

            layers.RemoveAll(v => v == removeLayer);

            return removeLayer != null;
        }

        /// <summary>
        /// 打印图层
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="graphics"></param>
        void PrintLayer(Layer layer, Graphics graphics)
        {
            switch (layer.LayerType)
            {
                case LayerType.Text:
                    PrintText(layer, graphics);
                    break;
                case LayerType.Barcode:
                    PrintBarcode(layer, graphics);
                    break;
                case LayerType.Qrcode:
                    PrintQrcode(layer, graphics);
                    break;
                case LayerType.Delimiter:
                    PrintDelimiter(layer, graphics);
                    break;
                case LayerType.Image:
                    PrintImage(layer, graphics);
                    break;
                case LayerType.Panel:
                    PrintPanel(layer, graphics);
                    break;
                default:
                    break;
            }

            if (layer.Layers != null && layer.Layers.Count > 0)
            {
                foreach (var child in layer.Layers)
                {
                    PrintLayer(child, graphics);
                }
            }
        }

        void PrintPanel(Layer layer, Graphics graphics)
        {
            DrawBorder(graphics, layer);
        }

        void PrintText(Layer layer, Graphics graphics)
        {
            List<MapData<string,bool>> texts = layer.MeasureString(graphics, layer.Data);

            var p = 0;
            var pleft = layer.Padding.Left;
            var pright = layer.Padding.Right;
            var ptop = layer.Padding.Top;
            var pbottom = layer.Padding.Bottom;

            var pwidth = layer.Bound.Width;
            var pheight = layer.Bound.Height;

            var lheight = (int)Math.Round(layer.Font.Size * layer.LineHeight);
            var submtop = (layer.Font.Font.GetHeight() - lheight) / 2;
            var maxHeight = texts.Count * lheight;
            if (layer.Autosize)
            {
                if (maxHeight > layer.Size.Height)
                {
                    layer.Size = new PSize(layer.Size.Width, maxHeight);
                }
            }

            foreach (var line in texts)
            {
                p++;

                var subLeft = 0f;
                var subtop = 0f;
                var remainder = pwidth;

                if (line.Item1)
                {
                    remainder = (int)graphics.MeasureString(line.Item, layer.Font.Font).Width;
                }

                switch (layer.Textalign)
                {
                    case Textalign.TopLeft:
                        subtop = ptop - submtop;
                        subLeft = pleft;
                        break;
                    case Textalign.TopCenter:
                        subtop = ptop - submtop;
                        subLeft = pleft + (pwidth - remainder) / 2;
                        break;
                    case Textalign.TopRight:
                        subtop = ptop - submtop;
                        subLeft = pleft + pwidth - remainder;
                        break;
                    case Textalign.MiddleLeft:
                        subtop = -submtop - (maxHeight - pheight) / 2;
                        subLeft = pleft;
                        break;
                    case Textalign.MiddleCenter:
                        subtop = -submtop - (maxHeight - pheight) / 2;
                        subLeft = pleft + (pwidth - remainder) / 2;
                        break;
                    case Textalign.MiddleRight:
                        subtop = -submtop + (pheight - maxHeight) / 2;
                        subLeft = pleft + pwidth - remainder;
                        break;
                    case Textalign.BottomLeft:
                        subtop = ptop + pheight - maxHeight - submtop;
                        subLeft = pleft;
                        break;
                    case Textalign.BottomCenter:
                        subtop = ptop + pheight - maxHeight - submtop;
                        subLeft = pleft + (pwidth - remainder) / 2;
                        break;
                    case Textalign.BottomRight:
                        subtop = ptop + pheight - maxHeight - submtop;
                        subLeft = pleft + pwidth - remainder;
                        break;
                }
                subtop = subtop + (p - 1) * lheight;

                graphics.DrawString(line.Item, layer.Font.Font, Brushes.Black, layer.Bound.Left + subLeft - pleft, layer.Bound.Top + subtop - ptop);
            }

            DrawBorder(graphics, layer);
        }

        private void DrawBorder(Graphics graphics, Layer layer)
        {
            var left = layer.AbspLocation.Left + layer.Location.Left;
            var top = layer.AbspLocation.Top + layer.Location.Top;
            var right = left + layer.Size.Width;
            var bottom = top + layer.Size.Height;

            if (layer.Border.Left != 0)
            {
                graphics.DrawLine(Pens.Black, left, top, left, bottom);
            }
            if (layer.Border.Top != 0)
            {
                graphics.DrawLine(Pens.Black, left, top, right, top);
            }
            if (layer.Border.Right != 0)
            {
                graphics.DrawLine(Pens.Black, right, top, right, bottom);
            }
            if (layer.Border.Bottom != 0)
            {
                graphics.DrawLine(Pens.Black, left, bottom, right, bottom);
            }
        }

        void PrintDelimiter(Layer layer, Graphics graphics)
        {
            List<string> texts = new List<string>();
            texts.Add(LayerUtil.MeasureDelimiterString(graphics, layer.Text, layer.Font.Font, layer.Size.Width));
            
            var p = 0;
            var pleft = layer.Padding.Left;
            var pright = layer.Padding.Right;
            var ptop = layer.Padding.Top;
            var pbottom = layer.Padding.Bottom;

            var pwidth = layer.Bound.Width;
            var pheight = layer.Bound.Height;


            var lheight = (int)Math.Round(layer.Font.Size * layer.LineHeight);
            var submtop = (layer.Font.Font.GetHeight() - lheight) / 2;
            var maxHeight = texts.Count * lheight;
            foreach (var line in texts)
            {
                p++;

                var subLeft = 0f;
                var subtop = 0f;
                var remainder = 0f;

                if (p == texts.Count)
                {
                    remainder = (int)graphics.MeasureString(line, layer.Font.Font).Width;
                }

                if (remainder > layer.Size.Width)
                {
                    remainder = layer.Size.Width;
                }

                switch (layer.Textalign)
                {
                    case Textalign.TopLeft:
                        subtop = ptop - submtop;
                        subLeft = pleft;
                        break;
                    case Textalign.TopCenter:
                        subtop = ptop - submtop;
                        subLeft = pleft + (pwidth - remainder) / 2;
                        break;
                    case Textalign.TopRight:
                        subtop = ptop - submtop;
                        subLeft = pleft + pwidth - remainder;
                        break;
                    case Textalign.MiddleLeft:
                        subtop = -submtop - (maxHeight - pheight) / 2;
                        subLeft = pleft;
                        break;
                    case Textalign.MiddleCenter:
                        subtop = -submtop - (maxHeight - pheight) / 2;
                        subLeft = pleft + (pwidth - remainder) / 2;
                        break;
                    case Textalign.MiddleRight:
                        subtop = -submtop + (pheight - maxHeight) / 2;
                        subLeft = pleft + pwidth - remainder;
                        break;
                    case Textalign.BottomLeft:
                        subtop = ptop + pheight - maxHeight - submtop;
                        subLeft = pleft;
                        break;
                    case Textalign.BottomCenter:
                        subtop = ptop + pheight - maxHeight - submtop;
                        subLeft = pleft + (pwidth - remainder) / 2;
                        break;
                    case Textalign.BottomRight:
                        subtop = ptop + pheight - maxHeight - submtop;
                        subLeft = pleft + pwidth - remainder;
                        break;
                }
                subtop = subtop + (p - 1) * lheight;

                //graphics.FillRectangle(Brushes.SkyBlue, layer.Bound);

                graphics.DrawString(line, layer.Font.Font, Brushes.Black, layer.Bound.Left + subLeft - pleft, layer.Bound.Top + subtop - ptop);

                //graphics.DrawRectangle(Pens.Black, layer.Bound);
            }
        }

        void PrintImage(Layer layer, Graphics graphics)
        {
            try
            {
                Bitmap bitmap;
                var text = layer.Data;
                if (string.IsNullOrEmpty(text))
                    return;

                var base64Png = "data:image/png;base64,";
                var base64Jpg = "data:image/jpg;base64,";
                var base64Jpeg = "data:image/jpeg;base64,";
                
                byte[] buffer;
                if (text.StartsWith("http://") || text.StartsWith("https://"))
                {
                    var resp = WebRequest.Create(text).GetResponse();
                    buffer = new byte[resp.ContentLength];
                    var ps = 0;

                    while (true)
                    {
                        var len = 0;
                        if (resp.ContentLength - ps < 1024)
                        {
                            len = resp.GetResponseStream().Read(buffer, ps, buffer.Length - ps);
                        }
                        else
                        {
                            len = resp.GetResponseStream().Read(buffer, ps, 1024);
                        }
                        ps += len;

                        if (ps == buffer.Length)
                        {
                            break;
                        }
                    }
                    resp.Close();
                }
                else if (text.StartsWith(base64Png) || text.StartsWith(base64Jpg))
                {
                    buffer = Convert.FromBase64String(text.Substring(base64Png.Length));
                }
                else if (text.StartsWith(base64Jpeg))
                {
                    buffer = Convert.FromBase64String(text.Substring(base64Jpeg.Length));
                }
                else
                {
                    buffer = Convert.FromBase64String(text);
                }

                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    bitmap = new Bitmap(stream);

                    // 绘制目标大小图片
                    graphics.DrawImage(bitmap, layer.Bound, new RectangleF(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);

                    bitmap.Dispose();
                }
            }
            catch(Exception ex)
            {
                graphics.DrawString($"绘制图片失败,{ex.Message + ex.StackTrace}", new Font("宋体", 20), Brushes.Red, layer.Bound);
            }
        }

        void PrintBarcode(Layer layer, Graphics graphics)
        {
            string text = layer.Data;

            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            try
            {
                var pixelData = BarcodeUtil.Create(text, layer.Size.Width - layer.Padding.Left - layer.Padding.Right, layer.Size.Height - layer.Padding.Top - layer.Padding.Bottom, ZXing.BarcodeFormat.CODE_128);

                using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb))

                using (var ms = new MemoryStream())
                {
                    var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height),
                       System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                    try
                    {
                        // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image
                        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0,
                           pixelData.Pixels.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bitmapData);
                    }
                    // save to stream as PNG
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    graphics.DrawImage(bitmap, layer.Bound.Left, layer.Bound.Top);
                }
            }
            catch
            { 
            }
            
        }

        void PrintQrcode(Layer layer, Graphics graphics)
        {
            string text = layer.Data;

            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            var pixelData = BarcodeUtil.Create(text, layer.Size.Width - layer.Padding.Left - layer.Padding.Right, layer.Size.Height - layer.Padding.Top - layer.Padding.Bottom, ZXing.BarcodeFormat.QR_CODE);

            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb))

            using (var ms = new MemoryStream())
            {
                var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height),
                   System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                try
                {
                    // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image
                    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0,
                       pixelData.Pixels.Length);
                }
                finally
                {
                    bitmap.UnlockBits(bitmapData);
                }
                // save to stream as PNG
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                graphics.DrawImage(bitmap, layer.Bound.Left, layer.Bound.Top);
            }
        }

        bool RunVif(Layer layer, JToken ds)
        {
            if (string.IsNullOrEmpty(layer.Vif))
                return true;

            string command = layer.Vif;
            string fields = layer.Field;

            var dic = new Dictionary<string, object>();

            foreach (var field in fields.Split(','))
            {
                if (ds[field] == null)
                {
                    dic.Add(field, null);
                }
                else
                {
                    switch (ds[field].Type)
                    {
                        case JTokenType.String:
                            dic.Add(field, ds[field].Value<string>());
                            break;
                        case JTokenType.Integer:
                            dic.Add(field, ds[field].Value<int>());
                            break;
                        case JTokenType.Date:
                            dic.Add(field, ds[field].Value<DateTime>());
                            break;
                        case JTokenType.Null:
                            dic.Add(field, null);
                            break;
                        default:
                            dic.Add(field, ds[field].Value<string>());
                            break;
                    }
                }
            }

            return CodeUnit.Excute(command, dic);
        }

        public void Dispose()
        {
            if (m_mesGraphics != null)
            {
                m_mesGraphics.Dispose();
            }
        }
    }

    public class PPaintEventArgs : EventArgs
    {
        public LayerContext Manager { get; set; }

        public Graphics Graphics { get; set; }
    }
}
