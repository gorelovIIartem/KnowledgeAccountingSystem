using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class ProgrammerModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(128)]
        public string WorkEmail { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(128)]
        public string Adress { get; set; }
       

    }
}