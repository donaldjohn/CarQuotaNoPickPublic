namespace CarQuotaNoPickPublic
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ApplyNumberCheck
    {
        public bool DeleteDir(string strPath)
        {
            bool flag;
            try
            {
                strPath = strPath.Trim().ToString();
                if (Directory.Exists(strPath))
                {
                    Directory.Delete(strPath, true);
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString());
            }
            return flag;
        }

        public string GetApplyInformationFileName(string periodType, string periodNO)
        {
            string str = "";
            if (periodNO != "")
            {
                if (periodType == "PERSONCOMMON")
                {
                    str = "bjPersonCommonNumberPeriod" + periodNO + ".csv";
                }
                if (periodType == "PERSONNEW")
                {
                    str = "bjPersonNewNumberPeriod" + periodNO + ".csv";
                }
                if (periodType == "UNITCOMMON")
                {
                    str = "bjUnitCommonNumberPeriod" + periodNO + ".csv";
                }
                if (periodType == "UNITNEW")
                {
                    str = "bjUnitNewNumberPeriod" + periodNO + ".csv";
                }
            }
            return str;
        }

        public string GetApplyNumberFileName(string periodType, string periodNO, int NO)
        {
            string str = "";
            if (periodNO != "")
            {
                int num = 0x2710 + NO;
                if (periodType == "PERSONCOMMON")
                {
                    str = "bjPersonCommonApplyNumber" + periodNO + "_" + num.ToString().Substring(1, 4) + ".csv";
                }
                if (periodType == "PERSONNEW")
                {
                    str = "bjPersonNewApplyNumber" + periodNO + "_" + num.ToString().Substring(1, 4) + ".csv";
                }
                if (periodType == "UNITCOMMON")
                {
                    str = "bjUnitCommonApplyNumber" + periodNO + "_" + num.ToString().Substring(1, 4) + ".csv";
                }
                if (periodType == "UNITNEW")
                {
                    str = "bjUnitNewApplyNumber" + periodNO + "_" + num.ToString().Substring(1, 4) + ".csv";
                }
            }
            return str;
        }

        public string GetApplyNumberFromArray(byte[] array, int index)
        {
            string str = "";
            if (((array != null) && (index >= 0)) && ((index * 13) < array.Length))
            {
                str = new string(Encoding.UTF8.GetChars(array, index * 13, 13));
            }
            return str;
        }

        public void ImportAppklyNumberPeriodFromMetaFileName(ApplynumberArray applynumberArray, string fileName)
        {
            if ((applynumberArray != null) && (fileName != ""))
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        using (StreamReader reader = File.OpenText(fileName))
                        {
                            if (reader.ReadLine() != applynumberArray.PeriodType)
                            {
                                throw new Exception("前后分期类型不一致！");
                            }
                            if (reader.ReadLine() != applynumberArray.PeriodNO)
                            {
                                throw new Exception("前后分期编号数据不一致！");
                            }
                            string str = reader.ReadLine();
                            applynumberArray.PeriodTitle = str;
                            str = reader.ReadLine();
                            str = reader.ReadLine();
                            str = reader.ReadLine();
                            if (str != "")
                            {
                                applynumberArray.Count = Convert.ToInt32(str);
                                if (applynumberArray.Count <= 0)
                                {
                                    throw new Exception("申请编码数据总数应该大于零！");
                                }
                            }
                            str = reader.ReadLine();
                            if (str != "")
                            {
                                applynumberArray.QuotaNumber = Convert.ToInt32(str);
                            }
                            reader.Close();
                        }
                        return;
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
                throw new Exception("文件不存在！");
            }
        }

        public void ImportApplyNumberPeriodFromDataFileName(ApplynumberArray applynumberArray, string fileName, int filenum, int count)
        {
            if ((applynumberArray != null) && (fileName != ""))
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        Regex regex = new Regex(@"^\d{13}$");
                        using (StreamReader reader = File.OpenText(fileName))
                        {
                            int num = (filenum - 1) * 0x186a0;
                            for (int i = 0; i < count; i++)
                            {
                                string str = reader.ReadLine();
                                if (str != "")
                                {
                                    string[] strArray = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                    if (!regex.IsMatch(strArray[1]))
                                    {
                                        throw new Exception("申请编码应该是13位数字！");
                                    }
                                    Encoding.UTF8.GetBytes(strArray[1]).CopyTo(applynumberArray.Applynumbers, (int) (num * 13));
                                    num++;
                                }
                            }
                        }
                        return;
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
                throw new Exception("文件不存在！");
            }
        }

        public void ImportPersonNumberPeriodFromFilePath(ApplynumberArray applynumberArray, string filePath)
        {
            if ((applynumberArray != null) && (filePath != ""))
            {
                if (!Directory.Exists(filePath))
                {
                    throw new Exception("目录" + filePath + "不存在！");
                }
                FileInfo[] files = new DirectoryInfo(filePath).GetFiles();
                Regex regex = new Regex(@"^\d{6}$");
                string name = "";
                string input = "";
                foreach (FileInfo info2 in files)
                {
                    if (info2.Name.StartsWith("bjPersonCommonNumberPeriod"))
                    {
                        applynumberArray.PeriodType = "PERSONCOMMON";
                        name = info2.Name;
                        input = Path.GetFileNameWithoutExtension(info2.Name).Substring("bjPersonCommonNumberPeriod".Length);
                        if (!regex.IsMatch(input))
                        {
                            throw new Exception("文件名称不符合规范！");
                        }
                        break;
                    }
                    if (info2.Name.StartsWith("bjPersonNewNumberPeriod"))
                    {
                        applynumberArray.PeriodType = "PERSONNEW";
                        name = info2.Name;
                        input = Path.GetFileNameWithoutExtension(info2.Name).Substring("bjPersonNewNumberPeriod".Length);
                        if (!regex.IsMatch(input))
                        {
                            throw new Exception("文件名称不符合规范！");
                        }
                        break;
                    }
                    if (info2.Name.StartsWith("bjUnitCommonNumberPeriod"))
                    {
                        applynumberArray.PeriodType = "UNITCOMMON";
                        name = info2.Name;
                        input = Path.GetFileNameWithoutExtension(info2.Name).Substring("bjUnitCommonNumberPeriod".Length);
                        if (!regex.IsMatch(input))
                        {
                            throw new Exception("文件名称不符合规范！");
                        }
                        break;
                    }
                    if (info2.Name.StartsWith("bjUnitNewNumberPeriod"))
                    {
                        applynumberArray.PeriodType = "UNITNEW";
                        name = info2.Name;
                        input = Path.GetFileNameWithoutExtension(info2.Name).Substring("bjUnitNewNumberPeriod".Length);
                        if (!regex.IsMatch(input))
                        {
                            throw new Exception("文件名称不符合规范！");
                        }
                        break;
                    }
                }
                try
                {
                    applynumberArray.PeriodNO = input;
                    this.ImportAppklyNumberPeriodFromMetaFileName(applynumberArray, filePath + @"\" + name);
                    if ((applynumberArray != null) && (applynumberArray.Count > 0))
                    {
                        applynumberArray.Applynumbers = new byte[applynumberArray.Count * 13];
                        int count = applynumberArray.Count;
                        int num2 = 0x186a0;
                        int num3 = Convert.ToInt32(Math.Ceiling((decimal) (count / Convert.ToDecimal(num2))));
                        for (int i = 1; i <= num3; i++)
                        {
                            name = this.GetApplyNumberFileName(applynumberArray.PeriodType, applynumberArray.PeriodNO, i);
                            if (!File.Exists(filePath + @"\" + name))
                            {
                                throw new Exception("文件" + name + "不存在！");
                            }
                            if (i < num3)
                            {
                                this.ImportApplyNumberPeriodFromDataFileName(applynumberArray, filePath + @"\" + name, i, num2);
                            }
                            else
                            {
                                this.ImportApplyNumberPeriodFromDataFileName(applynumberArray, filePath + @"\" + name, i, count - ((i - 1) * num2));
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception("读取文件出错！ " + exception.Message);
                }
            }
        }
    }
}

