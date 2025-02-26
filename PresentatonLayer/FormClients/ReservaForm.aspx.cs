using BussinesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentatonLayer
{
    public partial class ReservaForm : Page
    {
        NegocioReservacion negocioReservacion = new NegocioReservacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                CargarReservas();
            }
            if (!IsPostBack)
            {
                lblTotal.Text = "Total: $0.00";
                
            }
        }

        private void CargarReservas()
        {
           
            DataTable dtReservas = negocioReservacion.obtenerReservaciones();

            
            gvReservas.DataSource = dtReservas;
            gvReservas.DataBind();
        }
        protected void CalcularTotal(object sender, EventArgs e)
        {
            try
            {
                
                decimal precioPorNoche = Convert.ToDecimal(ddlHabitaciones.SelectedValue);
                int descuento = Convert.ToInt32(rblDescuento.SelectedValue);

                
                DateTime checkin;
                DateTime checkout;
                if (DateTime.TryParse(txtFechaInicio.Text, out checkin) && DateTime.TryParse(txtFechaFin.Text, out checkout))
                {
                    if (checkout > checkin)
                    {
                       
                        int dias = (int)Math.Ceiling((checkout - checkin).TotalDays);

                     
                        decimal precioTotal = decimal.Round(precioPorNoche * dias, 2);

                        
                        decimal descuentoAplicado = decimal.Round((precioTotal * descuento) / 100, 2);
                        decimal precioConDescuento = precioTotal - descuentoAplicado;

                      
                        decimal iva = decimal.Round(precioConDescuento * 0.13m, 2);

                       
                        decimal total = decimal.Round(precioConDescuento + iva, 2);

                        // Mostrar total con precisión exacta
                        lblTotal.Text = $"Total: ${total:F2}";
                    }
                    else
                    {
                        lblTotal.Text = "Error: La fecha de fin debe ser mayor que la fecha de inicio.";
                    }
                }
                else
                {
                    lblTotal.Text = "Error: Ingrese fechas válidas.";
                }
            }
            catch (Exception ex)
            {
                lblTotal.Text = $"Error: {ex.Message}";
            }
        }

        private string GenerarIdReserva()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        protected void guardar(object sender, EventArgs e)
        {
            {
                string idReserva = GenerarIdReserva();

               
                int id_Cliente = Convert.ToInt32(ddlClientes.SelectedValue); 
                int idHabitacion = Convert.ToInt32(ddlHabitaciones.SelectedValue);
                decimal precio = Convert.ToDecimal(ddlHabitaciones.SelectedValue); 
                int descuento = Convert.ToInt32(rblDescuento.SelectedValue);
                DateTime checkin = Convert.ToDateTime(txtFechaInicio.Text);
                DateTime checkout = Convert.ToDateTime(txtFechaFin.Text);
                string fecha_registro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                int id_usuario = Convert.ToInt32(Session["id_usuario"]);


                bool resultado = negocioReservacion.AgregarReserva(id_Cliente, idHabitacion, precio, descuento, checkin, checkout, fecha_registro, id_usuario);

                if (resultado)
                {
                    lblTotal.Text = $"Reserva guardada con ID: {idReserva}";
                }
                else
                {
                    lblTotal.Text = "Error: No se pudo guardar la reserva.";
                }
            }
        }
    }
}
