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
    public class StaffRepository
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

        private const string StaffId = "StaffId";
        private const string EmployeeId = "EmployeeId";
        private const string StaffName = "StaffName";
        private const string ChineseName = "ChineseName";
        private const string Title = "Title";
        private const string OnboardDate = "OnboardDate";
        private const string Email = "Email";
        private const string PhoneNumber = "PhoneNumber";
        private const string Gender = "Gender";
        private const string Married = "Married";
        private const string StatusId = "StatusId";
        private const string DepartmentId = "DepartmentId";
        private const string Location = "Location";
        private const string EmployeeCategory = "EmployeeCategory";
        private const string ContractTerm = "ContractTerm";
        private const string LastyearRemains = "LastyearRemains";
        private const string StartWork = "StartWork";

        #endregion

        #region public method

        /// <summary>
        /// Create a data access for interact with database
        /// </summary>
        public StaffRepository()
        {
            _dataAccess = DataAccessFactory.CreateDataAccess();
        }

        /// <summary>
        /// Insert a piece of record in database.
        /// </summary>
        /// <param name="Staff"></param>
        /// <returns></returns>
        public Response InsertStaff(Staff staff)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "INSERT INTO [Staff] ([EmployeeId],[StaffName],[ChineseName],[Title],[OnboardDate],[Email],[PhoneNumber],"
                    + "[Gender],[Married],[StatusId],[Title],[EmployeeCategory],[DepartmentId],[ContractTerm],[LastyearRemains],[StartWork]) "
                    + " VALUES (@EmployeeId,@StaffName,@ChineseName,@Title,@OnboardDate,@Email,@PhoneNumber,@Gender,@Married,"
                    + "@StatusId,@Location,@EmployeeCategory,@DepartmentId,@ContractTerm,@LastyearRemains,@StartWork)";
                QueryParameter[] list = new QueryParameter[16];
                list[0] = new QueryParameter("@EmployeeId", staff.EmployeeId, DbType.String);
                list[1] = new QueryParameter("@StaffName", staff.StaffName, DbType.String);
                list[2] = new QueryParameter("@ChineseName", staff.ChineseName, DbType.String);
                list[3] = new QueryParameter("@Title", staff.Title, DbType.String);
                list[4] = new QueryParameter("@OnboardDate", staff.OnboardDate, DbType.DateTime);
                list[5] = new QueryParameter("@Email", staff.Email, DbType.String);
                list[6] = new QueryParameter("@PhoneNumber", staff.PhoneNumber, DbType.String);
                list[7] = new QueryParameter("@Gender", staff.Gender, DbType.Int32);
                list[8] = new QueryParameter("@Married", staff.Married, DbType.Boolean);
                list[9] = new QueryParameter("@StatusId", staff.StatusId, DbType.Int32);
                list[10] = new QueryParameter("@Location", staff.Location, DbType.String);
                list[11] = new QueryParameter("@EmployeeCategory", staff.EmployeeCategory, DbType.String);
                list[12] = new QueryParameter("@DepartmentId", staff.DepartmentId, DbType.Int32);
                list[13] = new QueryParameter("@ContractTerm", staff.ContractTerm, DbType.String);
                list[14] = new QueryParameter("@LastyearRemains", staff.LastyearRemains, DbType.String);
                list[15] = new QueryParameter("@StartWork", staff.StartWork, DbType.DateTime);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, list));
            }
            return response;
        }

        /// <summary>
        /// Update a piece of record in database.
        /// </summary>
        /// <param name="Staff"></param>
        /// <returns></returns>
        public Response UpdateStaff(Staff staff)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "UPDATE [Staff] SET [EmployeeId]=@EmployeeId,[StaffName]=@StaffName,[ChineseName]=@ChineseName,"
                    + "[Title]=@Title,[OnboardDate]=@OnboardDate,[Email]=@Email,[PhoneNumber]=@PhoneNumber,[Gender]=@Gender,"
                    + "[Married]=@Married,[StatusId]=@StatusId,[Location]=@Location,[EmployeeCategory]=@EmployeeCategory,"
                    + "[DepartmentId]=@DepartmentId,[ContractTerm]=@ContractTerm,[LastyearRemains]=@LastyearRemains,[StartWork]=@StartWork"
                    + " WHERE [StaffId]=@StaffId";
                QueryParameter[] list = new QueryParameter[17];
                list[0] = new QueryParameter("@EmployeeId", staff.EmployeeId, DbType.String);
                list[1] = new QueryParameter("@StaffName", staff.StaffName, DbType.String);
                list[2] = new QueryParameter("@ChineseName", staff.ChineseName, DbType.String);
                list[3] = new QueryParameter("@Title", staff.Title, DbType.String);
                list[4] = new QueryParameter("@OnboardDate", staff.OnboardDate, DbType.DateTime);
                list[5] = new QueryParameter("@Email", staff.Email, DbType.String);
                list[6] = new QueryParameter("@PhoneNumber", staff.PhoneNumber, DbType.String);
                list[7] = new QueryParameter("@Gender", staff.Gender, DbType.Int32);
                list[8] = new QueryParameter("@Married", staff.Married, DbType.Boolean);
                list[9] = new QueryParameter("@StatusId", staff.StatusId, DbType.Int32);
                list[10] = new QueryParameter("@Location", staff.Location, DbType.String);
                list[11] = new QueryParameter("@EmployeeCategory", staff.EmployeeCategory, DbType.String);
                list[12] = new QueryParameter("@DepartmentId", staff.DepartmentId, DbType.Int32);
                list[13] = new QueryParameter("@ContractTerm", staff.ContractTerm, DbType.String);
                list[14] = new QueryParameter("@LastyearRemains", staff.LastyearRemains, DbType.Int32);
                list[15] = new QueryParameter("@StartWork", staff.StartWork, DbType.DateTime);
                list[16] = new QueryParameter("@StaffId", staff.StaffId, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, list));
            }
            return response;
        }

        /// <summary>
        /// Delete a piece of Staff record in database.
        /// </summary>
        /// <param name="Staff"></param>
        /// <returns></returns>
        public Response DeleteStaff(Staff staff)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "DELETE FROM [Staff] WHERE [StaffId]=@StaffId";
                QueryParameter p = new QueryParameter("@StaffId", staff.StaffId, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, p));
            }
            return response;
        }

        /// <summary>
        /// Select All records
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllStaffs()
        {
            List<Staff> staffList = new List<Staff>();
            DataSet ds = new DataSet();
            try
            {
                using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
                {
                    _dataAccess.Open();
                    string sql = "select [Staff].[StaffId],[Staff].[EmployeeId],[Staff].[StaffName],[Staff].[ChineseName],[Staff].[Title],[Staff].[OnboardDate],[Staff].[Email],[Staff].[PhoneNumber],[Staff].[Gender],[Staff].[Married],[Status].[StatusName],[Staff].[Location],[Department].[DepartmentName],[Staff].[EmployeeCategory],[Staff].[ContractTerm],[Staff].[LastyearRemains],[Staff].[StartWork] from ([Staff] left join [Department] on [Department].DepartmentId=[Staff].DepartmentId )left join [Status] on [Staff].StatusId=[Status].[StatusId] where [Staff].StatusId <>  -1 order by [Staff].[StaffId]";
                    ds = _dataAccess.GetSet(sql, "Staff");
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    Staff staff = new Staff()
                    //    {
                    //        StaffId = Convert.ToInt32(dr[StaffId]),
                    //        EmployeeId = dr[EmployeeId].ToString(),
                    //        StaffName = dr[StaffName].ToString(),
                    //        ChineseName = dr[ChineseName].ToString(),
                    //        Title = dr[Title].ToString(),
                    //        OnboardDate = Convert.ToDateTime(dr[OnboardDate]),
                    //        Email = dr[Email].ToString(),
                    //        PhoneNumber = dr[PhoneNumber].ToString(),
                    //        Gender = Convert.ToInt32(dr[Gender]),
                    //        Married = Convert.ToBoolean(dr[Married]),
                    //        StatusId = Convert.ToInt32(dr[StatusId]),
                    //        Location = dr[Location].ToString(),
                    //        EmployeeCategory = dr[EmployeeCategory].ToString(),
                    //        DepartmentId = Convert.ToInt32(dr[DepartmentId]),
                    //        ContractTerm = dr[ContractTerm].ToString(),
                    //    };
                    //    staffList.Add(staff);
                    //}
                }
            }
            catch (Exception ex)
            {
                return null;
            } return ds;
        }

        /// <summary>
        /// Select a Staff list by Staff id
        /// </summary>
        /// <param name="Staff"></param>
        /// <returns></returns>
        public Staff GetStaffByStaffId(Staff s)
        {
            Staff staff = new Staff();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [Staff] WHERE StaffId=@StaffId";
                QueryParameter p = new QueryParameter("StaffId", s.StaffId, DbType.Int32);
                DataTable dt = _dataAccess.GetTable(sql, p);
                foreach (DataRow dr in dt.Rows)
                {
                    staff.StaffId = Convert.ToInt32(dr[StaffId]);
                    staff.EmployeeId = dr[EmployeeId].ToString();
                    staff.StaffName = dr[StaffName].ToString();
                    staff.ChineseName = dr[ChineseName].ToString();
                    staff.Title = dr[Title].ToString();
                    staff.OnboardDate = Convert.ToDateTime(dr[OnboardDate]);
                    staff.Email = dr[Email].ToString();
                    staff.PhoneNumber = dr[PhoneNumber].ToString();
                    staff.Gender = Convert.ToInt32(dr[Gender]);
                    staff.Married = Convert.ToBoolean(dr[Married]);
                    staff.StatusId = Convert.ToInt32(dr[StatusId]);
                    staff.Location = dr[Location].ToString();
                    staff.EmployeeCategory = dr[EmployeeCategory].ToString();
                    staff.DepartmentId = Convert.ToInt32(dr[DepartmentId]);
                    staff.ContractTerm = dr[ContractTerm].ToString();
                    staff.LastyearRemains = Convert.ToSingle(dr[LastyearRemains]);
                    staff.StartWork = Convert.ToDateTime(dr[StartWork]);
                }
                CommonFunction commonFunction = new CommonFunction();
                staff = commonFunction.ChangeLastyearRemain(staff);
            }
            return staff;
        }

        /// <summary>
        /// Select a Staff list by Staff name
        /// </summary>
        /// <param name="Staff"></param>
        /// <returns></returns>
        public Staff GetStaffByEmployeeId(Staff s)
        {
            Staff staff = new Staff();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [Staff] WHERE EmployeeId=@EmployeeId";
                QueryParameter p = new QueryParameter("EmployeeId", s.EmployeeId, DbType.String);
                DataTable dt = _dataAccess.GetTable(sql, p);
                foreach (DataRow dr in dt.Rows)
                {
                    staff.StaffId = Convert.ToInt32(dr[StaffId]);
                    staff.EmployeeId = dr[EmployeeId].ToString();
                    staff.StaffName = dr[StaffName].ToString();
                    staff.ChineseName = dr[ChineseName].ToString();
                    staff.Title = dr[Title].ToString();
                    staff.OnboardDate = Convert.ToDateTime(dr[OnboardDate]);
                    staff.Email = dr[Email].ToString();
                    staff.PhoneNumber = dr[PhoneNumber].ToString();
                    staff.Gender = Convert.ToInt32(dr[Gender]);
                    staff.Married = Convert.ToBoolean(dr[Married]);
                    staff.StatusId = Convert.ToInt32(dr[StatusId]);
                    staff.Location = dr[Location].ToString();
                    staff.EmployeeCategory = dr[EmployeeCategory].ToString();
                    staff.DepartmentId = Convert.ToInt32(dr[DepartmentId]);
                    staff.ContractTerm = dr[ContractTerm].ToString();
                    staff.LastyearRemains = Convert.ToSingle(dr[LastyearRemains]);
                    staff.StartWork = Convert.ToDateTime(dr[StartWork]);
                }
                CommonFunction commonFunction = new CommonFunction();
                staff = commonFunction.ChangeLastyearRemain(staff);
            }
            return staff;
        }

        /// <summary>
        /// Select a Staff list by Staff name
        /// </summary>
        /// <param name="Staff"></param>
        /// <returns></returns>
        public Staff GetStaffByStaffName(Staff s)
        {
            Staff staff = new Staff();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [Staff] WHERE StaffName=@StaffName";
                QueryParameter p = new QueryParameter("StaffName", s.StaffName, DbType.String);
                DataTable dt = _dataAccess.GetTable(sql, p);
                foreach (DataRow dr in dt.Rows)
                {
                    staff.StaffId = Convert.ToInt32(dr[StaffId]);
                    staff.EmployeeId = dr[EmployeeId].ToString();
                    staff.StaffName = dr[StaffName].ToString();
                    staff.ChineseName = dr[ChineseName].ToString();
                    staff.Title = dr[Title].ToString();
                    staff.OnboardDate = Convert.ToDateTime(dr[OnboardDate]);
                    staff.Email = dr[Email].ToString();
                    staff.PhoneNumber = dr[PhoneNumber].ToString();
                    staff.Gender = Convert.ToInt32(dr[Gender]);
                    staff.Married = Convert.ToBoolean(dr[Married]);
                    staff.StatusId = Convert.ToInt32(dr[StatusId]);
                    staff.Location = dr[Location].ToString();
                    staff.EmployeeCategory = dr[EmployeeCategory].ToString();
                    staff.DepartmentId = Convert.ToInt32(dr[DepartmentId]);
                    staff.ContractTerm = dr[ContractTerm].ToString();
                    staff.LastyearRemains = Convert.ToSingle(dr[LastyearRemains]);
                    staff.StartWork = Convert.ToDateTime(dr[StartWork]);
                }
                CommonFunction commonFunction = new CommonFunction();
                staff = commonFunction.ChangeLastyearRemain(staff);
            }
            return staff;
        }

        #endregion
    }
}



