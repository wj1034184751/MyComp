using System;
using YuanTu.Platform.Common.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;

namespace YuanTu.Platform.Local
{


    public class ReportData
    {
        public int code { get; set; }
        public string msg { get; set; }
        public string success { get; set; }
        public string traceid { get; set; }
        public List<ReportRecord> data { get; set; }

    }


    [AutoMap(typeof(STReportRecord))]
    public class STReportRecordDto : ReportRecord
    {

        public string PrintHistoryId { get; set; }
        public string ReportId { get; set; }
        public string PrinterTypeId { get; set; }
        public string PrinterName { get; set; }
        public string StTerminalId { get; set; }
        public string Input { get; set; }
        public string PrintTemplateId { get; set; }
        public string PrintFile { get; set; }
        public int PageCount { get; set; }
        public string PaperSize { get; set; }
        public DateTime? PrintTime { get; set; }
        public string BusinessTypeId { get; set; }
        public string TraceId { get; set; }
        public string IdCardNo { get; set; }
        public string SsCardNo { get; set; }
        public string DeptId { get; set; }
        public string PrintFailMsg { get; set; }
        public string BusinessId { get; set; }
        public string PrintStatusDesc { get; set; }
        public string ReportDesc { get; set; }

        public STReportRecordDto(string BusinessTypeId)
        {
            switch (BusinessTypeId)
            {
                case "5300":
                    ReportDesc = "���鱨��";
                    break;
                case "5301":
                    ReportDesc = "�¹ڱ���";
                    break;
                case "5302":
                    ReportDesc = "Ѫ���汨��";
                    break;
                case "5303":
                    ReportDesc = "�򳣹汨��";
                    break;
                case "5400":
                    ReportDesc = "��鱨��";
                    break;
                case "5401":
                    ReportDesc = "��������";
                    break;
                case "5402":
                    ReportDesc = "�ھ�����";
                    break;
                case "5403":
                    ReportDesc = "�ĵ籨��";
                    break;
                case "5404":
                    ReportDesc = "���䱨��";
                    break;
                case "5500":
                    ReportDesc = "������";
                    break;
                case "5600":
                    ReportDesc = "���ӱ���";
                    break;
               default:
                    ReportDesc = "����";
                    break;
            }
        }

    }


    public class ReportRecord : CustomEntityWithOrgDto<string>
    {
        public PrinterType PrintType { get; set; }
        /// <summary>
        /// ����Id
        /// </summary>
        public string CheckNo { get; set; }

        /// <summary>
        /// ���߲�����
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// �ͼ�ҽ������
        /// </summary>
        public string InspecDoctCode { get; set; }
        /// <summary>
        /// ���ָ��
        /// </summary>
        public string CheckGuide { get; set; }
        /// <summary>
        /// ��������(�����)
        /// </summary>
        public string ReportName { get; set; }
        /// <summary>
        /// �ͼ�ҽ������
        /// </summary>
        public string InspecDoctName { get; set; }
        /// <summary>
        /// �ͼ��������
        /// </summary>
        public string InspecDeptName { get; set; }
        /// <summary>
        /// �ͼ�ʱ��
        /// </summary>
        public string InspecTime { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public string CheckDate { get; set; }
        /// <summary>
        /// ���ҽ������
        /// </summary>
        public string AuditDoctCode { get; set; }
        /// <summary>
        /// ���ҽ������
        /// </summary>
        public string AuditDoctName { get; set; }
        /// <summary>
        /// ���ҽ���ֻ�
        /// </summary>
        public string AuditDoctPhone { get; set; }
        /// <summary>
        /// ��˿�������
        /// </summary>
        public string AuditDeptName { get; set; }
        /// <summary>
        /// ���״̬
        /// </summary>
        public int? CheckStatus { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public string CheckDesc { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        public string CheckResult { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public string AuditDate { get; set; }
        /// <summary>
        /// �����Ա�
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// ���֤��
        /// </summary>
        public string IdNo { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string Diagnosis { get; set; }
        /// <summary>
        /// ��齨��
        /// </summary>
        public string Suggestion { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? ReportTime { get; set; }
        /// <summary>
        /// ���湫������
        /// </summary>
        public string ReportUrl { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        public string ReportIntranetUrl { get; set; }
        public string CheckItem { get; set; }
        public bool IsPrinted { get; set; }
        public ExtendMap ExtendMap { get; set; }
    }


    public class ExtendMap
    {
        public int? ReportType { get; set; }

        public string Phone { get; set; }
        public int? ReportStatus { get; set; }
    }
}
