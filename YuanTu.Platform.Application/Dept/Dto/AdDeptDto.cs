using Abp.Application.Services.Dto;

namespace YuanTu.Platform.Dept.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(AdDept))]
    public class AdDeptDto : EntityDto<long>
    {  
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
        /// 科室简介
        /// </summary>   
        public string DeptIntro { get; set; }

        /// <summary>
        /// 科室电话
        /// </summary>   
        public string Phone { get; set; }

        /// <summary>
        /// 科室地址
        /// </summary>   
        public string Address { get; set; }

        /// <summary>
        /// 科室类别
        /// </summary>   
        public string DeptType { get; set; }

        /// <summary>
        /// 删除标记 0-正常 1-删除
        /// </summary> 
        public bool IsDelete { get; set; }
         
        /// <summary>
        /// 性别限制
        /// </summary>
        public byte GenderRestrictionType { get; set; }

        /// <summary>
        /// 可挂号年龄段最小值
        /// </summary>
        public int MinAge { get; set; }

        /// <summary>
        /// 可挂号年龄段最大值
        /// </summary>
        public int MaxAge { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}