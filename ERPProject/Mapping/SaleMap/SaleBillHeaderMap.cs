using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using ERPProject.Areas.Sale.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;
using ERPProject.Areas.Sale;
using ERPProject.Models;

namespace ERPProject.Mapping.SaleMap
{
    public class SaleBillHeaderMap : EntityTypeConfiguration<SaleBillHeader>
    {
        public SaleBillHeaderMap()
        {
            HasKey(x => x.SaleBillHeaderid);
            Property(x => x.SaleBillHeaderid).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(x => x.SaleBillDetails).WithRequired(p => p.SaleBillHeaders).HasForeignKey(x => x.SaleBillHeaderid).WillCascadeOnDelete(false); ;
            HasRequired(x => x.Account).WithMany().HasForeignKey(p => p.PartyAccountId).WillCascadeOnDelete(false);
            HasRequired(x => x.VoucherHeader).WithMany().HasForeignKey(x => x.VoucherHeaderId).WillCascadeOnDelete(false);
            HasRequired(x => x.Godown).WithMany().HasForeignKey(p => p.GodownId).WillCascadeOnDelete(false);
        }
    }

    public class SaleBillDetailMap : EntityTypeConfiguration<SaleBillDetail>
    {
        public SaleBillDetailMap()
        {
            HasKey(x => x.SaleBillDetailId);
            Property(x => x.SaleBillDetailId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(x => x.Item).WithMany().HasForeignKey(p => p.ItemId).WillCascadeOnDelete(false);
            HasRequired(x => x.Taxclass).WithMany().HasForeignKey(p => p.TaxClassId).WillCascadeOnDelete(false);
            HasRequired(x => x.PackingSize).WithMany().HasForeignKey(p => p.PackingSizeId).WillCascadeOnDelete(false);
            Property(x => x.Description).IsOptional();
            Property(x => x.CGSTPer).IsOptional();
            Property(x => x.CGSTAmount).IsOptional();
            Property(x => x.IGSTAmount).IsOptional();
            Property(x => x.IGSTPer).IsOptional();
            Property(x => x.SGSTAmount).IsOptional();
            Property(x => x.SGSTPer).IsOptional();
        }
    }

    public class VoucherHeaderMap : EntityTypeConfiguration<VoucherHeaders>
    {
        public VoucherHeaderMap()
        {
            HasKey(x => x.VoucherHeaderID);
            Property(x => x.VoucherHeaderID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(x => x.VoucherDetails).WithRequired(x => x.VoucherHeader).HasForeignKey(p => p.VoucherHeaderID).WillCascadeOnDelete(true);
            Property(x => x.VoucherAccountID).IsOptional();
            HasOptional(x => x.Account).WithMany().HasForeignKey(p => p.VoucherAccountID).WillCascadeOnDelete(false);
            
        }
    }

    public class VoucherDetailMap : EntityTypeConfiguration<VoucherDetail>
    {
        public VoucherDetailMap()
        {
            HasKey(x => x.VoucherDetailID);
            Property(x => x.VoucherDetailID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(x => x.Account).WithMany().HasForeignKey(p => p.AccountID).WillCascadeOnDelete(false);
            HasOptional(x => x.Account).WithMany().HasForeignKey(p => p.SAccountID).WillCascadeOnDelete(false);
            

        }
    }

    public class AccountMap : EntityTypeConfiguration<Accounts>
    {
        public AccountMap()
        {
            HasKey(x => x.AccountId);
            Property(x => x.AccountId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);   

        }
    }

    public class GodownMap: EntityTypeConfiguration<Godowns>
    {
        public GodownMap()
        {
            HasKey(x => x.GodownId);
            Property(x => x.GodownId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

     public class ItemMap : EntityTypeConfiguration<Items>
        {
            public ItemMap()
            {
                HasKey(x => x.ItemId);
                Property(x => x.ItemId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                HasRequired(x => x.Account).WithMany().HasForeignKey(p => p.SaleAccountId).WillCascadeOnDelete(false);
                HasRequired(x => x.Account).WithMany().HasForeignKey(p => p.PurchaseAccountId).WillCascadeOnDelete(false);

            }
        }

     public class PaclingSizeMap : EntityTypeConfiguration<PackingSizes>
     {
         public PaclingSizeMap()
         {
             HasKey(x => x.PackingSizeId);
             Property(x => x.PackingSizeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         }
     }

     public class AccountingYearMap : EntityTypeConfiguration<AccountingYears>
     {
         public AccountingYearMap()
         {
             HasKey(x => x.AccountingYearId);
             Property(x => x.AccountingYearId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

         }
     }

     public class TaxClassMap : EntityTypeConfiguration<TaxClass>
     {
         public TaxClassMap()
         {
             HasKey(x => x.TaxId);
             Property(x => x.TaxId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);            

         }
     }
}