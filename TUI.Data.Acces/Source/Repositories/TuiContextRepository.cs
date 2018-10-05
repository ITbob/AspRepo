using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Model.Shared.Source;

namespace TUI.Data.Access.Source.Repositories
{
    public abstract class TuiContextRepository<T> 
        : IRepository<T> where T : class, IIdContainer
    {
        protected TuiContext Context { get; set; }
        protected abstract DbSet<T> GetDb();
        protected abstract IQueryable<T> GetQueryable();

        public void Add(T element)
        {
            this.GetDb().Add(element);
        }

        public void AddRange(IEnumerable<T> element)
        {
            this.GetDb().AddRange(element);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return this.GetQueryable().Where(predicate).ToList();
        }

        public T Get(int i)
        {
            var result = this.GetQueryable().Where(f => f.Id == i);

            if (!result.Any())
            {
                return null;
            }

            return result.Single();
        }

        public IEnumerable<T> GetAll()
        {
            return this.GetQueryable().ToList();
        }

        public void Remove(T element)
        {
            this.GetDb().Remove(element);
        }

        public void RemoveRange(IEnumerable<T> element)
        {
            this.GetDb().RemoveRange(element);
        }

        public void SetModified(T element)
        {
            this.Context.Entry(element).State = EntityState.Modified;
        }

        public void SetContext(TuiContext context)
        {
            this.Context = context;
        }
    }
}
