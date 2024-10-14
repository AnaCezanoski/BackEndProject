﻿using BackEndProject.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.Infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "Server=localhost;" +
                "Port=3306;" +
                "Database=BACKENDPROJECT;" +
                "User=root;" +
                "Password=chowchow;",
                new MySqlServerVersion(new Version(8, 0, 23))
            );
        }
    }
}
