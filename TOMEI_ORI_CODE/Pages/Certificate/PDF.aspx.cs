using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Certificate_PDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ReportManager"] != null)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument crReportDocument;
            crReportDocument = (CrystalDecisions.CrystalReports.Engine.ReportDocument)Session["ReportManager"];
            crReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, DateTime.Now.ToString("yyyyMMdd_HHmmss"));

            crReportDocument.Close();
            crReportDocument.Dispose();

            Session["ReportManager"] = null;
        }
    }
}
