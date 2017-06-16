using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using DataModel;

namespace BLL
{
    public class LeaveDetailsService
    {
        /// <summary>
        /// Chen chao
        /// </summary>
        /// <param name="UserId">The user id.</param>
        /// <returns></returns>
        public DataSet ObtaineDetails(int UserId)
        {
            LeaveDetailsRepository detail = new LeaveDetailsRepository();
            return detail.GetDetailsById(UserId);
        }

        /// <summary>
        /// get a range of leavedetails of certain staff----chenchao
        /// </summary>
        /// <param name="ld">The ld.</param>
        /// <returns></returns>
        public List<LeaveDetails> ObtainLeaveDetailsByStaffId(LeaveDetails ld)
        {
            return new LeaveDetailsRepository().GetLeaveDetailsByStaffId(ld);
        }

        /// <summary>
        /// Adds the new details.
        /// </summary>
        /// <param name="ld">The ld.</param>
        public void AddNewDetails(LeaveDetails ld)
        {
            new LeaveDetailsRepository().InsertLeaveDetails(ld);
        }

        /// <summary>
        /// Removes the details.
        /// </summary>
        /// <param name="ld">The ld.</param>
        public void RemoveDetails(LeaveDetails ld)
        {
            new LeaveDetailsRepository().DeleteLeaveDetails(ld);
        }
    }
}
