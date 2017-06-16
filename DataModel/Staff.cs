using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string EmployeeId { get; set; }
        public string StaffName { get; set; }
        public string ChineseName { get; set; }
        public string Title { get; set; }
        public DateTime OnboardDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Gender { get; set; }
        public bool Married { get; set; }
        public int StatusId { get; set; }
        public string Location { get; set; }
        public int DepartmentId { get; set; }
        public string EmployeeCategory { get; set; }
        public string ContractTerm { get; set; }
        public Single LastyearRemains { get; set; }
        public DateTime StartWork { get; set; }
        public virtual Status status { get; set; }
        public virtual Department department { get; set; }
    }
}
