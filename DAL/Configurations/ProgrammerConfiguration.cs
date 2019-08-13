using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity.ModelConfiguration;
namespace DAL.Configurations
{
    public class ProgrammerConfiguration:EntityTypeConfiguration<Programmer>
    {
        public ProgrammerConfiguration()
        {
            Property(p => p.FullName).IsRequired().HasMaxLength(64);
            Property(p => p.WorkEmail).IsRequired().HasMaxLength(64);
            Property(p => p.Address).HasMaxLength(64);
           // Property(p => p.GitHub).HasMaxLength(64);
            HasRequired(c => c.ApplicationUser)
                .WithOptional(c => c.Programmer);
        }
    }
}
