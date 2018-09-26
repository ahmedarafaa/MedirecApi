using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Dtos
{
    public class MedicationsDto
    {
        [Key]
        public int MedicationsId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int UserId { get; set; }
    }
}