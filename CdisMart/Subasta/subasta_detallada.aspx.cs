using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMartBLL;
using CdisMartDAL;
using System.Globalization;
using System.Diagnostics;

namespace CdisMart.Subasta
{
    public partial class subasta_detallada : TemaCdisMart, IAcceso
    {
        private string fechaFin;
        private int userId;
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    validacion();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            agregarPuja();
            limpiarCampos();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "hecho()", true);
            validacion();
        }
        #endregion
        #region Metodos
        public void cargarSubasta(int id)
        {
            Subasta_BLL subasta = new Subasta_BLL();
            object itemSubasta = new object();

            try
            {
                string[] keys = { "AuctionId", "ProductName", "Description", "StartDate", "EndDate", "HighestBid", "WinnerName", "UserId" };
                itemSubasta = subasta.cargarSubastaId(id);

                lNumeroSubasta.Text = (itemSubasta.GetType().GetProperty(keys[0]).GetValue(itemSubasta, null)).ToString();
                lNombreProducto.Text = (itemSubasta.GetType().GetProperty(keys[1]).GetValue(itemSubasta, null)).ToString();
                lDescripcion.Text = (itemSubasta.GetType().GetProperty(keys[2]).GetValue(itemSubasta, null)).ToString();
                lFechaInicio.Text = (itemSubasta.GetType().GetProperty(keys[3]).GetValue(itemSubasta, null)).ToString();
                lFechaFin.Text = (itemSubasta.GetType().GetProperty(keys[4]).GetValue(itemSubasta, null)).ToString();
                fechaFin = (itemSubasta.GetType().GetProperty(keys[4]).GetValue(itemSubasta, null)).ToString();

                if (itemSubasta.GetType().GetProperty("Winner").GetValue(itemSubasta, null) is null && itemSubasta.GetType().GetProperty(keys[5]).GetValue(itemSubasta, null) is null)
                {
                    lHighestBid.Text = "NaN";
                    lWinner.Text = "NaN";
                }
                else
                {
                    lHighestBid.Text = (itemSubasta.GetType().GetProperty(keys[5]).GetValue(itemSubasta, null)).ToString();
                    lWinner.Text = (itemSubasta.GetType().GetProperty(keys[6]).GetValue(itemSubasta, null)).ToString();
                }

                userId = int.Parse((itemSubasta.GetType().GetProperty(keys[7]).GetValue(itemSubasta, null)).ToString());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "error('" + e.Message + "')", true);
            }
        }

        public void agregarPuja()
        {
            Subasta_Registro_BLL subasta_registro_bll = new Subasta_Registro_BLL();
            AuctionRecord Bid = new AuctionRecord();

            Bid.AuctionId = int.Parse(Request.QueryString["AuctionId"]);
            Bid.UserId = int.Parse((Session["Usuario"].GetType().GetProperty("UserId").GetValue(Session["Usuario"], null)).ToString());
            Bid.Amount = Convert.ToDecimal(txtBid.Text);
            Bid.BidDate = DateTime.Now;

            try
            {
                subasta_registro_bll.agregarPuja(Bid, int.Parse(Request.QueryString["AuctionId"]));
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "error('" + ex.Message + "')", true);
            }
        }

        public void validacion()
        {
            try
            {
                cargarSubasta(int.Parse(Request.QueryString["AuctionId"]));
                if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(fechaFin)) <= 0)
                {
                    cv_FechaFin.IsValid = true;
                }
                else
                {
                    cv_FechaFin.IsValid = false;
                }

                if (int.Parse((Session["Usuario"].GetType().GetProperty("UserId").GetValue(Session["Usuario"], null)).ToString()) == userId)
                {
                    cv_UserID.IsValid = false;
                }
                else
                {
                    cv_UserID.IsValid = true;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        public void limpiarCampos()
        {
            txtBid.Text = "";
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