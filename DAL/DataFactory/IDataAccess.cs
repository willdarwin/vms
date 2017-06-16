using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    /// <summary>
    /// Declare a interface to assist to excute SQL order.
    /// </summary>
    public interface IDataAccess
    {
        /// <summary>
        /// Get the connectString
        /// </summary>
        OleDbConnection Connection { get; set; }

        /// <summary>
        /// Open the data connection.
        /// </summary>
        void Open();

        /// <summary>
        /// Close the data connection.
        /// </summary>
        void Close();

        /// <summary>
        /// Begin a transaction.
        /// </summary>
        void BeginTran();

        /// <summary>
        /// Commite a transaction.
        /// </summary>
        void CommitTran();

        /// <summary>
        /// Rollback a transaction.
        /// </summary>
        void RollbackTran();


        int ExecuteNonQuery(string sql, params QueryParameter[] list);
        object ExecuteScalar(string sql, params QueryParameter[] list);
        DataTable GetTable(string sql, params QueryParameter[] list);
        DataSet GetSet(string sql, string tableName);
        IDataReader GetReader(string sql, params QueryParameter[] list);
        DataTable ExecuteSql(string sql);
    }
}
