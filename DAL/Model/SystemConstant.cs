using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Model
{
    public class SystemConstant
    {
        public int SystemConstantId { get; set; }
        public string ConstantName { get; set; }
        public string ConstantValue { get; set; }
        public string Description { get; set; }
    }
}
