using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_activos.Domain;

namespace API_activos.Controllers
{
    public class ActivosController : ApiController
    {

        [Route("~/activos/listar")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                Activos activos = new Activos();
                DataTable dt = activos.ListarActivos();

                if (dt.Rows.Count > 0)
                {
                    return Request.CreateResponse(dt);
                }// Fin del if.
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay activos para listar"); // Se retorna un mensaje de error.
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("~/activos/buscar-serial/{Id}")]
        [HttpGet]
        public HttpResponseMessage GetSerial(int Id)
        {
            try
            {
                Activos activos = new Activos();
                DataTable dt = activos.BuscarActivosSerial(Id);

                if (dt.Rows.Count > 0)
                {
                    return Request.CreateResponse(dt);
                }// Fin del if.
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay activos para listar"); // Se retorna un mensaje de error.
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [Route("~/activos/buscar-tipo/{tipo}")]
        [HttpGet]
        public HttpResponseMessage GetTipo(int tipo)
        {
            try
            {
                Activos activos = new Activos();
                DataTable dt = activos.BuscarActivosTipo(tipo);

                if (dt.Rows.Count > 0)
                {
                    return Request.CreateResponse(dt);
                }// Fin del if.
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay activos para listar"); // Se retorna un mensaje de error.
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("~/activos/buscar-fecha")]
        [HttpPost]
        public IHttpActionResult Recibir([FromBody] Fecha fecha)
        {
            try
            {
                var formats = new[] { "yyyy-M-d", "yyyy-M-dd", "yyyy-MM-d", "yyyy-MM-dd" };
                DateTime fecha_compra;
                if (DateTime.TryParseExact(fecha.fecha, formats, null, DateTimeStyles.None, out fecha_compra))
                {
                    //parsed correctly
                }
                else
                {
                    return BadRequest("El campo de fecha no tiene la longitud necesaria, el formato debe ser 'YYYY-MM-DD'");
                }



                Activos activos = new Activos();
                DataTable dt = activos.BuscarActivosFecha(fecha_compra);

                if (dt.Rows.Count > 0 && ModelState.IsValid)
                {
                    return Ok(dt);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        return BadRequest("No hay activos con la fecha de compra solicitada");
                    }
                    else
                    {
                        return BadRequest("Error en la petición");
                    }
                }
            }
            catch (Exception ex)
            {
                //return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return InternalServerError(ex);
            }


        }


        [Route("~/activos/activo-nuevo")]
        [HttpPost]
        public IHttpActionResult Nuevo([FromBody] Activos activo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (activo.nombre.Length < 3)
                    {
                        return BadRequest("Debe poner un nombre mas largo");
                    }

                    if (activo.descripcion.Length < 3)
                    {
                        return BadRequest("Debe poner una descripción mas especifica");
                    }

                    if (!activo.BuscarTipo(activo.tipo))
                    {
                        return BadRequest("El tipo no existe");
                    }

                    DataTable dt = activo.BuscarActivosSerial(activo.serial);
                    if (dt.Rows.Count > 0)
                    {
                        return BadRequest("El serial ya existe");
                    }

                    if (activo.fecha_compra > activo.fecha_baja && activo.fecha_baja > new DateTime(1960, 1, 1))
                    {
                        return BadRequest("La fecha de compra no puede ser mayor a la fecha de baja");
                    }

                    if (!activo.BuscarEstado(activo.estado))
                    {
                        return BadRequest("El estado no existe");
                    }

                    activo.AgregarActivoNuevo();

                    return Ok();
                }
                else
                {
                    string message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.Exception.Message));
                    return BadRequest(message);

                }
            }
            catch (Exception ex)
            {
                //return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return InternalServerError(ex);
            }
        }

        [Route("~/activos/activo-actualizar")]
        [HttpPost]
        public IHttpActionResult Actualizar([FromBody] ActualizaActivo activo_actualiza)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Activos activo = new Activos();
                    DataTable dt = activo.BuscarActivosSerial(activo_actualiza.serial);
                   
                    if (dt.Rows.Count == 0)
                    {
                        return BadRequest("El serial no existe");
                    }
                    activo.fecha_compra = (DateTime)(dt.Rows[0]["fecha_compra"]);


                    dt = activo.BuscarActivosSerial(activo_actualiza.serialNuevo);
                    if (dt.Rows.Count > 0)
                    {
                        return BadRequest("El serial que intenta cambiar ya existe");
                    }

                    

                    if (activo.fecha_compra > activo_actualiza.fecha_baja && activo_actualiza.fecha_baja > new DateTime(1960, 1, 1))
                    {
                        return BadRequest("La fecha de compra no puede ser mayor a la fecha de baja");
                    }

                    string resultado=activo_actualiza.Actualizar();

                    return Ok(resultado);
                }
                else
                {
                    string message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.Exception.Message));
                    return BadRequest(message);

                }
            }
            catch (Exception ex)
            {
                //return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return InternalServerError(ex);
            }
        }

        [Route("~/entes/listar")]
        [HttpGet]
        public HttpResponseMessage ListarEntes()
        {
            try
            {
                Entes entes = new Entes();
                DataTable dt = entes.ListarActivos();

                if (dt.Rows.Count > 0)
                {
                    return Request.CreateResponse(dt);
                }// Fin del if.
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay areas o personas para listar"); // Se retorna un mensaje de error.
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
