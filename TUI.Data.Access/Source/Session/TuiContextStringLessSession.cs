using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Data.Access.Source.Repositories;
using TUI.Model.Shared.Source;

namespace TUI.Data.Access.Source.Session
{
    public class TuiContextStringLessSession<T> : ISession<T>
                where T : class, IIdContainer
    {
        private readonly TuiContextRepository<T> _repo;
        private TuiContext _context { get; set; }
        private readonly HistoryLineRepository _historyRepo;
        private readonly IList<HistoryLine> _history;


        public TuiContextStringLessSession(TuiContextRepository<T> repo
            , Boolean listen = true)
        {
            this._repo = repo;
            if (listen)
            {
                this._repo.Operated += this.OnOperated;
                this._history = new List<HistoryLine>();
                this._historyRepo = new HistoryLineRepository();
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

        public int Complete()
        {
            var saved = this._context.SaveChanges();

            this._historyRepo.SetContext(this._context);
            this._historyRepo.AddRange(this._history);
            this._history.Clear();
            this._context.SaveChanges();

            return saved;
        }

        ~TuiContextStringLessSession()
        {
            Disposing(false);
        }

        public void Dispose()
        {
            this.Disposing(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Disposing(bool disposing)
        {
            this._repo.Operated -= this.OnOperated;
            this._context.Dispose();
        }

        public IRepository<T> GetRepository()
        {
            this._context = new TuiContext();
            this._repo.SetContext(this._context);
            return this._repo;
        }
    }
}
