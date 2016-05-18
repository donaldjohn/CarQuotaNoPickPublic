using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarQuotaNoPickPublic
{
    public class CSVFileHelper
    {
        //write a new file, existed file will be overwritten
        public static void WriteCSV(string filePathName, List<int> ls)
        {
            WriteCSV(filePathName, false, ls);
        }
        //write a file, existed file will be overwritten if append = false
        public static void WriteCSV(string filePathName, bool append, List<int> ls)
        {
            StreamWriter fileWriter = new StreamWriter(filePathName, append, Encoding.Default);
            foreach (int intArr in ls)
            {
                fileWriter.WriteLine(intArr.ToString());
            }
            fileWriter.Flush();
            fileWriter.Close();

        }
        public static List<String[]> ReadCSV(string filePathName)
        {
            List<String[]> ls = new List<String[]>();
            StreamReader fileReader = new StreamReader(filePathName);
            string strLine = "";
            while (strLine != null)
            {
                strLine = fileReader.ReadLine();
                if (strLine != null && strLine.Length > 0)
                {
                    ls.Add(strLine.Split(','));
                    //Debug.WriteLine(strLine);
                }
            }
            fileReader.Close();
            return ls;
        }
    }
}
