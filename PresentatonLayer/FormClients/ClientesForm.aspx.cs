using BussinesLayer;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentatonLayer
{
    public partial class ClientesForm : System.Web.UI.Page
    {
        NegocioCliente negocioCliente = new NegocioCliente();
        NegocioUsuario negocioUsuario = new NegocioUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("LoginForm.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    CargarCliente();
                    CargarUsuarios();
                }
            }
        }

        protected void CargarUsuarios()
        {
            DdlUsuario.DataSource = negocioUsuario.obtenerUsuario();
            DdlUsuario.DataTextField = "usuario";
            DdlUsuario.DataValueField = "id";
            DdlUsuario.DataBind();
        }

        protected void CargarCliente()
        {
            gvClientes.DataSource = negocioCliente.obtenerClientes();
            gvClientes.DataBind();
        }

        protected void btnAgregar_click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string dui = txtDui.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string departamento = txtDepartamento.Text.Trim();
            DateTime fecha_registro = DateTime.Now;
            int usuario = 0;

            // Validación simple en línea
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(dui) ||
                string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(departamento) || DdlUsuario.SelectedIndex == -1 ||
                !int.TryParse(DdlUsuario.SelectedValue, out usuario) ||
                dui.Length != 10 || !dui.Contains("-") || telefono.Length != 8 ||
                !telefono.All(char.IsDigit) || !correo.Contains("@"))
            {
                MostrarAlerta("Por favor ingrese datos válidos en todos los campos.");
                return;
            }

            bool exito = negocioCliente.AgregarCliente(nombre, dui, telefono, correo, departamento, fecha_registro, usuario);
            MostrarAlerta(exito ? "Cliente agregado con éxito" : "Error al agregar el cliente");
            if (exito) CargarCliente();
        }

        protected void gvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvClientes.EditIndex = e.NewEditIndex;
            CargarCliente();
        }

        protected void gvClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvClientes.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvClientes.Rows[e.RowIndex];

            string nombre = ((row.Cells[1].Controls[0] as TextBox).Text).Trim();
            string dui = (row.Cells[2].Controls[0] as TextBox).Text.Trim();
            string telefono = ((row.Cells[3].Controls[0] as TextBox).Text).Trim();
            string correo = (row.Cells[4].Controls[0] as TextBox).Text.Trim();
            string departamento = ((row.Cells[5].Controls[0] as TextBox).Text).Trim();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(dui) ||
                string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(departamento) || dui.Length != 10 ||
                !dui.Contains("-") || telefono.Length != 8 || !telefono.All(char.IsDigit) ||
                !correo.Contains("@"))
            {
                MostrarAlerta("Por favor ingrese datos válidos en todos los campos.");
                return;
            }

            if (negocioCliente.ModificarCliente(id, nombre, dui, telefono, correo, departamento))
            {
                gvClientes.EditIndex = -1;
                CargarCliente();
            }
            else
            {
                MostrarAlerta("Error al actualizar el cliente.");
            }
        }

        protected void gvClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvClientes.EditIndex = -1;
            CargarCliente();
        }

        protected void gvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvClientes.DataKeys[e.RowIndex].Value);
            if (negocioCliente.EliminarCliente(id))
            {
                CargarCliente();
            }
        }

        protected void btnSalir_click(object sender, EventArgs e)
        {
            Response.Redirect("../principal.aspx");
        }

        // Función auxiliar para mostrar alertas
        private void MostrarAlerta(string mensaje)
        {
            Response.Write($"<script>alert('{mensaje}');</script>");
        }
    }
}
