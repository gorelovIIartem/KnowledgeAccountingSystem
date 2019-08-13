using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using DAL.Configurations;

namespace DAL.EF
{
    public class KnowledgeAccountingSystemDBContext:IdentityDbContext
    {
        public KnowledgeAccountingSystemDBContext(string connectionString):base(connectionString)
        { }
        static KnowledgeAccountingSystemDBContext()
        {
            Database.SetInitializer(new KnowledgeAccountingSystemDBInitializer());
        }
        public DbSet<Programmer> Programmers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<ProgrammerSkill> ProgrammerSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProgrammerConfiguration());
            modelBuilder.Configurations.Add(new ProjectConfiguration());
            modelBuilder.Configurations.Add(new WorkExperienceConfiguration());
            modelBuilder.Configurations.Add(new EducationConfiguration());
            modelBuilder.Configurations.Add(new ProgrammerSkillConfiguration());
            modelBuilder.Configurations.Add(new SkillConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
