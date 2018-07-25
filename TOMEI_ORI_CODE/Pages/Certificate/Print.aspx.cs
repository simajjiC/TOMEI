using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DevExpress.Web.ASPxEditors;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

public partial class Pages_Print : System.Web.UI.Page
{
    CrystalDecisions.CrystalReports.Engine.ReportDocument crReportDocument;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (Session["ReportCertificateNo"] == null)
            {
                //setReportParameter();
                //initReportParameter();
                //LoadReport();
                //ShowReport(true);
            }
            else
            {
                LoadReport();
                initReportParameter();                
                //ShowReport(true);
            }
        }
        else
        {
            //ShowReport(false);
            //populateCertificateNo();
        }
    }

    //private void populateCertificateNo()
    //{
        //ddlCertificateNo.Items.Clear();
        //DB f_DBEngine = new DB();
        //System.Data.SqlClient.SqlDataReader f_Reader = f_DBEngine.GetRows("S_ListCertificateNo");
        //if (f_Reader.HasRows == true)
        //{
        //    while (f_Reader.Read())
        //    {
        //        ddlCertificateNo.Items.Add(f_Reader["CertificateNo"].ToString(), f_Reader["CertificateNo"].ToString());
        //    }
        //}
        //f_Reader = null;
        //f_DBEngine.closeConn();
        //f_DBEngine = null;
        //ddlCertificateNo.SelectedIndex = 0;
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxLabel lblPageTitle = (ASPxLabel)Master.FindControl("lblPageTitle");
        lblPageTitle.Text = "Print Certificate";
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {       
        LoadReport();
        setReportParameter();
        initReportParameter();
        //ShowReport(true);
        UpdateCounter();
        ExportReport();
    }

    private void LoadReport()
    {
        CrystalDecisions.Shared.ConnectionInfo crConnectionInfo;
        CrystalDecisions.CrystalReports.Engine.Database crDatabase;
        CrystalDecisions.CrystalReports.Engine.Tables crTables;
        //CrystalDecisions.CrystalReports.Engine.Table crTable;        
        CrystalDecisions.Shared.TableLogOnInfo crTableLogonInfo;
        
        //Setup the connection information structure to be used to log onto the datasource for the report. 
        crConnectionInfo = new ConnectionInfo();


        crConnectionInfo.ServerName = System.Configuration.ConfigurationManager.AppSettings["CrServer"].ToString(); //DSN or Server (bv)
        crConnectionInfo.DatabaseName = System.Configuration.ConfigurationManager.AppSettings["CrDatabase"].ToString();
        crConnectionInfo.UserID = System.Configuration.ConfigurationManager.AppSettings["CrUser"].ToString();
        crConnectionInfo.Password = System.Configuration.ConfigurationManager.AppSettings["CrPassword"].ToString();

        //crConnectionInfo.ServerName = "Tomei_Rpt"; //DSN or Server
        //crConnectionInfo.DatabaseName = "Tomei";
        //crConnectionInfo.UserID = "sa";
        //crConnectionInfo.Password = "p@ssword";
        
        //Create an instance of the strongly-typed report object

        crReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        String ReportPath = "";
        switch (rblReportType.SelectedItem.Value.ToString())
        {
            case ("A2"):
            {
                ReportPath = Server.MapPath("..\\..\\Reports\\TomeiReportA2.rpt");
                break;
            }
            case ("A3"):
            {
                ReportPath = Server.MapPath("..\\..\\Reports\\TomeiReportA3.rpt");
                break;
            }
            case ("B2"):
            {
                ReportPath = Server.MapPath("..\\..\\Reports\\TomeiReportB2.rpt");
                break;
            }
            case ("B3"):
            {
                ReportPath = Server.MapPath("..\\..\\Reports\\TomeiReportB3.rpt");
                break;
            }
        }
        crReportDocument.Load(ReportPath);

        crDatabase = crReportDocument.Database;
        crTables = crDatabase.Tables;

        //Loop through all tables in the report and apply the connection information for each table. 
        foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
        {
            crTableLogonInfo = crTable.LogOnInfo;
            crTableLogonInfo.ConnectionInfo = crConnectionInfo;
            crTable.ApplyLogOnInfo(crTableLogonInfo);
        }

        //CrystalReportViewer.ReportSource = crReportDocument;
    }

    private void setReportParameter()
    {
        String CertList = "";
        System.Collections.Generic.List<object> list = gv_Cert.GetSelectedFieldValues("CertificateNo");
        if (list.Count != 0)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(list[0].ToString());
            foreach (object key in list)
            {
                if (CertList == String.Empty)
                {
                    CertList += key.ToString();
                }
                else
                {
                    CertList += "," + key.ToString();
                }
            }
        }
        Session["ReportCertificateNo"] = CertList;
    }

    private void initReportParameter()
    {
        ParameterValues fParameterValues = new ParameterValues();
        ParameterDiscreteValue fDiscreteValue = new ParameterDiscreteValue();

        fDiscreteValue.Value = Session["ReportCertificateNo"].ToString();
        fParameterValues.Add(fDiscreteValue);
        crReportDocument.DataDefinition.ParameterFields["@CertNo"].ApplyCurrentValues(fParameterValues);
    }

    private void ShowReport(bool Visible)
    {
        Panel1.Visible = !Visible;
        //CrystalReportViewer.Visible = Visible;
    }

    private void ExportReport()
    {
        Session["ReportManager"] = crReportDocument;
        Response.Redirect("PDF.aspx");
        //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "script1", "javascript:window.open('PDF.aspx');", true);

        //MemoryStream oStream; // using System.IO
        //oStream = (MemoryStream)            
        //crReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,Response,false,DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        //Response.Clear();
        //Response.Buffer = true;
        //Response.ContentType = "application/pdf";
        //Response.BinaryWrite(oStream.ToArray());
        //Response.End();
    }

    private bool UpdateCounter()
    {
        bool f_result = false;
        DB f_DBEngine = new DB();
        SqlParameter[] f_Param = new SqlParameter[2];
        f_Param[0] = new SqlParameter("@CertificateNo", System.Data.SqlDbType.VarChar, 8000);
        f_Param[0].Value = Session["ReportCertificateNo"].ToString();
        f_Param[1] = new SqlParameter("@PrintedBy", System.Data.SqlDbType.VarChar, 32);
        f_Param[1].Value = Session["UserID"].ToString();
        int f_RowInserted = f_DBEngine.Query("S_UpdateCertificatePrintCount", f_Param);
        if (f_RowInserted == 1)
        {
            f_result = true;
        }
        else
        {
            f_result = false;
        }
        f_DBEngine.closeConn();
        f_DBEngine = null;
        return f_result;
    }
}
