using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using ERPProject.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;
using ERPProject.Areas.UserManagement.Models;

namespace ERPProject.Mapping.UserManagement
{
    public class RoleCapabilityMap: EntityTypeConfiguration<RoleCapabilities>
    {
        public RoleCapabilityMap()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(x => x.Role).WithMany().HasForeignKey(x => x.RoleId).WillCascadeOnDelete(false);
            HasRequired(p => p.CapaBilities).WithMany().HasForeignKey(p => p.CapabilityId).WillCascadeOnDelete(false);

        }
    }
}