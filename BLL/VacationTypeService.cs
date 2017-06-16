using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using DAL;

namespace BLL
{
    public class VacationTypeService
    {
        /// <summary>
        /// Obtains all types.
        /// </summary>
        /// <returns></returns>
        public List<LeaveType> ObtainAllTypes()
        {
            return new LeaveTypeRepository().GetAllLeaveTypes();
        }

        /// <summary>
        /// Obtains the vacation types.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public List<LeaveType> ObtainVacationTypes(string n)
        {
            LeaveTypeRepository vacationType = new LeaveTypeRepository();
            return vacationType.GetLeavings(n);
        }

    }
}
