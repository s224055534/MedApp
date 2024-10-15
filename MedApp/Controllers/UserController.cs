using MedApp.Data;
using MedApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ManagementContext _managementContext;

        public UserController(ManagementContext managementContext)
        {
            _managementContext = managementContext;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public string AddEmployee(Employee doctor)
        {
            string response = string.Empty;
            _managementContext.Employee.Add(doctor);
            _managementContext.SaveChanges();
            response = "Employee Successfully Added!";
            return response;
        }
        [HttpGet]
        [Route("GetEmployees")]
        public List<Employee> GetEmployees()
        {
            return _managementContext.Employee.ToList();
        }
        [HttpGet]
        [Route("GetEmployeeById")]
        public Employee GetEmployee(int id)
        {
            return _managementContext.Employee.Where(x => x.Id == id).FirstOrDefault();
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public string UpdateEmployee(Employee emp)
        {
            _managementContext.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _managementContext.SaveChanges();
            return "Employee Updated Successfully!";
        }
        [HttpDelete]
        public string DeleteEmployee(int id)
        {

            Employee emp = _managementContext.Employee.Where(x => x.Id == id).FirstOrDefault();
            if (emp != null)
            {
                _managementContext.Employee.Remove(emp);
                _managementContext.SaveChanges();
                return "Employee Successfully Deleted!";
            }
            else
            {
                return "Employee not Found.";
            }

        }

    }
}
