using System.ComponentModel.DataAnnotations;

namespace my.doctor.domain.ViewModels
{
    public class DoctorViewModel
    {
		[Display(Name ="Identificador")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CRM")]
		[StringLength(30, ErrorMessage = "O CRM deve possuir no máximo 30 caracteres")]
		public string Crm { get; set; }

		[Required(ErrorMessage = "Obrigatório informar o Nome")]
		[StringLength(80, ErrorMessage = "O Nome deve possuir no máximo 80 caracteres")]
		[Display(Name = "Nome")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Obrigatório informar o Endereço")]
		[StringLength(100, ErrorMessage = "O Endereço deve possuir no máximo 100 caracteres")]
		[Display(Name = "Endereço")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Obrigatório informar o Bairro")]
		[StringLength(60, ErrorMessage = "O Bairro deve possuir no máximo 60 caracteres")]
		[Display(Name = "Bairro")]
		public string Neighborhood { get; set; }

		[Required(ErrorMessage = "Obrigatório informar o E-mail")]
		[StringLength(100, ErrorMessage = "O E-mail deve possuir no máximo 100 caracteres")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Obrigatório informar se Atende por Convênio")]
		[Display(Name = "Atende por convênio")]
		public bool AttendsByConvenience { get; set; }

		[Required(ErrorMessage = "Obrigatório informar se Tem Clínica")]
		[Display(Name = "Possui clínica?")]
		public bool HasClinic { get; set; }

		[StringLength(80, ErrorMessage = "O Website deve possuir no máximo 80 caracteres")]
		[Display(Name = "Web site")]
		public string WebsiteBlog { get; set; }

		[Required(ErrorMessage = "Obrigatório informar a Cidade")]
		[Display(Name = "Identificador Especialidade")]
		public int IdSpecilist { get; set; }

		[Display(Name = "Identificador Cidade")]
		[Required(ErrorMessage = "Obrigatório informar a Especialidade")]
		public int IdCity { get; set; }
	}
}
