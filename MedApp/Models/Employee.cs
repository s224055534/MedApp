using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedApp.Models
{
    public enum UserType
    {      
        Admin,
        Doctor,
        Patient
    }
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(60)]
        public string Surname { get; set; }
        [Required, DataType(DataType.Password), StringLength(15)]
        public string Password { get; set; }
        [Required, StringLength(30)]
        public string Username { get; set; }
        [Required, EmailAddress, DataType(DataType.EmailAddress), StringLength(50)]
        [Display(Name="Email Address")]
        public string Email { get; set; }
        [Required, StringLength(10)]
        public string Gender { get; set; }
        [Required, StringLength(30),Display(Name ="User Type")]
        public string UserType {  get; set; }
        public bool IsActive { get; set; }
    }
}
