using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
public partial class Pages_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "";
        if (Request.QueryString["act"] == "Logout")
        {
            Session.Clear();
            Response.Redirect("~/Pages/Login.aspx?act=Logout");
        }
        else
        {
            Response.Redirect("~/Pages/Overview.aspx");
        }
    }
}
