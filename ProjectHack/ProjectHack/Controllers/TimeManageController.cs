using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using ProjectHack.Models;


namespace ProjectHack.Controllers
{
	public class TimeManageController : Controller
	{
		public ActionResult Index()
		{
<<<<<<< HEAD
			return View(CategoryElement.GetElementsFromFile(Server.MapPath(@"~/App_Data/Categories.xml"),"Categories","Category"));
=======
			return View(CategoryElement.GetElementsFromFile(Server.MapPath(@"~/App_Data/Categories.xml")));
>>>>>>> 6f69e16ce64f9c2123f548d01c01f33beb50c8e6
		}
	}
}