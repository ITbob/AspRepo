using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.TimeZone.Source;
using Unity;

namespace TUI.Injection.Source
{
    public class InjectionResolver
    {
        public static void Resolve(IUnityContainer container)
        {
            TimeZoneHelper.Api = container.Resolve<ITimeZoneApi>();
        }
    }
}
