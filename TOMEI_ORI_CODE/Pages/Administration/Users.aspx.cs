using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web;

public partial class Pages_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Administration: User Management";
        UserSet myUser = (UserSet)Session["User"];
        if (myUser.Role != "Administrator")
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
    }

    protected void gv_Users_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomButtonCallbackEventArgs e)
    {
        if (e.ButtonID == "Activation")
        {
            if (UserSet.activatesuspend(gv_Users.GetRowValues(e.VisibleIndex, "UserID").ToString()) == true)
            {
                gv_Users.DataBind();
            }
        }
    }
    protected void gv_Users_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
    {
        
    }

    protected void gv_Users_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        e.NewValues["UserID"] = (gv_Users.FindEditFormTemplateControl("txtUserID") as ASPxTextBox).Text;
        e.NewValues["UserName"] = (gv_Users.FindEditFormTemplateControl("txtUserName") as ASPxTextBox).Text;
        e.NewValues["Password"] = Tool.encrypt((gv_Users.FindEditFormTemplateControl("txtPassword") as ASPxTextBox).Value.ToString());
        e.NewValues["Status"] = (gv_Users.FindEditFormTemplateControl("ddlUserStatus") as DropDownList).SelectedValue;
        e.NewValues["UserRole"] = (gv_Users.FindEditFormTemplateControl("ddlUserRole") as DropDownList).SelectedValue;
    }

    protected void gv_Users_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        e.NewValues["UserID"] = (gv_Users.FindEditFormTemplateControl("txtUserID") as ASPxTextBox).Text;
        e.NewValues["UserName"] = (gv_Users.FindEditFormTemplateControl("txtUserName") as ASPxTextBox).Text;
        e.NewValues["Password"] = Tool.encrypt((gv_Users.FindEditFormTemplateControl("txtPassword") as ASPxTextBox).Value.ToString());
        e.NewValues["Status"] = (gv_Users.FindEditFormTemplateControl("ddlUserStatus") as DropDownList).SelectedValue;
        e.NewValues["UserRole"] = (gv_Users.FindEditFormTemplateControl("ddlUserRole") as DropDownList).SelectedValue;
    }

    protected void gv_Users_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
    {
        if (!gv_Users.IsNewRowEditing)
        {
            (gv_Users.FindEditFormTemplateControl("txtUserID") as ASPxTextBox).Enabled = false;
            (gv_Users.FindEditFormTemplateControl("ddlUserStatus") as DropDownList).SelectedValue = UserSet.getStatus(e.EditingKeyValue.ToString()).ToString(); //(gv_Users.FindEditFormTemplateControl("ddlUserStatus") as DropDownList).Items.FindByValue(UserSet.getStatus(e.EditingKeyValue.ToString()).ToString());
            (gv_Users.FindEditFormTemplateControl("ddlUserRole") as DropDownList).SelectedValue = UserSet.getRole(e.EditingKeyValue.ToString()).ToString(); // (gv_Users.FindEditFormTemplateControl("ddlUserRole") as DropDownList).Items.FindByValue(UserSet.getRole(e.EditingKeyValue.ToString()).ToString());
        }        
    }

    protected void gv_Users_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {
        e.NewValues["UserID"] = (gv_Users.FindEditFormTemplateControl("txtUserID") as ASPxTextBox).Value;
        String UserID = (e.NewValues["UserID"] == null ? string.Empty : e.NewValues["UserID"].ToString());
        if (UserID == String.Empty)
        {
            throw new Exception("UserID must not be empty!");
        }
        else if (UserSet.checkExist(UserID) == true)
        {
            if (gv_Users.IsNewRowEditing)
            {
                throw new Exception("UserID already exist!");
            }
        }

        e.NewValues["UserName"] = (gv_Users.FindEditFormTemplateControl("txtUserName") as ASPxTextBox).Value;
        String UserName = (e.NewValues["UserName"] == null ? string.Empty : e.NewValues["UserName"].ToString());
        if (UserName == String.Empty)
        {
            throw new Exception("UserName must not be empty!");
        }

        e.NewValues["Password"] = (gv_Users.FindEditFormTemplateControl("txtPassword") as ASPxTextBox).Value;
        String Password = (e.NewValues["Password"] == null ? string.Empty : e.NewValues["Password"].ToString());
        e.NewValues["ConfirmPassword"] = (gv_Users.FindEditFormTemplateControl("txtConfirmPassword") as ASPxTextBox).Value;
        String ConfirmPassword = (e.NewValues["ConfirmPassword"] == null ? string.Empty : e.NewValues["ConfirmPassword"].ToString());
        if (Password == String.Empty)
        {
            throw new Exception("Password must not be empty!");
        }
        else if (Password != ConfirmPassword)
        {
            throw new Exception("Password and Confirm Password not match!");
        }
    }

    protected void gv_Users_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
        lblRecordStatus.Text = "User Created";
    }

    protected void gv_Users_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {
        lblRecordStatus.Text = "User Updated";
    }
}
