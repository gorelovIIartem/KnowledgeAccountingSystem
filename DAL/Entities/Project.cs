using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public DateTime DeadLine { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public string ProgrammerId { get; set; }
        public virtual Programmer Programmer { get; set; }

    }
}
