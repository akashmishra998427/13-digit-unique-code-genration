// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using VCQRU.Models;

namespace VCQRU.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UniqueCode> UniqueCodes { get; set; }
        public DbSet<Company> Companies { get; set; } // Existing DbSet for Company
        public DbSet<ProductRegistration> ProductRegistrations { get; set; } // New DbSet for ProductRegistration
        public object Products { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite key for uniqueness
            modelBuilder.Entity<UniqueCode>()
                .HasIndex(u => new { u.Code1, u.Code2 })
                .IsUnique();

            // Configure SeriesNumber as the primary key
            modelBuilder.Entity<UniqueCode>()
                .HasKey(u => u.SeriesNumber);

            // Configure primary key for Company
            modelBuilder.Entity<Company>()
                .HasKey(c => c.CompanyId);

            // Configure primary key and additional settings for ProductRegistration
            modelBuilder.Entity<ProductRegistration>()
                .HasKey(p => p.Pro_ID);

            // Additional configuration if needed (e.g., setting up indexes, constraints)
            modelBuilder.Entity<ProductRegistration>()
                .HasIndex(p => p.Label_Code)
                .IsUnique(); // Example: setting a unique index on Label_Code if applicable
        }
    }
}
