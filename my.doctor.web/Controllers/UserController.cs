using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using my.doctor.domain.Interfaces.Repositories.Users;
using my.doctor.domain.Models;
using my.doctor.web.Configurations.Login;

namespace my.doctor.web.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly LoginUser _loginUser;
        public UserController(IUserRepository userRepository,
                              LoginUser loginUser)
        {
            _userRepository = userRepository;
            _loginUser = loginUser;
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
        public async Task<IActionResult> RegisterUser([FromForm] UserRequest userRequest)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.RegisterUser(userRequest);
                TempData["MSG_S"] = "Register with success!";

                // TODO - Implement Diferent redirection
                return RedirectToAction(nameof(RegisterUser));
            }


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] UserRequest userRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(userRequest);
            }

            var customerRepo = await _userRepository.CanDoLogin(userRequest);

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

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
