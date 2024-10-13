using Institute_of_Fine_Arts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

namespace Institute_of_Fine_Arts.Controllers
{
    public class HomeController : Controller
    {
        private readonly DotneteproContext db;
        public HomeController(DotneteproContext _db)
        {
            db = _db;
        }

      
        public IActionResult Index()
        {
            var compdata = db.Competitions;
            return View(compdata.ToList());
           
        }
        [Authorize(Roles = "Student")]

        public IActionResult Competitions()
        {
            var comp = db.Competitions.ToList();
            return View(comp);
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        [Authorize(Roles = "Student")]
        public IActionResult MySubmissions()
        {
            int stdid = Convert.ToInt32(HttpContext.Session.GetInt32("StudentId"));


            var submission=db.Submissions.Where(u=>u.StdId==stdid).ToList();
            
            return View(submission);
        }
        [Authorize(Roles = "Student")]
        public IActionResult EditSubmission(int id)
        {
          


            var submission=db.Submissions.Find(id);
            
            return View(submission);
        }
        [Authorize(Roles = "Student")]
        [HttpPost]
        public IActionResult EditSubmission(Submission sub,IFormFile file,string oldimage)
        {
      


         

            return View();
        }
        [Authorize(Roles = "Student")]
        public IActionResult DeleteSubmission(int id)
        {
           


            var submission = db.Submissions.Find(id);

            return View(submission);
        }

        [Authorize(Roles = "Student")]
        [HttpPost]
        public IActionResult DeleteSubmission(Submission sub)
        {
            DateTime today = DateTime.Now;
            var submission = db.Submissions.Find(sub.SubmissionId);
            var competition = db.Competitions.Find(submission.CompetId);

            if (today < competition.EndDate)
            {
                db.Submissions.Remove(submission);
                db.SaveChanges();
            }
           


          

            return RedirectToAction("MySubmissions");
        }


        [Authorize(Roles = "Student")]
        public IActionResult CompetitionDetails(int id)
        {
            var compdata = db.Competitions.Find(id);
            return View(compdata);
        }
    }
}
