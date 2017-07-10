using Orchard.Net.Dev.Test.Controllers.Web;
using Orchard.Net.Dev.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orchard.Net.Dev.Test.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [UserParameterInjector("id")]
        public ActionResult Index(int id)
        {
            var model = new UserViewModel { Id = id };
            return View(model);
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