using BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PresentatonLayer
{
    public partial class index : System.Web.UI.Page
    {
        NegocioUsuario negocioUsuario = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            
            
                string usuario = TextBox1.Text.Trim();
                string contraseña = TextBox2.Text.Trim();

                string resultado = negocioUsuario.iniciarSesion(usuario, contraseña);

                if (resultado == "OK")
                {
                    Response.Redirect("principal.aspx");
                }
                else
                {
                    Label1.Text = resultado;
                }

            
        }
    }
}