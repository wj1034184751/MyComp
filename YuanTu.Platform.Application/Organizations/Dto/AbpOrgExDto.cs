using Abp.AutoMapper;

namespace YuanTu.Platform.Organizations.Dto
{
    [AutoMap(typeof(AbpOrg))]
    public class AbpOrgExDto 
    {
        /// <summary>
        /// 编号，自增
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 院区编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }
    }

    public class AbpExtOrgDto
    {
        /// <summary>
        /// 编号，自增
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 院区编号
        /// </summary>
        public string HospitalCode { get; set; }

        /// <summary>
        /// 医联体ID
        /// </summary>
        public string UnionId { get; set; } 
    }
}
