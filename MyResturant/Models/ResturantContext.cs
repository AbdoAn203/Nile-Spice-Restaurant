using Microsoft.EntityFrameworkCore;

namespace MyResturant.Models
{
    public class ResturantContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= AHDULRAHMAN;DataBase= Resturant; Trusted_Connection= True; TrustServerCertificate = True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
