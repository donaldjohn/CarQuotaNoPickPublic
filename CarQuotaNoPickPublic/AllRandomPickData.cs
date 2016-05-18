namespace CarQuotaNoPickPublic
{
    using System;
    using System.Collections.Generic;

    public class AllRandomPickData
    {
        private List<int> _PickNumber = new List<int>();
        private int _QuotaNumber = 0;
        private int _Seed = 0;
        private int _TotalNumber = 0;

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

        public int TotalNumber
        {
            get
            {
                return this._TotalNumber;
            }
            set
            {
                this._TotalNumber = value;
            }
        }
    }
}

