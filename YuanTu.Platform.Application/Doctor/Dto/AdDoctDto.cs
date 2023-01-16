using Abp.Application.Services.Dto;

namespace YuanTu.Platform.Doctor.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(AdDoct))]
    public class AdDoctDto : EntityDto<long>
    {
        /// <summary>
        /// 医生编号
        /// </summary>  
        public string DoctCode { get; set; }

        /// <summary>
        /// 医生名称
        /// </summary>  
        public string DoctName { get; set; }

        /// <summary>
        /// 科室编号
        /// </summary>  
        public string DeptCode { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>  
        public string DeptName { get; set; }

        /// <summary>
        /// 医院ID
        /// </summary> 
        public long CorpId { get; set; }

        /// <summary>
        /// 院区代码 可空 可空，包含多个分院的情况需传入
        /// </summary>   
        public string CorpCode { get; set; }

        /// <summary>
        /// 医生职称
        /// </summary>   
        public string DoctProfe { get; set; }

        /// <summary>
        /// 医生简介
        /// </summary>   
        public string DoctIntro { get; set; }

        /// <summary>
        /// 医生特长
        /// </summary>   
        public string DoctSpec { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>   
        public string DoctPictureUrl { get; set; }

        /// <summary>
        /// 删除标记 0-正常 1-删除
        /// </summary> 
        public bool IsDelete { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}