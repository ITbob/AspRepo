using System.Web.Mvc;
using TUI.Data.Access.Source.Unit;
using TUI.Places.Source;
using TUI.Transportations.Air;
using TUI.Transportations.Air.Source;

namespace TUI.Project1.Controllers
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
        public override ActionResult Create([Bind(Include = "Id,StartDate,PlaneId,DepartureId,ArrivalId")] Flight flight)
        {
            return base.Create(flight);
        }

        // POST: Cities/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Edit([Bind(Include = "Id,StartDate,PlaneId,DepartureId,ArrivalId")] Flight flight)
        {
            return base.Edit(flight);
        }
    }
}

/*
         public ActionResult Create()
        {
            using (var container = ContainerFactory.Create())
            {
                ViewBag.DepartureId = new SelectList(container.GetRepository<Airport>().GetAll(), "Id", "Description");
                ViewBag.ArrivalId = new SelectList(container.GetRepository<Airport>().GetAll(), "Id", "Description");
                ViewBag.PlaneId = new SelectList(container.GetRepository<Plane>().GetAll(), "Id", "Description");
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,PlaneId,DepartureId,ArrivalId")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                using (var unit = ContainerFactory.Create())
                {
                    var repo = unit.GetRepository<Flight>();
                    repo.Add(flight);
                    unit.Complete();
                    return RedirectToAction("Index");

                }
            }
            using (var container = ContainerFactory.Create())
            {
                //ViewBag.LocationId = new SelectList(container.GetRepository<Location>().GetAll(), "Id", "Id", city.LocationId);
                return RedirectToAction("index", "Notification", new { notification = "An error happened, sorry." });
            }
        }

        public ActionResult Index()
        {
            using (var unit = ContainerFactory.Create())
            {
                var flights = unit.GetRepository<Flight>();
                return View(flights.GetAll());
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return this.GetInvalidParameterNotification();
            }

            var info = id ?? -1;

            using (var container = ContainerFactory.Create())
            {
                Flight city = container.GetRepository<Flight>().Get(info);
                if (city == null)
                {
                    return GetUnavailableItemNotification();
                }
                return View(city);
            }
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return this.GetInvalidParameterNotification();
            }
            using (var unit = ContainerFactory.Create())
            {
                var info = id ?? -1;
                var flight = unit.GetRepository<Flight>().Get(info);
                if (flight == null)
                {
                    return GetUnavailableItemNotification();
                }
                return View(flight);
            }
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var container = ContainerFactory.Create())
            {
                var repo = container.GetRepository<Flight>();
                Flight flight = repo.Get(id);
                repo.Remove(flight);
                container.Complete();
                return RedirectToAction("Index");
            }
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.GetInvalidParameterNotification();
            }
            var info = id ?? -1;

            using (var container = ContainerFactory.Create())
            {
                Flight flight = container.GetRepository<Flight>().Get(info);
                if (flight == null)
                {
                    return GetUnavailableItemNotification();
                }

                ViewBag.PlaneId = new SelectList(container.GetRepository<Plane>().GetAll(), "Id", "Description", flight.PlaneId);
                ViewBag.DepartureId = new SelectList(container.GetRepository<Airport>().GetAll(), "Id", "Description", flight.DepartureId);
                ViewBag.ArrivalId = new SelectList(container.GetRepository<Airport>().GetAll(), "Id", "Description", flight.ArrivalId);
                return View(flight);
            }
        }

        // POST: Cities/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlaneId,StartDate,DepartureId,ArrivalId")] Flight flight)
        {
            using (var container = ContainerFactory.Create())
            {
                var repo = container.GetRepository<Flight>();
                if (ModelState.IsValid)
                {
                    repo.SetModified(flight);
                    container.Complete();
                    return RedirectToAction("Index");
                }
                ViewBag.PlaneId = new SelectList(container.GetRepository<Plane>().GetAll(), "Id", "Description", flight.PlaneId);
                ViewBag.DepartureId = new SelectList(container.GetRepository<Airport>().GetAll(), "Id", "Description", flight.DepartureId);
                ViewBag.ArrivalId = new SelectList(container.GetRepository<Airport>().GetAll(), "Id", "Description", flight.ArrivalId);
                return View(flight);
            }
        }
*/
