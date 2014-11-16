namespace BullsAndCows.WebAPI
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Microsoft.Owin.Security.OAuth;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();
            ///api/games/GAME_ID/guess

            config.Routes.MapHttpRoute(
                name: "Play",
                routeTemplate: "api/games/{id}/guess",
                defaults: new
                {
                    controller = "Games",
                    action = "Play",
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}
