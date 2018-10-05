using System.Web.Mvc;
using TUI.Data.Access.Source.Unit;
using TUI.Places.Source;
using TUI.Project1.Controllers;
using TUI.TimeZone.Source;
using TUI.TimeZone.Source.Api.Google;
using TUI.Transportations.Air;
using TUI.Transportations.Air.Source;
using Unity;
using Unity.Mvc5;

namespace TUI.Project1
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

            // Register interface
            container.RegisterType<IUnit<Airport>, AirportUnit>();
            container.RegisterType<IUnit<City>, CityUnit>();
            container.RegisterType<IUnit<Flight>, FlightUnit>();
            container.RegisterType<IUnit<Plane>, PlaneUnit>();
            container.RegisterType<IUnit<Location>, LocationUnit>();
            container.RegisterType<ITimeZoneApi, GoogleTimeZoneApi>();

            TimeZoneHelper.Api = container.Resolve<ITimeZoneApi>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}