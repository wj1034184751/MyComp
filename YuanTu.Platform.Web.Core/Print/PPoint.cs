using System;

namespace YuanTu.Platform.Print
{
    [Serializable]
    public struct PPoint
    {
        public PPoint(int left, int top)
        {
            this.Left = left;
            this.Top = top;
        }

        public int Left { get; set; }

        public int Top { get; set; }
    }
}
