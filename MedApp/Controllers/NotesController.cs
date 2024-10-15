using MedApp.Data;
using MedApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ManagementContext _managementContext;

        public NotesController(ManagementContext managementContext)
        {
            _managementContext = managementContext;
        }

        [HttpPost]
        [Route("AddNote")]
        public string AddNote(Notes note)
        {
            string response = string.Empty;
            _managementContext.Notes.Add(note);
            _managementContext.SaveChanges();
            response = "Note Successfully Added!";
            return response;
        }
        [HttpGet]
        [Route("GetNotes")]
        public List<Notes> GetNotes()
        {
            return _managementContext.Notes.ToList();
        }
        [HttpGet]
        [Route("GetNoteById")]
        public Notes GetNote(int id)
        {
            return _managementContext.Notes.Where(x => x.Id == id).FirstOrDefault();
        }
        [HttpPut]
        [Route("UpdateNote")]
        public string UpdateNote(Notes note)
        {
            _managementContext.Entry(note).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _managementContext.SaveChanges();
            return "Note Updated Successfully!";
        }
        [HttpDelete]
        public string DeleteNote(int id)
        {

            Notes note = _managementContext.Notes.Where(x => x.Id == id).FirstOrDefault();
            if (note != null)
            {
                _managementContext.Notes.Remove(note);
                _managementContext.SaveChanges();
                return "Note Successfully Deleted!";
            }
            else
            {
                return "Note not Found.";
            }

        }
    }
}
