using System.Web.Mvc;
using TUI.Data.Access.Source;
using TUI.Data.Access.Source.Unit;
using TUI.Data.Access.Source.Unit.Tracker;
using TUI.Login.source;
using TUI.Places.Source;
using TUI.Sandbox.Controllers;
using TUI.TimeZone.Source;
using TUI.TimeZone.Source.Api.Google;
using TUI.Transportations.Air;
using TUI.Transportations.Air.Source;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace TUI.Sandbox
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // Register controller
            container.RegisterType<AirportsController>();
            container.RegisterType<HomeController>();
            container.RegisterType<CitiesController>();
            container.RegisterType<FlightsController>();
            container.RegisterType<HomeController>();
            container.RegisterType<LoginController>();
            container.RegisterType<ReportController>();

            // Register interface
            container.RegisterType<IUnit<Airport>, AirportTracker>();
            container.RegisterType<IUnit<City>, CityTracker>();
            container.RegisterType<IUnit<Flight>, FlightTracker>();
            container.RegisterType<IUnit<Plane>, PlaneTracker>();
            container.RegisterType<IUnit<Location>, LocationTracker>();
            container.RegisterType<IUnit<User>, UserTracker>();
            container.RegisterType<IUnit<HistoryLine>, HistoryUnit>();
            container.RegisterType<ITimeZoneApi, GoogleTimeZoneApi>();

            TimeZoneHelper.Api = container.Resolve<ITimeZoneApi>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}