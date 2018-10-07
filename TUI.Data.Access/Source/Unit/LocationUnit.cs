using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Data.Access.Source.Repositories;
using TUI.Data.Access.Source.Session;
using TUI.Places.Source;

namespace TUI.Data.Access.Source.Unit
{
    public class LocationUnit : IUnit<Location>
    {
        public ISession<Location> GetSession()
        {
            return new TuiContextStringLessSession<Location>(new LocationRepository());
        }
    }
}
