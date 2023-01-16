using Abp.AutoMapper;

namespace YuanTu.Platform.Organizations.Dto
{
    [AutoMap(typeof(AbpOrg))]
    public class AbpOrgExDto 
    {
        /// <summary>
        /// ��ţ�����
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Ժ�����
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// ҽԺ���
        /// </summary>
        public int HospitalId { get; set; }
    }

    public class AbpExtOrgDto
    {
        /// <summary>
        /// ��ţ�����
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// ҽԺ���
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// Ժ�����
        /// </summary>
        public string HospitalCode { get; set; }

        /// <summary>
        /// ҽ����ID
        /// </summary>
        public string UnionId { get; set; } 
    }
}
