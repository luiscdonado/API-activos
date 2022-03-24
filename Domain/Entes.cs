using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace API_activos.Domain
{
    public class Entes
    {
        public int id { get; set; }
        public int clase { get; set; }
        public string nombre { get; set; }
        public string ciudad { get; set; }

        public Entes()
        {

        }

        public Entes(int id_, int clase_, string nombre_, string ciudad_)
        {
            this.id = id_;
            this.clase = clase_;
            this.nombre = nombre_;
            this.ciudad = ciudad_;
        }

        public DataTable ListarActivos()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT id, CASE WHEN (clase=0) THEN 'PERSONA' ELSE 'ÁREA' end as ENTE,nombre,ciudad" +
                    " FROM public.entes ORDER BY CLASE,ID;";
                using (NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("CadenaConexion")))
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql))
                    {
                        using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 120;
                            cmd.Connection = conn;
                            cmd.Parameters.Clear();
                            sda.SelectCommand = cmd;
                            sda.Fill(dt);
                        }
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BuscarEnte(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT id, clase,nombre,ciudad" +
                    " FROM public.entes where id=@id";
                using (NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("CadenaConexion")))
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql))
                    {
                        using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 120;
                            cmd.Connection = conn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@id", id);
                            sda.SelectCommand = cmd;
                            sda.Fill(dt);
                        }
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}