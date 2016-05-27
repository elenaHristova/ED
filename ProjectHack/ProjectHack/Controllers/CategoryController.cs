using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectHack.Models;
using System.IO;

namespace ProjectHack.Controllers
{
    public class CategoryController : Controller
    {
		ProjectHackContext db= new ProjectHackContext();

		public ActionResult Index()
        {
			return View(db.Categories);
        }

	    public ActionResult AddCategory()
	    {
			
		    return View();
	    }

		public ActionResult SaveCategory(string txtTitle,string txtTopic, string txtTopic1, string txtTopic2)
		{
			string username=HttpContext.User.Identity.Name;
			string path=Server.MapPath("~/App_Data/");
			string filePath = Path.Combine(path, username + ".txt");
            string info = String.Format($"{txtTitle}:{txtTopic};{txtTopic1};{txtTopic2}{Environment.NewLine}");
			System.IO.File.WriteAllText(filePath,info);
			
			return RedirectToAction("Index","Account");
		}
	}
}