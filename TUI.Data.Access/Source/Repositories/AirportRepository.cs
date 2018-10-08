﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TUI.Places.Source;

namespace TUI.Data.Access.Source.Repositories
{
    internal class AirportRepository : TuiContextRepository<Airport>
    {
        protected override DbSet<Airport> GetDb()
        {
            return this.Context.Airports;
        }

        protected override IQueryable<Airport> GetQueryable()
        {
            return this.Context.Airports.Include(a => a.City.Location)
                .Include(a => a.Location);
        }

        public override void SetModified(Airport element)
        {
            var originalAirport = this.Context.Airports.Include(c => c.Location)
                .Single(c => c.Id == element.Id);
            this.Context.Locations.Attach(element.Location);

            originalAirport.Location.Latitude = element.Location.Latitude;
            originalAirport.Location.Longitude = element.Location.Longitude;
            this.Context.Entry(originalAirport).State = EntityState.Modified;

            this.OnOperated(OperationType.Update);
        }

    }
}
