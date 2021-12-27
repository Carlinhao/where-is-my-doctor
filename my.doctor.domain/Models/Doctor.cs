namespace my.doctor.domain.Models
{
	public class Doctor
	{
		public int Id { get; set; }
		public string Crm { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Neighborhood { get; set; }
		public string Email { get; set; }
		public bool AttendsByConvenience { get; set; }
		public bool HasClinic { get; set; }
		public string WebsiteBlog { get; set; }
		public int IdSpecilist { get; set; }
		public int IdCity { get; set; }
	}
}
