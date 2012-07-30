using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCScheduler.Web.Areas.Scheduler.Controllers
{
    public class MeetingController : Controller
    {
        //
        // GET: /Scheduler/Meeting/
		[HttpGet]
		[Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
