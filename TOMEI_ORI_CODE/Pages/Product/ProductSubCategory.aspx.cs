using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.ASPxEditors;
public partial class Pages_ProductSubCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Product Sub Category";
        UserSet myUser = (UserSet)Session["User"];
        if ((myUser.Role != "Administrator") && (myUser.Role != "Power User"))
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
    }

    protected void gv_ProductCategory_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        e.NewValues["SubCategoryCode"] = (gv_ProductCategory.FindEditFormTemplateControl("txtSubCategoryCode") as ASPxTextBox).Value;
        e.NewValues["SubCategoryName"] = (gv_ProductCategory.FindEditFormTemplateControl("txtSubCategoryName") as ASPxTextBox).Value;
        e.NewValues["userid"] = ((UserSet)Session["User"]).UserID;
    }

    protected void gv_ProductCategory_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        e.NewValues["SubCategoryCode"] = (gv_ProductCategory.FindEditFormTemplateControl("txtSubCategoryCode") as ASPxTextBox).Value;
        e.NewValues["SubCategoryName"] = (gv_ProductCategory.FindEditFormTemplateControl("txtSubCategoryName") as ASPxTextBox).Value;
        e.NewValues["userid"] = ((UserSet)Session["User"]).UserID;
    }

    protected void gv_ProductCategory_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
    {
        if (gv_ProductCategory.IsNewRowEditing == false)
        {
            
        }
    }

    protected void gv_ProductCategory_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {
        e.NewValues["SubCategoryCode"] = (gv_ProductCategory.FindEditFormTemplateControl("txtSubCategoryCode") as ASPxTextBox).Value;
        String SubCategoryCode = (e.NewValues["SubCategoryCode"] == null ? string.Empty : e.NewValues["SubCategoryCode"].ToString());        
        if (SubCategoryCode == String.Empty)
        {
            throw new Exception("Sub Category Code must not be empty!");
        }
        e.NewValues["SubCategoryName"] = (gv_ProductCategory.FindEditFormTemplateControl("txtSubCategoryName") as ASPxTextBox).Value;
        String SubCategoryName = (e.NewValues["SubCategoryName"] == null ? string.Empty : e.NewValues["SubCategoryName"].ToString());
        if (SubCategoryName == String.Empty)
        {
            throw new Exception("Sub Category Name must not be empty!");
        }

        int ID = 0;
        if (e.IsNewRow)
        {
            ID = 0;
        }
        else
        {
            ID = int.Parse(e.Keys["id"].ToString());
        }
        if (Product.checkProductSubCategoryExist(SubCategoryCode, ID) == true)
        {
            throw new Exception("Sub Category already exists in Database!");
        }
    }

    protected void gv_ProductCategory_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
    }

    protected void gv_ProductCategory_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {
    }
}
