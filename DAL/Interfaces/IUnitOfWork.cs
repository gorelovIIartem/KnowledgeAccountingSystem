using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Identity;

namespace DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Programmer, string> Programmers { get; }
        IRepository<Project, int> Projects { get; }
        IRepository<WorkExperience, int> WorkExperiences { get; }
        IRepository<Education, int> Educations { get; }
        IRepository<Skill, int> Skills { get; }
        IProgrammerSkillRepository ProgrammerSkills { get; }
        void Save();
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
