using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web.Mvc;

namespace DependencyInjectionTesting
{
    public class MefControllerFactory : DefaultControllerFactory
    {
        private readonly CompositionContainer _container; // This container will work like an IOC container

        public MefControllerFactory(CompositionContainer container)
        {
            _container = container;
        }

        //protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        //{
        //    // Use extension methods to get the requested controller type
        //    var export = _container.GetExportedValueByType(controllerType);

        //    // If none was found, just use the default constructor for this controller type
        //    return null == export ? base.GetControllerInstance(requestContext, controllerType) : (IController)export;
        //}

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            Lazy<object, object> export = _container.GetExports(controllerType, null, null).FirstOrDefault();

            //here if the controller object is not found (resulted as null) we can go ahead and get the default controller.
            //This means that in order to get the Controller we have to Export it first which will be shown later in this post
            return null == export ? base.GetControllerInstance(requestContext, controllerType) : (IController)export.Value;
        }


        public override void ReleaseController(IController controller)
        {
            //this is were the controller gets disposed
            ((IDisposable)controller).Dispose();
        }
    }
}