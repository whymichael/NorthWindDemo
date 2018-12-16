using Autofac;
using Autofac.Integration.Mvc;
using NorthwindWebApp.BusinessLayer;
using NorthwindWebApp.DataAccessLayer;
using NorthwindWebApp.Models;
using NorthwindWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace NorthwindWebApp
{
    public class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Base set-up
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            
            var baseType = typeof(IAutoInject);

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                            .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                            .AsImplementedInterfaces().InstancePerLifetimeScope().PropertiesAutowired();


            // Register dependencies
            SetUpRegistration(builder);


            // Build registration.
            var container = builder.Build();

            // Set the dependency resolver to be Autofac.
            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void SetUpRegistration(ContainerBuilder builder)
        {
            builder.RegisterType<NORTHWNDEntities>().As<DbContext>();
            builder.RegisterType<CategoriesDAL>().As<ICategoriesDAL>();
            builder.RegisterType<CategoriesBL>().As<ICategoriesBL>();
        }


    }
}