using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HelloWorld.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute
            (
                name: "MessageApi",
                routeTemplate: "api/message/{apiKey}",
                defaults: new { controller = "Message", action = "Get" }
            );
        }
    }
}
