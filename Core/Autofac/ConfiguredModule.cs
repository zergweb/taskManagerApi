using Autofac;
using Microsoft.Extensions.Configuration;

namespace Core.Autofac
{
    public abstract class ConfiguredModule : Module, IConfiguredModule
    {
        public IConfiguration Configuration { get; set; }
    }
}
