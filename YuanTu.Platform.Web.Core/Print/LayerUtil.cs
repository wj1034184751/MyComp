using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace YuanTu.Platform.Print
{
    public static class LayerUtil
    {
        public static List<MapData<string, bool>> MeasureString(this Layer layer, Graphics graphics, string input)
        {
            var temp = input.Split('\n').Select(v => new MapData<string, bool>(v.Replace("\r", ""), true)).ToList();

            if (!layer.Wordwrap)
            {
                return temp;
            }

            var result = new List<MapData<string, bool>>();
            var breakPoint = 0;

            var blank = graphics.MeasureString("a a", layer.Font.Font).Width - graphics.MeasureString("aa", layer.Font.Font).Width;
            var fullblank = graphics.MeasureString("哈　哈", layer.Font.Font).Width - graphics.MeasureString("哈哈", layer.Font.Font).Width;

            if (temp.Count > 0)
            {
                for (var p = 0; p < temp.Count; p++)
                {
                    var sp = temp[p].Item;

                    while ((breakPoint = FindBreakPoint(graphics, sp, layer.Font.Font, layer.Size.Width, blank, fullblank)) != -1)
                    {
                        result.Add(new MapData<string, bool>(sp.Substring(0, breakPoint), false));

                        sp = sp.Substring(breakPoint);

                        if (sp == "")
                            break;
                    }

                    if (!string.IsNullOrEmpty(sp))
                    {
                        result.Add(new MapData<string, bool>(sp, true));
                    }
                }
            }

            return result;
        }

        public static List<string> MeasureString(Graphics graphics, string input, Font font, int width, bool wordwrap)
        {
            var result = new List<string>();
            var breakPoint = 0;

            var temp = input.Split('\n').Select(v => v.Replace("\r", "")).ToList();

            if (!wordwrap)
            {
                return temp;
            }

            var blank = graphics.MeasureString("a a", font).Width - graphics.MeasureString("aa", font).Width;
            var fullblank = graphics.MeasureString("哈　哈", font).Width - graphics.MeasureString("哈哈", font).Width;

            if (temp.Count > 0)
            {
                for (var p = 0; p < temp.Count; p++)
                {
                    var sp = temp[p];

                    while ((breakPoint = FindBreakPoint(graphics, sp, font, width, blank, fullblank)) != -1)
                    {
                        result.Add(sp.Substring(0, breakPoint));

                        sp = sp.Substring(breakPoint);

                        if (sp == "")
                            break;
                    }

                    if (!string.IsNullOrEmpty(sp))
                    {
                        result.Add(sp);
                    }
                }
            }

            return result;
        }

        private static int FindBreakPoint(Graphics graphics, string input, Font font, int width, float blank, float fullblank)
        {
            var min = 0;
            var max = input.Length;
            var maxWidth = graphics.MeasureString(input, font).Width;

            if (maxWidth < width)
                return -1;
            var p = 1;
            while (true)
            {
                var middle = (min + max) / 2;
                var middleWidth = graphics.MeasureString(input.Substring(0, middle), font).Width;

                var oneCharWiderThanMiddleWidth = 0f;

                if (input.Substring(middle, 1).Equals(" "))
                {
                    oneCharWiderThanMiddleWidth += blank;
                }
                else if (input.Substring(middle, 1).Equals("　"))
                {
                    oneCharWiderThanMiddleWidth += fullblank;
                }
                else
                {
                    oneCharWiderThanMiddleWidth = graphics.MeasureString(input.Substring(0, middle + 1), font).Width;
                }

                if (middleWidth == oneCharWiderThanMiddleWidth)
                {
                    return middle;
                }

                if (middle == 0)
                {
                    return 1;
                }

                if (middleWidth <= width && oneCharWiderThanMiddleWidth > width)
                {
                    return middle;
                }

                if (middleWidth < width)
                {
                    min = middle + 1;
                }
                else
                {
                    max = middle - 1;
                }
            }
        }

        public static string MeasureDelimiterString(Graphics graphics, string input, Font font, int width)
        {
            var result = string.Empty;
            var oneWidth = graphics.MeasureString(input + input, font).Width - graphics.MeasureString(input, font).Width;
            for (var p = 0; p < width / oneWidth + 1; p++)
            {
                result += input;
            }

            var list = MeasureString(graphics, result, font, width, true);

            return list[0];
        }
    }
}
