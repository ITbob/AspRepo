using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.TimeZone.Source;
using TUI.TimeZone.Source.Api.Google;
using Unity;

namespace TUI.Injection.Source
{
    public class InjectionRegister
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<ITimeZoneApi, GoogleTimeZoneApi>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}
