using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medirec.Models
{
    public class DoctorsEntities
    {
        [Key]
        [ForeignKey("Doctors")]
        [Column(Order = 1)]
        public int DoctorId { get; set; }

        [Key]
        [ForeignKey("Entities")]
        [Column(Order = 2)]
        public int EntityId { get; set; }

        [Key]
        [ForeignKey("PaymentTypes")]
        [Column(Order = 3)]
        public int PaymentTypesId { get; set; }

        public int CalenderTypeId { get; set; }
        public int WaitingTime { get; set; }
        public int TicketPrice { get; set; }

        public virtual Doctors Doctors { get; set; }
        public virtual Entities Entities { get; set; }
        public virtual PaymentTypes PaymentTypes { get; set; }
    }
}