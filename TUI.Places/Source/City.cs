﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Places.Source
{
    public class City
    {
        [Key]
        public Int32 Id { get; set; }
        public String Name { get; set; }

        [ForeignKey("Location")]
        public Int32 LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
