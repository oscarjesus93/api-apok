using Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Api.Config
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }     
        
        public DbSet<BrandsCarsEntity> BrandsCars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BrandsCarsEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn();

                entity.Property(e => e.Date_register)
                        .HasDefaultValueSql("NOW()");                
            });

            modelBuilder.Entity<BrandsCarsEntity>().HasData(
                    new BrandsCarsEntity { Id = 1, Description = "Ford" },
                    new BrandsCarsEntity { Id = 2, Description = "Toyota" },
                    new BrandsCarsEntity { Id = 3, Description = "Hiunday" },
                    new BrandsCarsEntity { Id = 4, Description = "Mazda" },
                    new BrandsCarsEntity { Id = 5, Description = "Kia" },
                    new BrandsCarsEntity { Id = 6, Description = "Chevrolet"  }
                );
        }
    }
}
