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
			return View(HttpContext.User.Identity.IsAuthenticated);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}
		[HttpPost]
		public ActionResult Login(string txtUsername, string txtPassword)
		{
            bool flag = false;
            int uid = 0;
            User currentUser = null;

            foreach (User user in db.Users)
            {
                if (user.Username == txtUsername && user.Password == txtPassword)
                {
                    flag = true;
                    uid = user.UserId;
                    currentUser = user;
                    break;
                }
            }
            
            FormsAuthentication.SetAuthCookie(currentUser.Username, true);
            if (flag)
            {
                return RedirectToAction("Index", "Home");
            }
            return Index();
			//TODO: Implementation
			
		}

		public ActionResult Register()
		{
			//TODO: Implementation
			return View();
		}
	}
}