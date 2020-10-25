using System.Collections.Generic;
using Calendar.Models;
using Calendar.Repositories.IRepository;
using Calendar.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _depRepo;
        public DepartmentService(IDepartmentRepository depRepo)
        {
            _depRepo = depRepo;
        }

        public ObjectResult CreateDepartment(Department dep)
        {
            if (_depRepo.CreateDepartment(dep))
            {
                return new ObjectResult("Department succesfuly created") { StatusCode = 200 };
            }
            else
            {
                return new ObjectResult("Error while creating Department") { StatusCode = 500 };
            }
        }

        public ObjectResult DeleteDepartment(string name)
        {
            if (_depRepo.DepartmentExists(name))
            {
                var dep = _depRepo.GetDepartmentByName(name);
                if(_depRepo.DeleteDepartment(dep)){
                    return new ObjectResult("Department Excluded"){StatusCode=200};
                }
                else{
                    return new ObjectResult("Error while deleting department"){StatusCode=500};
                }
            }
            else
            {
                return new ObjectResult("Department does not exists") { StatusCode = 404 };
            }
        }

        public Department GetDepartmentByName(string name)
        {
            return _depRepo.GetDepartmentByName(name);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _depRepo.GetDepartments();
        }
    }
}