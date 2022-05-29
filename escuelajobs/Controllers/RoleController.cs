using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using escuelajobs.Core;

namespace escuelajobs.Controllers
{
    public class RoleController : Controller
    {
        [Authorize(Roles = $"{Constans.Roles.Administrator}")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Policy = "RequireAdmin")]
        public IActionResult Admin()
        {
            return View();
        }
        [Authorize(Policy = "RequireAlumno")]
        public IActionResult Alumno()
        {
            return View();
        }
    }
}
