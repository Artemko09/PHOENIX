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
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "SeedData", "categories.json");

            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                var categories = JsonSerializer.Deserialize<List<Category>>(jsonData);

                if (categories != null)
                {
                    builder.HasData(categories);
                }
            }
        }
    }
}
