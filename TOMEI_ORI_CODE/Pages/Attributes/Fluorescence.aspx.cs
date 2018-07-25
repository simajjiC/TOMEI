using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;

public partial class Pages_Fluorescence : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Attributes: Fluorescence";
        UserSet myUser = (UserSet)Session["User"];
        if ((myUser.Role != "Administrator") && (myUser.Role != "Power User"))
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
    }

    protected void gv_Fluorescence_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        e.NewValues["value"] = (gv_Fluorescence.FindEditFormTemplateControl("txtFluorescence")
            as ASPxTextBox).Value;
        e.NewValues["description"] = (gv_Fluorescence.FindEditFormTemplateControl("txtDescription")
                     as ASPxTextBox).Value;
    }

    protected void gv_Fluorescence_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        e.NewValues["value"] = (gv_Fluorescence.FindEditFormTemplateControl("txtFluorescence")
            as ASPxTextBox).Value;
        e.NewValues["description"] = (gv_Fluorescence.FindEditFormTemplateControl("txtDescription")
                     as ASPxTextBox).Value;
    }

    protected void gv_Fluorescence_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
    {
        //if (gv_Fluorescence.IsNewRowEditing == false)
        //{
        //    gv_Fluorescence.DoRowValidation();
        //}
    }

    protected void gv_Fluorescence_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {
        e.NewValues["value"] = (gv_Fluorescence.FindEditFormTemplateControl("txtFluorescence") as ASPxTextBox).Value;
        String Fluorescence = (e.NewValues["value"] == null ? string.Empty : e.NewValues["value"].ToString());
        if (Fluorescence == String.Empty)
        {
            throw new Exception("Fluorescence must not be empty!");
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

        if (Stone.checkFluorescenceExist(Fluorescence, ID) == true)
        {
            throw new Exception("Fluorescence: " + Fluorescence + " already exist!");
        }
    }

    protected void gv_Fluorescence_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
    }

    protected void gv_Fluorescence_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {
    }
}
