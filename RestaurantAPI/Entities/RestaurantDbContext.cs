using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        private string _connectionString =
            //"Server=(localdb)\\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=True;";
            "Server=XIAOMI-LAPTOP\\SQLEXPRESS;Database=RestaurantDb;Trusted_Connection=True;";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);
            
            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            
            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);
            
            modelBuilder.Entity<User>()
                .Property(u => u.Nationality)
                .IsRequired()
                .HasMaxLength(100);
            
            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(128);
            
            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);
            
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);
            
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Description)
                .HasMaxLength(100);
            
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Category)
                .HasMaxLength(25);
            
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.ContactEmail)
                .HasMaxLength(100);
            
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.ContactNumber)
                .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(25);
            
            modelBuilder.Entity<Dish>()
                .Property(d => d.Description)
                .HasMaxLength(100);

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);
            
            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);
            
            modelBuilder.Entity<Address>()
                .Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(25);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
