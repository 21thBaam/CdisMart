using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMartBLL;
using CdisMartDAL;

namespace CdisMart.Subasta
{
    public partial class subasta_alta : TemaCdisMart, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    string currentDate = DateTime.Today.ToShortDateString();
                    cvv_FechaInicio.ValueToCompare = currentDate;
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            altaSubasta();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "hecho()", true);
        }
        #endregion

        #region Metodos
        public void altaSubasta()
        {
            Subasta_BLL subasta_BLL = new Subasta_BLL();
            Auction subasta = new Auction();

            subasta.UserId = int.Parse((Session["Usuario"].GetType().GetProperty("UserId").GetValue(Session["Usuario"], null)).ToString());
            subasta.ProductName = txtNombreProducto.Text;
            subasta.Description = txtDescripcion.Text;
            subasta.StartDate = Convert.ToDateTime(txtFechaInicio.Text);
            subasta.EndDate = Convert.ToDateTime(txtFechaFin.Text);

            try
            {
                subasta_BLL.altaSubasta(subasta);
                limpiarCampos();
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "error('" + ex.Message + "')", true);
            }
        }

        public void limpiarCampos()
        {
            txtNombreProducto.Text = "";
            txtDescripcion.Text = "";
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
        }

        public bool sesionIniciada()
        {
            if (Session["Usuario"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}