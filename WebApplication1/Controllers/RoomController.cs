using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTravel.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            ViewBag.Title = "Hotel`s Rooms";
            var queryParametrs = Request.QueryString["hotelId"];

            return View();
        }
    }
}