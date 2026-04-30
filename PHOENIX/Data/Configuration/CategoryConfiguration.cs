using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PHOENIX.Models;
using System.Text.Json;

namespace PHOENIX.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // 1. Вказуємо шлях до файлу
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "SeedData", "categories.json");

            if (File.Exists(filePath))
            {
                // 2. Читаємо та десеріалізуємо JSON
                var jsonData = File.ReadAllText(filePath);
                var categories = JsonSerializer.Deserialize<List<Category>>(jsonData);

                if (categories != null)
                {
                    // 3. Передаємо дані в Entity Framework
                    builder.HasData(categories);
                }
            }
        }
    }
}
