using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Pages_ImagePreviewDefault : System.Web.UI.Page
{
    String ID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //ID = Request.QueryString["id"];
        ID = "1";
    }

    protected void ASPxUploadControl1_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
    {
        Session["SeriesDefaultImage"] = e.UploadedFile.FileBytes;
    }

    protected void Panel_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
    {        
        ASPxImage1.Visible = true;
        ASPxImage1.ContentBytes = Session["SeriesDefaultImage"] as Byte[];
        btn_Save.Enabled = true;
    }

    protected void Panel2_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
    {
        uploadtoDB();
        lblStatus.Text = "Image Saved!";
    }

    protected bool uploadtoDB()
    {
        byte[] imageData = Session["SeriesDefaultImage"] as byte[];
        byte[] resizeImageData = Tool.toByte(Tool.ResizeBitmap(Tool.toBitmap(imageData)));
        byte[] rotateImageData = Tool.toByte(Tool.rotateImage(Tool.toBitmap(resizeImageData)));

        DB DBEngine = new DB();
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[5];
        f_Param[0] = new SqlParameter("@DefaultImage", System.Data.SqlDbType.Image);
        f_Param[0].Value = imageData;
        f_Param[1] = new SqlParameter("@ResizedImage", System.Data.SqlDbType.Image);
        f_Param[1].Value = resizeImageData;
        f_Param[2] = new SqlParameter("@RotatedImage", System.Data.SqlDbType.Image);
        f_Param[2].Value = rotateImageData;
        f_Param[3] = new SqlParameter("@UserID", System.Data.SqlDbType.VarChar, 50);
        f_Param[3].Value = Session["UserID"].ToString();
        f_Param[4] = new SqlParameter("@id", System.Data.SqlDbType.VarChar, 50);
        f_Param[4].Value = ID;
        int f_updated = f_DBEngine.Query("S_UpdateDefaultImage", f_Param);
        if (f_updated == 1)
        {
            f_result = true;
        }
        else
        {
            f_result = false;
        }
        f_DBEngine.closeConn();
        f_DBEngine = null;
        return f_result;
    }
}
