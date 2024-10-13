using Microsoft.AspNetCore.Mvc;

namespace Institute_of_Fine_Arts.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
