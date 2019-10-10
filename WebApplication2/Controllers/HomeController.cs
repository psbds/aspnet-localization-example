using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = Resources.Global.Message;
			return View();
		}

		public ActionResult ChangeLanguage(string language)
		{
			Response.Cookies.Add(new HttpCookie("language", language)
			{
				Expires = DateTime.Now.AddYears(2)
			});

			return RedirectToAction("Index");
		}
	}
}