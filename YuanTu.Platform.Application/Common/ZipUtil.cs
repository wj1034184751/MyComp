using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksum;

namespace YuanTu.Platform
{
    public class DownloadInput
    {
        public string TableName
        {
            get; set;
        }
    }

    public class ZipUtil
    {
        public static void ZipFile(string FileToZip, string ZipedFile, int CompressionLevel, int BlockSize)
        {
            //如果文件没有找到则报错。
            if (!File.Exists(FileToZip))
            {
                throw new FileNotFoundException("The specified file " + FileToZip + " could not be found. Zipping aborderd");
            }

            FileStream StreamToZip = new FileStream(FileToZip, FileMode.Open, FileAccess.Read);
            FileStream ZipFile = File.Create(ZipedFile);
            ZipOutputStream ZipStream = new ZipOutputStream(ZipFile);
            ZipEntry ZipEntry = new ZipEntry("ZippedFile");
            ZipStream.PutNextEntry(ZipEntry);
            ZipStream.SetLevel(CompressionLevel);
            byte[] buffer = new byte[BlockSize];
            System.Int32 size = StreamToZip.Read(buffer, 0, buffer.Length);
            ZipStream.Write(buffer, 0, size);
            try
            {
                while (size < StreamToZip.Length)
                {
                    int sizeRead = StreamToZip.Read(buffer, 0, buffer.Length);
                    ZipStream.Write(buffer, 0, sizeRead);
                    size += sizeRead;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            ZipStream.Finish();
            ZipStream.Close();
            StreamToZip.Close();
            ZipFile.Close();
        }

        /// <summary>
        /// 递归压缩文件夹
        /// </summary>
        /// <param name="di"></param>
        /// <param name="s"></param>
        /// <param name="crc"></param>
        /// <param name="cutStr"></param>
        private static void RewriteDirect(DirectoryInfo di, ref ZipOutputStream s, Crc32 crc, string cutStr)
        {
            //DirectoryInfo di = new DirectoryInfo(filenames);
            DirectoryInfo[] dirs = di.GetDirectories("*");

            //遍历目录下面的所有的子目录
            foreach (DirectoryInfo dirNext in dirs)
            {
                //将该目录下的所有文件添加到 ZipOutputStream s 压缩流里面
                FileInfo[] a = dirNext.GetFiles();

                WriteStream(ref s, a, crc, cutStr);

                //递归调用直到把所有的目录遍历完成
                RewriteDirect(dirNext, ref s, crc, cutStr);
            }
        }

        private static void WriteStream(ref ZipOutputStream s, FileInfo[] a, Crc32 crc, string cutStr)
        {
            foreach (FileInfo fi in a)
            {
                //string fifn = fi.FullName;
                FileStream fs = fi.OpenRead();

                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);


                //ZipEntry entry = new ZipEntry(file);    Path.GetFileName(file)
                string file = fi.FullName;
                file = file.Replace(cutStr, "");

                ZipEntry entry = new ZipEntry(file);

                entry.DateTime = DateTime.Now;

                // set Size and the crc, because the information
                // about the size and crc should be stored in the header
                // if it is not set it is automatically written in the footer.
                // (in this case size == crc == -1 in the header)
                // Some ZIP programs have problems with zip files that don't store
                // the size and crc in the header.
                entry.Size = fs.Length;
                fs.Close();

                crc.Reset();
                crc.Update(buffer);

                entry.Crc = crc.Value;

                s.PutNextEntry(entry);

                s.Write(buffer, 0, buffer.Length);
            }
        }

        /// <summary>
        /// 压缩指定目录下指定文件(包括子目录下的文件)
        /// </summary>
        /// <param name="zipdir">args[0]为你要压缩的目录所在的路径 
        /// 例如：D:\\temp\\   (注意temp 后面加 \\ 但是你写程序的时候怎么修改都可以)</param>
        /// <param name="zipfilename">args[1]为压缩后的文件名及其路径
        /// 例如：D:\\temp.zip</param>
        /// <param name="fileFilter">文件过滤, 例如*.xml,这样只压缩.xml文件.</param>
        ///
        public static bool ZipDir(string zipdir, string zipfilename, string fileFilter = "*.*")
        {
            try
            {
                string cutStr = "";
                if (!zipdir.EndsWith("\\"))
                {
                    zipdir += "\\";
                }

                //string filenames = Directory.GetFiles(args[0]);

                Crc32 crc = new Crc32();
                ZipOutputStream s = new ZipOutputStream(File.Create(zipfilename));

                s.SetLevel(6); // 0 - store only to 9 - means best compression

                DirectoryInfo di = new DirectoryInfo(zipdir);

                FileInfo[] a = di.GetFiles(fileFilter);

                cutStr = zipdir.Trim();

                //压缩这个目录下的所有文件
                WriteStream(ref s, a, crc, cutStr);

                //压缩这个目录下子目录及其文件
                RewriteDirect(di, ref s, crc, cutStr);

                s.Finish();
                s.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 解压缩文件(压缩文件中含有子目录)
        /// </summary>
        /// <param name="source">待解压缩的文件路径</param>
        /// <param name="target">解压缩到指定目录</param>
        public static void UnZip(string source, string target)
        {
            ZipInputStream stream = new ZipInputStream(File.OpenRead(source));

            ZipEntry theEntry;
            try
            {
                while ((theEntry = stream.GetNextEntry()) != null)
                {
                    string directoryName = target;
                    string fileName = Path.GetFileName(theEntry.Name);

                    //生成解压目录
                    if (!Directory.Exists(directoryName))
                    {
                        Directory.CreateDirectory(directoryName);
                    }

                    if (fileName != String.Empty)
                    {
                        //如果文件的压缩后大小为0那么说明这个文件是空的,因此不需要进行读出写入
                        if (theEntry.CompressedSize == 0)
                            continue;

                        string zipfile = Path.Combine(target, theEntry.Name);

                        //解压文件到指定的目录
                        directoryName = Path.GetDirectoryName(zipfile);

                        //建立下面的目录和子目录
                        if (!Directory.Exists(directoryName))
                        {
                            Directory.CreateDirectory(directoryName);
                        }

                        FileStream streamWriter = File.Create(zipfile);

                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = stream.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                        streamWriter.Close();
                    }
                }
                stream.Close();
            }
            catch (Exception ex)
            {
                if (stream != null)
                {
                    stream.Close();
                }
                File.Delete(source);

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ZipedFile"></param>
        /// <param name="buffer"></param>
        /// <param name="CompressionLevel">最大压缩比例：9，常规：6</param>
        public static void ZipToFile(string ZipedFile, byte[] buffer, int CompressionLevel = 6)
        {
            //如果文件没有找到则报错。
            if (buffer == null || buffer.LongLength == 0)
            {
                throw new FileNotFoundException("The specified content could not be zipped. Zipping aborderd");
            }
            if (!Directory.Exists(Path.GetDirectoryName(ZipedFile)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(ZipedFile));
            }

            FileStream ZipFile = File.Create(ZipedFile);
            ZipOutputStream ZipStream = new ZipOutputStream(ZipFile);
            ZipEntry ZipEntry = new ZipEntry("ZippedFile");
            ZipStream.PutNextEntry(ZipEntry);
            ZipStream.SetLevel(CompressionLevel);
            try
            {
                ZipStream.Write(buffer, 0, buffer.Length);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            ZipStream.Finish();
            ZipStream.Close();
            ZipFile.Close();
        }


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ZipedFile"></param>
        ///// <param name="buffer"></param>
        ///// <param name="CompressionLevel">最大压缩比例：9，常规：6</param>
        //public static byte[] ZipToArray(byte[] buffer, int CompressionLevel = 6)
        //{
        //    //如果文件没有找到则报错。
        //    if (buffer == null || buffer.LongLength == 0)
        //    {
        //        throw new FileNotFoundException("The specified content could not be zipped. Zipping aborderd");
        //    }
        //    MemoryStream stream = new MemoryStream();

        //    //FileStream ZipFile = File.Create(ZipedFile);
        //    ZipOutputStream ZipStream = new ZipOutputStream(stream);
        //    ZipEntry ZipEntry = new ZipEntry("ZippedFile");
        //    ZipStream.PutNextEntry(ZipEntry);
        //    ZipStream.SetLevel(CompressionLevel);
        //    try
        //    {
        //        ZipStream.Write(buffer, 0, buffer.Length);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }
        //    ZipStream.Finish();
        //    ZipStream.Close();

        //    byte[] dd = stream.ToArray();

        //    stream.Close();

        //    return dd;
        //    //ZipFile.Close();
        //}

        /// <summary>
        /// 解压缩文件(压缩文件中含有子目录)
        /// </summary>
        /// <param name="zipfilepath">待解压缩的文件路径</param>
        public static byte[] UnZip(string zipfilepath)
        {
            byte[] data = null;

            ZipInputStream stream = new ZipInputStream(File.OpenRead(zipfilepath));

            ZipEntry theEntry;
            while ((theEntry = stream.GetNextEntry()) != null)
            {
                string fileName = Path.GetFileName(theEntry.Name);

                if (fileName != String.Empty)
                {
                    //如果文件的压缩后大小为0那么说明这个文件是空的,因此不需要进行读出写入
                    if (theEntry.CompressedSize == 0)
                        break;

                    data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);
                }
            }

            stream.Close();

            return data;
        }
    }
}