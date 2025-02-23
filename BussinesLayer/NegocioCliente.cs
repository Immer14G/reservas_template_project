using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public class NegocioCliente
    {
        Cliente ClientesN = new Cliente();

        public DataTable obtenerClientes()
        {
            return ClientesN.obtenerClientes();
        }

        public bool AgregarCliente(string nombre, string dui, string telefono, string correo, string departamento, DateTime fecha_registro, int id_usuario)
        {
            return ClientesN.AgregarCliente(nombre, dui, telefono,correo, departamento, fecha_registro,id_usuario);
        }

        public bool ModificarCliente(int id, string nombre, string dui, string telefono, string correo, string departamento)
        {
            return ClientesN.ModificarCliente(id, nombre, dui, telefono,correo, departamento );
        }

        public bool EliminarCliente(int id)
        {
            return ClientesN.EliminarCliente(id);
        }
    }
}