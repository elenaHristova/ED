using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHack.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
	        ViewBag.Title = "My profile";
            return View();
        }

	    public ActionResult NewUser()
	    {
		    return View();
	    }
    }
}