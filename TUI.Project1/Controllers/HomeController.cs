using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TUI.Data.Access.Source;
using TUI.Places.Source;
using TUI.Transportations.Air;

namespace TUI.Project1.Controllers
{
    public class HomeController : Controller
    {
        private IEnumerable<Airport> _airports;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAirports(String value)
        {
            var airportTextInfo = value;

            this._airports = DataAccessLayer.GetAllAirports();

            var matchedAirport = this._airports.Where(airport =>
                airport.Name.ToLower().Contains(airportTextInfo.ToLower())
                || (airport.City != null && airport.City.Name.ToLower().Contains(airportTextInfo.ToLower()))
                ).ToList().
                    Select(x => // circular references that json cannot serialize
                    new {Id = x.Id,
                        Name = x.Name,
                        City = x.City.Name }); 

            Debug.WriteLine($"{value} - airports count {matchedAirport.Count()}");
            foreach (var selectedAirport in matchedAirport)
            {
                Debug.WriteLine($"{selectedAirport.Name} ({selectedAirport.City})");
            }

            if(this.IsFound(airportTextInfo, matchedAirport))
            {
                return Json(new List<Airport>(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(matchedAirport.ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        private Boolean IsFound(String value, IEnumerable<dynamic> airports)
        {
            return airports.Count() == 1
                && (value.ToLower() == airports.First().City.ToLower()
                        || value.ToLower() == airports.First().Name.ToLower());
        }

        private Boolean HasAirport(String airportName)
        {
            return DataAccessLayer.GetAllAirports().
                Where(airport => airport.Name == airportName).Any();
        }

        [HttpPost]
        public ActionResult GetFlights(String departureName, String beginningDate, String arrivalName, String endingDate)
        {
            if (!HasAirport(departureName))
            {
                return RedirectToAction("index","Error", new { ErrorMessage = "The airport of departure is not found." });
            }

            if (!HasAirport(arrivalName))
            {
                return RedirectToAction("index", "Error", new { ErrorMessage = "The airport of arrival is not found." });
            }

            var departureAirport = DataAccessLayer.GetAllAirports().
                Where(airport => airport.Name == departureName).Single();

            var arrivalAirport = DataAccessLayer.GetAllAirports().
                Where(airport => airport.Name == arrivalName).Single();

            if(IsDate(beginningDate) && IsDate(endingDate))
            {
                ViewBag.flights = DataAccessLayer.
                GetFlights(departureAirport, arrivalAirport, DateTime.Parse(beginningDate), DateTime.Parse(endingDate));
            }
            else
            {
                ViewBag.flights = DataAccessLayer.
                GetFlights(departureAirport, arrivalAirport);
            }

            return View("Index");// Json(flights, JsonRequestBehavior.AllowGet);
        }

        private Boolean IsDate(String value)
        {
            try
            {
                DateTime.Parse(value);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}