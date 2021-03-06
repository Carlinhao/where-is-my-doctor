using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper.FluentMap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using my.doctor.crosscutting.AutoMapperConfiguration;
using my.doctor.domain.Interfaces.Repositories.Cities;
using my.doctor.domain.Interfaces.Repositories.Doctors;
using my.doctor.domain.Interfaces.Repositories.Specialisties;
using my.doctor.domain.Interfaces.Repositories.Users;
using my.doctor.infrastructure.EntityMapConfi;
using my.doctor.infrastructure.Repositories.Cities;
using my.doctor.infrastructure.Repositories.Doctors;
using my.doctor.infrastructure.Repositories.Specialisties;
using my.doctor.infrastructure.Repositories.Users;

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
			services.AddTransient<ICityRepository, CityRepository>();
			services.AddTransient<ISpecialistRepository, SpecialistRepository>();
			services.AddTransient<IUserRepository, UserRepository>();

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
