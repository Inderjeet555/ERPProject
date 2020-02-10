using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using ERPProject.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace ERPProject.Mapping
{
    public class RoleMap: EntityTypeConfiguration<Roles>
    {
        public RoleMap()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(x => x.Id);
            Property(p => p.RoleName).HasMaxLength(50).IsRequired();
        }
    }
}