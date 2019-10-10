using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{

		private readonly IStringLocalizer<Global> _localizer;

		public HomeController(IStringLocalizer<Global> localizer)
		{
			_localizer = localizer;
		}


		public IActionResult Index()
		{
			ViewBag.Message = _localizer["String1"].ToString();
			return View();
		}

		public IActionResult ChangeLanguage([FromQuery] string language)
		{

			Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, $"c={language}|uic={language}", new Microsoft.AspNetCore.Http.CookieOptions()
			{
				Expires = DateTime.Now.AddYears(2)
			});

			return RedirectToAction("Index");
		}
	}
}
