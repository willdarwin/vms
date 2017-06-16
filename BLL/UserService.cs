using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Drawing;
using DataModel;

namespace BLL
{
    public class UserService
    {
        /// <summary>
        /// Call the DAL layer to excute user login verification.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Response Authentication(User user)
        {
            //return new UserDataManager().Authentication(userName,password);
            Response r = new Response();
            User blluser = new User();
            user.Password = new DataEncryption().PasswordEncryption(user.Password);
            blluser = new UserRepository().GetUserByUserName(user);
            if (blluser != null && blluser.Password == user.Password)
            {
                //r.Message = "Welcome to Vacation Management System.";
            }
            else
            {
                r.Message = "Please check user name and password again.";
            }

            return r;
        }

        /// <summary>
        /// Call the DAL layer to update user login password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public Response ChangePassword(User user)
        {
            return new UserRepository().UpdateUser(user);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            return new UserRepository().GetAllUsers();
        }

        /// <summary>
        /// Inserts the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void InsertUser(User user)
        {
            new UserRepository().InsertUser(user);
        }

        /// <summary>
        /// Sets the initial password.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="userName">Name of the user.</param>
        public void SetInitialPassword(int userId, string userName)
        {
            new UserRepository().SetInitialPassword(userId, userName);
        }

        /// <summary>
        /// Gets the name of the user id by user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public int GetUserIdByUserName(string username)
        {
            return new UserRepository().GetUserIdByUserName(username);
        }

    }
}
