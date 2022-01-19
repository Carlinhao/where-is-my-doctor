using System.ComponentModel.DataAnnotations;

namespace my.doctor.domain.ViewModels
{
    public class BaseLoginViewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "O nome deve conter mais de 2 caracteres.")]
        [MaxLength(7, ErrorMessage = "O número máximo de caracteres para o Login é 7!")]
        public string Login { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "A senha deve conter no mínimo 2 caracteres.")]
        [MaxLength(50, ErrorMessage = "A senha deve conter no máximo 50 caracteres.")]
        public string Password { get; set; }
    }
}
