using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

public partial class Pages_Search : System.Web.UI.Page
{
    Boolean RequiredBarcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Stone Record: Enquiry";
        
    }

    protected void btnMultipleCreate_Click(object sender, EventArgs e)
    {
       

        if ((gv_Stone.FindEditFormTemplateControl("txtMultipleCreate") as ASPxTextBox).Value == null)
        {
            Response.Write("<script>alert('Please key in the value for Multiple Create!');</script>");
        }else
        {
            if (Tool.IsNumeric((gv_Stone.FindEditFormTemplateControl("txtMultipleCreate") as ASPxTextBox).Value.ToString().Trim()) == false)
            {
                Response.Write("<script>alert('Multiple Create format is invalid!');</script>");
                (gv_Stone.FindEditFormTemplateControl("txtMultipleCreate") as ASPxTextBox).Value = "";
                (gv_Stone.FindEditFormTemplateControl("txtMultipleCreate") as ASPxTextBox).Focus();
            }
            else if (((gv_Stone.FindEditFormTemplateControl("txtStoneID") as ASPxTextBox).Value == null) || ((gv_Stone.FindEditFormTemplateControl("txtWeight") as ASPxTextBox).Value == null) || 
                ((gv_Stone.FindEditFormTemplateControl("ddlClarity") as ASPxComboBox).SelectedItem.Value == null) || ((gv_Stone.FindEditFormTemplateControl("ddlColour") as ASPxComboBox).SelectedItem.Value == null) ||
                ((gv_Stone.FindEditFormTemplateControl("ddlFluorescence") as ASPxComboBox).SelectedItem.Value == null) || ((gv_Stone.FindEditFormTemplateControl("ddlGirdle") as ASPxComboBox).SelectedItem.Value == null) ||
                ((gv_Stone.FindEditFormTemplateControl("ddlPolish") as ASPxComboBox).SelectedItem.Value == null) || ((gv_Stone.FindEditFormTemplateControl("ddlSymmetry") as ASPxComboBox).SelectedItem.Value == null) ||
                ((gv_Stone.FindEditFormTemplateControl("txtDepth") as ASPxTextBox).Value == null) || ((gv_Stone.FindEditFormTemplateControl("txtSize") as ASPxTextBox).Value == null) ||
                ((gv_Stone.FindEditFormTemplateControl("txtMin") as ASPxTextBox).Value == null) || ((gv_Stone.FindEditFormTemplateControl("txtMax") as ASPxTextBox).Value == null) ||
                ((gv_Stone.FindEditFormTemplateControl("txtTable") as ASPxTextBox).Value == null))
            {
                Response.Write("<script>alert('Please fill in the blank!');</script>");
                (gv_Stone.FindEditFormTemplateControl("txtMultipleCreate") as ASPxTextBox).Value = "";
            }
            else
            {
                ASPxLabel lblEmptyMsg = (ASPxLabel)FindControl("lblEmptyMsg");

                var StoneID = Convert.ToString((gv_Stone.FindEditFormTemplateControl("txtStoneID") as ASPxTextBox).Value);
                var Weight = Convert.ToString((gv_Stone.FindEditFormTemplateControl("txtWeight") as ASPxTextBox).Value);
                var Clarity = Convert.ToInt32((gv_Stone.FindEditFormTemplateControl("ddlClarity") as ASPxComboBox).SelectedItem.Value);
                var Colour = Convert.ToInt32((gv_Stone.FindEditFormTemplateControl("ddlColour") as ASPxComboBox).SelectedItem.Value);
                var Fluorescence = Convert.ToInt32((gv_Stone.FindEditFormTemplateControl("ddlFluorescence") as ASPxComboBox).SelectedItem.Value);
                var Girdle = Convert.ToInt32((gv_Stone.FindEditFormTemplateControl("ddlGirdle") as ASPxComboBox).SelectedItem.Value);
                var Polish = Convert.ToInt32((gv_Stone.FindEditFormTemplateControl("ddlPolish") as ASPxComboBox).SelectedItem.Value);
                var Symmetry = Convert.ToInt32((gv_Stone.FindEditFormTemplateControl("ddlSymmetry") as ASPxComboBox).SelectedItem.Value);
                var Depth = Convert.ToInt32((gv_Stone.FindEditFormTemplateControl("txtDepth") as ASPxTextBox).Value);
                var Size = Convert.ToInt32((gv_Stone.FindEditFormTemplateControl("txtSize") as ASPxTextBox).Value);
                var Measurement_1 = Convert.ToInt32((gv_Stone.FindEditFormTemplateControl("txtMin") as ASPxTextBox).Value);
                var Measurement_2 = Convert.ToInt32((gv_Stone.FindEditFormTemplateControl("txtMax") as ASPxTextBox).Value);
                var Measurement_3 = Convert.ToInt32((gv_Stone.FindEditFormTemplateControl("txtTable") as ASPxTextBox).Value);
                var UserID = ((UserSet)Session["User"]).UserID;

                var createNumberTimes = Convert.ToInt32((gv_Stone.FindEditFormTemplateControl("txtMultipleCreate") as ASPxTextBox).Value);

                if (StoneID.ToUpper().ToString() == "NIL")
                {
                    if (createNumberTimes != 0)
                    {
                        for (int i = 0; i < createNumberTimes; i++)
                        {
                            Stone.insertStone(StoneID, Weight, Clarity, Colour, Fluorescence, Girdle, Polish, Symmetry, Depth, Size, Measurement_1, Measurement_2, Measurement_3, UserID);

                        }
                        //Stone.insertStone(StoneID, Weight, Clarity, Colour, Fluorescence, Girdle, Polish, Symmetry, Depth, Size, Measurement_1, Measurement_2, Measurement_3, UserID);

                        Response.Write("<script>if(confirm('" + createNumberTimes + " records inserted successfully')){ document.location = 'Search.aspx';}else{document.location = 'Search.aspx';}</script>");
                        //Response.Redirect("~/Pages/Stone/Search.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Please key in the value for Multiple Create');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('This function is only for StoneID equal to NIL');</script>");
                }
            }
        }
        
        




    }

    //protected void NullValidate(object source, ServerValidateEventArgs arguments)
    //{
    //    var createNumberTimes = Convert.ToInt32((gv_Stone.FindEditFormTemplateControl("txtMultipleCreate") as ASPxTextBox).Value);
    //    RequiredBarcode = checkRequiredNumber();
    //    if (RequiredBarcode == true)
    //    {
    //        //check txtProductNo is empty
    //        if (createNumberTimes == 0 || createNumberTimes == null)
    //        {
    //            arguments.IsValid = false;
    //        }
    //        else
    //        {
    //            arguments.IsValid = true;
    //        }
    //    }
    //    else
    //    {
    //        arguments.IsValid = false;
    //    }

    //}

    //private Boolean checkRequiredNumber()
    //{


    //    int createNumberTimes = 0;
    //    //string ProductBarcode = "";
    //    Boolean rValue = false;

    //    try
    //    {
    //        createNumberTimes = Convert.ToInt32((gv_Stone.FindEditFormTemplateControl("txtMultipleCreate") as ASPxTextBox).Value);
    //        //var str = txtMultipleCreate.Value.ToString();
    //        //ProductBarcode = str.Substring(0, 2);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine("An error occurred: '{0}'", ex);
    //    }


    //    /*
    //     logic to check this product series required barcode
    //     if required
    //        rValue = true;
    //     else
    //        rValue = false;
    //    */
    //    if (createNumberTimes != 0 )
    //    {
    //        rValue = true;
    //    }
    //    else
    //    {
    //        rValue = false;
    //    }
    //    return rValue;


    //}

    protected void gv_Stone_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCommandButtonEventArgs e)
    {
        if (e.Button.ButtonType == DevExpress.Web.ASPxGridView.ColumnCommandButtonType.Edit)
        {
            UserSet myUser = (UserSet)Session["User"];
            if ((myUser.Role != "Administrator") && (myUser.Role != "Power User"))
            {
                e.Visible = false;
            }            
        }
        if (e.Button.ButtonType == DevExpress.Web.ASPxGridView.ColumnCommandButtonType.Delete)
        {
            UserSet myUser = (UserSet)Session["User"];
            if ((myUser.Role != "Administrator") && (myUser.Role != "Power User"))
            {
                e.Visible = false;
            }
        }
    }

    protected void gv_Stone_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
    {
        ASPxComboBox ddlClarity = (gv_Stone.FindEditFormTemplateControl("ddlClarity") as ASPxComboBox);
        ASPxComboBox ddlColour = (gv_Stone.FindEditFormTemplateControl("ddlColour") as ASPxComboBox);
        ASPxComboBox ddlFluorescence = (gv_Stone.FindEditFormTemplateControl("ddlFluorescence") as ASPxComboBox);
        ASPxComboBox ddlGirdle = (gv_Stone.FindEditFormTemplateControl("ddlGirdle") as ASPxComboBox);
        ASPxComboBox ddlPolish = (gv_Stone.FindEditFormTemplateControl("ddlPolish") as ASPxComboBox);
        ASPxComboBox ddlSymmetry = (gv_Stone.FindEditFormTemplateControl("ddlSymmetry") as ASPxComboBox);
        
        if (gv_Stone.IsNewRowEditing == false)
        {
            (gv_Stone.FindEditFormTemplateControl("txtStoneID") as ASPxTextBox).Enabled = false;
            ddlClarity.SelectedItem = (gv_Stone.FindEditFormTemplateControl("ddlClarity") as ASPxComboBox).Items.FindByValue(Stone.getClarityID(e.EditingKeyValue.ToString()).ToString());
            ddlColour.SelectedItem = (gv_Stone.FindEditFormTemplateControl("ddlColour") as ASPxComboBox).Items.FindByValue(Stone.getColourID(e.EditingKeyValue.ToString()).ToString());
            ddlFluorescence.SelectedItem = (gv_Stone.FindEditFormTemplateControl("ddlFluorescence") as ASPxComboBox).Items.FindByValue(Stone.getFluorescenceID(e.EditingKeyValue.ToString()).ToString());
            ddlGirdle.SelectedItem = (gv_Stone.FindEditFormTemplateControl("ddlGirdle") as ASPxComboBox).Items.FindByValue(Stone.getGirdleID(e.EditingKeyValue.ToString()).ToString());
            ddlPolish.SelectedItem = (gv_Stone.FindEditFormTemplateControl("ddlPolish") as ASPxComboBox).Items.FindByValue(Stone.getPolishID(e.EditingKeyValue.ToString()).ToString());
            ddlSymmetry.SelectedItem = (gv_Stone.FindEditFormTemplateControl("ddlSymmetry") as ASPxComboBox).Items.FindByValue(Stone.getSymmetryID(e.EditingKeyValue.ToString()).ToString());
        }
        else
        {
            (gv_Stone.FindEditFormTemplateControl("txtStoneID") as ASPxTextBox).Enabled = true;
            ddlClarity.SelectedIndex = 0;
            ddlColour.SelectedIndex = 0;
            ddlFluorescence.SelectedIndex = 0;
            ddlGirdle.SelectedIndex = 0;
            ddlPolish.SelectedIndex = 0;
            ddlSymmetry.SelectedIndex = 0;
        }
    }

    protected void gv_Stone_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        e.NewValues["StoneID"] = (gv_Stone.FindEditFormTemplateControl("txtStoneID") as ASPxTextBox).Value;
        e.NewValues["Weight"] = (gv_Stone.FindEditFormTemplateControl("txtWeight") as ASPxTextBox).Value;
        e.NewValues["Clarity"] = (gv_Stone.FindEditFormTemplateControl("ddlClarity") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["Colour"] = (gv_Stone.FindEditFormTemplateControl("ddlColour") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["Fluorescence"] = (gv_Stone.FindEditFormTemplateControl("ddlFluorescence") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["Girdle"] = (gv_Stone.FindEditFormTemplateControl("ddlGirdle") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["Polish"] = (gv_Stone.FindEditFormTemplateControl("ddlPolish") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["Symmetry"] = (gv_Stone.FindEditFormTemplateControl("ddlSymmetry") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["Depth"] = (gv_Stone.FindEditFormTemplateControl("txtDepth") as ASPxTextBox).Value.ToString().TrimEnd('%');
        e.NewValues["Size"] = (gv_Stone.FindEditFormTemplateControl("txtSize") as ASPxTextBox).Value.ToString().TrimEnd('%');
        e.NewValues["Measurement_1"] = (gv_Stone.FindEditFormTemplateControl("txtMin") as ASPxTextBox).Value;
        e.NewValues["Measurement_2"] = (gv_Stone.FindEditFormTemplateControl("txtMax") as ASPxTextBox).Value;
        e.NewValues["Measurement_3"] = (gv_Stone.FindEditFormTemplateControl("txtTable") as ASPxTextBox).Value;
        e.NewValues["adminuserid"] = ((UserSet)Session["User"]).UserID;
    }

    protected void gv_Stone_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        e.NewValues["StoneID"] = (gv_Stone.FindEditFormTemplateControl("txtStoneID") as ASPxTextBox).Value;
        var StoneID = e.NewValues["StoneID"].ToString();
        if (StoneID.ToUpper() != "NIL")
        {
            if (Tool.IsNumeric((gv_Stone.FindEditFormTemplateControl("txtWeight") as ASPxTextBox).Value.ToString().Trim()) == false)
            {
                throw new Exception("Weight format is invalid. Only StoneID is NIL can allow alphabet!");
            }
        }

        e.NewValues["Weight"] = (gv_Stone.FindEditFormTemplateControl("txtWeight") as ASPxTextBox).Value;
        e.NewValues["Clarity"] = (gv_Stone.FindEditFormTemplateControl("ddlClarity") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["Colour"] = (gv_Stone.FindEditFormTemplateControl("ddlColour") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["Fluorescence"] = (gv_Stone.FindEditFormTemplateControl("ddlFluorescence") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["Girdle"] = (gv_Stone.FindEditFormTemplateControl("ddlGirdle") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["Polish"] = (gv_Stone.FindEditFormTemplateControl("ddlPolish") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["Symmetry"] = (gv_Stone.FindEditFormTemplateControl("ddlSymmetry") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["Depth"] = (gv_Stone.FindEditFormTemplateControl("txtDepth") as ASPxTextBox).Value;
        e.NewValues["Size"] = (gv_Stone.FindEditFormTemplateControl("txtSize") as ASPxTextBox).Value;
        e.NewValues["Measurement_1"] = (gv_Stone.FindEditFormTemplateControl("txtMin") as ASPxTextBox).Value;
        e.NewValues["Measurement_2"] = (gv_Stone.FindEditFormTemplateControl("txtMax") as ASPxTextBox).Value;
        e.NewValues["Measurement_3"] = (gv_Stone.FindEditFormTemplateControl("txtTable") as ASPxTextBox).Value;
        e.NewValues["adminuserid"] = ((UserSet)Session["User"]).UserID;
    }

    protected void gv_Stone_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {
        if (e.IsNewRow)
        {
            if (Stone.checkExist((gv_Stone.FindEditFormTemplateControl("txtStoneID") as ASPxTextBox).Value.ToString()) == true)
            {
                throw new Exception("Stone ID already Exist!");
            }
        }

        if ((gv_Stone.FindEditFormTemplateControl("txtWeight") as ASPxTextBox).Value.ToString().Trim() == String.Empty)
        {
            throw new Exception("Weight cannot be blank!");
        }

        //if (Tool.IsNumeric((gv_Stone.FindEditFormTemplateControl("txtWeight") as ASPxTextBox).Value.ToString().Trim()) == false)
        //{
        //    throw new Exception("Weight format is invalid");
        //}

        if ((gv_Stone.FindEditFormTemplateControl("txtDepth") as ASPxTextBox).Value.ToString().Trim() == String.Empty)
        {
            throw new Exception("Depth cannot be blank!");
        }

        if (Tool.IsNumeric((gv_Stone.FindEditFormTemplateControl("txtDepth") as ASPxTextBox).Value.ToString().Trim().TrimEnd('%')) == false)
        {
            throw new Exception("Depth format is invalid!");
        }

        if ((gv_Stone.FindEditFormTemplateControl("txtSize") as ASPxTextBox).Value.ToString().Trim() == String.Empty)
        {
            throw new Exception("Size cannot be blank!");
        }

        if (Tool.IsNumeric((gv_Stone.FindEditFormTemplateControl("txtSize") as ASPxTextBox).Value.ToString().Trim().TrimEnd('%')) == false)
        {
            throw new Exception("Size format is invalid!");
        }

        if ((gv_Stone.FindEditFormTemplateControl("txtMin") as ASPxTextBox).Value.ToString().Trim() == String.Empty)
        {
            throw new Exception("Min cannot be blank!");
        }

        if (Tool.IsNumeric((gv_Stone.FindEditFormTemplateControl("txtMin") as ASPxTextBox).Value.ToString().Trim()) == false)
        {
            throw new Exception("Min format is invalid!");
        }

        if ((gv_Stone.FindEditFormTemplateControl("txtMax") as ASPxTextBox).Value.ToString().Trim() == String.Empty)
        {
            throw new Exception("Max cannot be blank!");
        }
        
        if (Tool.IsNumeric((gv_Stone.FindEditFormTemplateControl("txtMax") as ASPxTextBox).Value.ToString().Trim()) == false)
        {
            throw new Exception("Max format is invalid!");
        }

        if ((gv_Stone.FindEditFormTemplateControl("txtTable") as ASPxTextBox).Value.ToString().Trim() == String.Empty)
        {
            throw new Exception("Table cannot be blank!");
        }

        if (Tool.IsNumeric((gv_Stone.FindEditFormTemplateControl("txtTable") as ASPxTextBox).Value.ToString().Trim()) == false)
        {
            throw new Exception("Table format is invalid!");
        }
    }

    protected void ddlClarity_OnLoad(object sender, EventArgs e)
    {
        populateClarity(sender);
    }

    private void populateClarity(object sender)
    {
        ASPxComboBox ddlClarity = sender as ASPxComboBox;
        ddlClarity.Items.Clear();
        DB f_DBEngine = new DB();
        System.Data.SqlClient.SqlDataReader f_Reader = f_DBEngine.GetRows("S_ListClarity");
        if (f_Reader.HasRows == true)
        {
            while (f_Reader.Read())
            {
                ddlClarity.Items.Add(f_Reader["value"].ToString(), f_Reader["id"].ToString());
            }
        }
        f_Reader = null;
        f_DBEngine.closeConn();
        f_DBEngine = null;
    }

    protected void ddlColour_OnLoad(object sender, EventArgs e)
    {
        populateColour(sender);
    }

    private void populateColour(object sender)
    {
        ASPxComboBox ddlColour = sender as ASPxComboBox;
        ddlColour.Items.Clear();
        DB f_DBEngine = new DB();
        System.Data.SqlClient.SqlDataReader f_Reader = f_DBEngine.GetRows("S_ListColour");
        if (f_Reader.HasRows == true)
        {
            while (f_Reader.Read())
            {
                ddlColour.Items.Add(f_Reader["value"].ToString(), f_Reader["id"].ToString());
            }
        }
        f_Reader = null;
        f_DBEngine.closeConn();
        f_DBEngine = null;
    }

    protected void ddlFluorescence_OnLoad(object sender, EventArgs e)
    {
        populateFluorescence(sender);
    }

    private void populateFluorescence(object sender)
    {
        ASPxComboBox ddlFluorescence = sender as ASPxComboBox;
        ddlFluorescence.Items.Clear();
        DB f_DBEngine = new DB();
        System.Data.SqlClient.SqlDataReader f_Reader = f_DBEngine.GetRows("S_ListFluorescence");
        if (f_Reader.HasRows == true)
        {
            while (f_Reader.Read())
            {
                ddlFluorescence.Items.Add(f_Reader["value"].ToString(), f_Reader["id"].ToString());
            }
        }
        f_Reader = null;
        f_DBEngine.closeConn();
        f_DBEngine = null;
    }

    protected void ddlGirdle_OnLoad(object sender, EventArgs e)
    {
        populateGirdle(sender);
    }

    private void populateGirdle(object sender)
    {
        ASPxComboBox ddlGirdle = sender as ASPxComboBox;
        ddlGirdle.Items.Clear();
        DB f_DBEngine = new DB();
        System.Data.SqlClient.SqlDataReader f_Reader = f_DBEngine.GetRows("S_ListGirdle");
        if (f_Reader.HasRows == true)
        {
            while (f_Reader.Read())
            {
                ddlGirdle.Items.Add(f_Reader["value"].ToString(), f_Reader["id"].ToString());
            }
        }
        f_Reader = null;
        f_DBEngine.closeConn();
        f_DBEngine = null;
    }

    protected void ddlPolish_OnLoad(object sender, EventArgs e)
    {
        populatePolish(sender);
    }

    private void populatePolish(object sender)
    {
        ASPxComboBox ddlPolish = sender as ASPxComboBox;
        ddlPolish.Items.Clear();
        DB f_DBEngine = new DB();
        System.Data.SqlClient.SqlDataReader f_Reader = f_DBEngine.GetRows("S_ListPolish");
        if (f_Reader.HasRows == true)
        {
            while (f_Reader.Read())
            {
                ddlPolish.Items.Add(f_Reader["value"].ToString(), f_Reader["id"].ToString());
            }
        }
        f_Reader = null;
        f_DBEngine.closeConn();
        f_DBEngine = null;
    }

    protected void ddlSymmetry_OnLoad(object sender, EventArgs e)
    {
        populateSymmetry(sender);
    }

    private void populateSymmetry(object sender)
    {
        ASPxComboBox ddlSymmetry = sender as ASPxComboBox;
        ddlSymmetry.Items.Clear();
        DB f_DBEngine = new DB();
        System.Data.SqlClient.SqlDataReader f_Reader = f_DBEngine.GetRows("S_ListSymmetry");
        if (f_Reader.HasRows == true)
        {
            while (f_Reader.Read())
            {
                ddlSymmetry.Items.Add(f_Reader["value"].ToString(), f_Reader["id"].ToString());
            }
        }
        f_Reader = null;
        f_DBEngine.closeConn();
        f_DBEngine = null;
    }
}
