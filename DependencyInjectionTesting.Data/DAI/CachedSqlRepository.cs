using System.ComponentModel.Composition;
using DependencyInjectionTesting.Data.Interfaces;

namespace DependencyInjectionTesting.Data.DAI
{
    [Export("Cached", typeof(IReadOnlyRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CachedSqlRepository : IReadOnlyRepository
    {
        public string Get()
        {
            return "Cached Sql Repository";
        }
    }
}