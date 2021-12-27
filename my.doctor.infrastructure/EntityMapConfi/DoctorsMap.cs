using Dapper.FluentMap.Dommel.Mapping;
using my.doctor.domain.Models;

namespace my.doctor.infrastructure.EntityMapConfi
{
	public class DoctorsMap : DommelEntityMap<Doctor>
	{
		public DoctorsMap()
		{
			ToTable("Doctors");

			Map(x => x.Id).ToColumn("IDDoctors").IsKey();
			Map(x => x.Crm).ToColumn("CRM");
			Map(x => x.Name).ToColumn("Name");
			Map(x => x.Address).ToColumn("Address");
			Map(x => x.Neighborhood).ToColumn("Neighborhood");
			Map(x => x.Email).ToColumn("Email");
			Map(x => x.AttendsByConvenience).ToColumn("AttendsByConvenience");
			Map(x => x.HasClinic).ToColumn("HasClinic");
			Map(x => x.WebsiteBlog).ToColumn("WebsiteBlog");
			Map(x => x.IdCity).ToColumn("IDCity");
			Map(x => x.IdSpecilist).ToColumn("IDSpecialty");
		}
	}
}
