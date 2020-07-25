using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CdisMart
{
    public class TemaCdisMart : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            try
            {
                string username = (Session["Usuario"].GetType().GetProperty("UserName").GetValue(Session["Usuario"], null)).ToString();

                if (((Session["Usuario"].GetType().GetProperty("UserName").GetValue(Session["Usuario"], null)).ToString()).ToLower() == "angel")
                {
                    Page.Theme = "Tema1";
                }
                else
                {
                    Page.Theme = "Tema2";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}