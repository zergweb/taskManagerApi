using Microsoft.Extensions.Configuration;

namespace Core.Autofac
{
    public interface IConfiguredModule
    {
        IConfiguration Configuration { get; set; }
    }
}
