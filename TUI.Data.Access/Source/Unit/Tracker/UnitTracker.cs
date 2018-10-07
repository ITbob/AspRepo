using TUI.Data.Access.Source.Session;
using TUI.Model.Shared.Source;

namespace TUI.Data.Access.Source.Unit.Tracker
{
    public class UnitTracker<T> : IUnit<T>
        where T : class, IIdContainer
    {
        private readonly IUnit<T> _unit;

        public UnitTracker(IUnit<T> unit)
        {
            this._unit = unit;
        }

        public ISession<T> GetSession()
        {
            var session = this._unit.GetSession();
            //create a tracker for each session, when the session is done
            // the tracker will unsubscribe its event
            // then be collected by GC
            var tracker = new SessionTracker<T>(session);
            return session;
        }
    }
}
