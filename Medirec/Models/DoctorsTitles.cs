using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Models
{
    public class DoctorsTitles
    {
        [Key]
        public int DoctorsTitlesId { get; set; }

        public string DoctorsTitlesCode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Arabic Name")]
        public string NameAr { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "English Name")]
        public string NameEn { get; set; }

        public virtual ICollection<DoctorsDoctorsTitles> DoctorsDoctorsTitles { get; set; }

    }
}