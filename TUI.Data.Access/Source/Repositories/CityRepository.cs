using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TUI.Places.Source;

namespace TUI.Data.Access.Source.Repositories
{
    internal class CityRepository : TuiContextRepository<City>
    {

        protected override DbSet<City> GetDb()
        {
            return this.Context.Cities;
        }

        protected override IQueryable<City> GetQueryable()
        {
            return this.Context.Cities.Include(c => c.Location);
        }

        public override void SetModified(City element)
        {
            var originalCity = this.Context.Cities.Include(c => c.Location)
                .Single(c => c.Id == element.Id);
            this.Context.Locations.Attach(element.Location);

            originalCity.Location.Latitude = element.Location.Latitude;
            originalCity.Location.Longitude = element.Location.Longitude;
            this.Context.Entry(originalCity).State = EntityState.Modified;

            this.OnOperated(OperationType.Update);
        }
    }
}
