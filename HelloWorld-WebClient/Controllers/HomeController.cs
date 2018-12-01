using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.ApiEndpoint = ConfigurationManager.AppSettings["apiEndpoint"];
            ViewBag.ApiKey = ConfigurationManager.AppSettings["apiKey"];

            return View();
        }
    }
}
