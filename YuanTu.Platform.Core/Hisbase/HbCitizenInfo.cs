using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Hisbase
{
    /// <summary>
    /// 公民信息
    /// </summary>
    public class HbCitizenInfo : CustomEntity<string>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDNo { get; set; }

        /// <summary>
        /// 身份证ID
        /// </summary>
        public string InnerID { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 联系电话/手机
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public string Nation { get; set; }

        /// <summary>
        /// 人脸数据
        /// </summary>
        public string FaceData { get; set; }

        /// <summary>
        /// 人脸数据
        /// </summary>
        public string FaceData1 { get; set; }

        /// <summary>
        /// 人脸数据
        /// </summary>
        public string FaceData2 { get; set; }

        /// <summary>
        /// 人脸数据
        /// </summary>
        public string FaceData3 { get; set; }

        /// <summary>
        /// 人脸数据
        /// </summary>
        public string FaceData4 { get; set; }
    }
}
