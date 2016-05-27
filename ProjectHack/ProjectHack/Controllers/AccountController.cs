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
        ProjectHackContext db = new ProjectHackContext();

        public ActionResult Index()
        {
            ViewBag.Title = "My profile";
            return View();
        }

        public ActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveNewUser(NewUserViewModel model)
        {
            int uid = (int)Session["uid"];
            PersonalInfo pi = new PersonalInfo(model.FullName, model.Age, model.Gender, uid);
            db.PersonalInfos.Add(pi);
            db.SaveChanges();

            var viewModels = new AccountInfoViewModel[2];
            viewModels[0] = new LoginViewModel();
            viewModels[1] = new RegisterViewModel();
            return RedirectToAction("Index", viewModels);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}