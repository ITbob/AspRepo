using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Places.Source;

namespace TUI.Transportations.Air.Source
{
    public static class FlightFactory
    {
        public static Flight Get(Airport departure, Airport arrival)
        {
            return new Flight(departure, arrival);
        }
    }
}
