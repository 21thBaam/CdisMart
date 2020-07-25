using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMartBLL;
using CdisMartDAL;
using System.Data;

namespace CdisMart.Subasta
{
    public partial class subasta_s : TemaCdisMart, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    grd_subastas.DataSource = cargarSubasta();
                    grd_subastas.DataBind();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
                
                //System.Diagnostics.Debug.WriteLine(int.Parse((Session["Usuario"].GetType().GetProperty("UserId").GetValue(Session["Usuario"], null)).ToString()));
            }
        }
        #endregion
        #region Metodos
        public List<Auction> cargarSubasta()
        {
            Subasta_BLL subastas = new Subasta_BLL();
            List<Auction> listSubastas = new List<Auction>();

            listSubastas = subastas.cargarSubasta();

            return listSubastas;
        }

        public bool sesionIniciada()
        {
            if(Session["Usuario"] != null)
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