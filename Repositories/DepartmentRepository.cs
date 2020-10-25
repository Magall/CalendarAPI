using System.Security.Cryptography;
using System.Net.Mime;
using System.Collections.Generic;
using Calendar.Models;
using Calendar.Repositories.IRepository;
using Calendar.Data;
using System.Linq;

namespace Calendar.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDBContext _db;


        public DepartmentRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public bool CreateDepartment(Department department)
        {
            _db.Departments.Add(department);
            return Save();
        }

        public bool DeleteDepartment(Department department)
        {
            _db.Departments.Remove(department);
            return Save();
        }

        public bool DepartmentExists(string name)
        {
            bool res = _db.Departments.Any(dep => dep.Name==name);
            return res;
        }

        public Department GetDepartment(string name)
        {
           return _db.Departments.FirstOrDefault(dep => dep.Name == name);
        }

        public Department GetDepartmentByName(string name)
        {
            return _db.Departments.FirstOrDefault(dep => dep.Name == name);
        }

        public IEnumerable<Department> GetDepartments()
        {
            var deps = _db.Departments.OrderBy(dep=> dep.Name).ToList();
            return deps;
        }

        public bool Save()
        {
            try
            { 
             return _db.SaveChanges() >= 0 ? true : false;
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                return false;
            }
        }
    }
}