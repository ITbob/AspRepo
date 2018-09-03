using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Places.Source;

namespace TUI.Data.Acces.Source
{
    public class DataInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<TuiContext> 
    {
        //the database context object as an input parameter
        protected override void Seed(TuiContext context)
        {
            var airports = new List<Airport>();
            airports.Add(AirportFactory.GetAirport(48.856614, 2.3522219, @"Paris"));
            airports.Add(AirportFactory.GetAirport(40.7127753, -74.0059728, @"New York"));
            airports.Add(AirportFactory.GetAirport(52.52000659999999, 13.404953999999975, @"Berlin"));
            airports.Add(AirportFactory.GetAirport(40.4325, 13.404953999999975, @"Philadelphia"));
            airports.ForEach(s => context.Airports.Add(s));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
