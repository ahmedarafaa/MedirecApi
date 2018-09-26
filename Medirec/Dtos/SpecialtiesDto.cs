using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Dtos
{
    public class SpecialtiesDto
    {
        [Key]
        public int SpecialtyId { get; set; }

        [StringLength(4)]
        public string SpecialtyCode { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Arabic Name")]
        public string NameAr { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "English Name")]
        public string NameEn { get; set; }
    }
}