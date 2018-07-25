using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

public partial class Pages_ProductSeries : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Product Series";
        UserSet myUser = (UserSet)Session["User"];
        if ((myUser.Role != "Administrator") && (myUser.Role != "Power User"))
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
    }

    protected void gv_ProductSeries_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        //ASPxGridView grid = sender as ASPxGridView;
        e.NewValues["SeriesPrefix"] = (gv_ProductSeries.FindEditFormTemplateControl("txtSeriesPrefix") as ASPxTextBox).Value;
        e.NewValues["ProductSubCategory"] = (gv_ProductSeries.FindEditFormTemplateControl("ddlProductSubCategory") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["ProductCategory"] = (gv_ProductSeries.FindEditFormTemplateControl("ddlProductCategory") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["SeriesDescription"] = ((gv_ProductSeries.FindEditFormTemplateControl("PanelDescription") as DevExpress.Web.ASPxCallbackPanel.ASPxCallbackPanel).FindControl("txtSeriesDescription") as ASPxMemo).Text;
        e.NewValues["BarcodeFlag"] = (gv_ProductSeries.FindEditFormTemplateControl("ASPxCheckBoxBarcode") as ASPxCheckBox).Value;
        e.NewValues["userid"] = ((UserSet)Session["User"]).UserID;
    }

    protected void gv_ProductSeries_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        //ASPxGridView grid = sender as ASPxGridView;
        e.NewValues["SeriesPrefix"] = (gv_ProductSeries.FindEditFormTemplateControl("txtSeriesPrefix") as ASPxTextBox).Value;
        e.NewValues["ProductSubCategory"] = (gv_ProductSeries.FindEditFormTemplateControl("ddlProductSubCategory") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["ProductCategory"] = (gv_ProductSeries.FindEditFormTemplateControl("ddlProductCategory") as ASPxComboBox).SelectedItem.Value;
        e.NewValues["SeriesDescription"] = ((gv_ProductSeries.FindEditFormTemplateControl("PanelDescription") as DevExpress.Web.ASPxCallbackPanel.ASPxCallbackPanel).FindControl("txtSeriesDescription") as ASPxMemo).Text;
        e.NewValues["BarcodeFlag"] = (gv_ProductSeries.FindEditFormTemplateControl("ASPxCheckBoxBarcode") as ASPxCheckBox).Value;
        e.NewValues["userid"] = ((UserSet)Session["User"]).UserID;
    } 

    protected void gv_ProductSeries_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
    {
        ASPxComboBox ddlProductCategory = (gv_ProductSeries.FindEditFormTemplateControl("ddlProductCategory") as ASPxComboBox);
        ASPxComboBox ddlProductSubCategory = (gv_ProductSeries.FindEditFormTemplateControl("ddlProductSubCategory") as ASPxComboBox);
        if (gv_ProductSeries.IsNewRowEditing == false)
        {
            ddlProductCategory.SelectedItem = (gv_ProductSeries.FindEditFormTemplateControl("ddlProductCategory") as ASPxComboBox).Items.FindByValue(Product.getProductCategoryID(e.EditingKeyValue.ToString()).ToString());
            ddlProductSubCategory.SelectedItem = (gv_ProductSeries.FindEditFormTemplateControl("ddlProductSubCategory") as ASPxComboBox).Items.FindByValue(Product.getProductSubCategoryID(e.EditingKeyValue.ToString()).ToString());
        }
        else
        {
            ddlProductCategory.SelectedIndex = 0;
            ddlProductSubCategory.SelectedIndex = 0;
        }
    }

    protected void gv_ProductSeries_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {
        ASPxComboBox ddlProductCategory = (gv_ProductSeries.FindEditFormTemplateControl("ddlProductCategory") as ASPxComboBox);
        ASPxComboBox ddlProductSubCategory = (gv_ProductSeries.FindEditFormTemplateControl("ddlProductSubCategory") as ASPxComboBox);
        ASPxTextBox txtSeriesPrefix = (gv_ProductSeries.FindEditFormTemplateControl("txtSeriesPrefix") as ASPxTextBox);

        int ProductCategory = int.Parse(ddlProductCategory.SelectedItem.Value.ToString());
        int ProductSubCategory = int.Parse(ddlProductSubCategory.SelectedItem.Value.ToString());
        String SeriesPrefix = txtSeriesPrefix.Text;

        if (SeriesPrefix == String.Empty)
        {
            throw new Exception("Remarks is Empty!");
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

        if (Product.checkProductSeriesExist(ProductCategory, ProductSubCategory, ID) == true)
        {
            throw new Exception("This Combination of Category and Sub Category already exists in Database!");
        }

        //if (Product.checkProductSeriesPrefixExist(SeriesPrefix, ID) == true)
        //{
        //    throw new Exception("Remarks already exists in Database!");
        //}
    }

    protected void gv_ProductSeries_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
    {
        //Session.Remove("SeriesCode");
        //Session.Remove("SeriesName");
        //Session.Remove("ProductCategory");
        //Session.Remove("SeriesImage");
    }

    protected void gv_ProductSeries_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {
        //Session.Remove("SeriesCode");
        //Session.Remove("SeriesName");
        //Session.Remove("ProductCategory");
        //Session.Remove("SeriesImage");
    }

    protected void ds_ProductSeries_Updating(object sender, SqlDataSourceCommandEventArgs e)
    {              
        //byte[] imageData = Session["SeriesImage"] as byte[];
        //System.Data.SqlClient.SqlParameter uploadData = new System.Data.SqlClient.SqlParameter("@SeriesImage", System.Data.SqlDbType.Image);
        //uploadData.Value = imageData;        
        //e.Command.Parameters.Add(uploadData);
    }

    protected void ds_ProductSeries_Inserting(object sender, SqlDataSourceCommandEventArgs e)
    {
        //byte[] imageData = Session["SeriesImage"] as byte[];
        //System.Data.SqlClient.SqlParameter uploadData = new System.Data.SqlClient.SqlParameter("@SeriesImage", System.Data.SqlDbType.Image);
        //uploadData.Value = imageData;
        //e.Command.Parameters.Add(uploadData);
    }

    protected void ddlProductCategory_OnLoad(object sender, EventArgs e)
    {
        populateCategory(sender);
    }

    protected void ddlProductSubCategory_OnLoad(object sender, EventArgs e)
    {
        populateSubCategory(sender);
    }

    private void populateCategory(object sender)
    {
        ASPxComboBox ddlProductCategory = sender as ASPxComboBox;
        ddlProductCategory.Items.Clear();
        DB f_DBEngine = new DB();        
        System.Data.SqlClient.SqlDataReader f_Reader = f_DBEngine.GetRows("S_ListProductCategory");
        if (f_Reader.HasRows == true)
        {
            while (f_Reader.Read())
            {
                ddlProductCategory.Items.Add(f_Reader["CategoryCode"].ToString(), f_Reader["id"].ToString());
            }
        }
        f_Reader = null;
        f_DBEngine.closeConn();
        f_DBEngine = null;        
    }

    private void populateSubCategory(object sender)
    {
        ASPxComboBox ddlProductSubCategory = sender as ASPxComboBox;
        ddlProductSubCategory.Items.Clear();
        DB f_DBEngine = new DB();
        System.Data.SqlClient.SqlDataReader f_Reader = f_DBEngine.GetRows("S_ListProductSubCategory");
        if (f_Reader.HasRows == true)
        {
            while (f_Reader.Read())
            {
                ddlProductSubCategory.Items.Add(f_Reader["SubCategoryCode"].ToString(), f_Reader["id"].ToString());
            }
        }
        f_Reader = null;
        f_DBEngine.closeConn();
        f_DBEngine = null;        
    }

    protected void PanelDescription_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
    {
        DevExpress.Web.ASPxCallbackPanel.ASPxCallbackPanel PanelDescription = (sender as DevExpress.Web.ASPxCallbackPanel.ASPxCallbackPanel);

        ASPxMemo txtSeriesDescription = (PanelDescription.FindControl("txtSeriesDescription") as ASPxMemo);
        ASPxComboBox ddlProductCategory = (gv_ProductSeries.FindEditFormTemplateControl("ddlProductCategory") as ASPxComboBox);
        ASPxComboBox ddlProductSubCategory = (gv_ProductSeries.FindEditFormTemplateControl("ddlProductSubCategory") as ASPxComboBox);

        String ProductCategory = "";
        String ProductSubCategory = "";
        

        try
        {
            ProductCategory = ddlProductCategory.SelectedItem.Text.ToString();
        }
        catch (Exception ex)
        {
        }

        try
        {
            ProductSubCategory = ddlProductSubCategory.SelectedItem.Text.ToString();
        }
        catch (Exception ex)
        {
        }

        txtSeriesDescription.Text = ProductCategory + " " + ProductSubCategory;
    }

    protected bool GenerateBindString(object dataItem)
    {
       
        bool ret = false;

        if (DataBinder.Eval(dataItem, "BarcodeFlag") != null)
        {
            if (((DataBinder.Eval(dataItem, "BarcodeFlag")).ToString() == null) || ((DataBinder.Eval(dataItem, "BarcodeFlag")).ToString() == "True"))
                ret = true;
            else

                ret = false;
        }
            return ret;
        

         
    }

    //protected void Barcode_checked(object sender, EventArgs e)
    //{
    //    ASPxCheckBox ASPxCheckBoxBarcode = sender as ASPxCheckBox;
    //    if (ASPxCheckBoxBarcode.Checked == false)
    //    {
  


    //        }
    //}
}
