using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.FindControl("Menu").Visible = false;
        Master.FindControl("lblName").Visible = false;
        Master.FindControl("lblPageTitle").Visible = false;
        //Master.FindControl("btnChangePassword").Visible = false;
        Master.FindControl("btnLogout").Visible = false;
        txtUserID.Focus();
        if (IsPostBack == true)
        {
            PerformLoginAction();
        }
        if (Request.QueryString["act"] == "Timeout")
        {
            lblStatus.Text = "Session Timeout";
        }
        else if (Request.QueryString["act"] == "Logout")
        {
            lblStatus.Text = "User Logout";
        }
    }

    private void PerformLoginAction()
    {
        UserSet User = new UserSet(txtUserID.Text, txtPassword.Text);
        if (User.Login() == true)
        {
            Session["User"] = User;
            Session["UserID"] = User.UserID;
            Response.Redirect("~/Pages/Overview.aspx");
        }
        else
        {
            lblStatus.Text = "UserID / Password incorrect!";
        }
    }
}
