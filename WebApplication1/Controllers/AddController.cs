using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTravel.Controllers
{
    public class AddController : Controller
    {
        // GET: Add
        public ActionResult Hotel()
        {
            return View();
        }

        public ActionResult Room()
        {
            return View();
        }
    }
}