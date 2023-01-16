using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace YuanTu.Platform.Utilities
{
    /// <summary>
    /// 常用工具类
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// 计算文件MD5值
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="lower">是否小写</param>
        public static string ComputeMD5(this FileStream fs, bool lower = false)
        {
            var bytes = new byte[fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Seek(0, SeekOrigin.Begin);
            return ComputeMD5(bytes);
        }

        /// <summary>
        /// 计算文件MD5值
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="lower">是否小写</param>
        public static string ComputeMD5(this byte[] bytes, bool lower = false)
        {
            //计算文件的MD5值
            var md5 = System.Security.Cryptography.MD5.Create();
            var buffer = md5.ComputeHash(bytes);
            md5.Clear();
            var sb = new StringBuilder();
            //将字节数组转换成十六进制的字符串形式
            foreach (var t in buffer)
            {
                sb.Append(t.ToString(lower ? "x2" : "X2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 计算文件SHA1值
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="lower">是否小写</param>
        public static string ComputeSHA1(this byte[] bytes, bool lower = false)
        {
            //计算文件SHA1值
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var buffer = sha1.ComputeHash(bytes);
            sha1.Clear();
            var sb = new StringBuilder();
            //将字节数组转换成十六进制的字符串形式
            foreach (var t in buffer)
            {
                sb.Append(t.ToString(lower ? "x2" : "X2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 计算文件SHA1值
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="lower">是否小写</param>
        public static string ComputeSHA1(this FileStream fs, bool lower = false)
        {
            var bytes = new byte[fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Seek(0, SeekOrigin.Begin);
            return ComputeSHA1(bytes);
        }

        /// <summary>
        /// 替换字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        /// <param name="maskChr"></param>
        /// <returns></returns>
        public static string Mask(this string str, int start, int len, char maskChr = '*')
        {
            if (str == null || str.Length <= start)
            {
                return str;
            }
            var part1 = str.Substring(0, start);
            var part2 = "".PadRight(Math.Min(str.Length - start, len), maskChr);
            var part3 = (str.Length - start - len > 0) ? str.Substring(start + len) : "";
            return part1 + part2 + part3;
        }

        /// <summary>
        /// double/int 转换
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this double value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// decimal/int 转换
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this decimal value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// float/int 转换
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this float value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// DateTime转换
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value)
        {
            return DateTime.TryParse(value, out var dt) ? dt : new DateTime();
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum @enum)
        {
            var field = @enum.GetType().GetField(@enum.ToString());
            var da = field?.GetCustomAttribute<DescriptionAttribute>();
            return da != null ? da.Description : string.Empty;
        }
    }
}