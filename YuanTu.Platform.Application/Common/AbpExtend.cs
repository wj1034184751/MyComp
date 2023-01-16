using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace YuanTu.Platform
{
    /// <summary>
    /// 默认扩展类
    /// </summary>
    public static class AbpExtend
    {
        /// <summary>
        /// 转换驼峰命名
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToCamelCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            return text.Substring(0, 1).ToLower() + text.Substring(1);
        }

        //public static void ZipFolderWithDownload(string folder, string filename, IHttpContextAccessor context)
        //{
        //    var path = Path.Combine(Directory.GetParent(folder).FullName, filename);
        //    ZipUtil.ZipDir(folder, path);

        //    context.HttpContext.Response.Headers.Add("Content-Disposition", $"attachment;filename={filename}");
        //    context.HttpContext.Response.ContentType = "application/octet-stream";
        //    context.HttpContext.Response.SendFileAsync($"{path}");
        //}

        /// <summary>
        /// 转换驼峰命名
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToSplitCamelCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var items = text.Split('_');


            return string.Join("_", items.Select(v => v.ToCamelCase()));
        }
    }
}
