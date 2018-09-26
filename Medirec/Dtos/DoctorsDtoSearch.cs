using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Dtos
{
    public class DoctorsDtoSearch
    {

        [Key]
        public int DoctorId { get; set; }

        [Required]
        [StringLength(5)]
        public string DoctorCode { get; set; }

        [Required]
        [StringLength(100)]
        public string NameAr { get; set; }

        [Required]
        [StringLength(100)]
        public string NameEn { get; set; }

        [Required]
        public int SpecialtyId { get; set; }

        //[Required]
        //public int CountryId { get; set; }

        //[Required]
        //public int CityId { get; set; }

        //[Required]
        //public int AreaId { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        public double TickerPrice { get; set; }

        [StringLength(100)]
        public string AboutDoctorShortDescription { get; set; }

        [StringLength(1000)]
        public string AboutDoctorLongDescription { get; set; }

        [StringLength(100)]
        public string AboutDoctorShortDescriptionAr { get; set; }

        [StringLength(1000)]
        public string AboutDoctorLongDescriptionAr { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Register Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RegisterDate { get; set; }

        [Required]
        [StringLength(225)]
        public string SearchName { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 11)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [StringLength(1500)]
        public string ImageURL { get; set; }

    }
}