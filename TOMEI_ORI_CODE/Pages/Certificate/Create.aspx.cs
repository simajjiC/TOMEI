using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

public partial class Pages_Create : System.Web.UI.Page
{
    Boolean RequiredBarcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Create Certificate";
        UserSet myUser = (UserSet)Session["User"];
        txthidfield.Value = txtProductNo.Text.Trim();

        


        if (myUser.Role == "Limited")
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
        if (!IsPostBack)
        {
            populateProductSeries();
            if (ddlProductSeries.SelectedItem.Value.ToString() != null)
            {
                string ddlProdSeries_Hid2 = ddlProductSeries.SelectedItem.Value.ToString();
                ddlProdSeries_Hid.Value = ddlProdSeries_Hid2;
            }
            RequiredBarcode = initialcheckRequiredBarcode();
            if (RequiredBarcode == false)
            {
                txtProductNo.Enabled = false;
                txtProductNo.Text = " ";
                
            }
            else
            {
                txtProductNo.Enabled = true;
            }
        }
        else
        {
            if (ddlProductSeries.SelectedItem != null)
            {
                string ddlProdSeries_Hid2 = ddlProductSeries.SelectedItem.Value.ToString();
                ddlProdSeries_Hid.Value = ddlProdSeries_Hid2;
            }
            RequiredBarcode = checkRequiredBarcode();
                   if (RequiredBarcode == false)
            {
                txtProductNo.Enabled = true;
                txtProductNo.Text = " ";
                
            }
            else
            {
                txtProductNo.Enabled = true;
            }
        }
    }

    private void populateProductSeries()
    {
        ddlProductSeries.Items.Clear();
        DB f_DBEngine = new DB();
        System.Data.SqlClient.SqlDataReader f_Reader = f_DBEngine.GetRows("S_ListProductSeries");
        if (f_Reader.HasRows == true)
        {
            while (f_Reader.Read())
            {
                //ddlProductSeries.Items.Add(new ListItem(f_Reader["SeriesPrefix"].ToString() + "-" + f_Reader["SeriesDescription"].ToString(), f_Reader["id"].ToString()));
                ddlProductSeries.Items.Add(f_Reader["SeriesPrefix"].ToString() + "-" + f_Reader["SeriesDescription"].ToString(), f_Reader["id"].ToString());
    
            }
        }
        f_Reader = null;
        f_DBEngine.closeConn();
        f_DBEngine = null;
        
        if (!IsPostBack)
        {
            ddlProductSeries.SelectedIndex = 0;
            RequiredBarcode = checkRequiredBarcode();
        }
    }

    protected void btnCreate_Click(object sender, EventArgs e )
    {
        RequiredBarcode = checkRequiredBarcode();
        if (txtProductNo.Text.Trim() == String.Empty && RequiredBarcode == true)
        {
    
                lblEmptyMsg.Text = "Product No is Required!";
            
        }
        else
        {
            lblEmptyMsg.Text = " ";

            if (Page.IsValid)
            {
                //String ProductBarcode = txtProductNo.Text.ToUpper();
                //String ProductBarcode = txtProductNo.Value.ToString().ToUpper();
                String ProductBarcode = txtProductNo.Text.Trim();
                //txthidfield.Value = txtProductNo.Text.Trim();

                //string asd = txthidfield.Value;
                string ProductBarcode2 = txthidfield.Value.ToUpper();
                //var ProductSeries2 = ddlProdSeries_Hid.Value;

                int PS2 = Int32.Parse(ddlProdSeries_Hid.Value);

                String CertNo = "";
                System.Collections.Generic.List<object> list = gv_Stone.GetSelectedFieldValues("GUID");
                //System.Collections.Generic.List<object> list = gv_Stone.GetSelectedFieldValues("StoneID");
                var selectionCount = list.Count;
                if (selectionCount <= 0)
                {
                    lblEmptyMsg.Text = "Please select at least one stone!";
                }
                else
                {
                    //CertNo = Stone.CreateCertificate(ProductBarcode2, int.Parse(ddlProductSeries.SelectedItem.Value.ToString()), Session["UserID"].ToString());
                    CertNo = Stone.CreateCertificate(ProductBarcode2, PS2, Session["UserID"].ToString());
                    if (CertNo != "")
                    {

                        //System.Text.StringBuilder sb = new System.Text.StringBuilder(list[0].ToString());



                        foreach (object key in list)
                        {
                            Stone.UpdateStoneCertificate(key.ToString(), int.Parse(CertNo.ToString()), Session["UserID"].ToString());
                        }
                    }
                    gv_Stone.DataBind();
                    txtProductNo.Text = "";
                    //ddlProductSeries.Text = "-Please Select-";
                    lblStatus.Text = "Certificate (" + CertNo + ") is created!";
                    //gv_Stone.GetSelectedFieldValues().Clear();
                    //gv_Stone.Refresh();
                    //list.Clear();
                    gv_Stone.Selection.UnselectAll();

                }
                
            }
        }
    }

    protected void ProductNoValidate(object source, ServerValidateEventArgs arguments)
    {

        if (Product.checkProductExist(txtProductNo.Text) == false)
        {
            arguments.IsValid = true;
        }
        else
        {
            arguments.IsValid = false;
        }

    }

    protected void BarcodeValidate(object source, ServerValidateEventArgs arguments)
    {
        RequiredBarcode = checkRequiredBarcode();
        if (RequiredBarcode == true)
        {
            //check txtProductNo is empty
            if (txtProductNo.Text.Trim() == String.Empty)
            {
                arguments.IsValid = false;
            }
            else
            {
                arguments.IsValid = true;
            }
        }
        else
        {
            arguments.IsValid = false;
        }

    }


    private Boolean checkRequiredBarcode()
    {
        
        
        int ProductSeriesID =0;
        Boolean rValue = false;

       try
        {
            ProductSeriesID = Int32.Parse(ddlProductSeries.SelectedItem.Value.ToString());
        }catch (Exception ex)
        {
            Console.WriteLine("An error occurred: '{0}'", ex);
        }
            
        
        /*
         logic to check this product series required barcode
         if required
            rValue = true;
         else
            rValue = false;
        */
        if (Product.checkBarcodeFlag(ProductSeriesID) == true)
        {
            rValue = true;
        }
        else
        {
            rValue = false;
        }
        return rValue;
        
        
    }

    protected void BarcodeMatchValidate(object source, ServerValidateEventArgs arguments)
    {
        RequiredBarcode = checkRequiredBarcodeMatch();
        if (RequiredBarcode == true)
        {
            //check txtProductNo is empty
            if (txtProductNo.Text.Trim() == String.Empty)
            {
                arguments.IsValid = false;
            }
            else
            {
                arguments.IsValid = true;
            }
        }
        else
        {
            arguments.IsValid = false;
        }

    }


    private Boolean checkRequiredBarcodeMatch()
    {


        //int ProductSeriesID = 0;
        string ProductBarcode = "";
        Boolean rValue = false;

        try
        {
            //ProductSeriesID = Int32.Parse(ddlProductSeries.SelectedItem.Value.ToString());
            var str = txtProductNo.Value.ToString();
            ProductBarcode = str.Substring(0,2);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: '{0}'", ex);
        }


        /*
         logic to check this product series required barcode
         if required
            rValue = true;
         else
            rValue = false;
        */
        if (Product.checkProductBarcodeWithProductGroupCodeExist(ProductBarcode) == true)
        {
            rValue = true;
        }
        else
        {
            rValue = false;
        }
        return rValue;


    }

    private Boolean initialcheckRequiredBarcode()
    {
        int ProductSeriesID;
        Boolean rValue = false;

        

        populateProductSeries();

        ProductSeriesID = int.Parse(ddlProductSeries.SelectedItem.Value.ToString());
       
        /*
         logic to check this product series required barcode
         if required
            rValue = true;
         else
            rValue = false;
        */
        if (Product.checkBarcodeFlag(ProductSeriesID) == true)
        {
            rValue = true;
        }
        else
        {
            rValue = false;
        }
        return rValue;
    }






    protected void ddlProductSeries_SelectedIndexChanged(object sender, EventArgs e)
    {
        RequiredBarcode = checkRequiredBarcode();
        lblEmptyMsg.Text = " ";
        lblStatus.Text = " ";
    }
}
