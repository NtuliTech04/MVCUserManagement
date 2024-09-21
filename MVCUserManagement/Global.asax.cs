using FluentValidation.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MVCUserManagement.Abstractions;
using MVCUserManagement.Abstractions.Repositories;
using MVCUserManagement.Extensions;
using MVCUserManagement.Persistence.Context;
using MVCUserManagement.Persistence.Migrations;
using System;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCUserManagement
{
    public class MvcApplication : HttpApplication
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Database Initializing & Seeding
            switch (HttpContext.Current.IsDebuggingEnabled)
            {
                case false:
                    #region Production
                    #endregion
                    break;
                case true:
                    #region Development
                    //Initialize Database
                    Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserManagementDbContext, Configuration>());

                    //Creates Database on Startup
                    using (var context = new UserManagementDbContext())
                    {
                        context.Database.Initialize(force: false); //Initialize DB only once.
                    }
                    #endregion
                    break;
            }

            //Configure DI Services
            var services = new ServiceCollection();
            RegisterServices(services);
            ServiceProvider = services.BuildServiceProvider();

            //Setup MVC Dependency Resolver
            DependencyResolver.SetResolver(new DefaultDependencyResolver(ServiceProvider));


            //Register FluentValidation
            FluentValidationModelValidatorProvider.Configure();
            DependencyResolver.SetResolver(new FluentValidationDependencyResolver());
        }

        // Configure Dependencies
        private void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IUserRolesRepository, UserRolesRepository>();
        }
    }
}
