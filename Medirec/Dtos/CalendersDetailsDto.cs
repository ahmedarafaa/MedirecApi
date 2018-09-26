using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Dtos
{
    public class CalendersDetailsDto
    {
        [Key]
        public int CalendersDetailsId { get; set; }

        [Required]
        public int CalendersId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int EntityId { get; set; }

        public TimeSpan? TimeFrom { get; set; }
        public TimeSpan? TimeTo { get; set; }
        public string DayName { get; set; }

        public DateTime? Date { get; set; }

        public bool IsReserved { get; set; }

    }
}