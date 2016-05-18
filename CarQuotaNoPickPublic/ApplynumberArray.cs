namespace CarQuotaNoPickPublic
{
    using System;
    using System.Collections.Generic;

    public class ApplynumberArray
    {
        private byte[] _Applynumbers = null;
        private int _Count = 0;
        private string _FileName = "";
        private string _PeriodNO = "";
        private string _PeriodTitle = "";
        private string _PeriodType = "";
        private List<int> _PickNumber = new List<int>();
        private int _QuotaNumber = 0;
        private int _Seed = 0;
        public const int LENGTHOFAPPLYNUMBER = 13;

        public void Initialize()
        {
            this._PeriodType = "";
            this._PeriodNO = "";
            this._Count = 0;
            this._QuotaNumber = 0;
            this._FileName = "";
            this._Applynumbers = null;
            this._Seed = 0;
            this._PickNumber = new List<int>();
        }

        public bool IsApplyNumber(byte[] applyNumber)
        {
            bool flag = false;
            if (((this.Applynumbers != null) && (applyNumber != null)) && (applyNumber.Length == 13))
            {
                for (int i = 0; i < (this.Applynumbers.Length / 13); i++)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        if (this.Applynumbers[(i * 13) + j] != applyNumber[j])
                        {
                            break;
                        }
                        if (j == 12)
                        {
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        return flag;
                    }
                }
            }
            return flag;
        }

        public byte[] Applynumbers
        {
            get
            {
                return this._Applynumbers;
            }
            set
            {
                this._Applynumbers = value;
            }
        }

        public int Count
        {
            get
            {
                return this._Count;
            }
            set
            {
                this._Count = value;
            }
        }

        public string FileName
        {
            get
            {
                return this._FileName;
            }
            set
            {
                this._FileName = value;
            }
        }

        public string PeriodNO
        {
            get
            {
                return this._PeriodNO;
            }
            set
            {
                this._PeriodNO = value;
            }
        }

        public string PeriodTitle
        {
            get
            {
                return this._PeriodTitle;
            }
            set
            {
                this._PeriodTitle = value;
            }
        }

        public string PeriodType
        {
            get
            {
                return this._PeriodType;
            }
            set
            {
                this._PeriodType = value;
            }
        }

        public List<int> PickNumber
        {
            get
            {
                return this._PickNumber;
            }
            set
            {
                this._PickNumber = value;
            }
        }

        public int QuotaNumber
        {
            get
            {
                return this._QuotaNumber;
            }
            set
            {
                this._QuotaNumber = value;
            }
        }

        public int Seed
        {
            get
            {
                return this._Seed;
            }
            set
            {
                this._Seed = value;
            }
        }
    }
}

