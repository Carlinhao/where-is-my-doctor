using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using my.doctor.crosscutting.AutoMapperConfiguration;
using my.doctor.domain.Interfaces.Repositories.Cities;
using my.doctor.domain.Interfaces.Repositories.Doctors;
using my.doctor.domain.Interfaces.Repositories.Specialisties;
using my.doctor.domain.Models;
using my.doctor.test.Utils;
using my.doctor.web.Controllers;
using Xunit;
using System.Linq;
using my.doctor.domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace my.doctor.test.Infrastructure
{
    public class DoctorsControllerTest
    {
        private readonly Mock<IDoctorRepository> _doctorRepository;
        private readonly Mock<ICityRepository> _cityRepository;
        private readonly Mock<ISpecialistRepository> _specialistRepository;
        private readonly IMapper _mapper;

        public DoctorsControllerTest()
        {
            _doctorRepository = new Mock<IDoctorRepository>();
            _cityRepository = new Mock<ICityRepository>();
            _specialistRepository = new Mock<ISpecialistRepository>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperSetUp());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }


        [Fact(DisplayName = "Must return all cities")]
        [Trait("Category", "DoctorsController")]
        public async Task Index_When_Finded_Any_Data_Must_Return_All()
        {
            // Arrange
            var controller = new DoctorsController(_doctorRepository.Object,
                                                   _cityRepository.Object,
                                                   _specialistRepository.Object,
                                                   _mapper);
            var doctors = GetDoctors();
            _doctorRepository.Setup(x => x.GetAll()).ReturnsAsync(doctors);

            // Act
            var resultIndex = await controller.Index();
            var viewResult = resultIndex.Should().BeOfType<ViewResult>().Subject;
            var doctorList = viewResult.Model.Should().BeAssignableTo<IEnumerable<DoctorViewModel>>().Subject;

            // Assert
            Assert.NotNull(viewResult.Model);
            Assert.Equal(2, doctorList.Count());

        }

        [Fact(DisplayName = "Must create a doctor")]
        [Trait("Category", "DoctorsController")]
        public async Task Create_When_Data_Is_Valid_Must_Salve_Doctor()
        {
            // Arrange
            var controller = new DoctorsController(_doctorRepository.Object,
                                                   _cityRepository.Object,
                                                   _specialistRepository.Object,
                                                   _mapper);
            var doctor = GetDoctorViewModel();
            var entity = _mapper.Map<Doctor>(doctor);

            _doctorRepository.Setup(x => x.Insert(entity)).Returns(Task.FromResult(new ViewResult()));
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            // Act
            controller.TempData = tempData;

            var resultIndex = await controller.Create(doctor);

            var viewResult = resultIndex.Should().BeOfType<RedirectToActionResult>().Subject;

            // Assert
            Assert.IsType<RedirectToActionResult>(viewResult);

        }

        private IEnumerable<Doctor> GetDoctors()
        {
            return new List<Doctor>
            {
                DoctorBuilder.Novo()
                             .WithId(1)
                             .WithName("Paul Stone")
                             .WithCrm("987456")
                             .WithIdCity(2)
                             .WithNeighborhood("Sion")
                             .WithHasClinic(true)
                             .WithAttendsByConvenience(true)
                             .WithIdSpecilist(2).Build(),

                DoctorBuilder.Novo()
                             .WithId(10)
                             .WithName("Maria Rita")
                             .WithCrm("986524")
                             .WithIdCity(2)
                             .WithNeighborhood("Pampulha")
                             .WithHasClinic(true)
                             .WithAttendsByConvenience(true)
                             .WithIdSpecilist(2).Build()
            };
        }

        private DoctorViewModel GetDoctorViewModel()
        {
            var doctor = DoctorBuilder.Novo()
                                      .WithName("Paul Stone")
                                      .WithEmail("paul.stone@teste.com")
                                      .WithWebsiteBlog("www.doctorwho.com")
                                      .WithNeighborhood("Sion Francisco")
                                      .WithAddress("Rua Do Test")
                                      .WithIdCity(1)
                                      .WithIdSpecilist(2)
                                      .WithHasClinic(false)
                                      .WithAttendsByConvenience(true)
                                      .WithCrm("852147")
                                      .Build();

            return _mapper.Map<DoctorViewModel>(doctor);
        }
    }
}
