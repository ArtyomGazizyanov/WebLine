using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTravel.Controllers
{
    public class ChangeHotelController : Controller
    {
        // GET: ChangeHotel
        public ActionResult Index(int id)
        {
            return View();
        }

        // GET: ChangeHotel/{id}
        public ActionResult Get()
        {
            return View();
        }
    }
}