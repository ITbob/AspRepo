using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TUI.Places.Source
{
    public class Airport
    {
        [Key]
        public Int32 Id { get; set; }
        public Location Location { get; set; }
        public String Name { get; set; }

        [ForeignKey("City")]
        public Int32? CityId { get; set; }
        public virtual City City { get; set; }
    }

    public static class AirportFactory
    {
        public static Airport GetAirport(Double latitude, Double longitude, String name)
        {
            return new Airport()
            {
                Location = new Location()
                {
                    Longitude = longitude,
                    Latitude = latitude
                },
                Name = name
            };
        }
    }
}
