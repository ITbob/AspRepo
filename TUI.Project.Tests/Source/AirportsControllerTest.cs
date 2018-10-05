using NUnit.Framework;
using TUI.Project1.Controllers;
using System.Web.Mvc;
using System.Configuration;
using System;
using TUI.Data.Access.Source;
using System.Web;
using TUI.Data.Access.Source.Unit;
using TUI.Places.Source;
using TUI.Data.Access.Source.Factory;

namespace TUI.Project.Tests.Source
{
    [TestFixture]
    class AirportsControllerTest
    {
        private AirportsController _controller;
        [SetUp]
        public void Setup()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
            var connection = ConfigurationManager.ConnectionStrings["TUITest"].ToString();

            var cityUnit = new TuiContextUnit<City>(connection, RepoFactory.GetTuiContextRepo<City>());
            var locationUnit = new TuiContextUnit<Location>(connection, RepoFactory.GetTuiContextRepo<Location>());
            var airportUnit = new TuiContextUnit<Airport>(connection, RepoFactory.GetTuiContextRepo<Airport>());

            this._controller =
                new AirportsController(airportUnit, cityUnit, locationUnit);
        }

        [Test]
        public void Should_Get_Airport_Index_Page()
        {
            ViewResult result = this._controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void Should_Get_Airport_Create_Page()
        {
            ViewResult result = this._controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void Should_Get_Airport_Details_Page()
        {
            RedirectToRouteResult routeResult = this._controller.Details(1) as RedirectToRouteResult;
            var value = routeResult.RouteValues["Notification"];
            Assert.AreEqual(value, "Sorry, the item is not available.");
        }

        [Test]
        public void Should_Get_Airport_Edit_Page()
        {
            RedirectToRouteResult routeResult = this._controller.Edit(1) as RedirectToRouteResult;
            var value = routeResult.RouteValues["Notification"];
            Assert.AreEqual(value, "Sorry, the item is not available.");
        }

        [Test]
        public void Should_Get_Airport_Delete_Page()
        {
            RedirectToRouteResult routeResult = this._controller.Delete(1) as RedirectToRouteResult;
            var value = routeResult.RouteValues["Notification"];
            Assert.AreEqual(value, "Sorry, the item is not available.");
        }
    }
}
