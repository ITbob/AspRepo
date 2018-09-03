using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Places.Source;
using TUI.Transportations.Air;

namespace TUI.Data.Acces.Source
{
    public static class DataAccessLayer
    {
        private static TuiContext Context { get; set; } = new TuiContext();

        public static void AddFlights(IEnumerable<Flight> flights)
        {
            foreach (var flight in flights)
            {
                Context.Flights.Add(flight);
            }

            Context.SaveChanges();
        }

        public static List<Flight> GetFlights()
        {
            var result = new List<Flight>();
            result.AddRange(Context.Flights);
            return result;
        }

        public static List<Airport> GetAirports()
        {
            var result = new List<Airport>();
             result.AddRange(Context.Airports);
            return result;
        }

        public static List<Flight> GetFlight(DateTime beginning, DateTime ending)
        {
            var result = new List<Flight>();

            return result;
        }
    }
}
