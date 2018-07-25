using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Standard : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if ((Session["User"] == null) && (Request.Url.ToString().ToLower().Contains("login.aspx") == false))
        {
            Response.Redirect("~/Pages/Login.aspx?act=Timeout");
        }
        else if ((Session["User"] != null))
        {
            lblName.Text = "Login as " + (Session["User"] as UserSet).UserName;
            UserSet myUser = (UserSet)Session["User"];
            switch (myUser.Role)
            {
                case "Administrator":
                    {
                        break;
                    }
                case "Power User":
                    {
                        Menu.Items[Menu.Items.IndexOfName("mnuAdministration")].Enabled = false;
                        break;
                    }
                case "User":
                    {                        
                        Menu.Items[Menu.Items.IndexOfName("mnuAdministration")].Enabled = false;
                        Menu.Items[Menu.Items.IndexOfName("mnuProduct")].Enabled = false;
                        Menu.Items[Menu.Items.IndexOfName("mnuAttribute")].Enabled = false;
                        Menu.Items[Menu.Items.IndexOfName("mnuCertificate")].Items[Menu.Items[Menu.Items.IndexOfName("mnuCertificate")].Items.IndexOfName("mnuVoid")].Enabled = false;
                        break;
                    }
                case "Limited":
                    {
                        Menu.Items[Menu.Items.IndexOfName("mnuAdministration")].Enabled = false;
                        Menu.Items[Menu.Items.IndexOfName("mnuStone")].Items[Menu.Items[Menu.Items.IndexOfName("mnuStone")].Items.IndexOfName("mnuUpload")].Enabled = false;
                        Menu.Items[Menu.Items.IndexOfName("mnuProduct")].Enabled = false;
                        Menu.Items[Menu.Items.IndexOfName("mnuAttribute")].Enabled = false;
                        Menu.Items[Menu.Items.IndexOfName("mnuCertificate")].Items[Menu.Items[Menu.Items.IndexOfName("mnuCertificate")].Items.IndexOfName("mnuVoid")].Enabled = false;
                        Menu.Items[Menu.Items.IndexOfName("mnuCertificate")].Items[Menu.Items[Menu.Items.IndexOfName("mnuCertificate")].Items.IndexOfName("mnuCreate")].Enabled = false;
                        break;
                    }

            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Logout.aspx?act=Logout");
    }
}
