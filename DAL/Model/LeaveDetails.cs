using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Model
{
    public class LeaveDetails
    {
        public int LeaveDetailsId { get; set; }
        public int StaffId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Duration { get; set; }
        public string Remark { get; set; }
        public LeaveType Leavings { get; set; }
    }
}
