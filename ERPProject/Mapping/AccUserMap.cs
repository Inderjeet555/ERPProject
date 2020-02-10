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
    public class AccUserMap: EntityTypeConfiguration<AccUser>
    {
        public AccUserMap()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.UserName).HasMaxLength(50);
            Property(c => c.Password).HasMaxLength(50);
            HasMany(x => x.UserRoles).WithRequired(x => x.User).HasForeignKey(z => z.UserId);
            Property(x => x.UnitId).IsOptional();
            
        }

    }

    public class AccUserRoleMap: EntityTypeConfiguration<AccUserRoles>
    {
        public AccUserRoleMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(x => x.Role).WithMany().HasForeignKey(x => x.RoleId).WillCascadeOnDelete(false);
        }


    }
}