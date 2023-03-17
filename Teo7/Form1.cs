using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teo7
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes formCliente = new frmClientes();
            formCliente.MdiParent = this;
            formCliente.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DialogResult dialog = MessageBox.Show("Estas seguro?", "SALIR",  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

            
        }

        private void listadoClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoClientes formListCliente = new frmListadoClientes();
            formListCliente.MdiParent = this;
            formListCliente.Show();
        }
    }
}
