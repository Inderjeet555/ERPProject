using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ERPProject.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using ERPProject.Mapping;
using ERPProject.Mapping.UserManagement;
using ERPProject.Areas.UserManagement.Models;
using ERPProject.Areas.Sale.Models;
using ERPProject.Areas.Sale;
using ERPProject.Mapping.SaleMap;


namespace ERPProject.Infrastructure
{
    public class ERPProjectDataContext : DbContext
    {
        public ERPProjectDataContext()
            : base("ERPSysConnection")
        {          

        }

        //User Data
        public DbSet<AccUser> AccUsers { get; set; }
        public DbSet<Roles> AccRoles { get; set; }
        public DbSet<AccUserRoles> AccUserRoles { get; set; }
        public DbSet<MenuItems> MenuItem { get; set; }

        //Sale Bill Map
        public DbSet<SaleBillHeader> SaleBillHeaders { get; set; }
        public DbSet<SaleBillDetail> SaleBillDetails { get; set; }
        public DbSet<VoucherHeaders> VoucherHeader { get; set; }
        public DbSet<VoucherDetail> VoucherDetails { get; set; }
        public DbSet<Accounts> Account { get; set; }
        public DbSet<Items> Item { get; set; }
        public DbSet<PackingSizes> PackingSize { get; set; }
        public DbSet<Godowns> Godown { get; set; }
        public DbSet<AccountingYears> AccountingYear { get; set; }
        public DbSet<TaxClass> Taxclass { get; set; }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new AccUserMap());
            modelBuilder.Configurations.Add(new AccUserRoleMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new CapabilityMap());
            modelBuilder.Configurations.Add(new RoleCapabilityMap());
            modelBuilder.Configurations.Add(new MenuItemMap());
            //Sale Bill Map

            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new SaleBillHeaderMap());
            modelBuilder.Configurations.Add(new SaleBillDetailMap());
            modelBuilder.Configurations.Add(new VoucherHeaderMap());
            modelBuilder.Configurations.Add(new VoucherDetailMap());
            modelBuilder.Configurations.Add(new AccountingYearMap());
            modelBuilder.Configurations.Add(new GodownMap());
            modelBuilder.Configurations.Add(new TaxClassMap());
            modelBuilder.Configurations.Add(new PaclingSizeMap());



        }
    }

   

}