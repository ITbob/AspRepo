using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TUI.Model.Shared.Source;

namespace TUI.Places.Source
{
    public class Airport : IIdContainer
    {
        [Key]
        public Int32 Id { get; set; }

        [ForeignKey("Location")]
        public Int32 LocationId { get; set; }
        public virtual Location Location { get; set; }
        public String Name { get; set; }

        [ForeignKey("City")]
        public Int32? CityId { get; set; }
        public virtual City City { get; set; }

        public String Description => this.ToString();

        public Airport()
        {

        }

        public Airport(Double latitude, Double longitude, String name, City city)
        {
            Location = new Location()
            {
                Longitude = longitude,
                Latitude = latitude
            };
            Name = name;
            City = city;
        }

        public override string ToString()
        {
            return City != null ? $"{Name} ({City.Name})" : Name;
        }
    }
}
