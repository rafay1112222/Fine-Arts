using Institute_of_Fine_Arts.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Institute_of_Fine_Arts.Controllers
{
    [Authorize (Roles = "Admin")]
    public class AdminController : Controller
    {
        
        private readonly DotneteproContext db;



        public AdminController(DotneteproContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStaff(Staff user)
        {
            var checkUser = db.Staff.FirstOrDefault(u => u.Email == user.Email);
            if (checkUser == null)
            {
                var hasher = new PasswordHasher<string>();
                var hashpassword = hasher.HashPassword(user.Email, user.Password);
                user.Password = hashpassword;
                db.Staff.Add(user);
                db.SaveChanges();
                return RedirectToAction("ViewStaff");
            }
            else
            {
                ViewBag.msg = "email already registered.";
                return View();
            }
        }


		public IActionResult EditStaff(int id)
		{
			var stf = db.Staff.Find(id);
			if (stf == null)
			{
				return RedirectToAction("ViewStaff");
			}
			else
			{

				return View(stf);
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditStaff(Staff user)
		{
			var checkUser = db.Staff.FirstOrDefault(u => u.Email == user.Email);
			
				var hasher = new PasswordHasher<string>();
				var hashpassword = hasher.HashPassword(user.Email, user.Password);
				user.Password = hashpassword;
				db.Staff.Update(user);
				db.SaveChanges();
				return RedirectToAction("ViewStaff");
			
			
		}

		[HttpGet]
		public IActionResult DeleteStaff(int id)
		{
			var stf = db.Staff.Find(id);
			if (stf == null)
			{
				return RedirectToAction("ViewStaff");
			}
			else
			{
				return View(stf);
			}

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteStaff(Staff stf)
		{


			db.Staff.Remove(stf);
			db.SaveChanges();
			return RedirectToAction("ViewStaff");
		}



		public IActionResult ViewStaff()
        {
           
            return View(db.Staff.ToList());
        }

         public IActionResult AddManager()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddManager(Manager user)
        {
            var checkUser = db.Managers.FirstOrDefault(u => u.Email == user.Email);
            if (checkUser == null)
            {
                var hasher = new PasswordHasher<string>();
                var hashpassword = hasher.HashPassword(user.Email, user.Password);
                user.Password = hashpassword;
                db.Managers.Add(user);
                db.SaveChanges();
                return RedirectToAction("ViewManager");
            }
            else
            {
                ViewBag.msg = "email already registered.";
                return View();
            }
        }

		public IActionResult EditManager(int id)
		{
			var stf = db.Managers.Find(id);
			if (stf == null)
			{
				return RedirectToAction("ViewManager");
			}
			else
			{

				return View(stf);
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditManager(Manager user)
		{
			var checkUser = db.Managers.FirstOrDefault(u => u.Email == user.Email);

			var hasher = new PasswordHasher<string>();
			var hashpassword = hasher.HashPassword(user.Email, user.Password);
			user.Password = hashpassword;
			db.Managers.Update(user);
			db.SaveChanges();
			return RedirectToAction("ViewStaff");


		}

		[HttpGet]
		public IActionResult DeleteManager(int id)
		{
			var mngr = db.Managers.Find(id);
			if (mngr == null)
			{
				return RedirectToAction("ViewManager");
			}
			else
			{
				return View(mngr);
			}

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteManager(Manager mngr)
		{


			db.Managers.Remove(mngr);
			db.SaveChanges();
			return RedirectToAction("ViewStaff");
		}



		public IActionResult ViewManager()
        {
           
            return View(db.Managers.ToList());
        }


        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(Student user)
        {
            var checkUser = db.Students.FirstOrDefault(u => u.Email == user.Email);
            if (checkUser == null)
            {
                var hasher = new PasswordHasher<string>();
                var hashpassword = hasher.HashPassword(user.Email, user.Password);
                user.Password = hashpassword;
                db.Students.Add(user);
                db.SaveChanges();
                return RedirectToAction("ViewStudent");
            }
            else
            {
                ViewBag.msg = "email already registered.";
                return View();
            }
        }



		public IActionResult EditStudent(int id)
		{
			var std = db.Students.Find(id);
			if (std == null)
			{
				return RedirectToAction("ViewStudent");
			}
			else
			{

				return View(std);
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditStudent(Student user)
		{
			var checkUser = db.Students.FirstOrDefault(u => u.Email == user.Email);

			var hasher = new PasswordHasher<string>();
			var hashpassword = hasher.HashPassword(user.Email, user.Password);
			user.Password = hashpassword;
			db.Students.Update(user);
			db.SaveChanges();
			return RedirectToAction("ViewStudent");


		}

		[HttpGet]
		public IActionResult DeleteStudent(int id)
		{
			var std = db.Students.Find(id);
			if (std == null)
			{
				return RedirectToAction("ViewStudent");
			}
			else
			{
				return View(std);
			}

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteStudent(Student std)
		{


			db.Students.Remove(std);
			db.SaveChanges();
			return RedirectToAction("ViewStaff");
		}



		public IActionResult ViewStudent()
        {

            return View(db.Students.ToList());
        }
    }
}
