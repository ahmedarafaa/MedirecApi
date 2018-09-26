using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Models
{
    public class SubSpecialities
    {
        [Key]
        public int SubSpecialitiesId { get; set; }

        [StringLength(5)]
        public string SubSpecialitiesCode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Arabic Name")]
        public string NameAr { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "English Name")]
        public string NameEn { get; set; }

        public int SpecialtyId { get; set; }
        public Specialties Specialties { get; set; }

        public virtual ICollection<DoctorsSubSpecialities> DoctorsSubSpecialities { get; set; }
    }
}