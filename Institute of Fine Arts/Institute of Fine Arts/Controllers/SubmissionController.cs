using Institute_of_Fine_Arts.Models;

using Microsoft.AspNetCore.Mvc;

namespace Institute_of_Fine_Arts.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly DotneteproContext db;



        public SubmissionController(DotneteproContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Submission(int id)
        {
            ViewBag.Compid = id;
            return View();
        }
        [HttpPost]
        public IActionResult Submission(Submission sub, IFormFile file)
        {
            string imageName = DateTime.Now.ToString("yymmddhhmmss");//6432647443473
            imageName += Path.GetFileName(file.FileName);//6432647443473apple.jpg
            var imagepath = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/uploads");
            var imageValue = Path.Combine(imagepath, imageName);

            using (var stream = new FileStream(imageValue, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            var dbimage = Path.Combine("/uploads", imageName);

            sub.ImageFilePath = dbimage;



            var competDetails=db.Competitions.FirstOrDefault(b=>b.CompetId==sub.CompetId);
            DateTime enddate = competDetails.EndDate;
            DateTime today = DateTime.Now;
            if(today < enddate)
            {
                db.Submissions.Add(sub);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.msg = "Sorry, this Competition has ended.";
                return View();
            }
        }

    }
}
