using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BussinesLayer
{
    public class NegocioReservacion
    {
        Reservacion ReservacionesN = new Reservacion();

        public DataTable obtenerReservaciones()
        {
            return ReservacionesN.obtenerReservacion();

        }
        private string GenerarIdReserva()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public bool AgregarReserva(int id_Cliente, int id_habitacion, decimal precio, decimal descuento, DateTime checkin, DateTime checkout, string fecha_registro, int id_usuario)
        {
            GenerarIdReserva();
            return ReservacionesN.AgregarReserva(id_Cliente, id_habitacion, precio, descuento, checkin, checkout, fecha_registro, id_usuario);
        }


        public bool ModificarReservacion(int id, int id_Cliente, int id_habitacion, decimal precio, decimal descuento, DateTime checkin, DateTime checkout, string fecha_registro, int id_usuario)
        {
            return ReservacionesN.ModificarReserva(id, id_Cliente, id_habitacion, precio, descuento,checkin, checkout, fecha_registro, id_usuario);
        }

        public bool EliminarReservacion(int id)
        {
            return ReservacionesN.EliminarReserva(id);
        }
    }
}
