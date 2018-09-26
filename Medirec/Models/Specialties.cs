using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Models
{
    public class Specialties
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

        [StringLength(225)]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreadtedDateTime { get; set; }

        [StringLength(225)]
        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ModifiedDateTime { get; set; }
    }
}