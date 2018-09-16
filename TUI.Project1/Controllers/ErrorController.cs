using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TUI.Project1.Controllers
{
    public class ErrorController : Controller
    {

        [Route("Error/Index")]
        public ActionResult Index(String errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }
    }
}