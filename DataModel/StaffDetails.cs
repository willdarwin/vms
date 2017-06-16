using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class StaffDetails
    {
        public int StaffId { get; set; }
        public string totalAnnualLeave { get; set; }
        public string usedAnnualLeave { get; set; }
        public string annualLeaveBalance { get; set; }
        public string totalSickLeave { get; set; }
        public string usedSickLeave { get; set; }
        public string lastyearUsedSickLeave { get; set; }
        public string sickLeaveBalance { get; set; }
        public string usednopayLeave { get; set; }
        public string usedmarriageLeave { get; set; }
        public string usedmaternity { get; set; }
        public string usedpaternity { get; set; }
        public string usedcompassionate { get; set; }
        public string usedothers { get; set; }
    }
}
