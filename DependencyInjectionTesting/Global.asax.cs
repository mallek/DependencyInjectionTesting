using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DependencyInjectionTesting.Bootstrapper;
using DependencyInjectionTesting.Models;

namespace DependencyInjectionTesting
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Get the types for this assembly (Feeds.Web)
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var partsCatalog = new List<ComposablePartCatalog>() { catalog };

            // Initialize the DI container
            ObjectBase.Container = MEFLoader.Init(catalogParts: partsCatalog, useCaching: true);

            // Setup the DI resolver (MEF)
            var resolver = new MefDependencyResolver(ObjectBase.Container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            // Set up a controller factory using the DI container
            //IControllerFactory mefControllerFactory = new MefControllerFactory(ObjectBase.Container);
            //ControllerBuilder.Current.SetControllerFactory(mefControllerFactory);
        }
    }
}
