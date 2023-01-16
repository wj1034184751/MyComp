namespace YuanTu.Platform.Print
{
    /// <summary>
    /// 图层类型
    /// </summary>
    public enum LayerType
    {
        None = 0, Text = 1, Barcode = 2, Qrcode = 3, Image = 4, Newpage = 4, Delimiter = 5, Table = 6, Bindtable = 7, Panel = 8
    }

    /// <summary>
    /// 停靠模式
    /// </summary>
    public enum DockStyle
    {
        None, Top, Bottom, Left, Right, Fill
    }

    /// <summary>
    /// 文本对齐方式
    /// </summary>
    public enum Textalign
    {
        Default = 0, TopLeft = 1, TopCenter = 2, TopRight = 3, MiddleLeft = 4, MiddleCenter = 5, MiddleRight = 6, BottomLeft = 7, BottomCenter = 8, BottomRight = 9
    }
}
