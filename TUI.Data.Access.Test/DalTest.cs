using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TUI.Data.Access.Source;
using TUI.Data.Access.Source.Factory;
using TUI.Places.Source;
using TUI.Transportations.Air;
using TUI.Transportations.Air.Source;
using System.Configuration;
using TUI.Gasoline.Source;
using TUI.Data.Access.Source.Unit;
using TUI.Places.Air.Source;
using System.Data.Entity;

namespace TUI.Data.Access.Test
{
    [TestFixture]
    class DalTest
    {

        private IUnit<Flight> _flightUnit;
        private IUnit<Airport> _airportUnit;
        private IUnit<City> _cityUnit;


        [SetUp]
        public void Setup()
        {
            var connection = ConfigurationManager.ConnectionStrings["TUITest"].ToString();
            var tui = new TuiContext(connection);
            tui.Database.Delete();

            this._flightUnit = new TuiContextUnit<Flight>(connection, RepoFactory.GetTuiContextRepo<Flight>());
            this._airportUnit = new TuiContextUnit<Airport>(connection, RepoFactory.GetTuiContextRepo<Airport>());
            this._cityUnit = new TuiContextUnit<City>(connection, RepoFactory.GetTuiContextRepo<City>());
        }

        [Test, Order(1)]
        public void Should_Flight_list_be_empty()
        {
            using (var session = this._flightUnit.GetSession())
            {
                var flightsInfo = session.GetRepository().GetAll();
                Assert.AreEqual(0, flightsInfo.Count());
            }
        }

        [Test, Order(2)]
        public void Should_Get_Two_Cities()
        {
            using (var session = this._cityUnit.GetSession())
            {
                var citiesRepo = session.GetRepository();
                var citiesCount = citiesRepo.GetAll().Count();
                var paris = CityFactory.GetCity(CityType.Paris);
                var newYork = CityFactory.GetCity(CityType.NewYork);


                citiesRepo.AddRange(new[] { newYork, paris });
                session.Complete();

                Assert.AreEqual(citiesCount+2, citiesRepo.GetAll().Count());
            }
        }

        [Test,Order(2)]
        public void Should_Get_Three_More_Flights()
        {
            using (var flightSession = this._flightUnit.GetSession())
            {
                using (var citySession = this._cityUnit.GetSession())
                {
                    using (var airportSession = this._airportUnit.GetSession())
                    {
                        var fightRepo = flightSession.GetRepository();
                        var flightsInfo = fightRepo.GetAll();

                        var aiportRepo = airportSession.GetRepository();

                        var parisAirport = AirportFactory.GetAirport(AirportType.CharlesDeGaule);
                        var newYorkAirport = AirportFactory.GetAirport(AirportType.JFK);
                        var berlinAirport = AirportFactory.GetAirport(AirportType.berlin);

                        var airports = new[] { parisAirport, newYorkAirport, berlinAirport };

                        var citiesRepo = citySession.GetRepository();
                        citiesRepo.AddRange(airports.Select(ap => ap.City));
                        citySession.Complete();

                        aiportRepo.AddRange(airports);
                        airportSession.Complete();

                        var airbusKind = PlaneKindFactory.GetPlane(PlaneType.airbus);
                        var gasKind = GasFactory.GetJetFuel();


                        var flights = new List<Flight>()
                        {
                            new Flight(){
                                DepartureAirport = parisAirport,
                                ArrivalAirport= newYorkAirport,
                                StartDate =  new DateTime(2001, 6, 6),
                                Plane = new Plane() { Kind = airbusKind, GasKind = gasKind },
                            },
                            new Flight(){
                                DepartureAirport = newYorkAirport,
                                ArrivalAirport = berlinAirport,
                                StartDate = new DateTime(2001, 6, 6),
                                Plane = new Plane() { Kind = airbusKind, GasKind = gasKind },
                            },
                            new Flight(){
                                DepartureAirport = parisAirport,
                                ArrivalAirport = berlinAirport,
                                StartDate = new DateTime(2001, 6, 6),
                                Plane = new Plane() { Kind = airbusKind, GasKind = gasKind },
                            }
                        };

                        fightRepo.AddRange(flights);
                        flightSession.Complete();
                        var result = fightRepo.GetAll();

                        Assert.AreEqual(flightsInfo.Count() + 3, result.Count());
                    }
                }
            }
        }
    }
}
