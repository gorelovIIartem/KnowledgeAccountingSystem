﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configurations
{
    public class SkillConfiguration:EntityTypeConfiguration<Skill>

    {
        public SkillConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(128);
            Property(p => p.Description).HasMaxLength(512);
        }
    }
}
