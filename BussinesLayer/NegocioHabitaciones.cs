using System;
using System.Data;
using DataLayer;

namespace BussinesLayer
{
    public class NegocioHabitaciones
    {
        Habitaciones habitacionesN = new Habitaciones();

        public DataTable ObtenerHabitaciones()
        {
            return habitacionesN.ObtenerHabitaciones();
        }

        public bool AgregarHabitacion(int numero, string descripcion, int huespedes, int idUsuario)
        {
            return habitacionesN.AgregarHabitacion(numero, descripcion, huespedes, idUsuario);
        }

        public bool ModificarHabitacion(int id, int numero, string descripcion, int huespedes, int idUsuario)
        {
            return habitacionesN.ModificarHabitacion(id, numero, descripcion, huespedes, idUsuario);
        }

        public bool EliminarHabitacion(int id)
        {
            return habitacionesN.EliminarHabitacion(id);
        }
    }
}
