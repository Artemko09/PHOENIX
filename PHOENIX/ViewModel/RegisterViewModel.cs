using PHOENIX.Models;
using System.ComponentModel.DataAnnotations;

namespace PHOENIX.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Паролі не збігаються")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        [Range(1, 150)]
        public double Weight { get; set; }

        public int CategoryId { get; set; }
    }
}
