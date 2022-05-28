using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace escuelajobs.Controllers
{
    public class RoleController : Controller
    {
        [Authorize(Policy = "EmployeeOnly")]
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
