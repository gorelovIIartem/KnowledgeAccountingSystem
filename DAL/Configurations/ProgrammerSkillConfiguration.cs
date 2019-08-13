using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity.ModelConfiguration;


namespace DAL.Configurations
{
    public class ProgrammerSkillConfiguration:EntityTypeConfiguration<ProgrammerSkill>
    {
        public ProgrammerSkillConfiguration()
        {
            Property(p => p.ProgrammerSkillLevel).IsRequired();
            HasKey(p => new { p.ProgrammerId, p.SkillId });
            HasRequired(t => t.Skill)
                .WithMany(t => t.ProgrammerSkills)
                .HasForeignKey(t => t.SkillId);
            HasRequired(t => t.Programmer)
                .WithMany(t => t.ProgrammerSkills)
                .HasForeignKey(t => t.ProgrammerId);
        }
    }
}
