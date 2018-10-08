using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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

        public EventHandler<OperationType> Operated { get; set; }

        protected void OnOperated(OperationType type)
        {
            this.Operated?.Invoke(this, type);
        }

        public void Add(T element)
        {
            this.GetDb().Add(element);
            this.OnOperated(OperationType.Create);
        }

        public void AddRange(IEnumerable<T> element)
        {
            this.GetDb().AddRange(element);
            this.OnOperated(OperationType.Create);
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
            var data = this.GetQueryable();
            if (data == null)
            {
                return new List<T>();
            }
            else
            {
                return data.ToList();
            }
        }

        public void Remove(T element)
        {
            this.GetDb().Remove(element);
            this.OnOperated(OperationType.Remove);
        }

        public void RemoveRange(IEnumerable<T> element)
        {
            this.GetDb().RemoveRange(element);
            this.OnOperated(OperationType.Remove);
        }

        public virtual void SetModified(T element)
        {
            this.Context.Entry(element).State = EntityState.Modified;
            this.OnOperated(OperationType.Update);
        }

        public void SetContext(TuiContext context)
        {
            this.Context = context;
        }
    }
}
