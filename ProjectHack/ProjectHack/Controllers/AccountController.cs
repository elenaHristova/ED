using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjectHack.Models;

namespace ProjectHack.Controllers
{
    public class AccountController : Controller
    {
        ProjectHackContext db=new ProjectHackContext();

        public ActionResult Index()
        {
	        ViewBag.Title = "My profile";
	        ViewBag.Id = Session["uid"];
            return View();
        }

	    public ActionResult NewUser()
	    {
			return View();
	    }

		[HttpPost]
		public ActionResult SaveNewUser(string txtFullname, string txtAge, string gender)
		{
			int age = int.Parse(txtAge);
			int uid = (int)Session["uid"];
			PersonalInfo pi= new PersonalInfo(txtFullname,age,gender,uid);
			db.PersonalInfos.Add(pi);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}