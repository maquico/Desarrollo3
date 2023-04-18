using Lab10.lab10_dsTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab10
{
    public partial class frmReporteTotal : Form
    {
        public frmReporteTotal()
        {
            InitializeComponent();
        }

        private void frmReporteTotal_Load(object sender, EventArgs e)
        {
            tblSolicitudTableAdapter adapter = new tblSolicitudTableAdapter();
            adapter.Connection.Open();
            var registro = adapter.GetAll();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Value = registro,
                Name = "lab10_ds"
            });
            this.reportViewer1.RefreshReport();
            adapter.Connection.Close();
        }
    }
}
