using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TUI.Data.Access.Source;
using TUI.Data.Access.Source.Factory;
using TUI.Data.Access.Source.Unit;
using TUI.Places.Source;
using TUI.Sandbox.Controllers;

namespace TUI.Sandbox.Test.Source
{
    [TestFixture]
    class CitiesControllerTest
    {
        private CitiesController _controller;

        [SetUp]
        public void Setup()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
            var connection = ConfigurationManager.ConnectionStrings["TUITest"].ToString();
            var tui = new TuiContext(connection);
            tui.Database.Delete();

            var cityUnit = new TuiContextUnit<City>(connection, RepoFactory.GetTuiContextRepo<City>());
            var locationUnit = new TuiContextUnit<Location>(connection, RepoFactory.GetTuiContextRepo<Location>());

            this._controller = 
                new CitiesController(cityUnit,locationUnit);
        }

        [Test]
        public void Should_Get_City_Index_Page()
        {
            ViewResult result = this._controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }


        [Test]
        public void Should_Get_City_Create_Page()
        {
            ViewResult result = this._controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }


        [Test]
        public void Should_Get_City_Details_Page()
        {
            RedirectToRouteResult routeResult = this._controller.Details(1) as RedirectToRouteResult;
            var value = routeResult.RouteValues["Notification"];
            Assert.AreEqual("Sorry, the item is not available.", value);
        }

        [Test]
        public void Should_Get_City_Edit_Page()
        {
            RedirectToRouteResult routeResult = this._controller.Edit(1) as RedirectToRouteResult;
            var value = routeResult.RouteValues["Notification"];
            Assert.AreEqual("Sorry, the item is not available.", value);
        }

        [Test]
        public void Should_Get_City_Delete_Page()
        {
            RedirectToRouteResult routeResult = this._controller.Delete(1) as RedirectToRouteResult;
            var value = routeResult.RouteValues["Notification"];
            Assert.AreEqual("Sorry, the item is not available.", value);
        }
    }
}
