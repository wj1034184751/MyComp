using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.Print
{
    public class MapData<T, T1>
    {
        public MapData(T item, T1 item1)
        {
            this.Item = item;
            this.Item1 = item1;
        }
        public T Item { get; set; }
        public T1 Item1 { get; set; }
    }
}