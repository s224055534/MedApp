using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedApp.Models
{
    public class Doctor
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(60)]
        public string Surname { get; set; }
        [Required, StringLength(10)]
        public string Gender { get; set; }
        [Required, StringLength(150), Display(Name = "Home Address")]
        public string Address { get; set; }
        [Required, StringLength(75), DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(12), DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNo { get; set; }
        
        
    }
}
