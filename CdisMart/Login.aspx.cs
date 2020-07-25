using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMartBLL;
using CdisMartDAL;

namespace CdisMart
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Eventos
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (usuarioValido())
            {
                Response.Redirect("~/Subasta/subasta_s.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Sesión", "error()", true);
            }
        }
        #endregion

        #region Metodos
        public bool usuarioValido()
        {
            bool acceso = false;
            Usuario_BLL user_bll = new Usuario_BLL();
            User usuario = new User();
            usuario = user_bll.consultarUsuario(txtUsuario.Text, txtContraseña.Text);

            if (usuario != null)
            {
                Session["Usuario"] = usuario;
                acceso = true;
            }
            return acceso;
        }
        #endregion
    }
}