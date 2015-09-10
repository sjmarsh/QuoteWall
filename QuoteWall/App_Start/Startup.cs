using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using QuoteWall.Infrastructure.Modules;
using QuoteWall.App_Start;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QuoteWall
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());

            WebApiConfig.Register(config);

            appBuilder.UseWebApi(config);
            appBuilder.UseNinjectMiddleware(() => CreateKernel(config));
            appBuilder.UseNinjectWebApi(config);
        }
 
        public static IKernel CreateKernel(HttpConfiguration config)
        {
            var kernel = new StandardKernel();
 
            kernel.Load<QuoteWallModule>();
              // load other modules here
           
            return kernel;
        }

    }
}