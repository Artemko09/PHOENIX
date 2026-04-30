using Microsoft.EntityFrameworkCore;
using PHOENIX.Data.Configuration;
using PHOENIX.Models;

namespace PHOENIX.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Sportsman> Sportsmen { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<RatingCategory> RatingCategories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
