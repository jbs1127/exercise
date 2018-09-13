using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using HW.Api.Common;
using HW.Api.Repository;

namespace HW.Api
{
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DbGreeter>().As<IGreeter>(); // db
            builder.RegisterType<ConsoleGreeter>().As<IGreeter>(); // console
            builder.RegisterType<MobileGreeter>().As<IGreeter>(); // mobile

            builder.RegisterType<DbWriter>().As<IWriter>(); // db
            builder.RegisterType<ConsoleWriter>().As<IWriter>(); // console
            builder.RegisterType<MobileWriter>().As<IWriter>(); // mobile

            builder.RegisterType<GreetingRepository>().As<IRepository>();

            builder.Register<IRepository>(
                (c) =>
                {
                    var storageProvider = ConfigurationManager.AppSettings["greeting:storageProvider"];
                    switch (storageProvider)
                    {
                        case "db":
                            return new GreetingRepository();
                        default:
                            throw new ArgumentException("Invalid storage provider"); // add descriptive error
                    }
                }
            );

            builder.Register<IGreeter>(
                (c) =>
                {
                    var storageProvider = ConfigurationManager.AppSettings["greeting:storageProvider"];
                    switch (storageProvider)
                    {
                        case "console":
                            return new ConsoleGreeter();
                        case "mobile":
                            return new MobileGreeter();
                        case "db":
                            return new DbGreeter(c.Resolve<IRepository>());
                        default:
                            throw new ArgumentException("Invalid storage provider"); // add descriptive error
                    }
                }
            );

            builder.Register<IWriter>(
                (c) =>
                {
                    var storageProvider = ConfigurationManager.AppSettings["greeting:storageProvider"];
                    switch (storageProvider)
                    {
                        case "console":
                            return new ConsoleWriter();
                        case "mobile":
                            return new MobileWriter();
                        case "db":
                            return new DbWriter(c.Resolve<IRepository>());
                        default:
                            throw new ArgumentException("Invalid storage provider"); // add descriptive error
                    }
                }
            );

            Container = builder.Build();

            return Container;
        }
    }
}