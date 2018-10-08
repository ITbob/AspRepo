﻿using TUI.Data.Access.Source.Session;
using TUI.Model.Shared.Source;

namespace TUI.Data.Access.Source.Unit.Tracker
{
    public class UnitTracker<T> : IUnit<T>
        where T : class, IIdContainer
    {
        private readonly IUnit<T> _unit;
        private readonly string _connectionString = null;

        public UnitTracker(IUnit<T> unit, string connectionString = null)
        {
            this._unit = unit;
            this._connectionString = connectionString;
        }

        public ISession<T> GetSession()
        {
            var session = this._unit.GetSession();
            //create a tracker for each session, when the session is done
            // the tracker will unsubscribe its event
            // then be collected by GC
            var tracker = new SessionTracker<T>(session, this._connectionString);
            return session;
        }
    }
}
