using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopifyTestApp.Controllers
{
    public class HomeController : Controller
    {

        public static string Secret = ConfigurationManager.AppSettings["Secret"];
        public ActionResult Index()
        {
            //var secret = Secret;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}