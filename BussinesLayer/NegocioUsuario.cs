using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BussinesLayer
{
    public class NegocioUsuario
    {
        usuarios DataUsers = new usuarios();

        public string iniciarSesion (string usuario, string contraseña)
        {
            if(DataUsers.validarUsuario (usuario, contraseña))
            {
                return "OK";
            }
            else
            {
                return "Usuario o contraseña incorrectos";
            }
        }
        public DataTable obtenerUsuario()
        {
            return DataUsers.ObtenerUsuarios();
        }
    }
}
