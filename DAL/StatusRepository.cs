using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using DataModel;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class StatusRepository
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

        private const string StatusId = "StatusId";
        private const string StatusName = "StatusName";

        #endregion

        #region public method
        /// <summary>
        /// Create a data access for interact with database
        /// </summary>
        public StatusRepository()
        {
            _dataAccess = DataAccessFactory.CreateDataAccess();
        }

        /// <summary>
        /// Insert a piece of record in database.
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public Response InsertStatus(Status status)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "INSERT INTO [Status] ([StatusName]) VALUES (@StatusName)";
                QueryParameter p = new QueryParameter("@StatusName", status.StatusName, DbType.String);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, p));
            }
            return response;
        }

        /// <summary>
        /// Update a piece of record in database.
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public Response UpdateStatus(Status status)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "UPDATE [Status] SET [StatusName]=@StatusName WHERE [StatusId]=@StatusId";
                QueryParameter[] list = new QueryParameter[2];
                list[0] = new QueryParameter("@StatusName", status.StatusName, DbType.String);
                list[1] = new QueryParameter("@StatusId", status.StatusId, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, list));
            }
            return response;
        }

        /// <summary>
        /// Delete a piece of Status record in database.
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public Response DeleteStatus(Status status)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "DELETE FROM [Status] WHERE [StatusId]=@StatusId";
                QueryParameter p = new QueryParameter("@StatusId", status.StatusId, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, p));
            }
            return response;
        }

        /// <summary>
        /// Select All records
        /// </summary>
        /// <returns></returns>
        public List<Status> GetAllStatus()
        {
            List<Status> statusList = new List<Status>();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [Status] ";
                DataTable dt = _dataAccess.ExecuteSql(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    Status status = new Status()
                    {
                        StatusId = Convert.ToInt32(dr[StatusId]),
                        StatusName = dr[StatusName].ToString(),
                    };
                    statusList.Add(status);
                }
            }
            return statusList;
        }

        /// <summary>
        /// Select a Status list by Status id
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public Status GetStatusByStatusId(Status s)
        {
            Status status = new Status();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [Status] WHERE StatusId=@StatusId";
                QueryParameter p = new QueryParameter("StatusId", s.StatusId, DbType.Int32);
                DataTable dt = _dataAccess.GetTable(sql, p);
                foreach (DataRow dr in dt.Rows)
                {
                    status.StatusId = Convert.ToInt32(dr[StatusId]);
                    status.StatusName = dr[StatusName].ToString();
                }
            }
            return status;
        }

        /// <summary>
        /// Select a Status list by Status name
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public Status GetStatusByStatusName(Status s)
        {
            Status status = new Status();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [Status] WHERE StatusName=@StatusName";
                QueryParameter p = new QueryParameter("StatusName", s.StatusName, DbType.String);
                DataTable dt = _dataAccess.GetTable(sql, p);
                foreach (DataRow dr in dt.Rows)
                {
                    status.StatusId = Convert.ToInt32(dr[StatusId]);
                    status.StatusName = dr[StatusName].ToString();
                }
            }
            return status;
        }

        #endregion
    }
}
