using BankApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.DataAccess
{
    public class BalanceDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=BankDb;Uid=sa;Pwd=aysu123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         

            modelBuilder.Entity<Balance>()
                .HasOne(b => b.Currency)
                .WithMany()
                .HasForeignKey(b => b.CurrencyId);

        }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}

    
