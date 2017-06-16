using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using DAL;
using System.Data;

namespace BLL
{
    public class StaffService
    {
        /// <summary>
        /// Updates the staff infor.
        /// </summary>
        /// <param name="staff">The staff.</param>
        public void UpdateStaffInfor(Staff staff)
        {
            new StaffRepository().UpdateStaff(staff);
        }

        /// <summary>
        /// Inserts the staff.
        /// </summary>
        /// <param name="staff">The staff.</param>
        /// <returns></returns>
        public Response InsertStaff(Staff staff)
        {
            return new StaffRepository().InsertStaff(staff);
        }

        /// <summary>
        /// Updates the staff.
        /// </summary>
        /// <param name="staff">The staff.</param>
        /// <returns></returns>
        public Response UpdateStaff(Staff staff)
        {
            return new StaffRepository().UpdateStaff(staff);
        }

        /// <summary>
        /// Deletes the staff.
        /// </summary>
        /// <param name="staff">The staff.</param>
        /// <returns></returns>
        public Response DeleteStaff(Staff staff)
        {
            return new StaffRepository().DeleteStaff(staff);
        }

        /// <summary>
        /// Gets all staffs.
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllStaffs()
        {
            return new StaffRepository().GetAllStaffs();
        }

        /// <summary>
        /// Gets the staff by staff id.
        /// </summary>
        /// <param name="staff">The staff.</param>
        /// <returns></returns>
        public Staff GetStaffByStaffId(Staff staff)
        {
            return new StaffRepository().GetStaffByStaffId(staff);
        }

        /// <summary>
        /// Gets the staff by employee id.
        /// </summary>
        /// <param name="staff">The staff.</param>
        /// <returns></returns>
        public Staff GetStaffByEmployeeId(Staff staff)
        {
            return new StaffRepository().GetStaffByEmployeeId(staff);
        }

        /// <summary>
        /// Gets the name of the staff by staff.
        /// </summary>
        /// <param name="staff">The staff.</param>
        /// <returns></returns>
        public Staff GetStaffByStaffName(Staff staff)
        {
            return new StaffRepository().GetStaffByStaffName(staff);
        }
    }
}
