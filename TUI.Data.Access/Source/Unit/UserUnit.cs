using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Data.Access.Source.Repositories;
using TUI.Data.Access.Source.Session;
using TUI.Login.source;

namespace TUI.Data.Access.Source.Unit
{
    public class UserUnit : IUnit<User>
    {
        public ISession<User> GetSession()
        {
            return new TuiContextStringLessSession<User>(new UserRepository());
        }
    }
}
