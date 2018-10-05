using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TUI.Project1.Models
{
    public struct FlightSearch
    {
        [Required]
        public String DepartureAirport { get; set; }
        [DataType(DataType.Date)]
        public DateTime BeginningDate { get; set; }
        [Required]
        public String ArrivalAirport { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndingDate { get; set; }
    }
}