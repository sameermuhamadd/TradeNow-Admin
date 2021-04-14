using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TradeNow_Admin.Controllers
{
    public class RiderController : Controller
    {
        // GET: Rider
        public ActionResult RiderList()
        {
            return View();
        }
        public ActionResult RiderLogin()
        {
            return View();
        }
    }
}