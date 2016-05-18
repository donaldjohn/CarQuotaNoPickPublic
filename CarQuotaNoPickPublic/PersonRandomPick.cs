namespace CarQuotaNoPickPublic
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;

    public class PersonRandomPick
    {
        public void GetMoreRandomNumber(ApplynumberArray applynumberArray)
        {
            if (applynumberArray != null)
            {
                if (applynumberArray.QuotaNumber >= applynumberArray.Count)
                {
                    for (int i = 0; i < applynumberArray.Count; i++)
                    {
                        applynumberArray.PickNumber.Add(i);
                    }
                }
                else
                {
                    this.GetRandomNumber(applynumberArray);
                }
            }
        }

        public void GetRandomNumber(ApplynumberArray applynumberArray)
        {
            Predicate<string> match = null;
            string applyNumber;
            if (applynumberArray != null)
            {
                ApplyNumberCheck check = new ApplyNumberCheck();
                Random random = new Random(applynumberArray.Seed);
                List<string> list = new List<string>();
                applynumberArray.PickNumber.Clear();
                if (applynumberArray.QuotaNumber > 0)
                {
                    int num2 = 0;
                    int num3 = (Convert.ToInt64((int) (applynumberArray.Count * 10)) >= 0x100000000L) ? applynumberArray.Count : (applynumberArray.Count * 10);
                    while (num2 < num3)
                    {
                        int index = random.Next(applynumberArray.Count);
                        applyNumber = check.GetApplyNumberFromArray(applynumberArray.Applynumbers, index);
                        if (applyNumber != "")
                        {
                            if (match == null)
                            {
                                match = p => p == applyNumber;
                            }
                            if (!list.Exists(match))
                            {
                                applynumberArray.PickNumber.Add(index);
                                list.Add(applyNumber);
                            }
                        }
                        if (applynumberArray.PickNumber.Count == applynumberArray.QuotaNumber)
                        {
                            break;
                        }
                        num2++;
                    }
                    // Add Personal Analysis Here
                    //MessageBox.Show("配额指标数："+ applynumberArray.QuotaNumber.ToString() + "; 过程中实际要到的随机数目："+num2.ToString()+"; 实际随机数废弃次数："+ (num2-applynumberArray.QuotaNumber).ToString());
                    if (num2 >= num3)
                    {
                        throw new Exception("运算超时！");
                    }
                }
            }
        }

        public void SetPickNumberDataSet(ApplynumberArray applynumberArray, PersonNumberDataSet pickNumberDataSet)
        {
            if (((applynumberArray != null) && (pickNumberDataSet != null)) && (applynumberArray.Count > 0))
            {
                ApplyNumberCheck check = new ApplyNumberCheck();
                pickNumberDataSet.Clear();
                for (int i = 0; i < applynumberArray.PickNumber.Count; i++)
                {
                    DataRow dataRow = pickNumberDataSet.NewRow();
                    dataRow["PickNO"] = i + 1;
                    string applyNumberFromArray = check.GetApplyNumberFromArray(applynumberArray.Applynumbers, applynumberArray.PickNumber[i]);
                    dataRow["ApplyNumber"] = applyNumberFromArray;
                    pickNumberDataSet.AddRow(dataRow);
                }
            }
        }
    }
}

