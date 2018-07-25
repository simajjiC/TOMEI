using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;

public partial class Pages_Polish : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Attributes: Polish";
        UserSet myUser = (UserSet)Session["User"];
        if ((myUser.Role != "Administrator") && (myUser.Role != "Power User"))
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
    }

    protected void gv_Polish_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        e.NewValues["value"] = (gv_Polish.FindEditFormTemplateControl("txtPolish")
            as ASPxTextBox).Value;
        e.NewValues["description"] = (gv_Polish.FindEditFormTemplateControl("txtDescription")
                     as ASPxTextBox).Value;
    }

    protected void gv_Polish_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        e.NewValues["value"] = (gv_Polish.FindEditFormTemplateControl("txtPolish")
            as ASPxTextBox).Value;
        e.NewValues["description"] = (gv_Polish.FindEditFormTemplateControl("txtDescription")
                     as ASPxTextBox).Value;
    }

    protected void gv_Polish_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
    {
        //if (gv_Polish.IsNewRowEditing == false)
        //{
        //    gv_Polish.DoRowValidation();
        //}
    }

    protected void gv_Polish_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {
        e.NewValues["value"] = (gv_Polish.FindEditFormTemplateControl("txtPolish") as ASPxTextBox).Value;
        String Polish = (e.NewValues["value"] == null ? string.Empty : e.NewValues["value"].ToString());
        if (Polish == String.Empty)
        {
            throw new Exception("Polish must not be empty!");
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

        if (Stone.checkPolishExist(Polish, ID) == true)
        {
            throw new Exception("Polish: " + Polish + " already exist!");
        }
    }

    protected void gv_Polish_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
    }

    protected void gv_Polish_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {
    }
}
