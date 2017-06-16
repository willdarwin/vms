using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;


namespace LeavingManagementSystem
{
    class DataManage
    {
        #region public variable
        public static string Login_Id = "";
        public static string Login_Name = "";
        public static DataGridView dataGridView;
        public static OleDbConnection oleDbconnection;
        public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/App_Data/LeavingDB.accdb";
        #endregion

        #region create database link
        public static OleDbConnection GetCon()
        {
            oleDbconnection = new OleDbConnection(connectionString);
            oleDbconnection.Open();
            return oleDbconnection;
        }
        #endregion

        #region Test whether the database is attached
        public void Con_open()
        {
            GetCon();
        }
        #endregion

        #region close database link
        public void Con_Close()
        {
            if (oleDbconnection.State == ConnectionState.Open)
            {
                oleDbconnection.Close();
                oleDbconnection.Dispose();
            }
        }
        #endregion

        #region  Read data in a specified table
        public OleDbDataReader GetCom(string cmdstr, string userName, string password)
        {
            GetCon();
            OleDbCommand cmd = oleDbconnection.CreateCommand();
            cmd.CommandText = cmdstr;
            OleDbParameter[] paras = new OleDbParameter[] 
                    { 
                      new OleDbParameter("@UserName",userName),
                      new OleDbParameter("@Password",password) 
                    };
            cmd.Parameters.AddRange(paras);
            OleDbDataReader reader = cmd.ExecuteReader(); 
            return reader;
        }
        #endregion

        #region  Read data in a specified table
        public OleDbDataReader GetCom(string cmdstr)
        {
            GetCon();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = GetCon();
            cmd.CommandText = cmdstr;
            OleDbDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        #endregion

        #region Execute the OleDbCommand command
        public bool GetOleDbCom(string OleDbstr)
        {
            GetCon();  
            OleDbCommand OleDbcom = new OleDbCommand(OleDbstr, oleDbconnection); 
            int flag=OleDbcom.ExecuteNonQuery();   
            OleDbcom.Dispose();   
            Con_Close();
            if (flag > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region  Create DataSet object.
        public DataSet GetDataSet(string OleDbstr, string tableName)
        {
            GetCon();   
            OleDbDataAdapter da = new OleDbDataAdapter(OleDbstr, oleDbconnection);  
            DataSet ds= new DataSet(); 
            da.Fill(ds, tableName); 
            Con_Close();    
            return ds; 
        }
        #endregion
    }
}
