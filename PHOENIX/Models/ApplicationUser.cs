using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PHOENIX.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 25 characters.")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯіїєІЇЄ' ]+$", ErrorMessage = "Ім'я може містити лише літери.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        public DateTime BirthDate { get; set; }

        public int Age => (DateTime.Today.Year - BirthDate.Year) - (DateTime.Today < BirthDate.AddYears(DateTime.Today.Year - BirthDate.Year) ? 1 : 0);

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        [Range(1, 100, ErrorMessage = "Weight must be between 1 and 100.")]
        public double Weight { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public Rank SportsRank { get; set; } = Rank.White;
        public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }

    public enum Rank
    {
        [Display(Name = "10 Кю (Білий пояс)")] White,
        [Display(Name = "9 Кю (Білий пояс з полоскою)")] WhiteStrip,

        [Display(Name = "8 Кю (Жовтий пояс)")] Yellow,

        [Display(Name = "7 Кю (Оранжевий пояс)")] Orange,

        [Display(Name = "6 Кю (Зелений пояс)")] Green,

        [Display(Name = "5 Кю (Синій пояс)")] Blue,
        [Display(Name = "4 Кю (Синій пояс з полоскою)")] BlueStrip,

        [Display(Name = "3 Кю (Коричневий пояс)")] Brown3,
        [Display(Name = "2 Кю (Коричневий пояс)")] Brown2,
        [Display(Name = "1 Кю (Коричневий пояс)")] Brown1,

        [Display(Name = "1 Дан (Чорний пояс)")] Black
    }
}
