using Autofac;
using Autofac.Integration.Mvc;
using Colors.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Colors.Web.App_Start
{
    public class AutofacConfig
    {
        private static AutofacDependencyResolver _resolver;

        public static IContainer Configuration()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();

            builder.RegisterType<ColorContext>().InstancePerLifetimeScope();
            builder.RegisterType<ColorContext>().As<DbContext>().InstancePerLifetimeScope();

            var container = builder.Build();


            _resolver = new AutofacDependencyResolver(container);

            DependencyResolver.SetResolver(_resolver);

            return container;
        }
    }
}