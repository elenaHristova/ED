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
            string username = HttpContext.User.Identity.Name;
            User currentUser = db.Users.Where(user => user.Username == username).FirstOrDefault();
            Session["uid"] = currentUser.UserId;
            ViewBag.Id = currentUser.UserId;
            List<string> categories = currentUser.Categories?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //List<int> categoriesId = new List<int>();
            List<string> catTitles = new List<string>();
            if (categories == null) return View(catTitles);
            var categoriesXml = CategoryElement.GetElementsFromFile(Server.MapPath(@"~/App_Data/Categories.xml")).Cast<MainCategory>();
            //for (int i = 0; i<categories.Count; i++)
            //      {
            //       categoriesId.Add(Convert.ToInt32(categories[i]));
            //      }
            //categories.Clear();
            foreach (var dbCats in categories)
            {
                foreach (var category in categoriesXml.Select(c => c.Elements).SelectMany(i => i))
                {
                    if (dbCats == category.Id) catTitles.Add(category.Title);
                }
                //var categoryId = db.Categories.Where(cat => cat.CategoryId == categoryId).FirstOrDefault();
            }
            return View(catTitles);
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
            PersonalInfo pi = new PersonalInfo(txtFullname, age, gender, uid);
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