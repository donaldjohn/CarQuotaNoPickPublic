namespace CarQuotaNoPickPublic
{
    using System;
    using System.Data;

    public class PersonNumberDataSet
    {
        private System.Data.DataSet _DataSet = new System.Data.DataSet();

        public PersonNumberDataSet()
        {
            this.InitializeDataSet();
        }

        public void AddRow(DataRow dataRow)
        {
            if (((this._DataSet != null) && (this._DataSet.Tables != null)) && (this._DataSet.Tables[0] != null))
            {
                this._DataSet.Tables[0].Rows.Add(dataRow);
            }
        }

        public void Clear()
        {
            if (((this._DataSet != null) && (this._DataSet.Tables != null)) && (this._DataSet.Tables[0] != null))
            {
                this._DataSet.Tables[0].Clear();
            }
        }

        private void InitializeDataSet()
        {
            DataTable table = new DataTable();
            DataColumn column = new DataColumn();
            DataColumn column2 = new DataColumn();
            this._DataSet.DataSetName = "DataSet1";
            this._DataSet.Tables.Add(table);
            table.Columns.AddRange(new DataColumn[] { column, column2 });
            table.TableName = "Table1";
            column.Caption = "序号";
            column.ColumnName = "PickNO";
            column.DataType = typeof(int);
            column2.Caption = "申请编码";
            column2.ColumnName = "ApplyNumber";
            column.DataType = typeof(int);
        }

        public DataRow NewRow()
        {
            DataRow row = null;
            if (((this._DataSet != null) && (this._DataSet.Tables != null)) && (this._DataSet.Tables[0] != null))
            {
                row = this._DataSet.Tables[0].NewRow();
            }
            return row;
        }

        public System.Data.DataSet DataSet
        {
            get
            {
                return this._DataSet;
            }
            set
            {
                this._DataSet = value;
            }
        }
    }
}

