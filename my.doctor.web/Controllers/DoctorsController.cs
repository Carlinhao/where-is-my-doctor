using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using my.doctor.domain.Interfaces.Repositories.Cities;
using my.doctor.domain.Interfaces.Repositories.Doctors;
using my.doctor.domain.Interfaces.Repositories.Specialisties;
using my.doctor.domain.Models;
using my.doctor.domain.ViewModels;

namespace my.doctor.web.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ISpecialistRepository _specialistRepository;
        private readonly IMapper _mapper;

        public DoctorsController(IDoctorRepository doctorRepository,
                                 ICityRepository cityRepository,
                                 ISpecialistRepository specialistRepository,
                                 IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _cityRepository = cityRepository;
            _specialistRepository = specialistRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var map = await _doctorRepository.GetAll();
            var result = _mapper.Map<IEnumerable<DoctorViewModel>>(map);

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var models = _mapper.Map<IEnumerable<CityViewModel>>(await _cityRepository.GetAll());
            var modelsSpecialist = _mapper.Map<IEnumerable<SpecialistViewModel>>(await _specialistRepository.GetAll());

            ViewBag.Cities = models.ToList().Select(a => new SelectListItem(a.Name,
                                                                            a.Id.ToString()));
            ViewBag.Specialisties = modelsSpecialist.ToList().Select(a => new SelectListItem(a.Name,
                                                                                             a.Id.ToString()));

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<Doctor>(model);
                await _doctorRepository.Insert(entity);

                TempData["MSG_S"] = "Register save succsess.";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
