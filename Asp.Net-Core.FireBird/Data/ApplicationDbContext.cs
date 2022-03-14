using System;
using System.Linq;
using Asp.Net_Core.FireBird.Data.Entities;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Asp.Net_Core.FireBird.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().ToTable("CUSTOMER");
            modelBuilder.Entity<Customer>().HasKey(p => p.CUSTOMER_ID);
            modelBuilder.Entity<Customer>().Property(p => p.CUSTOMER_ID).HasColumnName("CUSTOMER_ID");
            modelBuilder.Entity<Customer>().Property(p => p.NAME).HasColumnName("NAME");
            modelBuilder.Entity<Customer>().Property(p => p.ADDRESS).HasColumnName("ADDRESS");
            modelBuilder.Entity<Customer>().Property(p => p.ZIPCODE).HasColumnName("ZIPCODE");
            modelBuilder.Entity<Customer>().Property(p => p.PHONE).HasColumnName("PHONE");
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseFirebird(ConStr);

                //optionsBuilder.UseFirebird(ConStr, null);
            }
        }
        private string ConStr
        {
            get
            {
                return @"datasource=localhost;database=C:\examples.FDB;user=SYSDBA;password=masterkey";
            }
        }
    }
}

//Scaffold-DbContext: Bir veritabanı varlık türleri için DbContext kod üretir.
//Scaffold-DbContext "datasource=localhost;database=C:\examples.FDB;user=SYSDBA;password=masterkey" FirebirdSql.EntityFrameworkCore.Firebird -OutputDir Models