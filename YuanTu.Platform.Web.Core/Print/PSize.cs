namespace YuanTu.Platform.Print
{
    public struct PSize
    {
        public static PSize Empty = new PSize(0, 0);

        public PSize(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public static bool operator ==(PSize s1, PSize s2)
        {
            return s1.Width == s2.Width && s1.Height == s2.Height;
        }

        public static bool operator !=(PSize s1, PSize s2)
        {
            return s1.Width != s2.Width || s1.Height != s2.Height;
        }
    }
}
