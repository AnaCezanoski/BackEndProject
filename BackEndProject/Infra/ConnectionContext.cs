using BackEndProject.Domain.Model.Roles;
using BackEndProject.Domain.Model.Users;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.Infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

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
