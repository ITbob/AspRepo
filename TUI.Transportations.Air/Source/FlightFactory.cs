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
        public static Flight Get(Airport departure, Airport arrival
            , DateTime departureTime, DateTime arrivalTime)
        {
            var plane = new Plane();
            plane.Name = @"airbus a380";
            plane.KilometersHourSpeed = 900;

            return new Flight(departure, arrival) {
                Plane = plane,
                StartDate = departureTime,
                EndDate = arrivalTime
            };
        }
    }
}
