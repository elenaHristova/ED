using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectHack.Models;

namespace ProjectHack.Controllers
{
	public class HomeController : Controller
	{
		public ProjectHackContext db=new ProjectHackContext();
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}
		[HttpPost]
		public ActionResult Login(string txtUsername, string txtPassword)
		{
			/*bool flag = false;
			int uid = 0;

			foreach (User user in db.Users)
			{
				if (user.Username == txtUsername && user.Password == txtPassword)
				{
					flag = true;
					//uid = user.UserId;
				}
			}
			Session.Add("uid", uid);
			if (flag)
			{
				return RedirectToAction("Index", "Account");
			}*/
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