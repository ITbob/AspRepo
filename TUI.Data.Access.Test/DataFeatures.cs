using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Data.Access.Source;
using TUI.Places.Source;
using TUI.Transportations.Air;
using TUI.Transportations.Air.Source;

namespace TUI.Data.Access.Test
{
    [TestFixture]
    public class DataFeatures
    {
        [SetUp]
        public void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        [Test, Order(1)]
        public void Should_Be_Empty()
        {
            var flightsInfo = DataAccessLayer.GetFlights();
            Assert.AreEqual(0, flightsInfo.Count());
        }

        [Test,Order(2)]
        public void Should_Get_Three_More_Flights()
        {
            var flightsInfo = DataAccessLayer.GetFlights();

            var parisAirport = AirportFactory.GetAirport(48.856614, 2.3522219, @"Paris", new City() { Name = "Paris"});
            var newYorkAirport = AirportFactory.GetAirport(40.7127753, -74.0059728, @"New York", new City() { Name = "Paris" });
            var berlinAirport = AirportFactory.GetAirport(52.52000659999999, 13.404953999999975, @"Berlin", new City() { Name = "Paris" });

            var flights = new List<Flight>()
            {
                FlightFactory.Get(parisAirport, newYorkAirport, new DateTime(2001, 6, 6), new DateTime(2001, 7, 6)),
                FlightFactory.Get(newYorkAirport, berlinAirport,new DateTime(2001, 6, 6), new DateTime(2001, 7, 6)),
                FlightFactory.Get(parisAirport, berlinAirport,new DateTime(2001, 6, 6), new DateTime(2001, 7, 6))
            };

            DataAccessLayer.AddFlights(flights);

            var result = DataAccessLayer.GetFlights();

            Debug.WriteLine($"total {flightsInfo.Count()}");

            Assert.AreEqual(flightsInfo.Count()+3, result.Count());
        }

        [TearDown]
        public void Clean()
        {
            DataAccessLayer.CleanAll();
        }


    }
}
