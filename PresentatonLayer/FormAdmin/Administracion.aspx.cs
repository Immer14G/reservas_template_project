using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinesLayer;

namespace PresentatonLayer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        NegocioUsuario negocioUsuario = new NegocioUsuario();
        NegocioHabitaciones negocioHabitaciones = new NegocioHabitaciones();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarHabitaciones();
                CargarUsuarios();
            }
        }

        protected void CargarHabitaciones()
        {
            gvHabitaciones.DataSource = negocioHabitaciones.ObtenerHabitaciones();
            gvHabitaciones.DataBind();
        }

        protected void CargarUsuarios()
        {
            DdlUsuario.DataSource = negocioUsuario.obtenerUsuario();
            DdlUsuario.DataTextField = "usuario";
            DdlUsuario.DataValueField = "id";
            DdlUsuario.DataBind();
        }

        protected void btnAgregar_click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtHuespedes.Text) || DdlUsuario.SelectedIndex == -1)
            {
                MostrarAlerta("Por favor complete todos los campos.");
                return;
            }

            int numero, huespedes;
            if (!int.TryParse(txtNumero.Text, out numero) || !int.TryParse(txtHuespedes.Text, out huespedes) || numero <= 0 || huespedes <= 0)
            {
                MostrarAlerta("El número de habitación y los huéspedes deben ser números positivos.");
                return;
            }

            string descripcion = txtDescripcion.Text;
            int idUsuario = int.Parse(DdlUsuario.SelectedValue);

            if (negocioHabitaciones.AgregarHabitacion(numero, descripcion, huespedes, idUsuario))
            {
                MostrarAlerta("Habitación agregada con éxito");
                CargarHabitaciones();
            }
            else
            {
                MostrarAlerta("Error al agregar la habitación");
            }
        }

        protected void gvHabitaciones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHabitaciones.EditIndex = e.NewEditIndex;
            CargarHabitaciones();
        }

        protected void gvHabitaciones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvHabitaciones.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvHabitaciones.Rows[e.RowIndex];

            int numero, huespedes, idUsuario;
            string descripcion = (row.Cells[2].Controls[0] as TextBox).Text;

            if (!int.TryParse((row.Cells[1].Controls[0] as TextBox).Text, out numero) ||
                !int.TryParse((row.Cells[3].Controls[0] as TextBox).Text, out huespedes) ||
                !int.TryParse((row.Cells[4].Controls[0] as TextBox).Text, out idUsuario) ||
                numero <= 0 || huespedes <= 0)
            {
                MostrarAlerta("Los valores ingresados deben ser válidos y positivos.");
                return;
            }

            if (negocioHabitaciones.ModificarHabitacion(id, numero, descripcion, huespedes, idUsuario))
            {
                gvHabitaciones.EditIndex = -1;
                CargarHabitaciones();
            }
        }

        protected void gvHabitaciones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHabitaciones.EditIndex = -1;
            CargarHabitaciones();
        }

        protected void gvHabitaciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvHabitaciones.DataKeys[e.RowIndex].Value);
            if (negocioHabitaciones.EliminarHabitacion(id))
            {
                CargarHabitaciones();
            }
        }

        protected void btnSalir_click(object sender, EventArgs e)
        {
            Response.Redirect("../principal.aspx");
        }

        private void MostrarAlerta(string mensaje)
        {
            Response.Write($"<script>alert('{mensaje}');</script>");
        }
    }
}
