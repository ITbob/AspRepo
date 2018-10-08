﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Login.source;

namespace TUI.Data.Access.Source.Unit.Tracker
{
    public class UserTracker : UnitTracker<User>
    {
        public UserTracker() : base(new UserUnit(), new HistoryUnit())
        {

        }
    }
}
