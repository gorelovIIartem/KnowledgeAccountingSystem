using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class ProgrammerSkillModel
    {
        [Required]
        public int SkillId { get; set; }
        [Required]
        public int ProgrammerSkillLevel { get; set; }
        public string ProgrammerId { get; set; }
    }
}