using Institute_of_Fine_Arts.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Institute_of_Fine_Arts.Controllers
{
    public class CompetitionsController : Controller
    {
        private readonly DotneteproContext db;
        public CompetitionsController(DotneteproContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult create()
        {
            return View();
        }
    }
}
