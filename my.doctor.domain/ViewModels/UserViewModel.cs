using System.ComponentModel.DataAnnotations;

namespace my.doctor.domain.ViewModels
{
    public class UserViewModel : BaseLoginViewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "O nome deve conter mais de 2 caracteres.")]
        public string Name { get; set; }

        [EmailAddress]
        [MinLength(250, ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }        
    }
}
