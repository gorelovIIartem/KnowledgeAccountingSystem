using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class ProjectModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        public string Reference { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        [Required]
        public DateTime DeadLine { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [MaxLength(512)]
        public string Description { get; set; }
        public string ProgrammerId { get; set; }
    }
}