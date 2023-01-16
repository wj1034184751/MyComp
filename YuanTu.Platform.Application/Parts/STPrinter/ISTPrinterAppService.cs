using YuanTu.Platform.Parts.Dto;

namespace YuanTu.Platform.Parts
{
    public interface ISTPrinterAppService : IAsynPermissionAppService<STPrinter, STPrinterDto, string, PagedSTPrinterRequestDto, STPrinterDto, STPrinterDto>
    { 
    }
}