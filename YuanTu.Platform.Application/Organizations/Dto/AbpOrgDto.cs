using System;
using System.Collections.Generic;
using Abp.AutoMapper;
using Abp.Organizations;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Organizations.Dto
{
    [AutoMap(typeof(AbpOrg))]
    public class AbpOrgDto : ParentCustomEntityDto<long>
    {
        /// <summary>
        /// ��������
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Ժ�����
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// ����ģʽ 1-���� 0-����
        /// </summary>
        public int OfflineMode { get; set; } = 0;

        /// <summary>
        /// �Խ�ģʽ 1-������ģʽ 2-������ģʽ  3-����ģʽ
        /// </summary>
        public int DockMode { get; set; } = 3;

        /// <summary>
        /// ҽ����ͨ��ģʽ�����ô��룩0-�� 1-��
        /// </summary>
        public int UnionMode { get; set; } = 1;

        /// <summary>
        /// ҽ����ID
        /// </summary> 
        public string UnionId { get; set; }

        /// <summary>
        /// ҽԺ���
        /// </summary> 
        public int HospitalId { get; set; } = 0;

        /// <summary>
        /// ���ҽԺ���
        /// </summary> 
        public int MonitorHospitalId { get; set; } = 0;

        /// <summary>
        /// ��Կ
        /// </summary>
        public string OrgSecret { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// ǰ�����ص�ַ
        /// </summary> 
        public string GatewayUrl { get; set; }

        /// <summary>
        /// ��ʱʱ��
        /// </summary>
        public int Timeout { get; set; } = 0;

        /// <summary>
        /// ʡҽ������
        /// </summary> 
        public string ProvincialMiCode { get; set; }

        /// <summary>
        /// ��ҽ������
        /// </summary> 
        public string MunicipalMiCode { get; set; }

        /// <summary>
        /// �ն˹���ƽ̨��̨�����ַ
        /// </summary> 
        public string ServerUrl { get; set; }

        /// <summary>
        /// ���ƽ̨��ַ
        /// </summary> 
        public string MonitorUrl { get; set; }

        /// <summary>
        /// �ն˹���ƽ̨ǰ�˵�ַ
        /// </summary> 
        public string FrontUrl { get; set; }

        /// <summary>
        /// ҽ������ģʽ
        /// </summary> 
        public int McReadMode { get; set; } = 0;

        /// <summary>
        /// ����ƥ�����
        /// </summary> 
        public string Pattern { get; set; }

        /// <summary>
        /// ά����
        /// </summary> 
        public string Maintainer { get; set; }

        /// <summary>
        /// �ն˰汾
        /// </summary> 
        public string Version { get; set; }
    }
}
