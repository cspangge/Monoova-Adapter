using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );

            config.Routes.MapHttpRoute(
                name: "ReceivePayment",
                routeTemplate: "api/v1/ReceivePayment"
            );
            
            config.Routes.MapHttpRoute(
                name: "ReceiveInboundDirectCredits",
                routeTemplate: "api/v1/ReceiveInboundDirectCredits"
            );
            
            config.Routes.MapHttpRoute(
                name: "ReceiveInboundDirectDebits",
                routeTemplate: "api/v1/ReceiveInboundDirectDebits"
            );
            
            config.Routes.MapHttpRoute(
                name: "ReceiveDirectEntryDishonours",
                routeTemplate: "api/v1/ReceiveDirectEntryDishonours"
            );
            
        }
    }
}