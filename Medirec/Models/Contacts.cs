using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medirec.Models
{
    public class Contacts
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(10)]
        [Display(Name = "Type of Relation")]
        public string TypeOfRelation { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 11)]
        [Phone]
        [Display(Name = "Phone Number 1")]
        public string PhoneNumber01 { get; set; }

        [StringLength(11, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 11)]
        [Phone]
        [Display(Name = "Phone Number 2")]
        public string PhoneNumber02 { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public int UserId { get; set; }


    }
}