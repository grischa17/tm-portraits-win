using TuRM.Portrait.Models;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TuRM.Portrait.Other;

namespace TuRM.Portrait
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig<DataModule<ApplicationDbContext>>.ConfigureContainer();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
}
