using InteractivePreGeneratedViews;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TUI.Data.Access.Source;

namespace TUI.Project1
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            UnityConfig.RegisterComponents();

            Database.SetInitializer(new TuiInitializer());
            SetCache(Server.MapPath("~/App_Data/efcache.xml"));
        }


        private static void SetCache(String cachePath)
        {
            using (var ctx = new TuiContext())
            {
                try
                {
                    InteractiveViews
                        .SetViewCacheFactory(
                            ctx,
                            new SqlServerViewCacheFactory(ctx.Database.Connection.ConnectionString));
                }
                catch (Exception)
                {
                    Debug.WriteLine("not available");
                }

            }
        }
    }
}
