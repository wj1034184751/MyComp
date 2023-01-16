using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace YuanTu.Platform.Print
{
    [Serializable]
    public struct PPadding
    {
        public PPadding(int all)
        {
            Left = all;
            Top = all;
            Right = all;
            Bottom = all;
        }

        public PPadding(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        //
        // 摘要:
        //     获取或设置上边缘的空白值。
        //
        // 返回结果:
        //     上边缘的空白值（以像素为单位）。
        public int Top { get; set; }
        //
        // 摘要:
        //     获取或设置右边缘的空白值。
        //
        // 返回结果:
        //     右边缘的空白值（以像素为单位）。
        public int Right { get; set; }
        //
        // 摘要:
        //     获取或设置左边缘的空白值。
        //
        // 返回结果:
        //     左边缘的空白值（以像素为单位）。
        public int Left { get; set; }
        //
        // 摘要:
        //     获取或设置下边缘的空白值。
        //
        // 返回结果:
        //     下边缘的空白值（以像素为单位）。
        public int Bottom { get; set; }


        private static PPadding m_empty = new PPadding(0);
        public static PPadding Empty
        {
            get
            {
                return m_empty;
            }
        }
    }
}
