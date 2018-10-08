using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Data.Access.Source.Repositories;
using TUI.Login.source;
using TUI.Model.Shared.Source;
using TUI.Places.Source;
using TUI.Transportations.Air;
using TUI.Transportations.Air.Source;

namespace TUI.Data.Access.Source.Factory
{
    public static class RepoFactory
    {
        private static Dictionary<Type, Func<Object>> _list 
            = new Dictionary<Type, Func<Object>>()
            {
                { typeof(Flight), () => new FlightRepository()},
                { typeof(Location), () => new LocationRepository()},
                { typeof(City), () => new CityRepository()},
                { typeof(Plane), () => new PlaneRepository()},
                { typeof(Airport), () => new AirportRepository()},
                { typeof(HistoryLine), () => new HistoryLineRepository()},
                { typeof(User), () => new UserRepository()},
            };

        public static TuiContextRepository<T> GetTuiContextRepo<T>()
            where T:class, IIdContainer
        {
            return (TuiContextRepository<T>) _list[typeof(T)]();
        }
    }
}
