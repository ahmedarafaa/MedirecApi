using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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

        public TimeSpan? TimeFrom { get; set; }
        public TimeSpan? TimeTo { get; set; }
        public string DayName { get; set; }

        public DateTime? Date { get; set; }

        public bool IsReserved { get; set; }
    }
}