using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEFcrud.Data
{
    public class EmployeeService
    {

        private readonly ApplicationDbContext _db;

        public EmployeeService(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get all employees
        public List<EmployeeInfo> GetEmployees()
        {
            var empList = _db.Employees.ToList();
            return empList;
        }

        //Insert employee info
        public string Create(EmployeeInfo objEmp)
        {
            _db.Employees.Add(objEmp);
            _db.SaveChanges();
            return "Succesfuly added Employee";
        }

        //Get employee by ID
        public EmployeeInfo GetEmployeeByID(int id)
        {
            EmployeeInfo employee = _db.Employees.FirstOrDefault(s=>s.EmployeeID == id);
            return employee;
        }

        //Update employee
        public string UpdateEmployee(EmployeeInfo objEmp)
        {
            _db.Employees.Update(objEmp);
            _db.SaveChanges();
            return "Succesfuly updated Employee";
        }

        //Delete employee
        public string DeleteEmployee(EmployeeInfo objEmp)
        {
            _db.Employees.Remove(objEmp);
            _db.SaveChanges();
            return "Succesfuly removed Employee";
        }
    }
}
