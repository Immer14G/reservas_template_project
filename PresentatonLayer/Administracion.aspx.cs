using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            int numero = Convert.ToInt32(txtNumero.Text);
            string descripcion = txtDescripcion.Text;
            int huespedes = Convert.ToInt32(txtHuespedes.Text);
            int idUsuario = int.Parse(DdlUsuario.SelectedValue);

            bool exito = negocioHabitaciones.AgregarHabitacion(numero, descripcion, huespedes, idUsuario);
            if (exito)
            {
                Response.Write("<script>alert('Habitación agregada con éxito');</script>");
                CargarHabitaciones();
            }
            else
            {
                Response.Write("<script>alert('Error al agregar la habitación');</script>");
            }
        }

        protected void gvHabitaciones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHabitaciones.EditIndex = e.NewEditIndex;
            CargarHabitaciones();
        }
        protected void gvHabitaciones_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvHabitaciones.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvHabitaciones.Rows[e.RowIndex];

            int numero = int.Parse((row.Cells[1].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            string descripcion = (row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text;

            int huespedes = int.Parse((row.Cells[3].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            int idUsuario = int.Parse((row.Cells[4].Controls[0] as System.Web.UI.WebControls.TextBox).Text);

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
    }
}
