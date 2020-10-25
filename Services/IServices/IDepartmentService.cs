using System.Collections.Generic;
using Calendar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Services.IServices
{
    public interface IDepartmentService
    {
        ObjectResult CreateDepartment(Department dep);
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentByName(string name);
        ObjectResult DeleteDepartment(string  name);
    }
}