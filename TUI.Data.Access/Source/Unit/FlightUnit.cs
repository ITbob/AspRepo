using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Data.Access.Source.Repositories;
using TUI.Data.Access.Source.Session;
using TUI.Transportations.Air;

namespace TUI.Data.Access.Source.Unit
{
    public class FlightUnit : IUnit<Flight>
    {
        public ISession<Flight> GetSession()
        {
            return new TuiContextStringLessSession<Flight>(new FlightRepository());
        }
    }
}
