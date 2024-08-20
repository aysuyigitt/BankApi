using BankApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.DataAccess
{
    public class BranchDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=BankDb;Uid=sa;Pwd=aysu123;");

        }
        public DbSet<Branch> Branches { get; set; }

    }
}

    

