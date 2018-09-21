using CrossCutting.DependecyResolver.Dependency;
using TaskList.Helpers;
using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TaskList
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();


            var config = new HttpConfiguration();

            var container = new UnityContainer();
            DependencyRegister.Register(container);
            DependencyResolver.SetResolver(new UnityResolver(container));

            //ConfigureWebApi(config);
        }
    }
}
