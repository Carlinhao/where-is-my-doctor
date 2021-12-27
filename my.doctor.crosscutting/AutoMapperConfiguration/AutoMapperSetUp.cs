using AutoMapper;
using my.doctor.domain.Models;
using my.doctor.domain.ViewModels;

namespace my.doctor.crosscutting.AutoMapperConfiguration
{
    public class AutoMapperSetUp : Profile
    {
        public AutoMapperSetUp()
        {
            CreateMap<DoctorViewModel, Doctor>().ReverseMap();
            CreateMap<CityViewModel, City>().ReverseMap();
            CreateMap<UsersViewModel, Users>().ReverseMap();
            CreateMap<SpecialistViewModel, Specialist>().ReverseMap();
        }
    }
}
