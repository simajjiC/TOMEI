using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

public partial class Pages_ProductSeriesImage : System.Web.UI.Page
{
    const string UploadDirectory = "~/product_image/";

    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Product Series Image";
        UserSet myUser = (UserSet)Session["User"];
        if ((myUser.Role != "Administrator") && (myUser.Role != "Power User"))
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
    }

    protected void gv_ProductSeries_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
    {
        int startIndex = gv_ProductSeries.PageIndex * gv_ProductSeries.SettingsPager.PageSize;
        int end = Math.Min(gv_ProductSeries.VisibleRowCount, startIndex + gv_ProductSeries.SettingsPager.PageSize);
        object[] Id = new object[end - startIndex];
        for (int n = startIndex; n < end; n++)
        {
            Id[n - startIndex] = gv_ProductSeries.GetRowValues(n, "id");
        }
        e.Properties["cpId"] = Id;
    }

    protected void gv_ProductSeries_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        e.NewValues["userid"] = ((UserSet)Session["User"]).UserID;
    }

    protected void gv_ProductSeries_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {

    }

    protected void gv_ProductSeries_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
    {        

    }

    protected void gv_ProductSeries_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {

    }

    protected void gv_ProductSeries_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {

    }

    protected void gv_ProductSeries_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {
        
    }

    protected void ulcSeriesImage_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
    {
        if ((sender as ASPxUploadControl).IsValid)
        {
            Session["SeriesImage"] = (sender as ASPxUploadControl).FileBytes;            
        }
        SavePostedFile(e.UploadedFile);
        //imgPreview.ContentBytes = (sender as ASPxUploadControl).FileBytes;
        //gv_ProductSeries.UpdateEdit();
        //(gv_ProductSeries.FindEditFormTemplateControl("hplSave") as HyperLink).Enabled = true;
    }

    private void SavePostedFile(UploadedFile _UploadedFile)
    {
        if (_UploadedFile.IsValid == true)
        {
            String previewFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + _UploadedFile.FileName;
            String tempFileName = MapPath(UploadDirectory) + previewFileName;
            _UploadedFile.SaveAs(tempFileName);
        }
    }

    protected void ds_ProductSeries_Updating(object sender, SqlDataSourceCommandEventArgs e)
    {              
        byte[] imageData = Session["SeriesImage"] as byte[];
        System.Data.SqlClient.SqlParameter uploadData = new System.Data.SqlClient.SqlParameter("@SeriesImage", System.Data.SqlDbType.Image);
        uploadData.Value = imageData;        
        e.Command.Parameters.Add(uploadData);

        byte[] resizeImageData = Tool.toByte(Tool.ResizeBitmap(Tool.toBitmap(imageData)));
        System.Data.SqlClient.SqlParameter resizeData = new System.Data.SqlClient.SqlParameter("@ResizedImage", System.Data.SqlDbType.Image);
        resizeData.Value = resizeImageData;
        e.Command.Parameters.Add(resizeData);

        //byte[] rotateImageData = Tool.toByte(Tool.rotateImage(Tool.toBitmap(resizeImageData)));
        //System.Data.SqlClient.SqlParameter rotateData = new System.Data.SqlClient.SqlParameter("@RotatedImage", System.Data.SqlDbType.Image);
        //rotateData.Value = rotateImageData;
        //e.Command.Parameters.Add(rotateData);

        byte[] rotateImageData = Tool.toByte(Tool.rotateImage(Tool.toBitmap(imageData)));
        System.Data.SqlClient.SqlParameter rotateData = new System.Data.SqlClient.SqlParameter("@RotatedImage", System.Data.SqlDbType.Image);
        rotateData.Value = rotateImageData;
        e.Command.Parameters.Add(rotateData);
    }

    protected void ds_ProductSeries_Inserting(object sender, SqlDataSourceCommandEventArgs e)
    {

    }
}
