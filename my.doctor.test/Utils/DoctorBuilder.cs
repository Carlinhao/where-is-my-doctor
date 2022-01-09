using my.doctor.domain.Models;

namespace my.doctor.test.Utils
{
    internal class DoctorBuilder
    {
		private int _id;
		private string _crm;
		private string _name;
		private string _address;
		private string _neighborhood;
		private string _email;
		private bool _attendsByConvenience;
		private bool _hasClinic;
		private string _websiteBlog;
		private int _idSpecilist;
		private int _idCity;

		public static DoctorBuilder Novo()
        {
			return new DoctorBuilder();
        }

		public DoctorBuilder WithId(int id)
        {
			_id = id;
			return this;
        }

		public DoctorBuilder WithCrm(string crm)
		{
			_crm = crm;
			return this;
		}

		public DoctorBuilder WithName(string name)
        {
			_name = name;
			return this;
        }

		public DoctorBuilder WithAddress(string address)
        {
			_address = address;	
			return this;
        }

		public DoctorBuilder WithNeighborhood(string neighborhood)
        {
			_neighborhood = neighborhood;
			return this;
		}

		public DoctorBuilder WithEmail(string email)
        {
			_email = email;
			return this;
        }

		public DoctorBuilder WithAttendsByConvenience(bool attendsByConvenience)
        {
			_attendsByConvenience = attendsByConvenience;
			return this;
        }

		public DoctorBuilder WithHasClinic(bool hasClinic)
		{
			_hasClinic = hasClinic;
			return this;
		}

		public DoctorBuilder WithWebsiteBlog(string websiteBlog)
		{
			_websiteBlog = websiteBlog;
			return this;
		}

		public DoctorBuilder WithIdSpecilist(int idSpecilist)
		{
			_idSpecilist = idSpecilist;
			return this;
		}

		public DoctorBuilder WithIdCity(int idCity)
		{
			_idCity = idCity;
			return this;
		}

		public Doctor Build()
        {
			return new Doctor 
			{ 
				Id = _id,
				Name = _name,
				Address = _address,
				AttendsByConvenience = _attendsByConvenience,
				Crm = _crm,
				Email = _email,
				HasClinic = _hasClinic,
				IdCity = _idCity,
				IdSpecilist = _idSpecilist,
				Neighborhood = _neighborhood,
				WebsiteBlog = _websiteBlog
			};
        }
	}
}
