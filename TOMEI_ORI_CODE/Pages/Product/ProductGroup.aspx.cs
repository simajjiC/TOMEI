using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.ASPxEditors;
using System.Text.RegularExpressions;

public partial class Pages_ProductGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Product Group";
        UserSet myUser = (UserSet)Session["User"];
        if ((myUser.Role != "Administrator") && (myUser.Role != "Power User"))
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
    }

    protected void gv_ProductGroup_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        e.NewValues["ProductGroupCode"] = (gv_ProductGroup.FindEditFormTemplateControl("txtProductGroupCode") as ASPxTextBox).Value;
        e.NewValues["ProductGroupDescription"] = (gv_ProductGroup.FindEditFormTemplateControl("txtProductGroupDescription") as ASPxTextBox).Value;
        e.NewValues["userid"] = ((UserSet)Session["User"]).UserID;
    }

    protected void gv_ProductGroup_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        e.NewValues["ProductGroupCode"] = (gv_ProductGroup.FindEditFormTemplateControl("txtProductGroupCode") as ASPxTextBox).Value;
        e.NewValues["ProductGroupDescription"] = (gv_ProductGroup.FindEditFormTemplateControl("txtProductGroupDescription") as ASPxTextBox).Value;
        e.NewValues["userid"] = ((UserSet)Session["User"]).UserID;
    }

    protected void gv_ProductGroup_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
    {
        if (gv_ProductGroup.IsNewRowEditing == false)
        {
            
        }
    }

    protected void gv_ProductGroup_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {
        e.NewValues["ProductGroupCode"] = (gv_ProductGroup.FindEditFormTemplateControl("txtProductGroupCode") as ASPxTextBox).Value;
        String ProductGroupCode = (e.NewValues["ProductGroupCode"] == null ? string.Empty : e.NewValues["ProductGroupCode"].ToString());
        int ID = 0;

        //var regex = new Regex(@"[a - zA - Z]{ 1}[a-zA-Z0-9]{1}");

        Regex regexObj = new Regex(@"[a-zA-Z]{1}[a-zA-Z0-9]{1}");
        Match matchResult = regexObj.Match(ProductGroupCode);
        if (ProductGroupCode.Length >2)
        {
            throw new Exception("Product Group Code must have 2 character only! eg. AA or A1");
        }
        if(matchResult.Success == false)
        {
            throw new Exception("Product Group Code must have 2 character only , first character must be alphabet, second character can be alphabet or digit! eg. AA or A1");
        }
        
        if (ProductGroupCode == String.Empty)
        {
            throw new Exception("Product Group Code must not be empty!");
        }
        e.NewValues["ProductGroupDescription"] = (gv_ProductGroup.FindEditFormTemplateControl("txtProductGroupDescription") as ASPxTextBox).Value;
        String ProductGroupDescription = (e.NewValues["ProductGroupDescription"] == null ? string.Empty : e.NewValues["ProductGroupDescription"].ToString());
        if (ProductGroupDescription == String.Empty)
        {
            throw new Exception("Product Group Description must not be empty!");
        }
        if (e.IsNewRow)
        {
            ID = 0;
        }
        else
        {
            ID = int.Parse(e.Keys["id"].ToString());
        }

        if (Product.checkProductGroupExist(ProductGroupCode, ID) == true)
        {
            throw new Exception("Product Group Code already exists in Database!");
        }        
    }

    protected void gv_ProductGroup_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
    }

    protected void gv_ProductGroup_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {
    }
}
