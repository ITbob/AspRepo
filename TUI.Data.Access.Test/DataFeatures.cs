using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Data.Acces.Source;
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

        [Test]
        public void Should_Get_Three_More_Flights()
        {
            var initResult = DataAccessLayer.GetFlights();

            var parisAirport = AirportFactory.GetAirport(48.856614, 2.3522219, @"Paris");
            var newYorkAirport = AirportFactory.GetAirport(40.7127753, -74.0059728, @"New York");
            var berlinAirport = AirportFactory.GetAirport(52.52000659999999, 13.404953999999975, @"Berlin");

            var flights = new List<Flight>()
            {
                FlightFactory.Get(parisAirport, newYorkAirport),
                FlightFactory.Get(newYorkAirport, berlinAirport),
                FlightFactory.Get(parisAirport, berlinAirport)
            };

            DataAccessLayer.AddFlights(flights);

            var result = DataAccessLayer.GetFlights();

            Assert.AreEqual(initResult.Count()+3, result.Count());
        }
    }
}
