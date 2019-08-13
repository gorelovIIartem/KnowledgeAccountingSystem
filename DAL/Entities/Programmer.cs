using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Programmer
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string WorkEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<ProgrammerSkill> ProgrammerSkills { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }


        public Programmer()
        {
            ProgrammerSkills = new List<ProgrammerSkill>();
            Projects = new List<Project>();
            Educations = new List<Education>();
            WorkExperiences = new List<WorkExperience>();
        }
    }
}
