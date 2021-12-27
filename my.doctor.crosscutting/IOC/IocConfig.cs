using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper.FluentMap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using my.doctor.crosscutting.AutoMapperConfiguration;
using my.doctor.domain.Interfaces.Repositories.Doctors;
using my.doctor.infrastructure.EntityMapConfi;
using my.doctor.infrastructure.Repositories.Doctors;

namespace my.doctor.crosscutting.IOC
{
	public static class IocConfig
	{
		public static void ServiceConfig(this IServiceCollection services, IConfiguration configuration)
		{
			// Connections SqlServer
			services.AddScoped<IDbConnection>(it => new SqlConnection(configuration.GetConnectionString("SQL_SERVER")));			

			// Repositories
			services.AddTransient<IDoctorRepository, DoctorRepository>();

			// Automapper
			var mapping = new MapperConfiguration(conf =>
			{
				conf.AddProfile(new AutoMapperSetUp());
			});

			IMapper mapper = mapping.CreateMapper();
			services.AddSingleton(mapper);
		}

		public static void Rister()
		{
			FluentMapper.Initialize(config =>
			{
				config.AddMap(new CityMap());
				config.AddMap(new DoctorsMap());
				config.AddMap(new SpecialistMap());
				config.AddMap(new UsersMap());
			});
		}
	}
}
