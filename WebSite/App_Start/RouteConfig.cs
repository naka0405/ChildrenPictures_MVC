using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ChildCardViewModels", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

  //   <connectionStrings>
  //  <add name = "DataContext" connectionString="Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=DataContext-20200731131753; Integrated Security=True; MultipleActiveResultSets=True; AttachDbFilename=|DataDirectory|DataContext-20200731131753.mdf"
  //    providerName="System.Data.SqlClient" />
  //</connectionStrings>
}
