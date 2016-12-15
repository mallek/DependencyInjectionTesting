using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace DependencyInjectionTesting.Bootstrapper
{
    public static class MEFLoader
    {
        //Dependancy Injection Container initialization, builds a catalog of interfaces to types

        public static CompositionContainer Init(bool useCaching)
        {
            return Init(null, useCaching);
        }

        public static CompositionContainer Init(ICollection<ComposablePartCatalog> catalogParts, bool useCaching)
        {
            AggregateCatalog catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Data.DAI.SQLRepository).Assembly));

            if (catalogParts != null)
                foreach (var part in catalogParts)
                    catalog.Catalogs.Add(part);

            CompositionContainer container = new CompositionContainer(catalog);

            return container;
        }
    }
}
