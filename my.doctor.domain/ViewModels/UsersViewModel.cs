using System.ComponentModel.DataAnnotations;

namespace my.doctor.domain.ViewModels
{
    public class UsersViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string Login { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }
    }
}
