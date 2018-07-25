using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;

public partial class Pages_Symmetry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Attributes: Symmetry";
        UserSet myUser = (UserSet)Session["User"];
        if ((myUser.Role != "Administrator") && (myUser.Role != "Power User"))
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
    }

    protected void gv_Symmetry_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        e.NewValues["value"] = (gv_Symmetry.FindEditFormTemplateControl("txtSymmetry")
            as ASPxTextBox).Value;
        e.NewValues["description"] = (gv_Symmetry.FindEditFormTemplateControl("txtDescription")
                     as ASPxTextBox).Value;
    }

    protected void gv_Symmetry_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        e.NewValues["value"] = (gv_Symmetry.FindEditFormTemplateControl("txtSymmetry")
            as ASPxTextBox).Value;
        e.NewValues["description"] = (gv_Symmetry.FindEditFormTemplateControl("txtDescription")
                     as ASPxTextBox).Value;
    }

    protected void gv_Symmetry_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
    {
        //if (gv_Symmetry.IsNewRowEditing == false)
        //{
        //    gv_Symmetry.DoRowValidation();
        //}
    }

    protected void gv_Symmetry_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {
        e.NewValues["value"] = (gv_Symmetry.FindEditFormTemplateControl("txtSymmetry") as ASPxTextBox).Value;
        String Symmetry = (e.NewValues["value"] == null ? string.Empty : e.NewValues["value"].ToString());
        if (Symmetry == String.Empty)
        {
            throw new Exception("Symmetry must not be empty!");
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

        if (Stone.checkSymmetryExist(Symmetry, ID) == true)
        {
            throw new Exception("Symmetry: " + Symmetry + " already exist!");
        }
    }

    protected void gv_Symmetry_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
    }

    protected void gv_Symmetry_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {
    }
}
