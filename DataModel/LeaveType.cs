using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class LeaveType
    {
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; }

        public override string ToString()
        {
            return LeaveTypeName;
        }
    }
}
