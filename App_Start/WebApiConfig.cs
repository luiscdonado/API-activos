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

            config.Routes.MapHttpRoute(
                name: "Asignar activo",
                routeTemplate: "entes/asignar"
            );

            config.Routes.MapHttpRoute(
                name: "Buscar por asignado",
                routeTemplate: "activos/buscar-asignado/{id}",
                defaults: new { controller = "BuscarAsignado", id = RouteParameter.Optional }
            );

            // Set Swagger as default start page

            config.Routes.MapHttpRoute(
                name: "swagger_root",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new Swashbuckle.Application.RedirectHandler((message => message.RequestUri.ToString()), "swagger"));
            

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
