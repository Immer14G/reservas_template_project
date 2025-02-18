using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Habitaciones
    {


        string ConexionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        public DataTable ObtenerHabitaciones()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM habitaciones", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool AgregarHabitacion(int numero, string descripcion, int huespedes, int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(ConexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO habitaciones" +
                    " (numero, descripcion, huespedes, id_usuario)" +
                    " VALUES (@numero, @descripcion, @huespedes, @idUsuario)", con))
                {
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@huespedes", huespedes);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);


                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool ModificarHabitacion(int id, int numero, string descripcion, int huespedes, int idUsuario)
        {
        {
                using (SqlConnection con = new SqlConnection(ConexionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("UPDATE habitaciones SET numero = @numero, descripcion = @descripcion, huespedes = @huespedes, id_usuario = @idUsuario WHERE id_habitaciones = @id ", con))

                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@numero", numero);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@huespedes", huespedes);
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }

           
        }


        public bool EliminarHabitacion(int id)
        {

            using (SqlConnection con = new SqlConnection(ConexionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM habitaciones WHERE id_habitaciones = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;



                }
            }

        }

    }

}



