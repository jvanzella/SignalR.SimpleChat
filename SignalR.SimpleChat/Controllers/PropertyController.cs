using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR.SimpleChat.Controllers
{
    public class PropertyController : Controller
    {
        //
        // GET: /Property/

        public ActionResult Index()
        {
            return View("ListingDetails");
        }

    }
}
