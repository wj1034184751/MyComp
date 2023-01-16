namespace YuanTu.Platform.St
{
    using System;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 数字模型
    /// 作者: 系统用户
    /// 生成时间: 2022年09月07日 16:40:32
    /// </summary>
    [Abp.AutoMapper.AutoMap(typeof(DigitalMapModel))]
    public class DigitalMapModelDto : CustomEntityWithOrgDto<string>
    {
        
        private decimal _X;
        
        private decimal _Y;
        
        private decimal _Z;
        
        private decimal _RotationX;
        
        private decimal _RotationY;
        
        private decimal _RotationZ;
        
        private string _BackgroundImage;
        
        private string _BackgroundColor;
        
        private decimal _Width;
        
        private decimal _Height;
        
        private decimal _Depth;
        
        private string _ModelTypeId;
        
        private string _DigitalMapId;
        
        private decimal _Radius;
        
        private int _Segments;
        
        private decimal _ThetaStart;
        
        private decimal _ThetaLength;
        
        private bool _IsOpenEnded;
        
        private int _HeightSegments;
        
        private decimal _RadiusTop;
        
        private int _Detail ;
        
        private string _Text;
        
        private string _GroupId;
        
        private bool _IsGroup;
        
        private string _UserModelAddress;
        
        private string _StTerminalId;
        
        private string _Data;
        
        /// <summary>
        /// 坐标X
        /// </summary>
        public decimal X
        {
            get
            {
                return this._X;
            }
            set
            {
                this._X = value;
            }
        }
        
        /// <summary>
        /// 坐标Y
        /// </summary>
        public decimal Y
        {
            get
            {
                return this._Y;
            }
            set
            {
                this._Y = value;
            }
        }
        
        /// <summary>
        /// 坐标Z
        /// </summary>
        public decimal Z
        {
            get
            {
                return this._Z;
            }
            set
            {
                this._Z = value;
            }
        }
        
        /// <summary>
        /// 旋转角度X
        /// </summary>
        public decimal RotationX
        {
            get
            {
                return this._RotationX;
            }
            set
            {
                this._RotationX = value;
            }
        }
        
        /// <summary>
        /// 旋转角度Y
        /// </summary>
        public decimal RotationY
        {
            get
            {
                return this._RotationY;
            }
            set
            {
                this._RotationY = value;
            }
        }
        
        /// <summary>
        /// 旋转角度Z
        /// </summary>
        public decimal RotationZ
        {
            get
            {
                return this._RotationZ;
            }
            set
            {
                this._RotationZ = value;
            }
        }
        
        /// <summary>
        /// 背景图
        /// </summary>
        public string BackgroundImage
        {
            get
            {
                return this._BackgroundImage;
            }
            set
            {
                this._BackgroundImage = value;
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
        
        /// <summary>
        /// 宽
        /// </summary>
        public decimal Width
        {
            get
            {
                return this._Width;
            }
            set
            {
                this._Width = value;
            }
        }
        
        /// <summary>
        /// 高
        /// </summary>
        public decimal Height
        {
            get
            {
                return this._Height;
            }
            set
            {
                this._Height = value;
            }
        }
        
        /// <summary>
        /// 深
        /// </summary>
        public decimal Depth
        {
            get
            {
                return this._Depth;
            }
            set
            {
                this._Depth = value;
            }
        }
        
        /// <summary>
        /// 模型种类
        /// </summary>
        public string ModelTypeId
        {
            get
            {
                return this._ModelTypeId;
            }
            set
            {
                this._ModelTypeId = value;
            }
        }
        
        /// <summary>
        /// 所属地图Id
        /// </summary>
        public string DigitalMapId
        {
            get
            {
                return this._DigitalMapId;
            }
            set
            {
                this._DigitalMapId = value;
            }
        }
        
        /// <summary>
        /// 半径
        /// </summary>
        public decimal Radius
        {
            get
            {
                return this._Radius;
            }
            set
            {
                this._Radius = value;
            }
        }
        
        /// <summary>
        /// 分段数量
        /// </summary>
        public int Segments
        {
            get
            {
                return this._Segments;
            }
            set
            {
                this._Segments = value;
            }
        }
        
        /// <summary>
        /// 起始角度
        /// </summary>
        public decimal ThetaStart
        {
            get
            {
                return this._ThetaStart;
            }
            set
            {
                this._ThetaStart = value;
            }
        }
        
        /// <summary>
        /// 中心角
        /// </summary>
        public decimal ThetaLength
        {
            get
            {
                return this._ThetaLength;
            }
            set
            {
                this._ThetaLength = value;
            }
        }
        
        /// <summary>
        /// 是否封顶
        /// </summary>
        public bool IsOpenEnded
        {
            get
            {
                return this._IsOpenEnded;
            }
            set
            {
                this._IsOpenEnded = value;
            }
        }
        
        /// <summary>
        /// 高度分段数
        /// </summary>
        public int HeightSegments
        {
            get
            {
                return this._HeightSegments;
            }
            set
            {
                this._HeightSegments = value;
            }
        }
        
        /// <summary>
        /// 顶部半径
        /// </summary>
        public decimal RadiusTop
        {
            get
            {
                return this._RadiusTop;
            }
            set
            {
                this._RadiusTop = value;
            }
        }
        
        /// <summary>
        /// 顶点
        /// </summary>
        public int Detail 
        {
            get
            {
                return this._Detail ;
            }
            set
            {
                this._Detail  = value;
            }
        }
        
        /// <summary>
        /// 文本内容
        /// </summary>
        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                this._Text = value;
            }
        }
        
        /// <summary>
        /// 关联模型Id
        /// </summary>
        public string GroupId
        {
            get
            {
                return this._GroupId;
            }
            set
            {
                this._GroupId = value;
            }
        }
        
        /// <summary>
        /// 是否组合
        /// </summary>
        public bool IsGroup
        {
            get
            {
                return this._IsGroup;
            }
            set
            {
                this._IsGroup = value;
            }
        }
        
        /// <summary>
        /// 用户模型地址
        /// </summary>
        public string UserModelAddress
        {
            get
            {
                return this._UserModelAddress;
            }
            set
            {
                this._UserModelAddress = value;
            }
        }
        
        /// <summary>
        /// 自助终端Id
        /// </summary>
        public string StTerminalId
        {
            get
            {
                return this._StTerminalId;
            }
            set
            {
                this._StTerminalId = value;
            }
        }
        
        /// <summary>
        /// 模型数据
        /// </summary>
        public string Data
        {
            get
            {
                return this._Data;
            }
            set
            {
                this._Data = value;
            }
        }
    }
}
