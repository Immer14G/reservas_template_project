using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Cliente
    {


        string ConexionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        public DataTable obtenerClientes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM cliente", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool AgregarCliente(string nombre, string dui, string telefono, string correo, string departamento, DateTime fecha_registro, int id_usuario)
        {
            using (SqlConnection con = new SqlConnection(ConexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO cliente" +
                    " (nombre, dui, telefono,correo, departamento, fecha_registro, id_usuario)" +
                    " VALUES (@nombre, @dui, @telefono,@correo, @departamento,@fecha_registro, @id_usuario)", con))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@dui", dui);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@departamento", departamento);
                    cmd.Parameters.AddWithValue("@fecha_registro", fecha_registro);
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);


                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool ModificarCliente(int id, string nombre, string dui, string telefono, string correo, string departamento)
        {
            {
                using (SqlConnection con = new SqlConnection(ConexionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("UPDATE cliente SET nombre = @nombre, dui = @dui, telefono = @telefono ,correo = @correo, departamento =@departamento WHERE id_cliente = @id ", con))

                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@dui", dui);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@departamento", departamento);
                        
                     

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }


        }


        public bool EliminarCliente(int id)
        {

            using (SqlConnection con = new SqlConnection(ConexionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM cliente WHERE id_cliente = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;



                }
            }

        }

    }

}


