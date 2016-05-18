namespace CarQuotaNoPickPublic
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class AllRandomPick
    {
        public void GetRandomNumber(AllRandomPickData allRandomPickData)
        {
            Predicate<int> match = null;
            int pickNumber;
            if ((allRandomPickData != null) && (allRandomPickData.QuotaNumber < allRandomPickData.TotalNumber))
            {
                int num = (Convert.ToInt64((int) (allRandomPickData.TotalNumber * 10)) >= 0x100000000L) ? allRandomPickData.TotalNumber : (allRandomPickData.TotalNumber * 10);
                Random random = new Random(allRandomPickData.Seed);
                List<int> list = new List<int>();
                allRandomPickData.PickNumber.Clear();
                if (allRandomPickData.QuotaNumber > 0)
                {
                    int num2 = 0;
                    while (num2 < num)
                    {
                        pickNumber = random.Next(allRandomPickData.TotalNumber);
                        if (match == null)
                        {
                            match = p => p == pickNumber;
                        }
                        if (!list.Exists(match))
                        {
                            allRandomPickData.PickNumber.Add(pickNumber + 1);
                            list.Add(pickNumber);
                        }
                        if (allRandomPickData.PickNumber.Count >= allRandomPickData.QuotaNumber)
                        {
                            break;
                        }
                        num2++;
                    }
                    if (num2 == num)
                    {
                        throw new Exception("运算超时！");
                    }
                }
            }
        }

        public void SetPickNumberDataSet(List<int> pickNumberList, PickNumberDataSet pickNumberDataSet)
        {
            if (((pickNumberList != null) && (pickNumberDataSet != null)) && (pickNumberList.Count > 0))
            {
                pickNumberDataSet.Clear();
                for (int i = 0; i < pickNumberList.Count; i++)
                {
                    DataRow dataRow = pickNumberDataSet.NewRow();
                    dataRow["PickNO"] = i + 1;
                    dataRow["PoolNO"] = pickNumberList[i];
                    pickNumberDataSet.AddRow(dataRow);
                }
            }
        }
    }
}

