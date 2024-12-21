using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ExamenFinal.capalogica
{
    public class Empleados
    {
        public static int InsertarEmpleado(string numeroCarnet, string nombre, string fechaNacimiento, string categoria, string direccion, string correo, string telefono, string estado)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarEmpleado", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@NumeroCarnet", numeroCarnet));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", fechaNacimiento));
                    cmd.Parameters.Add(new SqlParameter("@Categoria", categoria));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", direccion));
                    cmd.Parameters.Add(new SqlParameter("@Correo", correo));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", telefono));
                    cmd.Parameters.Add(new SqlParameter("@Estado", estado));

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

        public static DataTable BuscarEmpleadosPorCategoria(string categoria = null)
        {
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ListarBuscarEmpleadosPorCategoria", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (!string.IsNullOrEmpty(categoria))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Categoria", categoria));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@Categoria", DBNull.Value));
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