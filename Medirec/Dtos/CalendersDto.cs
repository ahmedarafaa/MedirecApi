using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medirec.Dtos
{
    public class CalendersDto
    {
        [Key]
        public int CalendersId { get; set; }

        [Index("IX_Calenders", 1, IsUnique = true)]
        public TimeSpan? TimeFrom { get; set; }

        [Index("IX_Calenders", 2, IsUnique = true)]
        public TimeSpan? TimeTo { get; set; }

        [Required]
        [StringLength(10)]
        [Index("IX_Calenders", 3, IsUnique = true)]
        public string DayName { get; set; }

        [Index("IX_Calenders", 4, IsUnique = true)]
        public int GenerateEveryXMin { get; set; }

        [Index("IX_Calenders", 5, IsUnique = true)]
        public int DoctorId { get; set; }

        [Index("IX_Calenders", 6, IsUnique = true)]
        public int EntityId { get; set; }
    }
}