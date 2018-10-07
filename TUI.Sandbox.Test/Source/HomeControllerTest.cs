using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TUI.Data.Access.Source;
using TUI.Data.Access.Source.Factory;
using TUI.Data.Access.Source.Unit;
using TUI.Places.Source;
using TUI.Sandbox;
using TUI.Sandbox.Controllers;
using TUI.Transportations.Air;

namespace TUI.Sandbox.Test.Source
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Should_Get_Home_Index_Page()
        {
            var connection = ConfigurationManager.ConnectionStrings["TUITest"].ToString();
            var tui = new TuiContext(connection);
            tui.Database.Delete();

            var airportUnit = new TuiContextUnit<Airport>(connection, RepoFactory.GetTuiContextRepo<Airport>());
            var flightUnit = new TuiContextUnit<Flight>(connection, RepoFactory.GetTuiContextRepo<Flight>());


            var controller = new HomeController(airportUnit,flightUnit);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
