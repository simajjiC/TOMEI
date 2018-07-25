using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;

public partial class Pages_Clarity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Attributes: Clarity";
        UserSet myUser = (UserSet)Session["User"];
        if ((myUser.Role != "Administrator") && (myUser.Role != "Power User"))
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
    }

    protected void gv_Clarity_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        e.NewValues["value"] = (gv_Clarity.FindEditFormTemplateControl("txtClarity") as ASPxTextBox).Value;
        e.NewValues["description"] = (gv_Clarity.FindEditFormTemplateControl("txtDescription") as ASPxTextBox).Value;
        e.NewValues["userid"] = ((UserSet)Session["User"]).UserID;
    }

    protected void gv_Clarity_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        e.NewValues["value"] = (gv_Clarity.FindEditFormTemplateControl("txtClarity") as ASPxTextBox).Value;
        e.NewValues["description"] = (gv_Clarity.FindEditFormTemplateControl("txtDescription") as ASPxTextBox).Value;
        e.NewValues["userid"] = ((UserSet)Session["User"]).UserID;
    }

    protected void gv_Clarity_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
    {
        //if (gv_Clarity.IsNewRowEditing == false)
        //{
        //    gv_Clarity.DoRowValidation();
        //}
    }

    protected void gv_Clarity_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {
        e.NewValues["value"] = (gv_Clarity.FindEditFormTemplateControl("txtClarity") as ASPxTextBox).Value;
        String Clarity = (e.NewValues["value"] == null ? string.Empty : e.NewValues["value"].ToString()); 
        if (Clarity == String.Empty)
        {
            throw new Exception("Clarity must not be empty!");
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

        if (Stone.checkClarityExist(Clarity, ID) == true)
        {
            throw new Exception("Clarity: " + Clarity + " already exist!");
        }
    }

    protected void gv_Clarity_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
    }

    protected void gv_Clarity_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {
    }
}
