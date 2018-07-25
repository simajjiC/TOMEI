using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.ASPxEditors;
public partial class Pages_ProductCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Product Category";
        UserSet myUser = (UserSet)Session["User"];
        if ((myUser.Role != "Administrator") && (myUser.Role != "Power User"))
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
    }

    protected void gv_ProductCategory_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        e.NewValues["CategoryCode"] = (gv_ProductCategory.FindEditFormTemplateControl("txtCategoryCode") as ASPxTextBox).Value;
        e.NewValues["CategoryName"] = (gv_ProductCategory.FindEditFormTemplateControl("txtCategoryName") as ASPxTextBox).Value;
        e.NewValues["userid"] = ((UserSet)Session["User"]).UserID;
    }

    protected void gv_ProductCategory_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        e.NewValues["CategoryCode"] = (gv_ProductCategory.FindEditFormTemplateControl("txtCategoryCode") as ASPxTextBox).Value;
        e.NewValues["CategoryName"] = (gv_ProductCategory.FindEditFormTemplateControl("txtCategoryName") as ASPxTextBox).Value;
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
        e.NewValues["CategoryCode"] = (gv_ProductCategory.FindEditFormTemplateControl("txtCategoryCode") as ASPxTextBox).Value;
        String CategoryCode = (e.NewValues["CategoryCode"] == null ? string.Empty : e.NewValues["CategoryCode"].ToString());
        int ID = 0;
        if (CategoryCode == String.Empty)
        {
            throw new Exception("Category Code must not be empty!");
        }
        e.NewValues["CategoryName"] = (gv_ProductCategory.FindEditFormTemplateControl("txtCategoryName") as ASPxTextBox).Value;
        String CategoryName = (e.NewValues["CategoryName"] == null ? string.Empty : e.NewValues["CategoryName"].ToString());
        if (CategoryName == String.Empty)
        {
            throw new Exception("Category Name must not be empty!");
        }
        if (e.IsNewRow)
        {
            ID = 0;
        }
        else
        {
            ID = int.Parse(e.Keys["id"].ToString());
        }

        if (Product.checkProductCategoryExist(CategoryCode, ID) == true)
        {
            throw new Exception("Category Code already exists in Database!");
        }        
    }

    protected void gv_ProductCategory_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
    }

    protected void gv_ProductCategory_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {
    }
}
