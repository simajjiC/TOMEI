using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;

public partial class Pages_Action : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Administration: User Activity";
        UserSet myUser = (UserSet)Session["User"];
        if (myUser.Role != "Administrator")
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
    }   
}
