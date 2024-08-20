﻿using BankApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserFinder.DataAccess
{
    public class UserDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=BankDb;Uid=sa;Pwd=aysu123;");
        }
        public DbSet<User> Users { get; set; }
    }
}