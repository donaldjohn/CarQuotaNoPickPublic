namespace CarQuotaNoPickPublic
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public static class MD5HashCodeHeler
    {
        public static string GetBufferHashCode(byte[] buffer)
        {
            string str = null;
            if ((buffer != null) && (buffer.Length > 0))
            {
                StringBuilder builder = new StringBuilder();
                try
                {
                    byte[] buffer2 = MD5.Create().ComputeHash(buffer);
                    builder = new StringBuilder();
                    for (int i = 0; i < buffer2.Length; i++)
                    {
                        builder.Append(buffer2[i].ToString("x2"));
                    }
                    str = builder.ToString();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return str;
        }

        public static string GetFileHashCode(string fileName)
        {
            string str = null;
            if (fileName != null)
            {
                StringBuilder builder = new StringBuilder();
                try
                {
                    if (!File.Exists(fileName))
                    {
                        return str;
                    }
                    FileStream inputStream = File.OpenRead(fileName);
                    byte[] buffer = MD5.Create().ComputeHash(inputStream);
                    inputStream.Close();
                    inputStream.Dispose();
                    builder = new StringBuilder();
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        builder.Append(buffer[i].ToString("x2"));
                    }
                    str = builder.ToString();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return str;
        }
    }
}

