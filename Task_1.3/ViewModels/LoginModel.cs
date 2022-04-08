using System.ComponentModel.DataAnnotations;

namespace Task_1._3.ViewModels
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }

    }
}
