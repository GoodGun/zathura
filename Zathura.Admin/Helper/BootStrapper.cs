using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Zathura.Core.Infrastructure;
using Zathura.Core.Repository;

namespace Zathura.Admin.Helper
{
    public class BootStrapper
    {
        //runs on boot period
        public static void RunConfig()
        {
            BuildAutoFac();
        }

        private static void BuildAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ContentRepository>().As<IContentRepository>();
            builder.RegisterType<ContentTypeRepository>().As<IContentTypeRepository>();
            builder.RegisterType<ImageRepository>().As<IImageRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();


            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}