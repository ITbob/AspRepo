using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TUI.Data.Access.Source.Unit;
using TUI.Places.Source;

namespace TUI.Project1.Controllers
{
    public class CitiesController : CrudController<City>
    {
        private readonly IUnit<Location> _locationUnit;


        public CitiesController(IUnit<City> unit, IUnit<Location> locationUnit) : base(unit)
        {
            this._locationUnit = locationUnit;
        }

        protected override void SetViewBagDependencies()
        {
            using (var session = this._locationUnit.GetSession())
            {
                ViewBag.LocationId = new SelectList(
                    session.GetRepository().GetAll(), "Id", "Description");
            }
        }

        // https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Create([Bind(Include = "Id, Name, LocationId")] City city)
        {
            return base.Create(city);
        }

        // POST: Cities/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Edit([Bind(Include = "Id, Name, LocationId")] City city)
        {
            return base.Edit(city);
        }
    }
}