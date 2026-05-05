using Azure;
using PHOENIX.Data;
using PHOENIX.Interface;
using PHOENIX.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PHOENIX.Services
{
    public class SportsmanValidationService : ISportsmanValidation
    {
        private readonly ApplicationDbContext _db;

        public SportsmanValidationService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Category?> FindCategoryAsync(int age, double weight, Gender gender)
        {
            return await _db.Categories
                .FirstOrDefaultAsync(c =>
                    gender == c.Gender &&
                    age >= c.MinAge && age <= c.MaxAge &&
                    weight >= c.MinWeight && weight <= c.MaxWeight);
        }

        public async Task<List<string>> ValidateSportsmanAsync(ApplicationUser s)
        {
            var errors = new List<string>();

            if (s.BirthDate > DateTime.Today)
                errors.Add("Дата народження не може бути у майбутньому.");

            var suitableCategory = await FindCategoryAsync(s.Age, s.Weight, s.Gender);

            if (suitableCategory == null)
            {
                errors.Add("Для ваших параметрів (вік/вага/стать) не знайдено жодної офіційної категорії.");
            }
            else if (s.CategoryId != 0 && s.CategoryId != suitableCategory.Id)
            {
                errors.Add($"Поточна категорія не відповідає вашим даним. Вам підходить: {suitableCategory.Name}");
            }

            return errors;
        }
    }
}
