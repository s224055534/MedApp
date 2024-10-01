using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedApp.Models
{
    public enum UserType
    {
        Admin,
        Doctor,
        Patient,
        Assistant
    }
    public class User:IdentityUser
    {
        [Required, StringLength(50)]
        public string Username { get; set; }
        [Required, StringLength(50)]
        [NotMapped]
        public string Password { get; set; }
        [Compare("Password"), Display(Name ="Confirm Password")]
        public string PasswordConfirmation { get; set; }
        [Required, StringLength(30),Display(Name ="User Type")]
        public string UserType {  get; set; }
        public bool IsActive { get; set; }
    }
}
