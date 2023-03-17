using Lab07.ds_lab7TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab07
{
    public partial class frmReporteEstudiantecs : Form
    {
        int tipoDocumentox = 0;
        string documentox = "";
        public frmReporteEstudiantecs(int tipoDocumento, string documento)
        {

            InitializeComponent();
            tipoDocumentox = tipoDocumento;
            documentox = documento;
        }

        private void frmReporteEstudiantecs_Load( object sender, EventArgs e)
        {
            
            tblEstudiantesTableAdapter adapter = new tblEstudiantesTableAdapter();
            var registro = adapter.GetEstudiante2(tipoDocumentox, documentox);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Value = registro,
                Name = "ds_lab7"
            });
            this.reportViewer1.RefreshReport();
        }
    }
}
