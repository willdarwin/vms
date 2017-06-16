using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;


namespace DAL
{
    public class LeaveDetailsRepository
    {
        #region private field

        /// <summary>
        /// Initialize a data access interface
        /// </summary>
        private IDataAccess _dataAccess = null;
        /// <summary>
        /// Connection String
        /// </summary>
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["LeavingDBConnectionString"].ToString();

        private const string LeaveDetailsId = "LeaveDetailsId";
        private const string StaffId = "StaffId";
        private const string LeaveTypeId = "LeaveTypeId";
        private const string StartDate = "StartDate";
        private const string EndDate = "EndDate";
        private const string Duration = "Duration";
        private const string Remark = "Remark";

        #endregion

        #region public method

        /// <summary>
        /// Create a data access for interact with database
        /// </summary>
        public LeaveDetailsRepository()
        {
            _dataAccess = DataAccessFactory.CreateDataAccess();
        }

        /// <summary>
        /// Insert a piece of record in database.
        /// </summary>
        /// <param name="LeaveDetails"></param>
        /// <returns></returns>
        public Response InsertLeaveDetails(LeaveDetails leaveDetails)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "INSERT INTO [LeaveDetails] ([StaffId],[LeaveTypeId],[StartDate],[EndDate],[Duration],[Remark]) VALUES (@StaffId,@LeaveTypeId,@StartDate,@EndDate,@Duration,@Remark)";
                QueryParameter[] list = new QueryParameter[6];
                list[0] = new QueryParameter("@StaffId", leaveDetails.StaffId, DbType.Int32);
                list[1] = new QueryParameter("@LeaveTypeId", leaveDetails.LeaveTypeId, DbType.Int32);
                list[2] = new QueryParameter("@StartDate", leaveDetails.StartDate, DbType.DateTime);
                list[3] = new QueryParameter("@EndDate", leaveDetails.EndDate, DbType.DateTime);
                list[4] = new QueryParameter("@Duration", leaveDetails.Duration, DbType.Single);
                list[5] = new QueryParameter("@Remark", leaveDetails.Remark, DbType.String);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, list));
            }
            return response;
        }

        /// <summary>
        /// Update a piece of record in database.
        /// </summary>
        /// <param name="LeaveDetails"></param>
        /// <returns></returns>
        public Response UpdateLeaveDetails(LeaveDetails leaveDetails)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "UPDATE [LeaveDetails] SET [StaffId]=@StaffId,[LeaveTypeId]=@LeaveTypeId,[StartDate]=@StartDate,[EndDate]=@EndDate,[Duration]=@Duration,[Remark]=@Remark WHERE [LeaveDetailsId]=@LeaveDetailsId";
                QueryParameter[] list = new QueryParameter[7];
                list[0] = new QueryParameter("@StaffId", leaveDetails.StaffId, DbType.Int32);
                list[1] = new QueryParameter("@LeaveTypeId", leaveDetails.LeaveTypeId, DbType.Int32);
                list[2] = new QueryParameter("@StartDate", leaveDetails.StartDate, DbType.DateTime);
                list[3] = new QueryParameter("@EndDate", leaveDetails.EndDate, DbType.DateTime);
                list[4] = new QueryParameter("@Duration", leaveDetails.Duration, DbType.Single);
                list[5] = new QueryParameter("@Remark", leaveDetails.Remark, DbType.String);
                list[6] = new QueryParameter("@LeaveDetailsId", leaveDetails.LeaveDetailsId, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, list));
            }
            return response;
        }

        /// <summary>
        /// Delete a piece of LeaveDetails record in database.
        /// </summary>
        /// <param name="LeaveDetails"></param>
        /// <returns></returns>
        public Response DeleteLeaveDetails(LeaveDetails leaveDetails)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "DELETE FROM [LeaveDetails] WHERE [LeaveDetailsId]=@LeaveDetailsId";
                QueryParameter p = new QueryParameter("@LeaveDetailsId", leaveDetails.LeaveDetailsId, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, p));
            }
            return response;
        }

        /// <summary>
        /// Select All records
        /// </summary>
        /// <returns></returns>
        public List<LeaveDetails> GetAllLeaveDetails()
        {
            List<LeaveDetails> leaveDetailsList = new List<LeaveDetails>();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [LeaveDetails] ";
                DataTable dt = _dataAccess.ExecuteSql(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    LeaveDetails leaveDetails = new LeaveDetails()
                    {
                        LeaveDetailsId = Convert.ToInt32(dr[LeaveDetailsId]),
                        StaffId = Convert.ToInt32(dr[StaffId]),
                        LeaveTypeId = Convert.ToInt32(dr[LeaveTypeId]),
                        StartDate = Convert.ToDateTime(dr[StartDate]),
                        EndDate = Convert.ToDateTime(dr[EndDate]),
                        Duration = Convert.ToSingle(dr[Duration]),
                        Remark = dr[Remark].ToString()
                    };
                    leaveDetailsList.Add(leaveDetails);
                }
            }
            return leaveDetailsList;
        }

        /// <summary>
        /// Select a LeaveDetails list by LeaveDetails id
        /// </summary>
        /// <param name="LeaveDetails"></param>
        /// <returns></returns>
        public LeaveDetails GetLeaveDetailsByLeaveDetailsId(LeaveDetails ld)
        {
            LeaveDetails leaveDetails = new LeaveDetails();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [LeaveDetails] WHERE LeaveDetailsId=@LeaveDetailsId";
                QueryParameter p = new QueryParameter("LeaveDetailsId", ld.LeaveDetailsId, DbType.Int32);
                DataTable dt = _dataAccess.GetTable(sql, p);
                foreach (DataRow dr in dt.Rows)
                {
                    leaveDetails.LeaveDetailsId = Convert.ToInt32(dr[LeaveDetailsId]);
                    leaveDetails.StaffId = Convert.ToInt32(dr[StaffId]);
                    leaveDetails.LeaveTypeId = Convert.ToInt32(dr[LeaveTypeId]);
                    leaveDetails.StartDate = Convert.ToDateTime(dr[StartDate]);
                    leaveDetails.EndDate = Convert.ToDateTime(dr[EndDate]);
                    leaveDetails.Duration = Convert.ToSingle(dr[Duration]);
                    leaveDetails.Remark = dr[Remark].ToString();
                }
            }
            return leaveDetails;
        }

        /// <summary>
        /// Select a LeaveDetails list by LeaveDetails name
        /// </summary>
        /// <param name="LeaveDetails"></param>
        /// <returns></returns>
        public List<LeaveDetails> GetLeaveDetailsByStaffId(LeaveDetails ld)
        {
            List<LeaveDetails> leaveDetailsList = new List<LeaveDetails>();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [LeaveDetails] WHERE StaffId=@StaffId AND StartDate>=#" + ld.StartDate + "# AND StartDate<=#" + ld.EndDate + "# ORDER BY [LeaveDetailsId] DESC";
                QueryParameter p = new QueryParameter("StaffId", ld.StaffId, DbType.Int32);
                DataTable dt = _dataAccess.GetTable(sql, p);
                foreach (DataRow dr in dt.Rows)
                {
                    LeaveDetails leaveDetails = new LeaveDetails()
                    {
                        LeaveDetailsId = Convert.ToInt32(dr[LeaveDetailsId]),
                        StaffId = Convert.ToInt32(dr[StaffId]),
                        LeaveTypeId = Convert.ToInt32(dr[LeaveTypeId]),
                        StartDate = Convert.ToDateTime(dr[StartDate]),
                        EndDate = Convert.ToDateTime(dr[EndDate]),
                        Duration = Convert.ToSingle(dr[Duration]),
                        Remark = dr[Remark].ToString()

                    };
                    leaveDetailsList.Add(leaveDetails);
                }
            }
            return leaveDetailsList;
        }

        /// <summary>
        /// methods for Test
        /// </summary>
        private OleDbCommand _cmd;
        private OleDbDataAdapter _da;

        /// <summary>
        /// Inserts the details.
        /// </summary>
        /// <param name="detail">The detail.</param>
        /// <param name="staffId">The staff id.</param>
        public void InsertDetails(DataSet detail, int staffId)
        {
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                string strSql = "select top 1 * from [LeaveDetails] where[StaffId]=" + staffId;// get table structure
                OleDbDataAdapter da = new OleDbDataAdapter(strSql, _dataAccess.Connection);
                OleDbCommandBuilder cmdb = new OleDbCommandBuilder(da);
                da.Update(detail);
            }
        }

        /// <summary>
        /// Gets the details by id.
        /// </summary>
        /// <param name="UserId">The user id.</param>
        /// <returns></returns>
        public DataSet GetDetailsById(int UserId)
        {
            List<LeaveDetails> details = new List<LeaveDetails>();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                DataSet ds = new DataSet();
                string Sqlstr;
                Sqlstr = "select [LeaveDetails].LeaveDetailsId, [LeaveType].LeaveTypeId,[LeaveDetails].StaffId,[LeaveType].LeaveTypeName, [LeaveDetails].StartDate, [LeaveDetails].EndDate, [LeaveDetails].Duration, [LeaveDetails].Remark from ([LeaveDetails] inner join [LeaveType] on [LeaveDetails].LeaveTypeId=[LeaveType].LeaveTypeId) where[LeaveDetails].StaffId=" + UserId;
                _cmd = new OleDbCommand(Sqlstr, _dataAccess.Connection);
                _da = new OleDbDataAdapter(_cmd);
                _da.Fill(ds);
                return ds;
            }
        }

        #endregion
    }
}


