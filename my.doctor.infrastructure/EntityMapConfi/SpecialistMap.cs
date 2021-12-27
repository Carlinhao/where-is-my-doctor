using Dapper.FluentMap.Dommel.Mapping;
using my.doctor.domain.Models;

namespace my.doctor.infrastructure.EntityMapConfi
{
	public class SpecialistMap : DommelEntityMap<Specialist>
	{
		public SpecialistMap()
		{
			ToTable("Specialties");

			Map(x => x.Id).ToColumn("IDSpecialty").IsKey();
			Map(x => x.Name).ToColumn("Name");
		}
	}
}
