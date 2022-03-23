using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace API_activos.Domain
{
    public class ActualizaActivo
    {        
        public int serial { get; set; }
        public int serialNuevo { get; set; }
        public DateTime fecha_baja { get; set; }


        public ActualizaActivo()
        {

        }

        public string Actualizar()
        {
            try
            {
                string sql = string.Empty;
                if (serialNuevo >0)
                {
                    sql = "update PUBLIC.activos " +
                        " 	set serial=@serialNuevo" +
                        " 	,fecha_baja=fecha_baja" +
                        " 	where serial=@serial";
                    using (NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("CadenaConexion")))
                    {
                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql))
                        {

                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 120;
                            cmd.Connection = conn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@serial", serial);
                            cmd.Parameters.AddWithValue("@serialNuevo", serialNuevo);
                            cmd.Parameters.AddWithValue("@fecha_baja", fecha_baja);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            return "Actualizado serial y fecha de baja";
                        }
                    }
                }
                else
                {
                    sql = "update PUBLIC.activos " +
                        " 	set fecha_baja=fecha_baja" +
                        " 	where serial=@serial";
                    using (NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("CadenaConexion")))
                    {
                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql))
                        {

                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 120;
                            cmd.Connection = conn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@serial", serial);
                            cmd.Parameters.AddWithValue("@fecha_baja", fecha_baja);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            return "Actualizada fecha de baja";
                        }
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}