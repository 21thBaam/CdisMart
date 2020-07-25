using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMartBLL;
using CdisMartDAL;

namespace CdisMart.AltaUsuario
{
    public partial class AltaUsuario : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            altaUsuario();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "hecho()", true);
        }
        #endregion

        #region Metodos
        public void altaUsuario()
        {
            Usuario_BLL usuario_bll = new Usuario_BLL();
            User usuario = new User();

            usuario.UserName = txtUsuario.Text;
            usuario.Password = txtContraseña.Text;
            usuario.Name = txtNombreCompleto.Text;
            usuario.Email = txtCorreoElectronico.Text;

            usuario_bll.altaUsuario(usuario);
        }
        #endregion
    }
}