using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Places.Source;
using TUI.Transportations.Air;
using TUI.Transportations.Air.Source;

namespace TUI.Data.Access.Source
{
    public class DataInitializer:System.Data.Entity.DropCreateDatabaseAlways<TuiContext> 
    {
        //the database context object as an input parameter
        protected override void Seed(TuiContext context)
        {
            Debug.WriteLine("initializing");

            var cities = new List<City>();
            cities.AddRange(new[]
            {
                new City() {
                Name = "New York",
                Location = new Location()
                {
                    Latitude = 48.856614,
                    Longitude = 2.3522219
                }
                },
                new City()
                {
                    Name = "Paris",
                Location = new Location()
                {
                    Latitude = 48.856614,
                    Longitude = 2.3522219
                }
                },
                new City()
                {
                    Name = "Berlin",
                Location = new Location()
                {
                    Latitude = 48.856614,
                    Longitude = 2.3522219
                }
                },
                new City()
                {
                    Name = "New Jersey",
                Location = new Location()
                {
                    Latitude = 48.856614,
                    Longitude = 2.3522219
                }
                },
                new City()
                {
                    Name = "Shanghai",//4
                    Location = new Location()
                    {
                        Latitude = 31.230416,
                        Longitude = 121.473701
                    }
                },
                new City()
                {
                    Name = "Beijing",//5
                    Location = new Location(){
                        Latitude = 39.904211,
                        Longitude = 116.407395
                    }
                },
                new City()
                {
                    Name = "Seoul",//6
                    Location = new Location(){
                        Latitude = 37.566535,
                        Longitude = 126.97796919999996
                    }
                },
                new City()
                {
                    Name = "Buenos Aires",//7
                    Location = new Location(){
                        Latitude = -34.6037232,
                        Longitude = -58.3815931
                    }
                },
                new City()
                {
                    Name = "Calcutta",//8
                    Location = new Location(){
                        Latitude =22.572646,
                        Longitude = 88.363895
                    }
                },
                new City()
                {
                    Name = "Melbourne",//9
                    Location = new Location(){
                        Latitude = -37.814107,
                        Longitude = 144.96328
                    }
                }
            }
        );

            cities.ForEach(s => context.Cities.Add(s));

            var airports = new List<Airport>();
            airports.Add(AirportFactory.GetAirport(48.856614, 2.3522219, @"Orly Airport", cities[1]));
            airports.Add(AirportFactory.GetAirport(49.0096906, 2.547924500000022, @"Charles de Gaulle Airport", cities[1]));
            airports.Add(AirportFactory.GetAirport(40.7127753, -74.0059728, @"JFK Airport", cities[0]));
            airports.Add(AirportFactory.GetAirport(52.52000659999999, 13.404953999999975, @"Berlin Airport", cities[2]));
            airports.Add(AirportFactory.GetAirport(40.4325, 13.404953999999975, @"Newwark Airport", cities[3]));

            airports.Add(AirportFactory.GetAirport(-34.598326, -58.375275, @"Buenos Aires Airport", cities[7]));

            airports.Add(AirportFactory.GetAirport(31.1443439, 121.80827299999999, @"Pudong Airport", cities[4]));
            airports.Add(AirportFactory.GetAirport(31.192209, 121.334297, @"Hongqiao Airport", cities[4]));

            airports.Add(AirportFactory.GetAirport(22.6520429, 88.4463299, @"Netaji Subhas Chandra Bose International Airport", cities[8]));

            airports.Add(AirportFactory.GetAirport(-37.669012, 144.841027, @"Melbourne Airport", cities[9]));

            airports.Add(AirportFactory.GetAirport(40.0798573, 116.60311209999998, @"Beijing Capital International  Airport", cities[5]));

            airports.Add(AirportFactory.GetAirport(37.460191, 126.440696, @"Incheon Airport", cities[6]));
            airports.Add(AirportFactory.GetAirport(-37.814107, 144.96328, @"Gimpo Airport", cities[6]));

            airports.ForEach(s => context.Airports.Add(s));

            var flights = new List<Flight>();
            flights.Add(FlightFactory.Get(airports[0], airports[1], new DateTime(2001, 6, 6), new DateTime(2001, 6, 6)));
            flights.Add(FlightFactory.Get(airports[0], airports[1], new DateTime(2001, 7, 6), new DateTime(2001, 7, 6)));
            flights.Add(FlightFactory.Get(airports[0], airports[1], new DateTime(2001, 8, 6), new DateTime(2001, 8, 6)));
            flights.Add(FlightFactory.Get(airports[0], airports[1], new DateTime(2001, 9, 6), new DateTime(2001, 9, 6)));
            flights.ForEach(s => context.Flights.Add(s));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
