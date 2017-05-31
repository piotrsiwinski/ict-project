using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using Autofac.Integration.Mvc;
using SmartCardReader.ServiceLayer.Configuration;
using SmartCardReader.ServiceLayer.DI;
using SmartCardReader.WebUI.Configuration;

namespace SmartCardReader.WebUI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfiguration.Configure();
            AreaRegistration.RegisterAllAreas();
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(AutofacResolver.GetContainer()));
        }
    }
}