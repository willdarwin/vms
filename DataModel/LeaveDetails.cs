using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class LeaveDetails
    {
        public int LeaveDetailsId { get; set; }
        public int StaffId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Single Duration { get; set; }
        public string Remark { get; set; }
        public virtual LeaveType Leavings { get; set; }
        public virtual Staff StaffInfor { get; set; }


    }
}
