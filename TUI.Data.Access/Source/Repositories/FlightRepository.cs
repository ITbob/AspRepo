using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TUI.Transportations.Air;

namespace TUI.Data.Access.Source.Repositories
{
    internal class FlightRepository : TuiContextRepository<Flight>
    {
        protected override DbSet<Flight> GetDb()
        {
            return this.Context.Flights;
        }

        protected override IQueryable<Flight> GetQueryable()
        {
            return this.Context.Flights.Include(x => x.ArrivalAirport)
                    .Include(x => x.ArrivalAirport.City)
                    .Include(x => x.ArrivalAirport.Location)
                    .Include(x => x.DepartureAirport)
                    .Include(x => x.DepartureAirport.City)
                    .Include(x => x.DepartureAirport.Location)
                    .Include(x => x.Plane)
                    .Include(x => x.Plane.GasKind)
                    .Include(x => x.Plane.Kind);
        }
    }
}
