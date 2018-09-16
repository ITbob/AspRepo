using InteractivePreGeneratedViews;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            //init when unsynchronised
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (var ctx = new TuiContext())
            {
                InteractiveViews
                    .SetViewCacheFactory(
                        ctx,
            new FileViewCacheFactory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\YOUR_APP_NAME\EFCache\"));
            }
            DataAccessLayer.Delete();
            DataAccessLayer.Initialize(); //If set to true the initializer is run even if it has already been run.       
        }
    }
}
