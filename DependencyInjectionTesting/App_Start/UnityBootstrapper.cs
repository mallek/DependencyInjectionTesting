using System.Web.Mvc;
using DependencyInjectionTesting.Controllers;
using DependencyInjectionTesting.Data.DAI;
using DependencyInjectionTesting.Data.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace DependencyInjectionTesting
{
    public class UnityBootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here  
            //This is the important line to edit  
            container.RegisterType<IReadOnlyRepository, SQLRepository>();
            container.RegisterType<IReadOnlyRepository, SQLRepository>("Sql");
            container.RegisterType<IReadOnlyRepository, CachedSqlRepository>("Cached");

            container.RegisterType<HomeController>(
    new InjectionConstructor(                        // Explicitly specify a constructor
        new ResolvedParameter<IReadOnlyRepository>("Cached") // Resolve parameter of type IRepository using name "Client"
    )
);



            RegisterTypes(container);
            return container;
        }
        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}