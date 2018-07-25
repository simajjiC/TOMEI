using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;

public partial class Pages_Colour : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Attributes: Colour";
        UserSet myUser = (UserSet)Session["User"];
        if ((myUser.Role != "Administrator") && (myUser.Role != "Power User"))
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
    }

    protected void gv_Colour_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        e.NewValues["value"] = (gv_Colour.FindEditFormTemplateControl("txtColour")
            as ASPxTextBox).Value;
        e.NewValues["description"] = (gv_Colour.FindEditFormTemplateControl("txtDescription")
                     as ASPxTextBox).Value;
    }

    protected void gv_Colour_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        e.NewValues["value"] = (gv_Colour.FindEditFormTemplateControl("txtColour")
            as ASPxTextBox).Value;
        e.NewValues["description"] = (gv_Colour.FindEditFormTemplateControl("txtDescription")
                     as ASPxTextBox).Value;
    }

    protected void gv_Colour_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
    {
        //if (gv_Colour.IsNewRowEditing == false)
        //{
        //    gv_Colour.DoRowValidation();
        //}
    }

    protected void gv_Colour_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {
        e.NewValues["value"] = (gv_Colour.FindEditFormTemplateControl("txtColour") as ASPxTextBox).Value;
        String Colour = (e.NewValues["value"] == null ? string.Empty : e.NewValues["value"].ToString());
        if (Colour == String.Empty)
        {
            throw new Exception("Colour must not be empty!");
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

        if (Stone.checkColourExist(Colour, ID) == true)
        {
            throw new Exception("Colour: " + Colour + " already exist!");
        }
    }

    protected void gv_Colour_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
    }

    protected void gv_Colour_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {
    }
}
