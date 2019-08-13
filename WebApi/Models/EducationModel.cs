using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class EducationModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }
        public DateTime? CloseDate { get; set; }
        [Required]
        [MaxLength(512)]
        public string Notes { get; set; }
        [Required]
        public string ProgrammerId { get; set; }
    }
}