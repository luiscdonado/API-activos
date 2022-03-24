using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace API_activos.Domain
{
    public class Activos
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int tipo { get; set; }
        public int serial { get; set; }
        public int num_inventario { get; set; }
        public string peso { get; set; }
        public string alto { get; set; }
        public string ancho { get; set; }
        public string largo { get; set; }
        public int valor { get; set; }
        public DateTime fecha_compra { get; set; }
        public DateTime fecha_baja { get; set; }
        public int estado { get; set; }
        public string color { get; set; }


        public Activos()
        {

        }

        public Activos(string nombre_, string descripcion_, int tipo_, int serial_, int num_inventario_, string peso_, string alto_, string ancho_, string largo_, int valor_, DateTime fecha_compra_, DateTime fecha_baja_, int estado_, string color_)
        {
            this.nombre = nombre_;
            this.descripcion = descripcion_;
            this.tipo = tipo_;
            this.serial = serial_;
            this.num_inventario = num_inventario_;
            this.peso = peso_;
            this.alto = alto_;
            this.ancho = ancho_;
            this.largo = largo_;
            this.valor = valor_;
            this.fecha_compra = fecha_compra_;
            this.fecha_baja = fecha_baja_;
            this.estado = estado_;
            this.color = color_;
        }

        public DataTable ListarActivos()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = " SELECT nombre" +
                    " 	,descripcion" +
                    " 	,tipo" +
                    " 	,serial" +
                    " 	,num_inventario" +
                    " 	,peso" +
                    " 	,alto" +
                    " 	,ancho" +
                    " 	,largo" +
                    " 	,valor" +
                    " 	,fecha_compra" +
                    " 	,fecha_baja" +
                    " 	,estado" +
                    " 	,color" +
                    " FROM PUBLIC.activos" +
                    " ORDER BY serial;";
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

        public DataTable BuscarActivosSerial(int serial)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = " SELECT nombre" +
                    " 	,descripcion" +
                    " 	,tipo" +
                    " 	,serial" +
                    " 	,num_inventario" +
                    " 	,peso" +
                    " 	,alto" +
                    " 	,ancho" +
                    " 	,largo" +
                    " 	,valor" +
                    " 	,fecha_compra" +
                    " 	,fecha_baja" +
                    " 	,estado" +
                    " 	,color" +
                    " FROM PUBLIC.activos" +
                    " where serial=@serial;";
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

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BuscarActivosTipo(int tipo)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = " SELECT nombre" +
                    " 	,descripcion" +
                    " 	,tipo" +
                    " 	,serial" +
                    " 	,num_inventario" +
                    " 	,peso" +
                    " 	,alto" +
                    " 	,ancho" +
                    " 	,largo" +
                    " 	,valor" +
                    " 	,fecha_compra" +
                    " 	,fecha_baja" +
                    " 	,estado" +
                    " 	,color" +
                    " FROM PUBLIC.activos" +
                    " where tipo=@tipo;";
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
                            cmd.Parameters.AddWithValue("@tipo", tipo);
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

        public DataTable BuscarActivosFecha(DateTime fecha)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = " SELECT nombre" +
                    " 	,descripcion" +
                    " 	,tipo" +
                    " 	,serial" +
                    " 	,num_inventario" +
                    " 	,peso" +
                    " 	,alto" +
                    " 	,ancho" +
                    " 	,largo" +
                    " 	,valor" +
                    " 	,fecha_compra" +
                    " 	,fecha_baja" +
                    " 	,estado" +
                    " 	,color" +
                    " FROM PUBLIC.activos" +
                    " where fecha_compra=@fecha_compra;";
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
                            cmd.Parameters.AddWithValue("@fecha_compra", fecha);
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

        public bool BuscarTipo(int tipo)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT tipo, descripcion FROM public.tipos where tipo=@tipo";
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
                            cmd.Parameters.AddWithValue("@tipo", tipo);
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

        public bool BuscarEstado(int estado)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT estado, descripcion FROM public.estados where estado=@estado";
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
                            cmd.Parameters.AddWithValue("@estado", estado);
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


        public void AgregarActivoNuevo()
        {
            try
            {
                string sql = " INSERT INTO PUBLIC.activos (" +
                    " 	nombre" +
                    " 	,descripcion" +
                    " 	,tipo" +
                    " 	,serial" +
                    " 	,num_inventario" +
                    " 	,peso" +
                    " 	,alto" +
                    " 	,ancho" +
                    " 	,largo" +
                    " 	,valor" +
                    " 	,fecha_compra" +
                    " 	,fecha_baja" +
                    " 	,estado" +
                    " 	,color" +
                    " 	)" +
                    " VALUES (" +
                    " 	@nombre" +
                    " 	,@descripcion" +
                    " 	,@tipo" +
                    " 	,@serial" +
                    " 	,@num_inventario" +
                    " 	,@peso" +
                    " 	,@alto" +
                    " 	,@ancho" +
                    " 	,@largo" +
                    " 	,@valor" +
                    " 	,@fecha_compra" +
                    " 	,@fecha_baja" +
                    " 	,@estado" +
                    " 	,@color" +
                    " 	)";
                using (NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("CadenaConexion")))
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql))
                    {

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 120;
                        cmd.Connection = conn;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@tipo", tipo);
                        cmd.Parameters.AddWithValue("@serial", serial);
                        cmd.Parameters.AddWithValue("@num_inventario", num_inventario);
                        if (peso== null)
                        {
                            peso = "";
                        }
                        cmd.Parameters.AddWithValue("@peso", peso);
                        if (alto == null)
                        {
                            alto = "";
                        }
                        cmd.Parameters.AddWithValue("@alto", alto);
                        if (ancho == null)
                        {
                            ancho = "";
                        }
                        cmd.Parameters.AddWithValue("@ancho", ancho);
                        if (largo == null)
                        {
                            largo = "";
                        }
                        cmd.Parameters.AddWithValue("@largo", largo);
                        
                        cmd.Parameters.AddWithValue("@valor", valor);
                        
                        cmd.Parameters.AddWithValue("@fecha_compra", fecha_compra);
                        cmd.Parameters.AddWithValue("@fecha_baja", fecha_baja);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        if (color == null)
                        {
                            color = "";
                        }
                        cmd.Parameters.AddWithValue("@color", color);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable BuscarActivosAsignados(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = " SELECT nombre" +
                    " 	,descripcion" +
                    " 	,tipo" +
                    " 	,a.serial" +
                    " 	,num_inventario" +
                    " 	,peso" +
                    " 	,alto" +
                    " 	,ancho" +
                    " 	,largo" +
                    " 	,valor" +
                    " 	,fecha_compra" +
                    " 	,fecha_baja" +
                    " 	,estado" +
                    " 	,color" +
                    " FROM PUBLIC.activos a" +
                    " inner join asignacion b on a.serial=b.serial" + 
                    " where b.id=@id;";
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