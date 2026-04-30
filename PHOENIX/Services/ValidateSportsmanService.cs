using Azure;
using PHOENIX.Data;
using PHOENIX.Models;
using System.ComponentModel.DataAnnotations;

namespace PHOENIX.Services
{
    public interface ISportsmanValidationService
    {
        List<string> ValidateSportsman(Sportsman sportsman);
    }

    public class SportsmanValidationService : ISportsmanValidationService
    {
        private readonly ApplicationDbContext _db;

        public SportsmanValidationService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<string> ValidateSportsman(Sportsman s)
        {
            var errors = new List<string>();
            var category = _db.Categories.Find(s.CategoryId);

            if (s.BirthDate > DateTime.Today)
                errors.Add("Дата народження не може бути у майбутньому.");

            if (category != null)
            {
                if (s.Gender != category.Gender)
                    errors.Add("Стать спортсмена не відповідає цій категорії.");

                if (s.Age < category.MinAge || s.Age > category.MaxAge)
                    errors.Add($"Вік має бути від {category.MinAge} до {category.MaxAge}.");

                if (s.Weight < category.MinWeight || s.Weight > category.MaxWeight)
                    errors.Add($"Вага має бути від {category.MinWeight} до {category.MaxWeight} кг.");
            }

            return errors;
        }
    }
}
