using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectHack.Models;
using System.Web.Security;
using System.Security.Principal;

namespace ProjectHack.Controllers
{
	public class HomeController : Controller
	{
		public ProjectHackContext db=new ProjectHackContext();
		public ActionResult Index()
		{
            bool IsAuthenticated = false;
            try
            {
                if (HttpContext.User.Identity.IsAuthenticated == false) ;
            }
            catch
            {
                IsAuthenticated = false;
            }

            ViewBag.IsAuthenticated = HttpContext.User.Identity.IsAuthenticated;

            var viewModels = new AccountInfoViewModel[2];
            viewModels[0] = new LoginViewModel();
            viewModels[1] = new RegisterViewModel();
            return View(viewModels);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}
		[HttpPost]
		public ActionResult Login(LoginViewModel model)
		{
            bool flag = false;
            int uid = 0;
            User currentUser = null;

            foreach (User user in db.Users)
            {
                if (user.Username == model.Username && user.Password == model.Password)
                {
                    flag = true;
                    uid = user.UserId;
                    currentUser = user;
                    break;
                }
            }
            
            FormsAuthentication.SetAuthCookie(currentUser.Username, true);
            var viewModels = new AccountInfoViewModel[2];
            viewModels[0] = new LoginViewModel();
            viewModels[1] = new RegisterViewModel();
            return RedirectToAction("Index", "Home", viewModels);
			//TODO: Implementation
			
		}

		[HttpPost]
		public ActionResult Register(RegisterViewModel model)
		{
			bool userExists = false;

			foreach (User user in db.Users)
			{
				if (user.Username == model.Username)
				{
					userExists = true;

				}
			}
			if (userExists==false)
			{
				User newUser = new User { Username = model.Username, Email = model.Email, Password = model.Password };
				db.Users.Add(newUser);
				db.SaveChanges();
				FormsAuthentication.SetAuthCookie(newUser.Username,true);
				Session["uid"] = newUser.UserId;
				return RedirectToAction("NewUser", "Account");
				//here we will show them the additional info we want
			}
			return RedirectToAction("Index");
		}
	}
}