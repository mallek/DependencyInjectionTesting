using System.ComponentModel.Composition;
using DependencyInjectionTesting.Data.Interfaces;

namespace DependencyInjectionTesting.Data.DAI
{
    [Export(typeof(IReadOnlyRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SQLRepository : IReadOnlyRepository
    {
        public string Get()
        {
            return "Sql Repository";
        }
    }
}