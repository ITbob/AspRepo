using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Places.Source;
using TUI.Transportations.Air.Source;

namespace TUI.Transportations.Air
{
    public class Flight : ITrip
    {
        [Key]
        public Int32 Id { get; set; }
        public TimeSpan Duration { get; set; }

        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MinValue;

        public Location Departure => DepartureAirport.Location;
        public Location Arrival => ArrivalAirport.Location;

        [ForeignKey("Plane")]
        public Int32 PlaneId { get; set; }
        public virtual Plane Plane {get;set;}

        [ForeignKey("DepartureAirport")]
        public Int32 DepartureId { get; set; }
        public virtual Airport DepartureAirport { get; set; }

        [ForeignKey("ArrivalAirport")]
        public Int32 ArrivalId { get; set; }
        public virtual Airport ArrivalAirport { get; set; }

        public double GetDistanceKm()
        {
            return this.Departure.GetDistance(this.Arrival);
        }

        public TimeSpan GetDuration()
        {
            var result = (double) ( (double)this.GetDistanceKm() / (double)this.Plane.KilometersHourSpeed);
            return new TimeSpan(Convert.ToInt32(result), 0, 0);
        }

        public Flight()
        {

        }

        public Flight(Airport departure, Airport arrival)
        {
            this.DepartureAirport = departure;
            this.ArrivalAirport = arrival;
        }

        public override string ToString()
        {
            return $"From {this.DepartureAirport} to {this.ArrivalAirport}";
        }
    }
}
