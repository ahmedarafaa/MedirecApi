using System;
using System.ComponentModel.DataAnnotations;

namespace Medirec.Models
{
    public class CalendersDetails
    {
        [Key]
        public int CalendersDetailsId { get; set; }

        [Required]
        public int CalendersId { get; set; }
        public Calenders Calenders { get; set; }

        [Required]
        public int DoctorId { get; set; }
        public Doctors Doctors { get; set; }

        [Required]
        public int EntityId { get; set; }
        public Entities Entities { get; set; }

        public DateTime? TimeFrom { get; set; }
        public DateTime? TimeTo { get; set; }
        public string DayName { get; set; }

        public DateTime? Date { get; set; }

        public bool IsReserved { get; set; }
    }
}