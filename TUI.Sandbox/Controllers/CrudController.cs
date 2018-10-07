using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TUI.Data.Access.Source.Factory;
using TUI.Data.Access.Source.Repositories;
using TUI.Data.Access.Source.Unit;
using TUI.Model.Shared.Source;

namespace TUI.Sandbox.Controllers
{
    public abstract class CrudController<T>:BasicController
        where T : class, IIdContainer
    {
        protected readonly IUnit<T> Unit;

        protected CrudController(IUnit<T> unit)
        {
            this.Unit = unit;
        }

        protected abstract void SetViewBagDependencies();

        public ActionResult Index()
        {
            using (var session = this.Unit.GetSession())
            {
                var items = session.GetRepository();
                return View(items.GetAll());
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return this.GetInvalidParameterNotification();
            }
            using (var session = this.Unit.GetSession())
            {
                var info = id ?? -1;
                var element = session.GetRepository().Get(info);
                if (element == null)
                {
                    return GetUnavailableItemNotification();
                }
                return View(element);
            }
        }

        [Authorize]
        public ActionResult Create()
        {
            this.SetViewBagDependencies();
            return View();
        }

        [Authorize]
        public virtual ActionResult Create(T item)
        {
            return this.Creating(item);
        }

        [Authorize]
        private ActionResult Creating(T item)
        {
            if (ModelState.IsValid)
            {
                using (var session = this.Unit.GetSession())
                {
                    var repo = session.GetRepository();
                    repo.Add(item);
                    session.Complete();
                    return RedirectToAction("Index");
                }
            }
            return this.GetErrorNotification();
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.GetInvalidParameterNotification();
            }
            var info = id ?? -1;

            using (var session = this.Unit.GetSession())
            {
                T item = session.GetRepository().Get(info);
                if (item == null)
                {
                    return GetUnavailableItemNotification();
                }

                this.SetViewBagDependencies();
                return View(item);
            }
        }

        [Authorize]
        public virtual ActionResult Edit(T item)
        {
            return Editing(item);
        }

        [Authorize]
        private ActionResult Editing(T item)
        {
            using (var session = this.Unit.GetSession())
            {
                var repo = session.GetRepository();
                if (ModelState.IsValid)
                {
                    repo.SetModified(item);
                    session.Complete();
                    return RedirectToAction("Index");
                }
                this.SetViewBagDependencies();
                return View(item);
            }
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return this.GetInvalidParameterNotification();
            }

            var info = id ?? -1;

            using (var container = this.Unit.GetSession())
            {
                T item = container.GetRepository().Get(info);
                if (item == null)
                {
                    return GetUnavailableItemNotification();
                }
                return View(item);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var session = this.Unit.GetSession())
            {
                var repo = session.GetRepository();
                T item = repo.Get(id);
                repo.Remove(item);
                session.Complete();
                return RedirectToAction("Index");
            }
        }
    }
}