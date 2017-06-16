using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DataModel;
using System.Data;

namespace BLL
{
    public class SystemConstantService
    {
        /// <summary>
        /// Gets the system constant.
        /// </summary>
        /// <returns></returns>
        public List<SystemConstant> GetSystemConstant()
        {
            return new SystemConstantRepository().GetAllSystemConstants();
        }

        /// <summary>
        /// Updates the system constant.
        /// </summary>
        /// <param name="sc">The sc.</param>
        public void UpdateSystemConstant(SystemConstant sc)
        {          
            new SystemConstantRepository().UpdateSystemConstant(sc);
        }
    }
}
