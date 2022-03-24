using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace API_activos.Domain
{
    public class Asignar
    {
        public int serial { get; set; }
        public int ente { get; set; }


        public Asignar()
        {

        }

        public string AsignarActivo()
        {
            try
            {
                string sql = string.Empty;
                if (ente == 0)
                {
                    sql = "delete from asignacion " +
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
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            return "Serial: " + serial + " desasignado";
                        }
                    }
                }
                else
                {
                    sql = "insert into asignacion ( id, serial) values(@id,@serial)";
                    using (NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("CadenaConexion")))
                    {
                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql))
                        {

                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 120;
                            cmd.Connection = conn;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@id", ente);
                            cmd.Parameters.AddWithValue("@serial", serial);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            return "Asignado el serial: " + serial + " a la persona o área:" + ente;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool BuscarAsignacion()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select id,serial from asignacion where serial=@serial";
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
                            cmd.Parameters.AddWithValue("@serial", serial);
                            sda.SelectCommand = cmd;
                            sda.Fill(dt);
                        }
                    }
                }

                return (dt.Rows.Count > 0);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}