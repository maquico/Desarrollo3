using Lab08.ds_lab08TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab08
{
    public partial class frmReportePorActividad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.LocalReport.DataSources.Clear();

            tblInscritoTableAdapter adapter = new tblInscritoTableAdapter();
            var registro = adapter.GetDataByActividad(int.Parse(txtActividad.Text));
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource()
            {
                Value = registro,
                Name = "ds_lab08"
            });
        }
    }
}