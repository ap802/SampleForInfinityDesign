using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using MySMA.Repositories;
using System.Web.Optimization;

namespace MySMA
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new DbInitializer());
        }
    }
}
