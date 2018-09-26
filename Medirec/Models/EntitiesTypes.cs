using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Models
{
    public class EntitiesTypes
    {
        [Key]
        public int EntitiesTypesId { get; set; }

        [Required]
        [StringLength(4)]
        public string EntitiesTypesCode { get; set; }

        [Required]
        public string NameAr { get; set; }

        [Required]
        public string NameEn { get; set; }

    }
}