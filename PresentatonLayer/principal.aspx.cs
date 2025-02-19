using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentatonLayer
{   
    public partial class principal : System.Web.UI.Page
    {
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./FormAdmin/Administracion.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("./FormCLients/ClientesForm.aspx");
        }
    }
}