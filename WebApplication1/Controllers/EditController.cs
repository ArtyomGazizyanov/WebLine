using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTravel.Controllers
{
    public class EditController : Controller
    {
        public ActionResult Hotel()
        {
            ViewBag.Title = "Hotel Editor";
            var queryParametrs = Request.QueryString["id"];

            return View();
        }

        public ActionResult Room()
        {
            ViewBag.Title = "Room Editor";
            return View();
        }
    }
}