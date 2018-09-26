using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Dtos
{
    public class HumanBodyDto
    {
        [Key]
        public int HumanBodyId { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }
    }
}