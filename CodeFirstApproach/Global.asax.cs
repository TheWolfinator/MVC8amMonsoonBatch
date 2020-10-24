using CodeFirstApproach.App_Start;
using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CodeFirstApproach
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilter(GlobalFilters.Filters);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EmployeeContext>());
            
        }
    }
}
