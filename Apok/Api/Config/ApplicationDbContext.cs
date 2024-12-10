using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Config
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }     
        
        public DbSet<BrandsCars> BrandsCars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BrandsCars>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn();
            });

            modelBuilder.Entity<BrandsCars>().HasData(
                    new BrandsCars { Id = 1, Description = "Ford" },
                    new BrandsCars { Id = 2, Description = "Toyota" },
                    new BrandsCars { Id = 3, Description = "Hiunday" },
                    new BrandsCars { Id = 4, Description = "Mazda" },
                    new BrandsCars { Id = 5, Description = "Kia" },
                    new BrandsCars { Id = 6, Description = "Chevrolet"  }
                );
        }
    }
}
