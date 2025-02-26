using Microsoft.Win32;
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
    public class Reservacion
    {
        string ConexionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public DataTable obtenerReservacion()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM reserva", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }


        public bool AgregarReserva(int id_Cliente, int id_habitacion, decimal precio, decimal descuento, DateTime checkin, DateTime checkout, string fecha_registro, int id_usuario)
        {
            string idReserva = DateTime.Now.ToString("yyyyMMddHHmmss");

            using (SqlConnection con = new SqlConnection(ConexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO reserva" +
                    " (id_reserva, id_Cliente, id_habitacion, precio, descuento, checkin, checkout, fecha_registro, id_usuario)" +
                    " VALUES (@id_reserva, @id_Cliente, @id_habitacion, @precio, @descuento, @checkin, @checkout, @fecha_registro, @id_usuario)", con))
                {
                    cmd.Parameters.AddWithValue("@id_reserva", idReserva);
                    cmd.Parameters.AddWithValue("@id_Cliente", id_Cliente);
                    cmd.Parameters.AddWithValue("@id_habitacion", id_habitacion);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@descuento", descuento);
                    cmd.Parameters.AddWithValue("@checkin", checkin);
                    cmd.Parameters.AddWithValue("@checkout", checkout);
                    cmd.Parameters.AddWithValue("@fecha_registro", fecha_registro); 
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        

        }

        public bool ModificarReserva(int id, int id_Cliente, int id_habitacion, decimal precio, decimal descuento, DateTime checkin, DateTime checkout, string fecha_registro, int id_usuario)
        {
            using (SqlConnection con = new SqlConnection(ConexionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE reserva SET id_cliente = @id_cliente, " +
                    "id_habitacion = @id_habitacion, precio = @precio, descuento = @descuento, checkin = @checkin, checkout = @checkout," +
                    " fecha_registro  = @fecha_registro, id_usuario = @id_usuario WHERE id_reserva = @id ", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@id_cliente", id_Cliente);
                    cmd.Parameters.AddWithValue("@id_habitacion", id_habitacion);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@descuento", descuento);
                    cmd.Parameters.AddWithValue("@checkin", checkin);
                    cmd.Parameters.AddWithValue("@checkout", checkout);
                    cmd.Parameters.AddWithValue("@fecha_registro", fecha_registro);
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool EliminarReserva(int id)
        {
            using (SqlConnection con = new SqlConnection(ConexionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM reserva WHERE id_reserva = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
    }
}

