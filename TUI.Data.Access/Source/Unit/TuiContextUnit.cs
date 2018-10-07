using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Data.Access.Source.Repositories;
using TUI.Data.Access.Source.Session;
using TUI.Model.Shared.Source;

namespace TUI.Data.Access.Source.Unit
{
    public class TuiContextUnit<T>: IUnit<T>
        where T : class, IIdContainer
    {
        private readonly String _connection;
        private readonly TuiContextRepository<T> _repo;

        public TuiContextUnit(String connection, TuiContextRepository<T> repo)
        {
            this._connection = connection;
            this._repo = repo;
        }

        public ISession<T> GetSession()
        {
            return new TuiContextSession<T>(this._connection, this._repo);
        }
    }
}
