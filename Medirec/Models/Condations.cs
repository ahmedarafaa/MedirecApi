using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Models
{
    public class Condations
    {
        [Key]
        public int CondationsId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int UserId { get; set; }
    }
}