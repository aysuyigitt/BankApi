using BankApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace BankApi.DataAccess
{
	public class TransactionDbContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=BankDb;Uid=sa;Pwd=aysu123;");
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Transaction>()
		   .HasOne(x => x.SenderAccount)
			.WithMany()
			.HasForeignKey(z => z.SenderAccountNumber)
			.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Transaction>()
			 .HasOne(x => x.ReceiverAccount)
			 .WithMany()
			 .HasForeignKey(z => z.ReceiverAccountNumber)
			.OnDelete(DeleteBehavior.NoAction);
		}

		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<Account> Accounts { get; set; }
		 
	
		
}
	}
