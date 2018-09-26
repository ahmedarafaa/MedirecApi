using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Models
{
    public class PaymentTypes
    {
        [Key]
        public int PaymentTypesId { get; set; }

        [Required]
        [StringLength(5)]
        public string PaymentTypesCode { get; set; }

        [Required]
        [StringLength(50)]
        public string NameAr { get; set; }

        [Required]
        [StringLength(50)]
        public string NameEn { get; set; }

        public virtual ICollection<DoctorsEntities> DoctorsEntities { get; set; }

    }
}