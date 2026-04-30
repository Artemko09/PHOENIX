using PHOENIX.Data;
using System.ComponentModel.DataAnnotations;

namespace PHOENIX.Models
{
    public class Sportsman
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 25 characters.")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯіїєІЇЄ' ]+$", ErrorMessage = "Ім'я може містити лише літери.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        public DateTime BirthDate { get; set; }

        public int Age => DateTime.Today.Year - BirthDate.Year;
        
        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }
        
        [Required(ErrorMessage = "Weight is required.")]
        [Range(1, 100, ErrorMessage = "Weight must be between 1 and 100.")]
        public double Weight { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }
}
