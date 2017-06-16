using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace DAL
{
    public class LeaveTypeRepository
    {
        #region private field

        private IDataAccess _dataAccess = null;
        private string connectionString = ConfigurationManager.ConnectionStrings["LeavingDBConnectionString"].ToString();
        private const string LeaveTypeId = "LeaveTypeId";
        private const string LeaveTypeName = "LeaveTypeName";

        #endregion

        #region public method

        /// <summary>
        /// Create a data access for interact with database
        /// </summary>
        public LeaveTypeRepository()
        {
            _dataAccess = DataAccessFactory.CreateDataAccess();
        }

        /// <summary>
        /// Insert a piece of record in database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Response InsertLeaveType(LeaveType leaveType)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(connectionString))
            {
                _dataAccess.Open();
                string sql = "INSERT INTO [LeaveType] ([LeaveTypeName]) VALUES (@LeaveTypeName)";
                QueryParameter p = new QueryParameter("@LeaveTypeName", leaveType.LeaveTypeName, DbType.String);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, p));
            }
            return response;
        }

        /// <summary>
        /// Update a piece of record in database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Response UpdateLeaveType(LeaveType leaveType)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(connectionString))
            {
                _dataAccess.Open();
                string sql = "UPDATE [LeaveType] SET [LeaveTypeName]=@LeaveTypeName WHERE [LeaveTypeId]=@LeaveTypeId";
                QueryParameter[] list = new QueryParameter[2];
                list[0] = new QueryParameter("@LeaveTypeName", leaveType.LeaveTypeName, DbType.String);
                list[1] = new QueryParameter("@LeaveTypeId", leaveType.LeaveTypeId, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, list));
            }
            return response;
        }

        /// <summary>
        /// Delete a piece of user record in database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Response DeleteLeaveType(LeaveType leaveType)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(connectionString))
            {
                _dataAccess.Open();
                string sql = "DELETE FROM [LeaveType] WHERE [LeaveTypeId]=@LeaveTypeId";
                QueryParameter p = new QueryParameter("@LeaveTypeId", leaveType.LeaveTypeId, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, p));
            }
            return response;
        }

        /// <summary>
        /// Select All records
        /// </summary>
        /// <returns></returns>
        public List<LeaveType> GetAllLeaveTypes()
        {
            List<LeaveType> leaveTypeList = new List<LeaveType>();
            using (_dataAccess.Connection = new OleDbConnection(connectionString))
            {
                _dataAccess.Open();
                string sql;
                sql = "SELECT * FROM [LeaveType]";
                DataTable dt = _dataAccess.ExecuteSql(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    LeaveType leaveType = new LeaveType()
                    {
                        LeaveTypeId = Convert.ToInt32(dr[LeaveTypeId]),
                        LeaveTypeName = dr[LeaveTypeName].ToString(),
                    };
                    leaveTypeList.Add(leaveType);
                }
            }
            return leaveTypeList;
        }

        /// <summary>
        /// Select a user list by user id
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public LeaveType GetLeaveTypeByLeaveTypeId(LeaveType lT)
        {
            LeaveType leaveType = new LeaveType();
            using (_dataAccess.Connection = new OleDbConnection(connectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [LeaveType] WHERE [LeaveTypeId]=@LeaveTypeId";
                QueryParameter p = new QueryParameter("LeaveTypeId", lT.LeaveTypeId, DbType.Int32);
                DataTable dt = _dataAccess.GetTable(sql, p);
                foreach (DataRow dr in dt.Rows)
                {
                    leaveType.LeaveTypeId = Convert.ToInt32(dr[LeaveTypeId]);
                    leaveType.LeaveTypeName = dr[LeaveTypeName].ToString();
                }
            }
            return leaveType;
        }

        /// <summary>
        /// Select a user list by user name
        /// </summary>
        /// <param name="lT"></param>
        /// <returns></returns>
        public LeaveType GetLeaveTypeByLeaveTypeName(LeaveType lT)
        {
            LeaveType leaveType = new LeaveType();
            using (_dataAccess.Connection = new OleDbConnection(connectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [LeaveType] WHERE [LeaveTypeName]=@LeaveTypeName";
                QueryParameter p = new QueryParameter("LeaveTypeName", lT.LeaveTypeName, DbType.String);
                DataTable dt = _dataAccess.GetTable(sql, p);
                foreach (DataRow dr in dt.Rows)
                {
                    leaveType.LeaveTypeId = Convert.ToInt32(dr[LeaveTypeId]);
                    leaveType.LeaveTypeName = dr[LeaveTypeName].ToString();
                }
            }
            return leaveType;
        }

        /// <summary>
        /// chenchao
        /// </summary>
        private OleDbConnection _conn;
        private OleDbCommand _cmd;
        private OleDbDataAdapter _da;

        /// <summary>
        /// chenchao
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<LeaveType> GetLeavings(string n)
        {

            List<LeaveType> leavings = new List<LeaveType>();
            using (_conn = new OleDbConnection(connectionString))
            {
                DataSet _ds = new DataSet();
                string Sqlstr;
                if (n == "common")
                { Sqlstr = "select top 2 * from [LeaveType]"; }
                else
                { Sqlstr = "select * from [LeaveType] where [LeaveTypeId] not in (select top 2 [LeaveTypeId] from [LeaveType] )"; }
                _cmd = new OleDbCommand(Sqlstr, _conn);
                _da = new OleDbDataAdapter(_cmd);
                _da.Fill(_ds);

                foreach (DataRow row in _ds.Tables[0].Rows)
                {
                    LeaveType l = new LeaveType
                    {
                        LeaveTypeId = Convert.ToInt32(row[0]),
                        LeaveTypeName = row[1].ToString(),
                    };
                    leavings.Add(l);
                }
                return leavings;
            }
        }
    }
        #endregion
}

