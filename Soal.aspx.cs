using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHEUjianOnline
{
    public partial class Soal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Microsoft.Reporting.WebForms.ReportParameter[] i_cls_rParam = new Microsoft.Reporting.WebForms.ReportParameter[1];

                i_cls_rParam[0] = new Microsoft.Reporting.WebForms.ReportParameter("generatedID", Request.QueryString["s_str_generatedID"]);

                string i_str_reportName = "ReportAllUser";
                Report.ServerReport.ReportServerUrl = new Uri(System.Configuration.ConfigurationManager.AppSettings["ReportServerUrl"].ToString());
                Report.ServerReport.ReportPath = System.Configuration.ConfigurationManager.AppSettings["ReportPath"].ToString() + i_str_reportName;
                Report.ServerReport.SetParameters(i_cls_rParam);
                Report.ServerReport.Refresh();
            }
            
        }
     
    }
}