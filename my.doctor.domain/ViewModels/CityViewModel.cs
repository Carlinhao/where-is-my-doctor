using System.ComponentModel.DataAnnotations;

namespace my.doctor.domain.ViewModels
{
    public class CityViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [StringLength(300, ErrorMessage = "O Nome deve possuir no máximo 300 caracteres")]
        public string Name { get; set; }
    }
}
