using Dapper.FluentMap.Dommel.Mapping;
using my.doctor.domain.Models;

namespace my.doctor.infrastructure.EntityMapConfi
{
	public class CityMap : DommelEntityMap<City>
	{
		public CityMap()
		{
			ToTable("Cities");

			Map(x => x.Id).ToColumn("IDCity").IsKey();
			Map(x => x.Name).ToColumn("Name");
		}
	}
}
