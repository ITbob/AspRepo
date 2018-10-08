using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Transportations.Air.Source;

namespace TUI.Data.Access.Source.Unit.Tracker
{
    public class PlaneTracker: UnitTracker<Plane>
    {
        public PlaneTracker() : base(new PlaneUnit(), new HistoryUnit())
        {

        }
    }
}
