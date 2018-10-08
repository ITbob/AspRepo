﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Places.Source;

namespace TUI.Data.Access.Source.Unit.Tracker
{
    public class AirportTracker: UnitTracker<Airport>
    {
        public AirportTracker() : base(new AirportUnit())
        {

        }
    }
}