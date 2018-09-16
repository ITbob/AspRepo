using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Transportations.Air.Source
{
    public class Plane
    {
        [Key]
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Int32 KilometersHourSpeed { get; set; }
    }
}
