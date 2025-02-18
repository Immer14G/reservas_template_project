using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class usuarios
    {
        private string connectionString = "Data Source=IMMER\\SQLEXPRESS;Initial Catalog=dbreservas;Integrated Security=True;TrustServerCertificate=True";

        public bool validarUsuario(string usuario, string contra)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open();
                using (SqlCommand consulta = new SqlCommand("SELECT COUNT(*) FROM usuarios WHERE Usuario = @usuario AND Contraseñas = @Contraseñas", con))
                {
                    consulta.Parameters.AddWithValue("@usuario", usuario);
                    consulta.Parameters.AddWithValue("@Contraseñas", contra);

                    int count = (int)consulta.ExecuteScalar();
                    return count > 0;
                }


            }


        }
        public DataTable ObtenerUsuarios()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id, usuario FROM usuarios", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        
    }
    
}
