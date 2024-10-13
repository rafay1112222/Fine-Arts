using Institute_of_Fine_Arts.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace Institute_of_Fine_Arts.Controllers
{
	public class AuthController : Controller
	{
		private readonly DotneteproContext db;



		public AuthController(DotneteproContext _db)
		{
			db = _db;
		}
		public IActionResult Signup()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Signup(User user)
		{
			var checkUser = db.Users.FirstOrDefault(u => u.Email == user.Email);
			if (checkUser == null)
			{
				var hasher = new PasswordHasher<string>();
				var hashpassword = hasher.HashPassword(user.Email, user.Password);
				user.Password = hashpassword;
				db.Users.Add(user);
				db.SaveChanges();
				return RedirectToAction("Login");
			}
			else
			{
				ViewBag.msg = "User already registered. please login";
				return View();
			}
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Login(string email, string password)
		{
			bool IsAuthenticated = false;
			ClaimsIdentity identity = null;
			string controller = "";
			var isAdmin = db.Admins.FirstOrDefault(u => u.Email == email);
			var isStudent = db.Students.FirstOrDefault(u => u.Email == email);
			var isStaff = db.Staff.FirstOrDefault(u => u.Email == email);
			var isManager = db.Managers.FirstOrDefault(u => u.Email == email);


			if (isAdmin != null)
			{
				var hasher = new PasswordHasher<string>();
				var verifypass = hasher.VerifyHashedPassword(email, isAdmin.Password, password);
				if (verifypass == PasswordVerificationResult.Success)
				{
					identity = new ClaimsIdentity(new[]
					{
						new Claim(ClaimTypes.Name ,isAdmin.Username),
						new Claim(ClaimTypes.Role,"Admin"),
					}
					, CookieAuthenticationDefaults.AuthenticationScheme);
					IsAuthenticated = true;
					controller = "Admin";


					HttpContext.Session.SetInt32("AdminId", isAdmin.Id);
					HttpContext.Session.SetString("AdminEmail", isAdmin.Email);
				}
				else
				{
					ViewBag.msg = "Invalid Credentials";
					return View();
				}
			}

			else if (isStaff != null)
			{
				var hasher = new PasswordHasher<string>();
				var verifypass = hasher.VerifyHashedPassword(email, isStaff.Password, password);
				if (verifypass == PasswordVerificationResult.Success)
				{

					identity = new ClaimsIdentity(new[]
			   {
						new Claim(ClaimTypes.Name ,isStaff.Username),
						new Claim(ClaimTypes.Role,"Staff"),
					}
			   , CookieAuthenticationDefaults.AuthenticationScheme);
					IsAuthenticated = true;
					controller = "Staff";
					HttpContext.Session.SetInt32("StaffId", isStaff.Id);
					HttpContext.Session.SetString("StaffEmail", isStaff.Email);
				}



				else
				{
					ViewBag.msg = "Invalid Credentials";
					return View();
				}
			}
			else if (isManager != null)
			{
				var hasher = new PasswordHasher<string>();
				var verifypass = hasher.VerifyHashedPassword(email, isManager.Password, password);
				if (verifypass == PasswordVerificationResult.Success)
				{

					identity = new ClaimsIdentity(new[]
			   {
						new Claim(ClaimTypes.Name ,isManager.Username),
						new Claim(ClaimTypes.Role,"Manager"),
					}
			   , CookieAuthenticationDefaults.AuthenticationScheme);
					IsAuthenticated = true;
					controller = "Manager";
					HttpContext.Session.SetInt32("ManagerId", isManager.Id);
					HttpContext.Session.SetString("ManagerEmail", isManager.Email);
				}



				else
				{
					ViewBag.msg = "Invalid Credentials";
					return View();
				}
			}
			else if (isStudent != null)
			{
				var hasher = new PasswordHasher<string>();
				var verifypass = hasher.VerifyHashedPassword(email, isStudent.Password, password);
				if (verifypass == PasswordVerificationResult.Success)
				{

					identity = new ClaimsIdentity(new[]
			   {
						new Claim(ClaimTypes.Name ,isStudent.StdName),
						new Claim(ClaimTypes.Role,"Student"),
					}
			   , CookieAuthenticationDefaults.AuthenticationScheme);
					IsAuthenticated = true;
					controller = "Home";
                    HttpContext.Session.SetInt32("StudentId", isStudent.StdId);
                    HttpContext.Session.SetString("Studentemail", isStudent.Email);
                    HttpContext.Session.SetString("Studentname", isStudent.StdName);
                }



				else
				{
					ViewBag.msg = "Invalid Credentials";
					return View();
				}
			}



			else
			{
				ViewBag.msg = "Invalid Credentials";
				return View();
			}




			if (IsAuthenticated)
			{
				var principal = new ClaimsPrincipal(identity);

				var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

				return RedirectToAction("Index", controller);
			}
			else
			{
				ViewBag.msg = "Login Failed";
				return View();
			}

		}


	



		public IActionResult Logout()
		{

			HttpContext.Session.Remove("UserId");
			HttpContext.Session.Remove("UserEmail");

			var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Home");
		}

	}
}
