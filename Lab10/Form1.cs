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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardarSolicitante_Click(object sender, EventArgs e)
        {
            tblSolicitudTableAdapter adapter = new tblSolicitudTableAdapter();
            adapter.Connection.Open();
            adapter.spInsertSolicitante(int.Parse(txtTipoDoc.Text), txtDocumento.Text, dpFechaNacimiento.Value, int.Parse(txtEstado.Text), txtNombres.Text,
                txtApellidos.Text, txtDireccion.Text, txtEstadoCivil.Text, int.Parse(txtAprobadoEsposo.Text));

        }

        private void btnGuardarSolicitud_Click(object sender, EventArgs e)
        {
            tblSolicitudTableAdapter adapter = new tblSolicitudTableAdapter();
            adapter.Connection.Open();
            adapter.spInsertSolicitud(int.Parse(txtTipoDocSolicitud.Text), txtDocumentoSolicitud.Text, int.Parse(txtEstadoSolicitud.Text),
                txtNivelAcademico.Text, int.Parse(txtEstatura.Text), int.Parse(txtSizePies.Text), txtColorOjos.Text, txtNacionalidad.Text,
                txtDescripcion.Text, int.Parse(txtEdadPromedio.Text));

            this.Hide();
            frmRecibo recibo = new frmRecibo();
            recibo.TipoDoc = int.Parse(txtTipoDocSolicitud.Text);
            recibo.Documento = txtDocumentoSolicitud.Text;
            recibo.Show();
            adapter.Connection.Close();
        }

        private void btnVerReportes_Click(object sender, EventArgs e)
        {
            frmReporteTotal reporteTotal = new frmReporteTotal();
            this.Hide();
            reporteTotal.Show();
        }
    }
}
