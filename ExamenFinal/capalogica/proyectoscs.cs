using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ExamenFinal.capalogica
{
    public class proyectoscs
    {
        public static int AsignarProyecto(int empleadoId, int proyectoId, DateTime fechaAsignacion)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AsignarProyecto", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EmpleadoID", empleadoId));
                    cmd.Parameters.Add(new SqlParameter("@ProyectoID", proyectoId));
                    cmd.Parameters.Add(new SqlParameter("@FechaAsignacion", fechaAsignacion));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static DataTable BuscarProyectos(string nombreProyecto = null)
        {
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ListarBuscarProyectos", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (!string.IsNullOrEmpty(nombreProyecto))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Nombre", nombreProyecto));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@Nombre", DBNull.Value));
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                dt = null;
            }
            finally
            {
                Conn.Close();
            }

            return dt;
        }

    }
}