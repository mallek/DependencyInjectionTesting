using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Web.Http.Dependencies;
using DependencyInjectionTesting.Extensions;

namespace DependencyInjectionTesting
{
    public class MefDependencyResolver : IDependencyResolver
    {
        private CompositionContainer _container;

        public MefDependencyResolver(CompositionContainer container)
        {
            _container = container;
        }

        public void Dispose()
        {
            _container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return _container.GetExportedValueByType(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetExportedValuesByType(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}