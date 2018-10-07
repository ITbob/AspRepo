using System.Web.Mvc;
using TUI.Data.Access.Source.Unit;
using TUI.Places.Source;
using TUI.Transportations.Air;
using TUI.Transportations.Air.Source;

namespace TUI.Sandbox.Controllers
{
    public class FlightsController : CrudController<Flight>
    {
        private readonly IUnit<Airport> _airportUnit;
        private readonly IUnit<Plane> _planeUnit;

        public FlightsController(IUnit<Flight> unit
            , IUnit<Airport> airportUnit
            , IUnit<Plane> planeUnit) : base(unit)
        {
            this._airportUnit = airportUnit;
            this._planeUnit = planeUnit;
        }

        protected override void SetViewBagDependencies()
        {
            using (var session = this._airportUnit.GetSession())
            {
                var airports = session.GetRepository().GetAll();
                ViewBag.DepartureId = new SelectList(airports, "Id", "Description");
                ViewBag.ArrivalId = new SelectList(airports, "Id", "Description");
            }

            using (var session = this._planeUnit.GetSession())
            {
                ViewBag.PlaneId = new SelectList(session.GetRepository().GetAll(), "Id", "Description");
            }
        }

        // https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Create([Bind(Include = "Id,StartDate,PlaneId,DepartureId,ArrivalId")] Flight item)
        {
            return base.Create(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Edit([Bind(Include = "Id,StartDate,PlaneId,DepartureId,ArrivalId")] Flight item)
        {
            return base.Edit(item);
        }
    }
}