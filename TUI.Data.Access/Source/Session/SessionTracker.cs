using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Data.Access.Source.Factory;
using TUI.Data.Access.Source.Repositories;
using TUI.Data.Access.Source.Unit;
using TUI.Model.Shared.Source;

namespace TUI.Data.Access.Source.Session
{
    internal class SessionTracker<T>
                where T : class, IIdContainer
    {
        private readonly IUnit<HistoryLine> _historyUnit;
        private readonly IList<HistoryLine> _history;
        private readonly IRepository<T> _repo;
        private readonly ISession<T> _session;

        public SessionTracker(ISession<T> session, String connectionString = null)
        {
            this._session = session;
            this._repo = session.GetRepository();
            this._history = new List<HistoryLine>();
            //ouch ugly
            if(connectionString != null)
            {
                this._historyUnit = new TuiContextUnit<HistoryLine>(connectionString, 
                    RepoFactory.GetTuiContextRepo<HistoryLine>());
            }
            else
            {
                this._historyUnit = new HistoryUnit();
            }

            this._repo.Operated += this.OnOperated;
            this._session.Completed += this.OnCompleted;
            this._session.Disposed += this.OnDisposed;
        }

        private void OnDisposed(Object obj, EventArgs e)
        {
            //unsubscribe for GC
            this._repo.Operated -= this.OnOperated;
            this._session.Completed -= this.OnCompleted;
            this._session.Disposed -= this.OnDisposed;
        }

        private void OnCompleted(Object obj, EventArgs e)
        {
            using(var session = this._historyUnit.GetSession())
            {
                session.GetRepository().AddRange(this._history);
                this._history.Clear();
                session.Complete();
            }
        }

        private void OnOperated(Object obj, OperationType operation)
        {
            this._history.Add(new HistoryLine()
            {
                Operation = operation,
                Datetime = DateTime.Now,
                DateType = typeof(T).Name
            });
        }
    }
}
