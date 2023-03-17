using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teo7.DS_ClientesTableAdapters;

namespace Teo7
{
    public partial class frmListadoClientes : Form
    {
        public frmListadoClientes()
        {
            InitializeComponent();
        }

        private void frmListadoClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dS_Clientes.tblClientes' Puede moverla o quitarla según sea necesario.
           this.tblClientesTableAdapter.Fill(this.dS_Clientes.tblClientes);
            tblClientesTableAdapter clienteAdapter = new tblClientesTableAdapter();
            var registro = clienteAdapter.GetData();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Value = registro,
                Name = "DS_Clientes"
            });
            this.reportViewer1.RefreshReport();
           
        }
    }
}
