using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Data.Access.Source.Factory;
using TUI.Places.Source;
using TUI.Transportations.Air;
using System.Data.Entity;

namespace TUI.Data.Access.Source
{
    public static class DataAccessLayer
    {
        private static IGenerateContext _generator = new ContextGenerator();

        public static void Delete()
        {
            using (var context = _generator.GenerateContext())
            {
                context.Database.Delete();
            }
        }

        public static void Initialize()
        {
            using (var context = _generator.GenerateContext())
            {
                context.Database.Initialize(true);
            }
        }

        public static void AddFlights(IEnumerable<Flight> flights)
        {
            using (var context = _generator.GenerateContext())
            {
                foreach (var flight in flights)
                {
                    context.Flights.Add(flight);
                }
                context.SaveChanges();
            }
        }

        public static List<Flight> GetFlights()
        {
            using(var context = _generator.GenerateContext())
            {
                var result = new List<Flight>();
                result.AddRange(context.Flights);
                return result;
            }
        }

        public static List<Airport> GetAllAirports()
        {
            using (var context = _generator.GenerateContext())
            {
                var result = context.Airports.Include(m=>m.City).Include(m => m.Location).ToList();
                return result;
            }
        }

        public static List<Flight> GetFlights(DateTime beginning, DateTime ending)
        {
            var result = new List<Flight>();

            return result;
        }

        public static List<Flight> GetFlights(Airport departure, Airport arrival)
        {
            using (var context = _generator.GenerateContext())
            {
                var result = new List<Flight>();
                result.AddRange(
                    context.Flights.Include(x => x.ArrivalAirport)
                    .Include(x => x.ArrivalAirport.City)
                    .Include(x => x.ArrivalAirport.Location)
                    .Include(x => x.DepartureAirport)
                    .Include(x => x.DepartureAirport.City)
                    .Include(x => x.DepartureAirport.Location)
                    .Include(x => x.Plane).ToList().Where(
                        flight => flight.DepartureAirport.Id == departure.Id
                        && flight.ArrivalAirport.Id == arrival.Id));
                return result;
            }
        }

        public static List<Flight> GetFlights(Airport departure, Airport arrival, DateTime beginning, DateTime ending)
        {
            using (var context = _generator.GenerateContext())
            {
                var result = new List<Flight>();
                result.AddRange(
                    context.Flights.Include(x => x.ArrivalAirport)
                    .Include(x => x.ArrivalAirport.City)
                    .Include(x => x.ArrivalAirport.Location)
                    .Include(x => x.DepartureAirport)
                    .Include(x => x.DepartureAirport.City)
                    .Include(x => x.DepartureAirport.Location)
                    .Include(x => x.Plane)
                    .ToList().Where(flight =>
                        flight.DepartureAirport.Id == departure.Id
                        && flight.ArrivalAirport.Id == arrival.Id
                        && beginning <= flight.StartDate
                        && ending <= flight.EndDate));
                return result;
            }
        }

        public static void CleanAll()
        {
            using (var context = _generator.GenerateContext())
            {
                context.Flights.RemoveRange(context.Flights);
                context.Cities.RemoveRange(context.Cities);
                context.SaveChanges();
            }
        }
    }
}
