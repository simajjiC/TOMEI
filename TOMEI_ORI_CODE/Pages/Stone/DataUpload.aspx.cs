using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxUploadControl;

public partial class Pages_DataUpload : System.Web.UI.Page
{
    const string UploadDirectory = "~/ExcelData/";

    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Upload Data";
        lblStatus.Text = " ";
        txtLog.Text = " ";

        UserSet myUser = (UserSet)Session["User"];
        if (myUser.Role == "Limited") 
        {
            Response.Redirect("~/Pages/Denied.aspx");
        }
    }

    protected void ulcExcel_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
    {
        SavePostedFile(e.UploadedFile);
    }
    private void SavePostedFile(UploadedFile _UploadedFile)
    {
        if (_UploadedFile.IsValid == true)
        {
            String tempFileName = MapPath(UploadDirectory) + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + _UploadedFile.FileName;
            _UploadedFile.SaveAs(tempFileName);

            ReadExcelData(tempFileName);
        }
    }

    private void ReadExcelData(String FileName)
    {
        String strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=Excel 12.0;";
        OleDbConnection ExcelConn = new OleDbConnection(strConn);
        ExcelConn.Open();
        OleDbCommand ExcelCommand = new OleDbCommand("SELECT * FROM [Sheet1$]", ExcelConn);
        OleDbDataReader ExcelReader = ExcelCommand.ExecuteReader();

        int uploaded = 0;
        int rejected = 0;
        int row = 1;
        if (ExcelReader.HasRows == true)
        {
            try
            {
                while (ExcelReader.Read())
                {
                    row++;
                    //check exist
                    int Column = ExcelReader.GetOrdinal("StoneID");
                    if (ExcelReader[Column].ToString().Trim() != string.Empty)
                    {
                        if (Stone.checkExist(ExcelReader[Column].ToString()) == false)
                        {
                            if (Stone.checkClarity(ExcelReader[Column+4].ToString()) == true) //check clarity
                            {
                                if (Stone.checkColour(ExcelReader[Column+3].ToString()) == true) //check colour
                                {
                                    if (Stone.checkFluorescence(ExcelReader[Column+5].ToString()) == true)
                                    {
                                        if (Stone.checkGirdle(ExcelReader[Column+36].ToString()) == true)//true
                                        {
                                            if (Stone.checkPolish(ExcelReader[Column+6].ToString()) == true)
                                            {
                                                if (Stone.checkSymmetry(ExcelReader[Column+74].ToString()) == true)
                                                {
                                                    Stone.insertStone(ExcelReader[Column].ToString(), String.Format(ExcelReader[Column + 2].ToString(), "{0:0.000}"), Stone.getClarity(ExcelReader[Column + 4].ToString()), Stone.getColour(ExcelReader[Column + 3].ToString()), Stone.getFluorescence(ExcelReader[Column + 5].ToString()), Stone.getGirdle(ExcelReader[Column + 36].ToString()), Stone.getPolish(ExcelReader[Column + 6].ToString()), Stone.getSymmetry(ExcelReader[Column + 74].ToString()), float.Parse(String.Format(ExcelReader[Column + 34].ToString(), "{0:0.000}")), float.Parse(String.Format(ExcelReader[Column + 27].ToString(), "{0:0.000}")), float.Parse(String.Format(ExcelReader[Column + 8].ToString(), "{0:0.000}")), float.Parse(String.Format(ExcelReader[Column + 9].ToString(), "{0:0.000}")), float.Parse(String.Format(ExcelReader[Column+35].ToString(), "{0:0.000}")), Session["UserID"].ToString());
                                                    uploaded++;
                                                }
                                                else
                                                {
                                                    txtLog.Text += ExcelReader[Column+74].ToString() + " is not a valid Symmetry at Row " + row.ToString() + "\n";
                                                    rejected++;
                                                }
                                            }
                                            else
                                            {
                                                txtLog.Text += ExcelReader[Column+6].ToString() + " is not a valid Polish at Row " + row.ToString() + "\n";
                                                rejected++;
                                            }
                                        }
                                        else
                                        {
                                            txtLog.Text += ExcelReader[Column+36].ToString() + " is not a valid Girdle at Row " + row.ToString() + "\n";
                                            rejected++;
                                        }
                                    }
                                    else
                                    {
                                        txtLog.Text += ExcelReader[Column+5].ToString() + " is not a valid Fluorescence at Row " + row.ToString() + "\n";
                                        rejected++;
                                    }
                                }
                                else
                                {
                                    txtLog.Text += ExcelReader[Column+3].ToString() + " is not a valid Colour at Row " + row.ToString() + "\n";
                                    rejected++;
                                }
                            }
                            else
                            {
                                txtLog.Text += ExcelReader[Column+4].ToString() + " is not a valid Clarity at Row " + row.ToString() + "\n";
                                rejected++;
                            }
                        }
                        else
                        {
                            txtLog.Text += ExcelReader[Column].ToString() + " already exist in Database at Row " + row.ToString() + ".\n";
                            rejected++;
                        }
                    }
                    else
                    {
                        txtLog.Text += ExcelReader[Column].ToString() + " Not a valid stone at Row " + row.ToString() + ".\n";
                        rejected++;
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error while uploading data.";
            }
        }
        txtLog.Text += "uploaded:" + uploaded + " rejected:" + rejected + "\n";
        Stone.InsertUploadAction(row-1,uploaded,rejected,Session["UserID"].ToString());
        btnUpload.Enabled = true;
        btnUpload.Text = "Upload";
        ExcelConn.Close();
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        btnUpload.Enabled = false;
        btnUpload.Text = "Uploading";
        Boolean fileOK = false;
        String path = Server.MapPath(UploadDirectory);
        if (ulcExcel.HasFile)
        {
            String fileExtension =
                System.IO.Path.GetExtension(ulcExcel.FileName).ToLower();
            String[] allowedExtensions = { ".xls", ".xlsx" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    fileOK = true;
                }
            }
        }

        if (fileOK)
        {
            try
            {
                String tempFileName = path + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + ulcExcel.FileName;
                ulcExcel.PostedFile.SaveAs(tempFileName);
                ReadExcelData(tempFileName);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "File could not be uploaded.";
            }
        }
        else
        {
            lblStatus.Text = "Cannot accept files of this type.";
        }        
    }
}
