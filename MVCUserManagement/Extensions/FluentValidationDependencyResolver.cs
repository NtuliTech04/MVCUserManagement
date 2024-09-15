using FluentValidation;
using System.Collections.Generic;
using System.Web.Mvc;
using System;

namespace MVCUserManagement.Extensions
{
    public class FluentValidationDependencyResolver : IDependencyResolver
    {
        private readonly IDependencyResolver _resolver;

        public FluentValidationDependencyResolver()
        {
            _resolver = DependencyResolver.Current;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsAssignableFrom(typeof(IValidator)))
            {
                return Activator.CreateInstance(serviceType);
            }

            return _resolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolver.GetServices(serviceType);
        }
    }
}