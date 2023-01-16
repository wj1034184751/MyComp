using System;
using System.IO;

namespace YuanTu.Platform.Utilities
{
    public class FileInputUtil
    { 
        /// <summary>
        /// 返回包含所请求文件的完整路径的文件信息
        /// </summary>
        /// <param name="directory">子目录</param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static FileInfo GetFileInfo(string directory, string file)
        {
            var rootDir = GetRootDirectory().FullName;
            return new FileInfo(Path.Combine(rootDir, directory, file));
        }

        public static DirectoryInfo GetRootDirectory()
        {
            var currentDir = AppDomain.CurrentDomain.BaseDirectory;
            while (!currentDir.EndsWith("bin"))
            {
                currentDir = Directory.GetParent(currentDir).FullName.TrimEnd('\\');
            }
            return new DirectoryInfo(currentDir).Parent;
        }

        public static DirectoryInfo GetSubDirectory(string directory, string subDirectory)
        {
            var currentDir = GetRootDirectory().FullName;
            return new DirectoryInfo(Path.Combine(currentDir, directory, subDirectory));
        }
    }
}
