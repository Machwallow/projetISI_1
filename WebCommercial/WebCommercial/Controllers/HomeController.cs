using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCommercial.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult Connexion()
        {
            ViewBag.Message = "Your connection page";

            return View();
        }

        public ActionResult Deconnexion()
        {
            ViewBag.Message = "Your deconnection page";

            return View();
        }
    }
}