namespace CarQuotaNoPickPublic
{
    using ICSharpCode.SharpZipLib.Zip;
    using System;
    using System.IO;

    public static class SharpZipHepler
    {
        private static void CopyStream(Stream source, Stream target)
        {
            int count = 0x800;
            byte[] buffer = new byte[0x800];
            while (true)
            {
                count = source.Read(buffer, 0, buffer.Length);
                if (count <= 0)
                {
                    break;
                }
                target.Write(buffer, 0, count);
            }
        }

        public static bool UnZipTo(string zipPath, string toPath)
        {
            if (zipPath == string.Empty)
            {
                throw new Exception("压缩文件不能为空！ ");
            }
            if (!File.Exists(zipPath))
            {
                throw new Exception("压缩文件不存在！ ");
            }
            if (toPath == string.Empty)
            {
                toPath = zipPath.Replace(Path.GetFileName(zipPath), Path.GetFileNameWithoutExtension(zipPath));
            }
            if (!toPath.EndsWith(@"\"))
            {
                toPath = toPath + @"\";
            }
            if (!Directory.Exists(toPath))
            {
                Directory.CreateDirectory(toPath);
            }
            try
            {
                using (ZipInputStream stream = new ZipInputStream(File.OpenRead(zipPath)))
                {
                    ZipEntry entry;
                    while ((entry = stream.GetNextEntry()) != null)
                    {
                        string directoryName = Path.GetDirectoryName(entry.Name);
                        string fileName = Path.GetFileName(entry.Name);
                        if (directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(toPath + directoryName);
                        }
                        if (!directoryName.EndsWith(@"\"))
                        {
                            directoryName = directoryName + @"\";
                        }
                        if (fileName != string.Empty)
                        {
                            using (FileStream stream2 = File.Create(toPath + entry.Name))
                            {
                                CopyStream(stream, stream2);
                                stream2.Close();
                                continue;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return true;
        }

        public static bool ZipTo(string zipPath, string toFilePath)
        {
            if (zipPath == string.Empty)
            {
                throw new Exception("要压缩文件夹不能为空！ ");
            }
            if (!Directory.Exists(zipPath))
            {
                throw new Exception("要压缩文件夹不存在！ ");
            }
            if (toFilePath == string.Empty)
            {
                if (zipPath.EndsWith(@"\"))
                {
                    zipPath = zipPath.Substring(0, zipPath.Length - 1);
                }
                toFilePath = zipPath + ".zip";
            }
            try
            {
                string[] files = Directory.GetFiles(zipPath);
                using (ZipOutputStream stream = new ZipOutputStream(File.Create(toFilePath)))
                {
                    stream.SetLevel(9);
                    foreach (string str in files)
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(str)) {
                            DateTime = DateTime.Now
                        };
                        stream.PutNextEntry(entry);
                        using (FileStream stream2 = File.OpenRead(str))
                        {
                            CopyStream(stream2, stream);
                            stream.Close();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return true;
        }
    }
}

