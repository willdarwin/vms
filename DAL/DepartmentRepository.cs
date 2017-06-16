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
    public class DepartmentRepository
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

        private const string DepartmentId = "DepartmentId";
        private const string DepartmentName = "DepartmentName";
        private const string Description = "Description";
        private const string DepartmentManagerId = "DepartmentManagerId";
        private const string ParentDepartmentId = "ParentDepartmentId";

        #endregion

        #region public method
        /// <summary>
        /// Create a data access for interact with database
        /// </summary>
        public DepartmentRepository()
        {
            _dataAccess = DataAccessFactory.CreateDataAccess();
        }

        /// <summary>
        /// Insert a piece of record in database.
        /// </summary>
        /// <param name="Department"></param>
        /// <returns></returns>
        public Response InsertDepartment(Department department)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "INSERT INTO [Department] ([DepartmentName],[Description],[DepartmentManagerId],[ParentDepartmentId]) VALUES (@DepartmentName,@Description,@DepartmentManagerId,@ParentDepartmentId)";
                QueryParameter[] list = new QueryParameter[4];
                list[0] = new QueryParameter("@DepartmentName", department.DepartmentName, DbType.String);
                list[1] = new QueryParameter("@Description", department.Description, DbType.String);
                list[2] = new QueryParameter("@DepartmentManagerId", department.DepartmentManagerId, DbType.Int32);
                list[3] = new QueryParameter("@ParentDepartmentId", department.ParentDepartmentId, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, list));
            }
            return response;
        }

        /// <summary>
        /// Update a piece of record in database.
        /// </summary>
        /// <param name="Department"></param>
        /// <returns></returns>
        public Response UpdateDepartment(Department department)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "UPDATE [Department] SET [DepartmentName]=@DepartmentName,[Description]=@Description,[DepartmentManagerId]=@DepartmentManagerId,[ParentDepartmentId]=@ParentDepartmentId WHERE [DepartmentId]=@DepartmentId";
                QueryParameter[] list = new QueryParameter[5];
                list[0] = new QueryParameter("@DepartmentName", department.DepartmentName, DbType.String);
                list[1] = new QueryParameter("@Description", department.Description, DbType.String);
                list[2] = new QueryParameter("@DepartmentManagerId", department.DepartmentManagerId, DbType.Int32);
                list[3] = new QueryParameter("@ParentDepartmentId", department.ParentDepartmentId, DbType.Int32);
                list[4] = new QueryParameter("@DepartmentId", department.DepartmentId, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, list));
            }
            return response;
        }

        /// <summary>
        /// Delete a piece of Department record in database.
        /// </summary>
        /// <param name="Department"></param>
        /// <returns></returns>
        public Response DeleteDepartment(int departmentid)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "DELETE FROM [Department] WHERE [DepartmentId]=@DepartmentId";
                QueryParameter p = new QueryParameter("@DepartmentId", departmentid, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, p));
            }
            return response;
        }

        /// <summary>
        /// Select All Departments
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllDepartments()
        {
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT d.DepartmentId,d.DepartmentName,d.Description, s.StaffName, t.DepartmentName from[Staff] s , [Department] d ,[Department] t where d.ParentDepartmentId=t.DepartmentId and d.DepartmentManagerId = s.StaffId";
                DataTable dt = _dataAccess.ExecuteSql(sql);
                return dt;

            }

        }

        /// <summary>
        /// Get managerId by manager name
        /// </summary>
        /// <param name="staffname"></param>
        /// <returns></returns>
        public int GetManagerId(string staffname)
        {
            _dataAccess.Open();
            string sql = "SELECT StaffId FROM Staff where StaffName=@staffname";
            QueryParameter p = new QueryParameter("@staffname", staffname, DbType.String);
            DataTable dt = _dataAccess.GetTable(sql, p);
            return Convert.ToInt32(dt.Rows[0][0].ToString());
        }

        /// <summary>
        /// Get parent departmentid by parent department name
        /// </summary>
        /// <param name="departmentname"></param>
        /// <returns></returns>
        public int GetParentId(string departmentname)
        {
            _dataAccess.Open();
            string sql = "SELECT ParentDepartmentId FROM Department where DepartmentName=@departmentname";
            QueryParameter p = new QueryParameter("@departmentname", departmentname, DbType.String);
            DataTable dt = _dataAccess.GetTable(sql, p);
            return Convert.ToInt32(dt.Rows[0][0].ToString());
        }

        /// <summary>
        /// Get all parent departments
        /// </summary>
        /// <param name="Department"></param>
        /// <returns></returns>
        public DataTable GetAllParentDepartment()
        {
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT DepartmentId,DepartmentName FROM Department";
                DataTable dt = _dataAccess.ExecuteSql(sql);
                return dt;
            }

        }

        /// <summary>
        /// Get departmentId by department name
        /// </summary>
        /// <param name="Department"></param>
        /// <returns></returns>
        public bool GetDepartmentByDepartmentName(string departmentname)
        {
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT DepartmentId FROM [Department] WHERE DepartmentName=@DepartmentName";
                QueryParameter p = new QueryParameter("@DepartmentName", departmentname, DbType.String);
                return _dataAccess.GetTable(sql, p).Rows.Count > 0 ? true : false;
            }
        }

        /// <summary>
        /// Gets the department id.
        /// </summary>
        /// <param name="departmentname">The departmentname.</param>
        /// <returns></returns>
        public int GetDepartmentId(string departmentname)
        {
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT DepartmentId FROM [Department] WHERE DepartmentName=@DepartmentName";
                QueryParameter p = new QueryParameter("@DepartmentName", departmentname, DbType.String);
                DataTable dt = _dataAccess.GetTable(sql, p);
                return Convert.ToInt32(dt.Rows[0][0].ToString());
            }
        }

        /// <summary>
        /// Get employeeId by departmentId
        /// </summary>
        /// <param name="departmentid"></param>
        /// <returns></returns>
        public bool GetEmployeeIdByDepartmentName(int departmentid)
        {
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT EmployeeId  FROM Department INNER JOIN Staff ON Department.DepartmentId = Staff.DepartmentId  WHERE Department.DepartmentId = @DepartmentId";
                QueryParameter p = new QueryParameter("@DepartmentId", departmentid, DbType.Int32);
                return _dataAccess.GetTable(sql, p).Rows.Count > 0 ? true : false;
            }
        }

        /// <summary>
        /// Get all manager names
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllManagerName()
        {
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT StaffId,StaffName FROM Staff ";
                DataTable dt = _dataAccess.ExecuteSql(sql);
                return dt;
            }
        }

        /// <summary>
        /// Get employeeId by employee name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool GetOneStaffId(string name)
        {
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT EmployeeId FROM Staff WHERE StaffName=@StaffName";
                QueryParameter p = new QueryParameter("@StaffName", name, DbType.String);
                return _dataAccess.GetTable(sql, p).Rows.Count > 0 ? true : false;
            }
        }

        #endregion
    }
}
