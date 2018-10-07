using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Login.source;

namespace TUI.Data.Access.Source.Repositories
{
    internal class UserRepository : TuiContextRepository<User>
    {
        protected override DbSet<User> GetDb()
        {
            return this.Context.Users;
        }

        protected override IQueryable<User> GetQueryable()
        {
            return this.Context.Users;
        }

    }
}
