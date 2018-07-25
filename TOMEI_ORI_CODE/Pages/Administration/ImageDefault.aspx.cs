using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using System.Data.SqlClient;
using System.IO;

public partial class Pages_ImageDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Administration: Default Image";
        loadImage();
    }

    private void loadImage()
    {
        DB f_DBEngine = new DB();
        SqlDataReader f_Reader = f_DBEngine.GetRows("S_GetDefaultImage");
        if (f_Reader.HasRows == true)
        {
            f_Reader.Read();           
            ASPxBinaryImage1.ContentBytes = (byte[])f_Reader["defaultImage"];
        }        
        f_Reader = null;
        f_DBEngine.closeConn();
        f_DBEngine = null;        
    }
}
