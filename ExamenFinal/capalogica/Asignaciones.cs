using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using static ExamenFinal.capaModelo.listaproyecto;
using static ExamenFinal.capaModelo.listarempleados;

namespace ExamenFinal.capalogica
{
    public class Asignaciones
    {
        public static int AgregarAsignaciones(int empleadoId, int proyectoId, string fechaAsignacion)
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

        public static int ModificarAsignaciones(int asignacionId, int empleadoId, int proyectoId, string fechaAsignacion)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarAsignaciones", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@AsignacionID", asignacionId));
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

        public static int BorrarAsignaciones(int asignacionId)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarAsignaciones", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@AsignacionID", asignacionId));

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

        public static int ModificarEstadoAsignacion(int asignacionId, string estado)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarEstadoAsignaciones", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@AsignacionID", asignacionId));
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
        public static List<Empleado> ListarEmpleadosPorProyecto(int proyectoId)
        {
            List<Empleado> empleados = new List<Empleado>();
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ListarEmpleadosPorProyecto", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ProyectoID", proyectoId));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Empleado empleado = new Empleado()
                        {
                            EmpleadoID = Convert.ToInt32(reader["EmpleadoID"]),
                            Nombre = reader["Nombre"].ToString(),
                            Categoria = reader["Categoria"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            Telefono = reader["Telefono"].ToString()
                        };
                        empleados.Add(empleado);
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Manejar el error
            }
            finally
            {
                Conn.Close();
            }

            return empleados;
        }


        public static List<Proyecto> ListarProyectosPorEmpleado(int empleadoId)
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ListarProyectosPorEmpleado", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EmpleadoID", empleadoId));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Proyecto proyecto = new Proyecto()
                        {
                            ProyectoID = Convert.ToInt32(reader["ProyectoID"]),
                            Nombre = reader["Nombre"].ToString(),
                            Codigo = Convert.ToInt32(reader["Codigo"]),
                            FechaAsignacion = Convert.ToDateTime(reader["FechaAsignacion"]),
                            FechaFinal = Convert.ToDateTime(reader["FechaFinal"])
                        };
                        proyectos.Add(proyecto);
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Manejar el error
            }
            finally
            {
                Conn.Close();
            }

            return proyectos;



        }

    }
}