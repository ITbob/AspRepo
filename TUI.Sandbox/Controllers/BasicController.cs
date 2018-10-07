using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace TUI.Sandbox.Controllers
{
    public class BasicController:Controller
    {
        public new ActionResult View([CallerMemberName] string actionMethod = null)
        {
            return base.View(actionMethod);
        }

        public ActionResult View(object model, [CallerMemberName] string actionMethod = null)
        {
            return base.View(actionMethod, model);
        }

        protected ActionResult GetNotification(String message)
        {
            return RedirectToAction("index", "notification", new { notification = message });
        }

        protected ActionResult GetErrorNotification()
        {
            return RedirectToAction("index", "notification", new { notification = "An error happened, sorry." });
        }

        protected ActionResult GetInvalidParameterNotification()
        {
            return RedirectToAction("index", "notification", new
            {
                notification =
                "Sorry, the parameter is invalid."
            });
        }

        protected ActionResult GetUnavailableItemNotification()
        {
            return RedirectToAction("index", "notification", new { notification = 
                "Sorry, the item is not available." });
        }

        protected ActionResult GetUnavailableItemNotification(String name)
        {
            return RedirectToAction("index", "notification", new
            {
                notification =
                $"Sorry, {name} is not available."
            });
        }

    }
}