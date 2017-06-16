using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DAL
{
    public class DataAccessFactory
    {
        /// <summary>
        /// Creates the data access.
        /// </summary>
        /// <returns></returns>
        public static IDataAccess CreateDataAccess()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LeavingDBConnectionString"].ToString();
            string databaseType = ConfigurationManager.ConnectionStrings["LeavingDBConnectionString"].ProviderName;
            switch (databaseType)
            {
                case "System.Data.OleDb":
                    return new OleDbDataAccess(connectionString);
                default: throw new Exception("The type of database isn't supported!");
            }
        }
    }
}
