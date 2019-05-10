using Microsoft.Extensions.DependencyInjection;
using System;

namespace NPV.Tests
{
    public class ServiceTestsLocator
    {
        public ServiceCollection serviceCollection;

        public ServiceTestsLocator()
        {
            serviceCollection = new ServiceCollection();
        }

        public TService GetService<TService>(Type serviceType, Type implementationType)
        {
            serviceCollection.AddTransient(serviceType, implementationType);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider.GetService<TService>();
        }
    }
}
