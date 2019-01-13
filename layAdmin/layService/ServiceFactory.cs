using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace layService
{
    public static class ServiceFactory
    {

        private static IContainer _container { get; set; }

        public static IT GetService<T, IT>()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<T>().As<IT>();
            _container = builder.Build();

            using(var scope = _container.BeginLifetimeScope())
            {
                return scope.Resolve<IT>();
            }
        }
    }
}
