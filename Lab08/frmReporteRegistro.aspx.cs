using Lab08.ds_lab08TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab08
{
    public partial class frmReporteRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ReportViewer1.LocalReport.DataSources.Clear();

                tblInscritoTableAdapter adapter = new tblInscritoTableAdapter();
                var registro = adapter.GetDataByDocumento(int.Parse(Session["TipoDocumento"].ToString()), Session["Documento"].ToString());
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource()
                {
                    Value = registro,
                    Name = "ds_lab08"
                });
            }
           
        }
    }
}