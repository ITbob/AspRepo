using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TUI.Project1.Controllers
{
    public class FlightsController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}