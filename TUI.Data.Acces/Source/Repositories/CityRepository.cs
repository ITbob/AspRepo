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


    }
}
