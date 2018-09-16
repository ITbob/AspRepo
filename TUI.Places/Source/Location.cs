using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Places.Source
{
    public class Location
    {
        [Key]
        public Int32 Id { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
    }
}
