using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class LeavingDetailsDataManager
    {
        IDataAccess dataAccess = null;

        public LeavingDetailsDataManager()
        {
            dataAccess = DataAccessFactory.CreateDataAccess();
        }

        public DataTable AllStaffsLeavingDetailsSelect()
        {
            //OleDbDataAccess dataAccess = new OleDbDataAccess();
            dataAccess.Open();
            string sql = "SELECT * FROM [LeavingDetails]";
            return dataAccess.GetTable(sql);;          
        }
    }
}
