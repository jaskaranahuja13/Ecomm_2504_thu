using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm_2504_thu.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name ="Postal Code")]
        public string PostalCode { get; set; }
        [Display(Name="Company")]
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
