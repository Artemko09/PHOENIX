using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PHOENIX.Data.Configuration;
using PHOENIX.Models;

namespace PHOENIX.Data
{
    // Наслідуємося від IdentityDbContext, щоб додати таблиці користувачів і ролей
    // <ApplicationUser, IdentityRole<int>, int> вказує, що ми використовуємо цілі числа для ID
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet для ApplicationUser тепер "живе" всередині Identity, 
        // але ви можете залишити цей рядок для зручного звернення (або змінити ім'я на Users)
        public DbSet<ApplicationUser> Sportsmen { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<RatingCategory> RatingCategories { get; set; } = null!;
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Це КРИТИЧНО важливо: викликати base.OnModelCreating спочатку, 
            // щоб Identity налаштувала свої внутрішні таблиці (ключі, індекси)
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            // Можна додати додаткові налаштування для ApplicationUser, якщо потрібно
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("Users"); // Назва таблиці в БД
            });
        }
    }
}