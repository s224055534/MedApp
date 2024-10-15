using MedApp.Data;
using MedApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly ManagementContext _managementContext;

        public VisitController(ManagementContext managementContext)
        {
            _managementContext = managementContext;
        }

        [HttpPost]
        [Route("AddVisit")]
        public string AddEmployee(Visit visit)
        {
            string response = string.Empty;
            _managementContext.Visit.Add(visit);
            _managementContext.SaveChanges();
            response = "Visit Successfully Added!";
            return response;
        }
        [HttpGet]
        [Route("GetVisits")]
        public List<Visit> GetEmployees()
        {
            return _managementContext.Visit.ToList();
        }
        [HttpGet]
        [Route("GetVisitById")]
        public Visit GetEmployee(int id)
        {
            return _managementContext.Visit.Where(x => x.VisitId == id).FirstOrDefault();
        }
        [HttpPut]
        [Route("UpdateVisit")]
        public string UpdateVisit(Visit v)
        {
            _managementContext.Entry(v).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _managementContext.SaveChanges();
            return "Employee Updated Successfully!";
        }
        [HttpDelete]
        public string DeleteVisit(int id)
        {

            Visit v = _managementContext.Visit.Where(x => x.VisitId == id).FirstOrDefault();
            if (v != null)
            {
                _managementContext.Visit.Remove(v);
                _managementContext.SaveChanges();
                return "Visit Successfully Deleted!";
            }
            else
            {
                return "Visit not Found.";
            }

        }
    }
}
