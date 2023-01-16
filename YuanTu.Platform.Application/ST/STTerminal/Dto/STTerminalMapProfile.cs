using AutoMapper;
using YuanTu.Platform.Organizations;

namespace YuanTu.Platform.ST.Dto
{
    public class STTerminalMapProfile : Profile
    {
        public STTerminalMapProfile()
        {
            CreateMap<AbpOrg, Hospital>()
                .ForMember(x => x.Name, opt => opt.MapFrom(s => s.DisplayName))
                .ForMember(x => x.AreaCode, opt => opt.MapFrom(s => s.Code));

            CreateMap<STTerminalPlugin, STTerminalExDto>()
                .ForMember(x => x.Code, opt => opt.MapFrom(s => s.PluginCode))
                .ForMember(x => x.Name, opt => opt.MapFrom(s => s.PluginName))
                .ForMember(x => x.Enable, opt => opt.MapFrom(s => s.Enabled));

            CreateMap<STTerminal, STHardwareInfoDto>()
                .ForMember(x => x.TerminalType, opt => opt.MapFrom(s => s.TerminalTypeId))
                .ForMember(x => x.Enable, opt => opt.MapFrom(s => s.IsActive));
        }
    }
}