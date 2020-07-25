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
    public partial class subasta_historial : TemaCdisMart, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    try
                    {
                        int AuctionId = int.Parse(Request.QueryString["AuctionId"]);
                        var temp = cargarHistorial(AuctionId);
                        grd_historial.DataSource = temp;
                        grd_historial.DataBind();
                        cargarUsuarios(temp);
                    }
                    catch (Exception er)
                    {
                        Console.WriteLine(er);
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        #endregion
        #region Metodos
        public List<object> cargarHistorial(int AuctionId)
        {
            Subasta_Registro_BLL registro = new Subasta_Registro_BLL();
            Subasta_BLL subasta_bll = new Subasta_BLL();

            try
            {
                var temp = subasta_bll.cargarSubastaId(AuctionId);

                lProductName.Text = (temp.GetType().GetProperty("ProductName").GetValue(temp, null)).ToString();
                lDescription.Text = (temp.GetType().GetProperty("Description").GetValue(temp, null)).ToString();

                return registro.cargarSubastaRegistroId(AuctionId);
            }
            catch(Exception err)
            {
                lProductName.Text = "NaN";
                lDescription.Text = "NaN";
                System.Diagnostics.Debug.WriteLine(err);
                return null;
            }
        }

        public void cargarUsuarios(List<object> temp)
        {
            List<string> usuarios = new List<string>();
            
            for (int i=0; i < temp.Count ; i++)
            {
                if (!usuarios.Contains((temp[i].GetType().GetProperty("UserId").GetValue(temp[i], null)).ToString()))
                {
                    usuarios.Add((temp[i].GetType().GetProperty("UserId").GetValue(temp[i], null)).ToString());
                }
            }

            var result = usuarios.Select(s => new { value = s }).ToList();

            ddl_Usuarios.DataSource = result;
            ddl_Usuarios.DataTextField = "value";
            ddl_Usuarios.DataValueField = "value";
            ddl_Usuarios.DataBind();
            ddl_Usuarios.Items.Insert(0, new ListItem("---- Seleccione Usuario ----","0"));
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