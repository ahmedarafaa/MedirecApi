using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Dtos
{
    public class PatientsDto
    {
        [Key]
        public int PatientId { get; set; }

        public int UserId { get; set; }

        [StringLength(4)]
        public string PatientCode { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public int AreaId { get; set; }

        public int InsuranceId { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 11)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(1500)]
        public string ImageURL { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }


    }
}