using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using my.doctor.domain.Interfaces.Repositories.Users;
using my.doctor.domain.Models;
using my.doctor.domain.ViewModels;
using my.doctor.web.Configurations.Login;

namespace my.doctor.web.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly LoginUser _loginUser;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository,
                              LoginUser loginUser,
                              IMapper mapper)
        {
            _userRepository = userRepository;
            _loginUser = loginUser;
            _mapper = mapper;
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromForm] UserViewModel userRequest)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<UserModel>(userRequest);

                await _userRepository.RegisterUser(entity);
                TempData["MSG_S"] = "Register with success!";

                // TODO - Implement Diferent redirection
                return RedirectToAction(nameof(RegisterUser));
            }


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] UserViewModel userRequest)
        {
            var entity = _mapper.Map<UserModel>(userRequest);
            var customerRepo = await _userRepository.CanDoLogin(entity);

            if (customerRepo != null)
            {
                _loginUser.PostUser(customerRepo);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["MSG_E"] = "User or Password invalid.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult LogOff()
        {
            _loginUser.Logout();
            return RedirectToAction("Login", "User");
        }
    }
}
