using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Dtos
{
    public class VaccinesDto
    {
        [Key]
        public int VaccineId { get; set; }

        public int VaccineCode { get; set; }

        [StringLength(1000)]
        public string Name { get; set; }
    }
}