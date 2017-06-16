using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;
using DataModel;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class UserRepository
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

        private const string userId = "UserId";
        private const string userName = "UserName";
        private const string password = "Password";

        #endregion

        #region public method
        /// <summary>
        /// Create a data access for interact with database
        /// </summary>
        public UserRepository()
        {
            _dataAccess = DataAccessFactory.CreateDataAccess();
        }

        /// <summary>
        /// Insert a piece of record in database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Response InsertUser(User user)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "INSERT INTO [User] ([UserName],[Password]) VALUES (@UserName,@Password)";
                QueryParameter[] list = new QueryParameter[2];
                list[0] = new QueryParameter("@UserName", user.UserName, DbType.String);
                list[1] = new QueryParameter("@Password", new DataEncryption().PasswordEncryption(user.Password), DbType.String);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, list));
            }
            return response;
        }

        /// <summary>
        /// Update a piece of record in database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Response UpdateUser(User user)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "UPDATE [User] SET [UserName]=@UserName,[Password]=@Password WHERE [UserId]=@UserId";
                QueryParameter[] list = new QueryParameter[3];
                list[0] = new QueryParameter("@UserName", user.UserName, DbType.String);
                list[1] = new QueryParameter("@Password", new DataEncryption().PasswordEncryption(user.Password), DbType.String);
                list[2] = new QueryParameter("@UserId", user.UserId, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, list));
            }
            return response;
        }

        /// <summary>
        /// Delete a piece of user record in database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Response DeleteUser(User user)
        {
            Response response = new Response();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "DELETE FROM [User] WHERE [UserId]=@UserId";
                QueryParameter p = new QueryParameter("@UserId", user.UserId, DbType.Int32);
                response.IsFailed = !Convert.ToBoolean(_dataAccess.ExecuteNonQuery(sql, p));
            }
            return response;
        }

        /// <summary>
        /// Select All records
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            List<User> userList = new List<User>();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [User] ";
                DataTable dt = _dataAccess.ExecuteSql(sql);
                int a = dt.Columns.Count;
                foreach (DataRow dr in dt.Rows)
                {
                    User user = new User()
                    {
                        UserId = Convert.ToInt32(dr[userId]),
                        UserName = dr[userName].ToString(),
                        Password = dr[password].ToString()
                    };
                    userList.Add(user);
                }
                _dataAccess.Close();
            }
            return userList;
        }

        /// <summary>
        /// Select a user list by user id
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User GetUserByUserId(User u)
        {
            User user = new User();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [User] WHERE UserId=@UserId";
                QueryParameter p = new QueryParameter("UserId", u.UserId, DbType.Int32);
                DataTable dt = _dataAccess.GetTable(sql, p);
                foreach (DataRow dr in dt.Rows)
                {
                    user.UserId = Convert.ToInt32(dr[userId]);
                    user.UserName = dr[userName].ToString();
                    user.Password = dr[password].ToString();
                }
            }
            return user;
        }

        /// <summary>
        /// Select a user list by user name
        ///</summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User GetUserByUserName(User u)
        {
            User user = new User();
            using (_dataAccess.Connection = new OleDbConnection(ConnectionString))
            {
                _dataAccess.Open();
                string sql = "SELECT * FROM [User] WHERE UserName=@UserName";
                QueryParameter p = new QueryParameter("UserName", u.UserName, DbType.String);
                DataTable dt = _dataAccess.GetTable(sql, p);
                foreach (DataRow dr in dt.Rows)
                {
                    user.UserId = Convert.ToInt32(dr[userId]);
                    user.UserName = dr[userName].ToString();
                    user.Password = dr[password].ToString();
                }
            }
            return user;
        }


        public void SetInitialPassword(int userId, string userName)
        {

            using (OleDbConnection con = new OleDbConnection(ConnectionString))
            {
                con.Open();

                string cmdString = "Update [User] set [Password]=@Password where [UserId]=@UserId";
                OleDbCommand cmd = new OleDbCommand(cmdString, con);

                cmd.Parameters.AddWithValue("@Password", new DataEncryption().PasswordEncryption(userName));
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                con.Close();
            }
        }

        public int GetUserIdByUserName(string username)
        {
            _dataAccess.Open();
            string sql = "SELECT UserId FROM [User] where UserName=@username";
            QueryParameter p = new QueryParameter("@username", username, DbType.String);
            DataTable dt = _dataAccess.GetTable(sql, p);
            return Convert.ToInt32(dt.Rows[0][0].ToString());
        }

        #endregion
    }
}
