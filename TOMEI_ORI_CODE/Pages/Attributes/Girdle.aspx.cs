using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;

public partial class Pages_Girdle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Attributes: Girdle";
        UserSet myUser = (UserSet)Session["User"];
        if ((myUser.Role != "Administrator") && (myUser.Role != "Power User"))
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
    }

    protected void gv_Girdle_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        e.NewValues["value"] = (gv_Girdle.FindEditFormTemplateControl("txtGirdle")
            as ASPxTextBox).Value;
        e.NewValues["description"] = (gv_Girdle.FindEditFormTemplateControl("txtDescription")
                     as ASPxTextBox).Value;
    }

    protected void gv_Girdle_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        e.NewValues["value"] = (gv_Girdle.FindEditFormTemplateControl("txtGirdle")
            as ASPxTextBox).Value;
        e.NewValues["description"] = (gv_Girdle.FindEditFormTemplateControl("txtDescription")
                     as ASPxTextBox).Value;
    }

    protected void gv_Girdle_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
    {
        //if (gv_Girdle.IsNewRowEditing == false)
        //{
        //    gv_Girdle.DoRowValidation();
        //}
    }

    protected void gv_Girdle_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {
        e.NewValues["value"] = (gv_Girdle.FindEditFormTemplateControl("txtGirdle") as ASPxTextBox).Value;
        String Girdle = (e.NewValues["value"] == null ? string.Empty : e.NewValues["value"].ToString());
        if (Girdle == String.Empty)
        {
            throw new Exception("Girdle must not be empty!");
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

        if (Stone.checkGirdleExist(Girdle, ID) == true)
        {
            throw new Exception("Girdle: " + Girdle + " already exist!");
        }
    }

    protected void gv_Girdle_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
    }

    protected void gv_Girdle_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {
    }
}
