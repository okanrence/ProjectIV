using Autofac;
//using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ProjectIV.Core.Infrastructure;
using ProjectIV.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ProjectIV.WebApi.App_Start
{
    public class DIConfig
    {
        public static void RegisterDependencies()
        {
            //bool isProduction = true;
            //isProduction = false;

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.Register(c => new StaffServices()).As<IStaffServices>().InstancePerRequest();
            builder.Register(c => new ClientServices()).As<IClientServices>().InstancePerRequest();
            builder.Register(c => new CaseServices()).As<ICaseServices>().InstancePerRequest();

            //builder.Register(c => new StaffServices_Fake()).As<IStaffServices>().InstancePerRequest();
            //builder.Register(c => new ClientServices_Fake()).As<IClientServices>().InstancePerRequest();
            //builder.Register(c => new CaseServices_Fake()).As<ICaseServices>().InstancePerRequest();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver =
                 new AutofacWebApiDependencyResolver(container);

        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}