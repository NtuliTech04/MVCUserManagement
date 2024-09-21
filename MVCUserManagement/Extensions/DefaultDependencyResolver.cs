using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Web.Mvc;
using System;

namespace MVCUserManagement.Extensions
{
    public class DefaultDependencyResolver : IDependencyResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public DefaultDependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _serviceProvider.GetServices(serviceType);
        }
    }
}