using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configurations
{
    public class ProjectConfiguration:EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            Property(x => x.Name).IsRequired().HasMaxLength(128);
            Property(x => x.StartDate).IsRequired().HasColumnType("date");
            Property(x => x.FinishDate).HasColumnType("date").IsOptional();
            Property(x => x.DeadLine).HasColumnType("date").IsRequired();
            Property(x => x.Description).IsRequired().HasMaxLength(512);
            Property(x => x.Reference).IsRequired();
            Property(x => x.Status).IsRequired();
            HasRequired(x => x.Programmer)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.ProgrammerId);
        }
    }
}
