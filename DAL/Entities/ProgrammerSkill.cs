using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ProgrammerSkill
    {
        public string ProgrammerId { get; set; }
        public int SkillId { get; set; }
        public virtual Programmer Programmer { get; set; }
        public virtual Skill Skill { get; set; }
        public int ProgrammerSkillLevel { get; set; }
    }
}
