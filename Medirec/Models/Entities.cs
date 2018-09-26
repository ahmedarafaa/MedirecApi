using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Models
{
    public class Entities
    {
        [Key]
        public int EntityId { get; set; }

        [Required]
        [StringLength(4)]
        public string EntityCode { get; set; }

        [Required]
        public string NameAr { get; set; }

        [Required]
        public string NameEn { get; set; }

        [Required]
        public int CountryId { get; set; }
        public Countries Countries { get; set; }

        [Required]
        public int CityId { get; set; }
        public Cities Cities { get; set; }

        [Required]
        public int AreaId { get; set; }
        public Areas Areas { get; set; }

        [Required]
        [StringLength(1000)]
        public string AddressEn { get; set; }

        [Required]
        [StringLength(1000)]
        public string AddressAr { get; set; }

        public int EntitiesTypesId { get; set; }
        public EntitiesTypes GetEntitiesTypes { get; set; }

        public virtual ICollection<DoctorsEntities> DoctorsEntities { get; set; }
    }
}