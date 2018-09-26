using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Models
{
    public class Resources
    {
        [Key]
        public int ResourcesId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        [StringLength(1500)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreadtedDateTime { get; set; }

        public int UserId { get; set; }
    }
}