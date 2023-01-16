using Abp.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace YuanTu.Platform.Print
{
    public class Layer : ILayer
    {
        public string Sid { get; set; } = Guid.NewGuid().ToString("N");

        public string Uid { get; set; }

        public string Pid { get; set; }

        public LayerType LayerType { get; set; }

        public DockStyle Dock { get; set; }

        public PPoint Location { get; set; }

        public PSize PreSize { get; set; } = PSize.Empty;

        public PSize Size { get; set; }

        public bool IsBody { get; set; }

        public decimal Ratio { get; set; }

        public PPadding Padding { get; set; } = PPadding.Empty;

        public PPadding Border { get; set; } = PPadding.Empty;

        public int Zindex { get; set; }

        public string Text { get; set; }

        public string Field { get; set; }

        public string Format { get; set; }

        public string Color { get; set; }

        public PFont Font { get; set; }

        public Textalign Textalign { get; set; }

        public bool Wordwrap { get; set; }

        public bool Autosize { get; set; }

        public float LineHeight { get; set; } = 1.4f;

        public string Vif { get; set; }

        public JToken Source { get; set; }

        public PPoint AbspLocation { get; set; } = new PPoint(0, 0);

        public List<Layer> Layers { get; set; }

        //public Layer Parent { get; set; }

        public bool IsPrinted { get; set; }

        public bool PageSplit { get; set; }

        public bool Visible { get; set; } = true;

        private bool isRuned = false;
        private string _data = string.Empty;
        public string Data
        {
            get
            {
                if (isRuned && !Field.Contains("ytpageIndex"))
                {
                    return _data;
                }

                if (string.IsNullOrEmpty(Field))
                    return this.Text;

                if (Source == null)
                    return string.Empty;

                if (Source == null || Source.Type == JTokenType.Null || Source.Type == JTokenType.Undefined)
                    return string.Format(Text, Field.Split(',').Select(v => "").ToArray());

                if (LayerType == LayerType.Panel)
                    return "";

                var dic = new Dictionary<string, object>();
                var fields = Field.Split(',');

                foreach (var field in fields)
                {
                    dic.Add(field, GetValue(Source, field));
                }

                if (!string.IsNullOrEmpty(Format))
                {
                    int p = 0;
                    var formats = GetFormats(fields, Format);
                    foreach (var format in formats)
                    {
                        var res = CodeUnit.RunScript<object>(format.Value, dic);
                        if (res)
                        {
                            dic[fields[p]] = res.Data;
                        }
                        else
                        {
                            throw new UserFriendlyException(res.Msg);
                        }
                        p++;
                    }
                }

                _data = string.Format(Text, dic.Select(v => v.Value).ToArray());

                isRuned = true;

                return _data;
            }
            set
            {
                if (isRuned)
                {
                    _data = value;
                }
            }
        }

        /// <summary>
        /// 默认打印内容范围
        /// </summary>
        public Rectangle Bound
        {
            get
            {
                return new Rectangle(AbspLocation.Left + Location.Left + Padding.Left, 
                    AbspLocation.Top + Location.Top + Padding.Top, 
                    Size.Width - Padding.Left - Padding.Right,
                    Size.Height - Padding.Top - Padding.Bottom);
            }
        }

        /// <summary>
        /// 实际打印范围
        /// </summary>
        //public Rectangle PrintBound { get; set; }

        public virtual void Paint(object sender, PPaintEventArgs e)
        {
            // 判断是否容器
            if (LayerType == LayerType.Panel)
            {
                if (Layers != null && Layers.Count > 0)
                {
                    foreach (var layer in Layers)
                    {

                    }
                }
            }
            else
            {
                
            }
        }

        public object GetValue(JToken item, string field)
        {
            field = field.TrimStart('#');

            if (Source.Type != JTokenType.Object)
            {
                return GetValue(Source);
            }

            return GetValue(Source[field]);
        }

        public object GetValue(JToken item)
        {
            object value = "";

            if (item == null)
                return value;

            switch (item.Type)
            {
                case JTokenType.String:
                    value = item.Value<string>();
                    break;
                case JTokenType.Integer:
                    value = item.Value<int>();
                    break;
                case JTokenType.Float:
                    value = item.Value<double>();
                    break;
                case JTokenType.Boolean:
                    value = item.Value<bool>();
                    break;
                case JTokenType.Date:
                    value = item.Value<DateTime>();
                    break;
                case JTokenType.Null:
                    value = null;
                    break;
                default:
                    value = item.Value<string>();
                    break;
            }

            return value;
        }

        public Dictionary<string, string> GetFormats(string[] fields, string format)
        {
            var res = new Dictionary<string, string>();
            try
            {
                var fj = JObject.Parse(format);

                foreach (var field in fields)
                {
                    if (fj[field] == null)
                        continue;

                    res.Add(field, fj[field].Value<string>());
                }
            }
            catch
            {
                res.Add(fields[0], format);
            }

            return res;
        }
    }
}
