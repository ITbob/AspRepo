using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TUI.Data.Access.Source;
using TUI.Data.Access.Source.Unit;

namespace TUI.Sandbox.Controllers
{
    public class ReportController : Controller
    {
        private readonly IUnit<HistoryLine> _historyUnit;

        public ReportController(IUnit<HistoryLine> historyUnit)
        {
            this._historyUnit = historyUnit;
        }

        // GET: Report
        public ActionResult Index()
        {
            using (var session = this._historyUnit.GetSession())
            {
                var items = session.GetRepository();
                return View(items.GetAll());
            }
        }
    }
}