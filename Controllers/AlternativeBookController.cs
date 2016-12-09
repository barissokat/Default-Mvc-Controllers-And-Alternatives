using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefaultMvcControllersAndAlternatives.Controllers
{
    public class AlternativeBookController : Controller
    {
        // GET: AlternativeBook
        public ActionResult Index()
        {
            return View();
        }
    }
}