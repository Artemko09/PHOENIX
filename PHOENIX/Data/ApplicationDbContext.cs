using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PHOENIX.Data.Configuration;
using PHOENIX.Models;

namespace PHOENIX.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> Sportsmen { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<News> News { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("Users");
            });
        }
    }
}