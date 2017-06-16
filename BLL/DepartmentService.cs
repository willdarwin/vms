using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DataModel;
using System.Data;

namespace BLL
{
    public class DepartmentService
    {
        /// <summary>
        /// Gets the departments.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepartments()
        {
            return new DepartmentRepository().GetAllDepartments();
        }

        /// <summary>
        /// Adds the department.
        /// </summary>
        /// <param name="department">The department.</param>
        public void AddDepartment(Department department)
        {
            new DepartmentRepository().InsertDepartment(department);
        }

        /// <summary>
        /// Updates the department.
        /// </summary>
        /// <param name="department">The department.</param>
        public void UpdateDepartment(Department department)
        {
            new DepartmentRepository().UpdateDepartment(department);
        }

        /// <summary>
        /// Deletes the department.
        /// </summary>
        /// <param name="departmentid">The departmentid.</param>
        public void DeleteDepartment(int departmentid)
        {
            new DepartmentRepository().DeleteDepartment(departmentid);
        }

        /// <summary>
        /// Searches the employee id by department.
        /// </summary>
        /// <param name="departmentid">The departmentid.</param>
        /// <returns></returns>
        public bool SearchEmployeeIdByDepartment(int departmentid)
        {
            return new DepartmentRepository().GetEmployeeIdByDepartmentName(departmentid);
        }

        /// <summary>
        /// Searches the name of the department by department.
        /// </summary>
        /// <param name="departmentname">The departmentname.</param>
        /// <returns></returns>
        public bool SearchDepartmentByDepartmentName(string departmentname)
        {
            return new DepartmentRepository().GetDepartmentByDepartmentName(departmentname);
        }

        /// <summary>
        /// Searches the one staff id.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public bool SearchOneStaffId(string name)
        {
            return new DepartmentRepository().GetOneStaffId(name);
        }

        /// <summary>
        /// Alls the department manager.
        /// </summary>
        /// <returns></returns>
        public DataTable AllDepartmentManager()
        {
            return new DepartmentRepository().GetAllManagerName();
        }

        /// <summary>
        /// Alls the parent department.
        /// </summary>
        /// <returns></returns>
        public DataTable AllParentDepartment()
        {
            return new DepartmentRepository().GetAllParentDepartment();
        }

        /// <summary>
        /// Gets the manager id.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public int GetManagerId(string name)
        {
            return new DepartmentRepository().GetManagerId(name);
        }

        /// <summary>
        /// Gets the parent id.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public int GetParentId(string name)
        {
            return new DepartmentRepository().GetParentId(name);
        }

        /// <summary>
        /// Gets the department id.
        /// </summary>
        /// <param name="departmentname">The departmentname.</param>
        /// <returns></returns>
        public int GetDepartmentId(string departmentname)
        {
            return new DepartmentRepository().GetDepartmentId(departmentname);

        }

    }
}
