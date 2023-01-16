using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using YuanTu.Platform.Dto;
using YuanTu.Platform.Models.Versions;
using YuanTu.Platform.Print;
using ZXing;
using ZXing.QrCode;

namespace YuanTu.Platform.Controllers
{
    /// <summary>
    /// 获取各版本号
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class CommonController : PlatformControllerBase
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

        [HttpGet]
        public FileResult CreateQrcode(QrcodedDto dto)
        {
            BarcodeWriterPixelData writer = new BarcodeWriterPixelData();
            writer.Format = dto.Format;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.DisableECI = true;
            //设置内容编码
            options.CharacterSet = "UTF-8";
            //设置二维码的宽度和高度
            options.Width = dto.Width;
            options.Height = dto.Height;
            //设置二维码的边距,单位不是固定像素
            options.Margin = 1;

            options.PureBarcode = dto.PureBarcode;

            writer.Options = options;

            var pixelData = writer.Write(dto.Text);

            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))

            using (var ms = new MemoryStream())
            {
                var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height),
                   System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                try
                {
                    // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image
                    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0,
                       pixelData.Pixels.Length);
                }
                finally
                {
                    bitmap.UnlockBits(bitmapData);
                }

                // save to stream as PNG
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                return File(ms.ToArray(), "application/png",Guid.NewGuid().ToString("N") + ".png");
            }
        }

        [HttpPost]
        public JsonResult PrintPreview([FromBody]PrintDto dto)
        {
            var res = Print.Result<string>.Success("");
            try
            {
                var context = JsonConvert.DeserializeObject<LayerContext>(dto.Template);
                string bitmapData = string.Empty;
                foreach (var buffer in context.Print(dto))
                {
                    if (string.IsNullOrEmpty(bitmapData))
                    {
                        bitmapData += "data:image/jpeg;base64," + Convert.ToBase64String(buffer);
                    }
                    else
                    {
                        bitmapData += "|data:image/jpeg;base64," + Convert.ToBase64String(buffer);
                    }
                }

                res.Data = bitmapData;

                context.Dispose();
            }
            catch (UserFriendlyException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException("其他未知错误：" + ex.Message + ex.StackTrace);
            }

            return Json(res);
        }

        [HttpGet]
        public JsonResult CompileInstall(DownloadInfoDto dto)
        {
            try
            {
                if (!System.IO.File.Exists(@"C:\web\webapi\publish\thp\Inno Setup 5\Compil32.exe"))
                {
                    return Json(Print.Result.Fail("只允许在47阿里云服务器上打包下载，其他请联系管理员！！"));
                }

                if (lockDownload)
                {
                    return Json(Print.Result.Fail("有人正在打包下载，请稍等！！！"));
                }

                // 生成install.json文件
                lockDownload = true;

                var insfile = @"C:\web\webapi\publish\thp\小远助手\install.json";
                if (System.IO.File.Exists(insfile))
                {
                    System.IO.File.Delete(insfile);
                }

                Install install = new Install();
                install.DataCenter.IP = dto.Datacenter;
                install.DataCenter.Port = dto.CenterPort;
                install.Server.IP = dto.Server;
                install.Server.Port = dto.ServerPort;
                install.OrgName = dto.OrgName;
                install.PluginName = dto.PluginName;
                install.PartsName = dto.PartsName;
                install.TerminalType = dto.TerminalType;
                install.IsNotYuantu = dto.IsNotYuantu;

                System.IO.File.WriteAllText(@"C:\web\webapi\publish\thp\小远助手\install.json", JsonConvert.SerializeObject(install, Formatting.Indented, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() }));

                //启动编译
                var pp = Process.Start(@"C:\web\webapi\publish\thp\Inno Setup 5\Compil32.exe", @"/cc C:\web\webapi\publish\thp\小远助手基础版.iss");

                pp.WaitForExit();

                lockDownload = false;
            }
            catch (Exception ex)
            {
                lockDownload = false;

                return Json(Print.Result.Fail(ex.Message));
            }

            return Json(Print.Result.Success());
        }

        [HttpGet]
        public FileResult DownloadInstall()
        {
            try
            {
                string filename = @"C:\web\webapi\publish\thp\小远助手.exe";

                byte[] buffer = System.IO.File.ReadAllBytes(filename);

                System.IO.File.Delete(filename);

                var provider = new FileExtensionContentTypeProvider();

                return File(buffer, "application/octet-stream", "小远助手.exe");
            }
            catch (Exception ex)
            {
                return File(System.Text.Encoding.UTF8.GetBytes(ex.Message), "text/html", "fail.txt");
            }
        }

        public static bool lockDownload = false;
    }
}