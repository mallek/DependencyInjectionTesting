using System.ComponentModel.Composition.Hosting;

namespace DependencyInjectionTesting.Models
{
    public abstract class ObjectBase
    {
        public static CompositionContainer Container { get; set; }
    }
}