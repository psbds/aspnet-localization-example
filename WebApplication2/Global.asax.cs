﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication2
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		protected void Application_AcquireRequestState(object sender, EventArgs e)
		{
			string culture = "en-US";
			var cookieLanguage = Request.Cookies.Get("language");
			if (cookieLanguage != null)
			{
				culture = cookieLanguage.Value;
			}
			else if (Request.UserLanguages != null)
			{
				culture = Request.UserLanguages[0];
			}

			Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
			Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
		}
	}
}
