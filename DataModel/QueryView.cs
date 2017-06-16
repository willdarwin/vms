using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class QueryView
    {
        public string EmployeeId { get; set; }
        public string StaffName { get; set; }
        public string LeaveTypeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Duration { get; set; }
        public string Remark { get; set; }

        public QueryView(string employeeId, string staffName, string leaveTypeName, DateTime startDate, DateTime endDate, float duration, string remark)
        {
            EmployeeId = employeeId;
            StaffName = staffName;
            LeaveTypeName = leaveTypeName;
            StartDate = startDate;
            EndDate = endDate;
            Duration = duration;
            Remark = remark;
        }

        public QueryView(string employeeId, string staffName, string leaveTypeName, DateTime startDate, DateTime endDate, float duration)
        {
            EmployeeId = employeeId;
            StaffName = staffName;
            LeaveTypeName = leaveTypeName;
            StartDate = startDate;
            EndDate = endDate;
            Duration = duration;
        }
    }
}
