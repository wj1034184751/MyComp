using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Local.StReportRecord.Rto;

namespace YuanTu.Platform.Local
{
    public class LocalMapProfile : Profile
    {
        public LocalMapProfile()
        {

            CreateMap<ReportRecord, STPrintHistory>().IncludeMembers(e => e.ExtendMap)
                .ForMember(dest => dest.ReportId, opt => opt.MapFrom(src => src.CheckNo))
                .ForMember(dest => dest.PrintFile, opt => opt.MapFrom(src => src.ReportIntranetUrl))
                .ForMember(dest => dest.ReportName, opt => opt.MapFrom(src => src.CheckItem))
                .ForMember(dest => dest.IdCardNo, opt => opt.MapFrom(src => src.IdNo));
            CreateMap<ExtendMap, STPrintHistory>();
            CreateMap<STPrintHistory, StQueryReportRecordRto>();
            CreateMap<STPrintHistoryDto, STReportRecord>();
        }
    }
}
