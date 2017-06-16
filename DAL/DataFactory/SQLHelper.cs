using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace DAL
{
    public class OleDbDataAccess : IDataAccess
    {

        public OleDbConnection Connection { get; set; }

        private OleDbTransaction transaction;

        public OleDbDataAccess(string connectionString)
        {
            Connection = new OleDbConnection(connectionString);
        }
        #region IDataAccess member

        public void Open()
        {
            if (this.Connection.State.Equals(ConnectionState.Closed))
            {
                this.Connection.Open();
            }
        }

        public void Close()
        {
            if (this.Connection != null && this.Connection.State.Equals(ConnectionState.Open))
            {
                this.Connection.Close();
            }
        }

        public void BeginTran()
        {
            transaction = this.Connection.BeginTransaction();
        }

        public void CommitTran()
        {
            this.transaction.Commit();
        }

        public void RollbackTran()
        {
            this.transaction.Rollback();
        }

        public int ExecuteNonQuery(string sql, params QueryParameter[] list)
        {
            OleDbCommand command = new OleDbCommand(sql, Connection);
            if (transaction != null)
            {
                command.Transaction = transaction;
            }
            PrepareCommand(command, CommandType.Text, sql, list);
            int i = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return i;
        }

        public object ExecuteScalar(string sql, params QueryParameter[] list)
        {
            OleDbCommand command = new OleDbCommand();
            PrepareCommand(command, CommandType.Text, sql, list);
            object obj = command.ExecuteScalar();
            command.Parameters.Clear();
            return obj;
        }

        public DataTable GetTable(string sql, params QueryParameter[] list)
        {
            DataTable table = new DataTable();
            OleDbCommand command = new OleDbCommand();
            PrepareCommand(command, CommandType.Text, sql, list);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(table);
            command.Parameters.Clear();
            return table;
        }

        public DataSet GetSet(string sql, string tableName)
        {
            OleDbDataAdapter myda = new OleDbDataAdapter(sql, this.Connection);
            DataSet result = new DataSet();
            myda.Fill(result, tableName);
            return result;
        }

        public IDataReader GetReader(string sql, params QueryParameter[] list)
        {
            OleDbCommand command = new OleDbCommand();
            PrepareCommand(command, CommandType.Text, sql, list);
            OleDbDataReader reader = command.ExecuteReader();
            command.Parameters.Clear();
            return reader;
        }

        public DataTable ExecuteSql(string sql)
        {
            OleDbDataAdapter myda = new OleDbDataAdapter(sql, this.Connection);
            DataSet result = new DataSet();
            myda.Fill(result);
            return result.Tables[0];
        }
        #endregion

        private void PrepareCommand(OleDbCommand command, CommandType type, string commandText, params QueryParameter[] list)
        {
            command.CommandText = commandText;
            command.CommandType = type;
            command.Connection = this.Connection;
            if (list != null && list.Length > 0)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    command.Parameters.AddWithValue(list[i].Name, list[i].Value);
                }
            }
        }
    }
}

