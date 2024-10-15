using System.ComponentModel.DataAnnotations;

namespace MedApp.Models
{
    public class Visit
    {
        [Key]
        public int VisitId { get; set; }
        [Required, DataType(DataType.Date)]
        public DateOnly Date { get; set; }
        [Required, DataType(DataType.Time)]
        public TimeOnly Time { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}
