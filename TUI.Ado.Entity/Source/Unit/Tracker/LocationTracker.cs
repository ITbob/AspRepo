﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Data.Access.Source.Unit.Tracker;
using TUI.Places.Source;

namespace TUI.Ado.Entity.Source.Unit.Tracker
{
    public class LocationTracker:UnitTracker<Location>
    {
        public LocationTracker() : base(new LocationUnit(), new HistoryUnit())
        {

        }
    }
}
