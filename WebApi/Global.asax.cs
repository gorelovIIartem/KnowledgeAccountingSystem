using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using BLL;
using WebApi.Ninject;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutomapperConfiguration>());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            NinjectModule registration = new NinjectRegistration();
            var kernel = new StandardKernel(registration);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}
