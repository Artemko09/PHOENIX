using System.ComponentModel.DataAnnotations;

namespace PHOENIX.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Вкажіть Email")]
        [EmailAddress(ErrorMessage = "Некоректний формат Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запам'ятати мене?")]
        public bool RememberMe { get; set; }
    }
}