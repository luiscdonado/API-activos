using System.Net.Http.Headers;
using System.Web.Http;

namespace API_activos
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Listar activos",
                routeTemplate: "activos/listar"
            );

            config.Routes.MapHttpRoute(
                name: "BuscarSerial",
                routeTemplate: "activos/buscar-serial/{Id}",
                defaults: new { controller = "BuscarSerial", Id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "BuscarTipo",
                routeTemplate: "activos/buscar-tipo/{tipo}",
                defaults: new { controller = "BuscarSerial", tipo = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "BuscarFecha",
                routeTemplate: "activos/buscar-fecha"
            );

            config.Routes.MapHttpRoute(
                name: "AgregarActivo",
                routeTemplate: "activos/activo-nuevo"
            );

            config.Routes.MapHttpRoute(
                name: "ActualizarActivo",
                routeTemplate: "activos/activo-actualizar"
            );

            config.Routes.MapHttpRoute(
                name: "Listar entes",
                routeTemplate: "entes/listar"
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
