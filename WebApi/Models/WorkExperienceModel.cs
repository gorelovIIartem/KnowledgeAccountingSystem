using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebApi.Models
{
    public class WorkExperienceModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Company { get; set; }
        [Required]
        [MaxLength(128)]
        public string Position { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }
        [Required]
        public DateTime CloseDate { get; set; }
        [MaxLength(512)]
        public string Notes { get; set; }
        public string ProgrammerId { get; set; }
    }
}