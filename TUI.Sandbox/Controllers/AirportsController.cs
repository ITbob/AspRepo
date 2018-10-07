using System.Net;
using System.Web.Mvc;
using TUI.Data.Access.Source.Factory;
using TUI.Data.Access.Source.Unit;
using TUI.Places.Source;

namespace TUI.Sandbox.Controllers
{
    public class AirportsController : CrudController<Airport>
    {
        private readonly IUnit<Location> _locationUnit;
        private readonly IUnit<City> _cityUnit;


        public AirportsController(IUnit<Airport> unit, IUnit<City> cityUnit, IUnit<Location> locationUnit) :base(unit)
        {
            this._cityUnit = cityUnit;
            this._locationUnit = locationUnit;
        }

        protected override void SetViewBagDependencies()
        {
            using (var session = this._cityUnit.GetSession())
            {
                ViewBag.CityId = new SelectList(
                    session.GetRepository().GetAll(), "Id", "Name");

            }

            using (var session = this._locationUnit.GetSession())
            {
                ViewBag.LocationId = new SelectList(
                    session.GetRepository().GetAll(), "Id", "Description");
            }
        }

        // https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Create([Bind(Include = "Id,LocationId,Name,CityId")] Airport item)
        {
            return base.Create(item);
        }

        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Edit([Bind(Include = "Id,LocationId,Name,CityId")] Airport item)
        {
            return base.Edit(item);
        }
    }
}