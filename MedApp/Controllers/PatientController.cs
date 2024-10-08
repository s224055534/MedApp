using MedApp.Data;
using MedApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ManagementContext _managementContext;

        public PatientController(ManagementContext managementContext)
        {
            _managementContext = managementContext;
        }

        [HttpPost]
        [Route("AddPatient")]
        public string AddPatient(Patient patient)
        {
            string response = string.Empty;
            _managementContext.Patient.Add(patient);
            _managementContext.SaveChanges();
            response = "Patient Successfully Added!";
            return response;
        }
        [HttpGet]
        [Route("GetPatients")]
        public List<Patient> GetPatients() 
        {
            return _managementContext.Patient.ToList();
        }
        [HttpGet]
        [Route("GetPatientById")]
        public Patient GetPatient(int id)
        {
            return _managementContext.Patient.Where(x => x.Id == id).FirstOrDefault();
        }
        [HttpPut]
        [Route("UpdatePatient")]
        public string UpdatePatient(Patient patient)
        { 
            _managementContext.Entry(patient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _managementContext.SaveChanges();
            return "Patient Updated Successfully!";
        }
        [HttpDelete]
        public string DeletePatient(int id)
        {

            Patient patient = _managementContext.Patient.Where(x => x.Id == id).FirstOrDefault();
            if (patient != null)
            {
                _managementContext.Patient.Remove(patient);
                _managementContext.SaveChanges();
                return "Patients Successfully Deleted!";
            }
            else 
            { 
                return "Patient not Found."; 
            }
            
        }
    }
}
