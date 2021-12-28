using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using my.doctor.domain.Interfaces.Repositories.Doctors;
using my.doctor.domain.Models;
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var models = await _doctorRepository.GetAll();
            ViewBag.Cities = _mapper.Map<IEnumerable<DoctorViewModel>>(models);

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
