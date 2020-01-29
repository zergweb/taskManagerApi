using Autofac;
using Core.Autofac;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Infrastructure.Model;

namespace Infrastructure
{
    public class DomainAutofacModule : ConfiguredModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            var config = new DbConfig();
            Configuration.Bind("Db", config);
  
            builder.RegisterType<BookService>().WithParameter("config", config);
        }     
    }

}
