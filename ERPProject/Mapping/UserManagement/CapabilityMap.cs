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
    public class CapabilityMap: EntityTypeConfiguration<Capabilities>
    {
        public CapabilityMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(p => p.MenuItem).WithMany().HasForeignKey(p => p.MenuItemId).WillCascadeOnDelete(false);            
        }
    }
}