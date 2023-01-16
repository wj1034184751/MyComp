using System.Drawing;

namespace YuanTu.Platform.Print
{
    public class PFont
    {
        public string Name { get; set; }

        public float Size { get; set; }

        public bool Bold { get; set; }

        public bool Italic { get; set; }

        public bool Underline { get; set; }

        public bool Strikeout { get; set; }

        private Font font = null;
        public Font Font
        {
            get
            {
                if (font == null)
                {
                    FontStyle style = FontStyle.Regular;
                    if (Bold)
                    {
                        style |= FontStyle.Bold;
                    }
                    if (Italic)
                    {
                        style |= FontStyle.Italic;
                    }
                    if (Underline)
                    {
                        style |= FontStyle.Underline;
                    }
                    if (Strikeout)
                    {
                        style |= FontStyle.Strikeout;
                    }

                    font = new Font(this.Name, this.Size * 4 / 3, style, GraphicsUnit.Pixel);
                }

                return font;
            }
        }
    }
}
