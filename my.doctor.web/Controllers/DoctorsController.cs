using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using my.doctor.domain.Interfaces.Repositories.Doctors;
using my.doctor.domain.ViewModels;

namespace my.doctor.web.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorsController(IDoctorRepository doctorRepository,
                                 IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var map = await _doctorRepository.GetAll();
            var result = _mapper.Map<IEnumerable<DoctorViewModel>>(map);

            return View(result);
        }
    }
}
