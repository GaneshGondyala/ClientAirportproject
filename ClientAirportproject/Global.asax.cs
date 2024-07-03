using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ClientAirportproject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["PlaneID"] = 31;
            Application["AddressID"] = 101;
            Application["PilotID"] = 31;
            Application["MgrID"] = 31;
            Application["HangerID"] = 101;
            Application["pOwnerID"] = 41;
          
        }
    }
}
