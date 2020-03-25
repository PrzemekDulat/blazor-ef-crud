using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEFcrud.Data
{
    public class EmployeeService
    {

        private IConfiguration Configuration;
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        public EmployeeService(IConfiguration configuration)
        {
            Configuration = configuration;
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConntection"));
        }

        //Get all employees
        public List<EmployeeInfo> GetEmployees()
        {
            using (var dbContext = new ApplicationDbContext(optionsBuilder.Options))
            {
                var empList = dbContext.Employees.ToList();
                return empList;
            }
        }

        //Insert employee info
        public string Create(EmployeeInfo objEmp)
        {
            using (var dbContext = new ApplicationDbContext(optionsBuilder.Options))
            {
                dbContext.Employees.Add(objEmp);
                dbContext.SaveChanges();
                return "Succesfuly added Employee";
            }
        }

        //Get employee by ID
        public EmployeeInfo GetEmployeeByID(int id)
        {
            using (var dbContext = new ApplicationDbContext(optionsBuilder.Options))
            {
                EmployeeInfo employee = dbContext.Employees.FirstOrDefault(s => s.EmployeeID == id);
                return employee;
            }
        }

        //Update employee
        public string UpdateEmployee(EmployeeInfo objEmp)
        {
            using (var dbContext = new ApplicationDbContext(optionsBuilder.Options))
            {
                dbContext.Employees.Update(objEmp);
                dbContext.SaveChanges();
                return "Succesfuly updated Employee";
            }
        }

        //Delete employee
        public string DeleteEmployee(EmployeeInfo objEmp)
        {
            using (var dbContext = new ApplicationDbContext(optionsBuilder.Options))
            {
                dbContext.Employees.Remove(objEmp);
                dbContext.SaveChanges();
                return "Succesfuly removed Employee";
            }
        }
    }
}
