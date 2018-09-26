using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Dtos
{
    public class ImmunizationsDto
    {
        [Key]
        public int ImmunizationId { get; set; }

        public int VaccineId { get; set; }

        [Display(Name = "Date Given")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateGiven { get; set; }

        [StringLength(25)]
        public string AdministratedBy { get; set; }

        [Display(Name = "Next Does Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime NextDoesDate { get; set; }

        public int UserId { get; set; }
    }
}