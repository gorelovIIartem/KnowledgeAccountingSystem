using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configurations
{
    public class WorkExperienceConfiguration:EntityTypeConfiguration<WorkExperience>
    {
        public WorkExperienceConfiguration()
        {
            Property(p => p.Company).IsRequired().HasMaxLength(128);
            Property(p => p.Position).IsRequired().HasMaxLength(128);
            Property(p => p.EntryDate).IsRequired().HasColumnType("date");
            Property(p => p.CloseDate).IsRequired().HasColumnType("date");
            Property(p => p.Notes).HasMaxLength(512);
            HasRequired(p => p.Programmer)
                .WithMany(p => p.WorkExperiences)
                .HasForeignKey(p => p.ProgrammerId);
        }
    }
}
