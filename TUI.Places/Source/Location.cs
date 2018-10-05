using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Model.Shared.Source;

namespace TUI.Places.Source
{
    public class Location : IIdContainer
    {
        [Key]
        public Int32 Id { get; set; }
        [Required]
        public Double Latitude { get; set; }
        [Required]
        public Double Longitude { get; set; }

        public String Description => this.ToString();

        public override string ToString()
        {
            return $"La:{this.Latitude}, Lo{this.Longitude}";
        }
    }
}
