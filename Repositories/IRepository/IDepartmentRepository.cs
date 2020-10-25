using System.Collections.Generic;
using Calendar.Models;

namespace Calendar.Repositories.IRepository
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartment(string name);
        Department GetDepartmentByName(string name);
        bool CreateDepartment(Department department);
        bool DeleteDepartment(Department department);
        bool DepartmentExists(string name);
        bool Save();
    }
}