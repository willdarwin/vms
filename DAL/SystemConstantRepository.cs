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
    public class SystemConstantRepository
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

        private const string SystemConstantId = "SystemConstantId";
        private const string ConstantName = "ConstantName";
        private const string ConstantValue = "ConstantValue";
        private const string Description = "Description";

        #endregion

        #region public method
        /// <summary>
        /// Create a data access for interact with database
        /// </summary>
        public SystemConstantRepository()
        {
            _dataAccess = DataAccessFactory.CreateDataAccess();
        }

        /// <summary>
        /// Insert a piece of record in database.
        /// </summary>
        /// <param name="SystemConstant"></param>
        /// <returns></returns>
        public Response InsertSystemConstant(SystemConstant systemConstant)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "INSERT INTO [SystemConstant] ([ConstantName],[ConstantValue],[Description]) VALUES (@ConstantName,@ConstantValue,@Description)";
                QueryParameter[] list = new QueryParameter[3];
                list[0] = new QueryParameter("@ConstantName", systemConstant.ConstantName, DbType.String);
                list[1] = new QueryParameter("@ConstantValue", systemConstant.ConstantValue, DbType.String);
                list[2] = new QueryParameter("@Description", systemConstant.Description, DbType.String);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, list));
            }
            return response;
        }

        /// <summary>
        /// Update a piece of record in database.
        /// </summary>
        /// <param name="SystemConstant"></param>
        /// <returns></returns>
        public Response UpdateSystemConstant(SystemConstant systemConstant)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "UPDATE [SystemConstant] SET [ConstantName]=@ConstantName,[ConstantValue]=@ConstantValue,[Description]=@Description WHERE [SystemConstantId]=@SystemConstantId";
                QueryParameter[] list = new QueryParameter[4];
                list[0] = new QueryParameter("@ConstantName", systemConstant.ConstantName, DbType.String);
                list[1] = new QueryParameter("@ConstantValue", systemConstant.ConstantValue, DbType.String);
                list[2] = new QueryParameter("@Description", systemConstant.Description, DbType.String);
                list[3] = new QueryParameter("@SystemConstantId", systemConstant.SystemConstantId, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, list));
            }
            return response;
        }

        /// <summary>
        /// Delete a piece of SystemConstant record in database.
        /// </summary>
        /// <param name="SystemConstant"></param>
        /// <returns></returns>
        public Response DeleteSystemConstant(SystemConstant systemConstant)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "DELETE FROM [SystemConstant] WHERE [SystemConstantId]=@SystemConstantId";
                QueryParameter p = new QueryParameter("@SystemConstantId", systemConstant.SystemConstantId, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, p));
            }
            return response;
        }

        /// <summary>
        /// Select All records
        /// </summary>
        /// <returns></returns>
        public List<SystemConstant> GetAllSystemConstants()
        {
            List<SystemConstant> systemConstantList = new List<SystemConstant>();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [SystemConstant] ";
                DataTable dt = _dataAccess.ExecuteSql(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    SystemConstant SystemConstant = new SystemConstant()
                    {
                        SystemConstantId = Convert.ToInt32(dr[SystemConstantId]),
                        ConstantName = dr[ConstantName].ToString(),
                        ConstantValue = dr[ConstantValue].ToString(),
                        Description = dr[Description].ToString(),
                    };
                    systemConstantList.Add(SystemConstant);
                }
            }
            return systemConstantList;
        }

        /// <summary>
        /// Select a SystemConstant list by SystemConstant id
        /// </summary>
        /// <param name="SystemConstant"></param>
        /// <returns></returns>
        public SystemConstant GetSystemConstantBySystemConstantId(SystemConstant s)
        {
            SystemConstant systemConstant = new SystemConstant();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [SystemConstant] WHERE SystemConstantId=@SystemConstantId";
                QueryParameter p = new QueryParameter("SystemConstantId", s.SystemConstantId, DbType.Int32);
                DataTable dt = _dataAccess.GetTable(sql, p);
                foreach (DataRow dr in dt.Rows)
                {
                    systemConstant.SystemConstantId = Convert.ToInt32(dr[SystemConstantId]);
                    systemConstant.ConstantName = dr[ConstantName].ToString();
                    systemConstant.ConstantValue = dr[ConstantValue].ToString();
                    systemConstant.Description = dr[Description].ToString();
                }
            }
            return systemConstant;
        }

        /// <summary>
        /// Select a SystemConstant list by SystemConstant name
        /// </summary>
        /// <param name="SystemConstant"></param>
        /// <returns></returns>
        public SystemConstant GetSystemConstantByConstantName(SystemConstant s)
        {
            SystemConstant systemConstant = new SystemConstant();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [SystemConstant] WHERE ConstantName=@ConstantName";
                QueryParameter p = new QueryParameter("SystemConstantName", s.ConstantName, DbType.String);
                DataTable dt = _dataAccess.GetTable(sql, p);
                foreach (DataRow dr in dt.Rows)
                {
                    systemConstant.SystemConstantId = Convert.ToInt32(dr[SystemConstantId]);
                    systemConstant.ConstantName = dr[ConstantName].ToString();
                    systemConstant.ConstantValue = dr[ConstantValue].ToString();
                    systemConstant.Description = dr[Description].ToString();
                }
            }
            return systemConstant;
        }

        #endregion
    }
}
