using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using YuanTu.Platform.Models.Versions;

namespace YuanTu.Platform.Controllers
{
    /// <summary>
    /// 获取各版本号
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class VersionController : PlatformControllerBase
    {
        [HttpGet]
        public VersionInfo GetVersion()
        {
            var result = new VersionInfo();
            try
            { 
                result.ProductVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                var ass = Assembly.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "YuanTu.Platform.EntityFrameworkCore.dll"));
                var id = ass.GetTypes().Where(s => typeof(Migration).IsAssignableFrom(s))
                    .Select(s => s.GetCustomAttribute<MigrationAttribute>()?.Id.Split('_')[0]).OrderByDescending(s => s)
                    .FirstOrDefault();

                if (!string.IsNullOrWhiteSpace(id))
                    result.DbVersion = $"{id.Substring(0, 4)}.{(int.TryParse(id.Substring(4, 2), out var a) ? a : 0)}.{(int.TryParse(id.Substring(6, 2), out var b) ? b : 0)}.{(int.TryParse(id.Substring(8), out var c) ? c : 0)}";
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
            }
            return result;
        }
    }
}