namespace YuanTu.Platform.St
{
    using System;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 数字地图
    /// 作者: 系统用户
    /// 生成时间: 2022年09月06日 14:19:37
    /// </summary>
    public class DigitalMapRto : CustomEntityWithOrgDto<string>
    {
        
        private decimal _PerScale;
        
        private decimal _MaxDepth;
        
        private decimal _MinDepth;
        
        private bool _IsDefault;
        
        private int _CameraX;
        
        private int _CameraY;
        
        private int _CameraZ;
        
        private string _BackgroundColor;
        
        /// <summary>
        /// 每单位尺寸
        /// </summary>
        public decimal PerScale
        {
            get
            {
                return this._PerScale;
            }
            set
            {
                this._PerScale = value;
            }
        }
        
        /// <summary>
        /// 投视范围
        /// </summary>
        public decimal MaxDepth
        {
            get
            {
                return this._MaxDepth;
            }
            set
            {
                this._MaxDepth = value;
            }
        }
        
        /// <summary>
        /// 最小投视范围
        /// </summary>
        public decimal MinDepth
        {
            get
            {
                return this._MinDepth;
            }
            set
            {
                this._MinDepth = value;
            }
        }
        
        /// <summary>
        /// 默认地图
        /// </summary>
        public bool IsDefault
        {
            get
            {
                return this._IsDefault;
            }
            set
            {
                this._IsDefault = value;
            }
        }
        
        /// <summary>
        /// 摄像头坐标X
        /// </summary>
        public int CameraX
        {
            get
            {
                return this._CameraX;
            }
            set
            {
                this._CameraX = value;
            }
        }
        
        /// <summary>
        /// 摄像头坐标Y
        /// </summary>
        public int CameraY
        {
            get
            {
                return this._CameraY;
            }
            set
            {
                this._CameraY = value;
            }
        }
        
        /// <summary>
        /// 摄像头坐标Z
        /// </summary>
        public int CameraZ
        {
            get
            {
                return this._CameraZ;
            }
            set
            {
                this._CameraZ = value;
            }
        }
        
        /// <summary>
        /// 背景色
        /// </summary>
        public string BackgroundColor
        {
            get
            {
                return this._BackgroundColor;
            }
            set
            {
                this._BackgroundColor = value;
            }
        }
    }
}
