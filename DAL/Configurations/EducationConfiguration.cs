using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configurations
{
    public class EducationConfiguration:EntityTypeConfiguration<Education>
    {
        public EducationConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(128);
            Property(p => p.EntryDate).IsRequired().HasColumnType("date");
            Property(p => p.CloseDate).IsOptional().HasColumnType("date");
            Property(p => p.Notes).HasMaxLength(512);
            HasRequired(x => x.Programmer)
                .WithMany(x => x.Educations)
                .HasForeignKey(x => x.ProgrammerId);

        }
    }
}
