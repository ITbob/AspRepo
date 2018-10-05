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

        public TuiContextStringLessSession(TuiContextRepository<T> repo)
        {
            this._repo = repo;
        }

        public int Complete()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
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
