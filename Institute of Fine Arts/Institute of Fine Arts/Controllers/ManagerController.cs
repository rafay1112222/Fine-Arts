using Institute_of_Fine_Arts.Models;

using Microsoft.AspNetCore.Mvc;

namespace Institute_of_Fine_Arts.Controllers
{
    public class ManagerController : Controller
    {
        private readonly DotneteproContext db;



        public ManagerController(DotneteproContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewStaff()
        {

            return View(db.Staff.ToList());
        }
        public IActionResult ViewStudent()
        {

            return View(db.Students.ToList());
        }

        public IActionResult ViewCompetition()
        {
            return View(db.Competitions.ToList());
        }
    }
}
