using Institute_of_Fine_Arts.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Institute_of_Fine_Arts.Controllers
{
    public class StaffController : Controller
    {
       

		private readonly DotneteproContext db;
		public StaffController(DotneteproContext _db)
		{
			db = _db;
		}
		[Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateCompetition()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult CreateCompetition(Competition comp, IFormFile file)
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

            comp.ImageFilePath = dbimage;

            db.Competitions.Add(comp);
            db.SaveChanges();

            return RedirectToAction("ViewCompetition");
        }

        [HttpGet]
        public IActionResult EditCompetition(int id)
        {
            var cmp = db.Competitions.Find(id);
            if (cmp == null)
            {
                return RedirectToAction("ViewCompetition");
            }
            else
            {
               
                return View(cmp);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCompetition(Competition cmp, IFormFile file, string oldImage)
        {
            var dbimage = "";
            if (file != null && file.Length > 0)
            {
                string imageName = DateTime.Now.ToString("yymmddhhmmss");//6432647443473
                imageName += Path.GetFileName(file.FileName);//6432647443473apple.jpg
                var imagepath = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/uploads");
                var imageValue = Path.Combine(imagepath, imageName);
                using (var stream = new FileStream(imageValue, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                dbimage = Path.Combine("/uploads", imageName);
                cmp.ImageFilePath = dbimage;
                db.Competitions.Update(cmp);
                db.SaveChanges();
            }
            else
            {
                cmp.ImageFilePath = oldImage;
                db.Competitions.Update(cmp);
                db.SaveChanges();
            }

           
            return RedirectToAction("ViewCompetition");
        }

        [HttpGet]
        public IActionResult DeleteCompetition(int id)
        {
            var item = db.Competitions.Find(id);
            if (item == null)
            {
                return RedirectToAction("ViewCompetition");
            }
            else
            {
                return View(item);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCompetition(Competition comp, IFormFile file, string oldImage)
        {


            db.Competitions.Remove(comp);
            db.SaveChanges();
            return RedirectToAction("ViewCompetition");
        }


        public IActionResult ViewCompetition()
        {
            return View(db.Competitions.Include(u=>u.Winner).ToList());
        }
        public IActionResult ViewSubmissions(int id)
        {
            var post = db.Submissions
           .Include(u=>u.Std)
                .Include(u=>u.Compet).Where(u=>u.CompetId==id);
            return View(post.ToList());
        }
        
        
        public IActionResult ChooseWinner(int id)
        {
            var post = db.Submissions.Include(u => u.Std).Include(u => u.Compet).FirstOrDefault(u => u.SubmissionId == id);


            return View(post);
        }

        [HttpPost]

        public IActionResult ConfirmWinner(int sid)
        {

            var details = db.Submissions.Find(sid);
            int stdid = details.StdId;
            int compid = details.CompetId;
            var comp = db.Competitions.FirstOrDefault(u=>u.CompetId==compid);
            comp.WinnerId = stdid;
            db.Competitions.Update(comp);
            db.SaveChanges();
            return RedirectToAction("ViewCompetition");
        }
    }
}
