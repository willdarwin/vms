using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Model
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string EmployeeId { get; set; }
        public string StaffName { get; set; }
        public DateTime OnboardDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Married { get; set; }
        public int StatusId { get; set; }
        public int DepartmentId { get; set; }
        public virtual Status status { get; set; }
        public virtual Department department { get; set; }

    }
}
