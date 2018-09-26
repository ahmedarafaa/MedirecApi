using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medirec.Models
{
    public class DoctorsSubSpecialities
    {
        [Key]
        [Column(Order = 1)]
        public int DoctorId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int SubSpecialitiesId { get; set; }

        public virtual Doctors Doctors { get; set; }
        public virtual SubSpecialities SubSpecialities { get; set; }
    }
}