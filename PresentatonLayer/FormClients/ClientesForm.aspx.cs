using BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentatonLayer
{
    public partial class ClientesForm : System.Web.UI.Page
    {
        NegocioCliente negocioCliente = new NegocioCliente();


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
                }
            }


        }
            
        

        protected void CargarCliente()
        {
            gvClientes.DataSource = negocioCliente.obtenerClientes();
            gvClientes.DataBind();
        }


        protected void btnAgregar_click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string dui = txtDui.Text;
            string telefono = txtTelefono.Text;
            string correo = txtCorreo.Text;
            string departamento = txtDepartamento.Text;
            DateTime fecha_registro = DateTime.Now;
            int usuario = Convert.ToInt32(txtusuario.Text);


            bool exito = negocioCliente.AgregarCliente(nombre, dui,telefono, correo,  departamento,  fecha_registro, usuario);
            if (exito)
            {
                Response.Write("<script>alert('Cliente agregada con éxito');</script>");
                CargarCliente();
            }
            else
            {
                Response.Write("<script>alert('Error al agregar el cliente');</script>");
            }
        }

        protected void gvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvClientes.EditIndex = e.NewEditIndex;
            CargarCliente();
        }
        protected void gvClientes_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvClientes.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvClientes.Rows[e.RowIndex];

            string nombre = ((row.Cells[1].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            string dui = (row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            string telefono =((row.Cells[3].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            string correo= (row.Cells[4].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            string departamento = ((row.Cells[5].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
           

            if (negocioCliente.ModificarCliente(id, nombre, dui, telefono,correo, departamento))
            {
                gvClientes.EditIndex = -1;
                CargarCliente();
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

        protected void btnVolver_click(object sender, EventArgs e)
        {
            Response.Redirect("principal.aspx");
        }
    }
}
