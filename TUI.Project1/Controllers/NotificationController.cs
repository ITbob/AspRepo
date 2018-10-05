using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TUI.Project1.Controllers
{
    public class NotificationController : Controller
    {
        public ActionResult Index(String notification)
        {
            ViewBag.Notification = notification;
            return View();
        }
    }
}