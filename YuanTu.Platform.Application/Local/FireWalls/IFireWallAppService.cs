using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Local;
using YuanTu.Platform.Local.FireWalls.Dto;

namespace YuanTu.Platform.Local.FireWalls
{
    public interface IFireWallAppService:IAsynPermissionAppService<FireWall, FireWallDto, string, PagedFireWallRequestDto, FireWallDto, FireWallDto>
    {

    }
}
