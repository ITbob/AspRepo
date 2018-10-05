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

            //TuiDataHelper.Initialize(ConfigurationManager.ConnectionStrings["TUIDefault"].ToString());
            //AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
            UnityConfig.RegisterComponents();

            //TuiDataHelper.Delete();
            //TuiDataHelper.Initialize(); //If set to true the initializer is run even if it has already been run.       
            TuiDataHelper.SetCache(Server.MapPath("~/App_Data/efcache.xml"));
        }
    }
}
