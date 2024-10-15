using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedApp.Models
{
    public class Notes
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Diagnostics { get; set; }
        [Required, StringLength(255)]
        public string Treatment { get; set; }
        [ForeignKey("Visit")]
        public int VisitId { get; set; }
        public Visit Visit { get; set; }


    }
}
