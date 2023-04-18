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

namespace Lab10
{
    public partial class frmRecibo : Form
    {
        public int TipoDoc { get; set; }
        public string Documento { get; set; }
        public frmRecibo()
        {
            InitializeComponent();
        }

        private void frmRecibo_Load(object sender, EventArgs e)
        {

            tblSolicitudTableAdapter adapter = new tblSolicitudTableAdapter();
            adapter.Connection.Open();
            var registro = adapter.GetByCedula(TipoDoc, Documento);
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
