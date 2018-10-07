using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Data.Access.Source.Repositories;
using TUI.Data.Access.Source.Session;

namespace TUI.Data.Access.Source.Unit
{
    public class HistoryUnit : IUnit<HistoryLine>
    {
        public ISession<HistoryLine> GetSession()
        {
            return new TuiContextStringLessSession<HistoryLine>(new HistoryLineRepository(),false);
        }
    }
}
