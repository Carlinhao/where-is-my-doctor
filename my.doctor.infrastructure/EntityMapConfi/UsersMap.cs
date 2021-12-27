using Dapper.FluentMap.Dommel.Mapping;
using my.doctor.domain.Models;

namespace my.doctor.infrastructure.EntityMapConfi
{
	public class UsersMap : DommelEntityMap<Users>
	{
		public UsersMap()
		{
			ToTable("Users");

			Map(x => x.Id).ToColumn("IDUsers").IsKey();
			Map(x => x.Name).ToColumn("Name");
			Map(x => x.Login).ToColumn("Name");
			Map(x => x.Password).ToColumn("Name");
			Map(x => x.Email).ToColumn("Name");
		}
	}
}
