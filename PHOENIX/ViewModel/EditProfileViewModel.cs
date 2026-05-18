using PHOENIX.Models;
using System.ComponentModel.DataAnnotations;

namespace PHOENIX.ViewModel
{
    public class EditProfileViewModel
    {
        [Required(ErrorMessage = "Ім'я обов'язкове")]
        public string Name { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Категорія")]
        public int CategoryId { get; set; }
    }
}
