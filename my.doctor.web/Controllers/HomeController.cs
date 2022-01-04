using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using my.doctor.web.Configurations.Login;

namespace my.doctor.web.Controllers
{
    [UserLoginAuthorization]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
