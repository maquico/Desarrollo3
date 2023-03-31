using Lab08.ds_lab08TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab08
{
    public partial class frmRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
           
                tblInscritoTableAdapter adapter = new tblInscritoTableAdapter();
                adapter.SP_InsertInscrito(int.Parse(txtTipoDocumento.Text),
                    txtDocumento.Text, txtNombres.Text,
                    txtApellidos.Text, dpFechaNacimiento.SelectedDate,
                    txtSexo.Text, int.Parse(txtEstadoInscrito.Text),
                    int.Parse(txtTipo.Text), int.Parse(txtActividadInscrito.Text));

                Session["TipoDocumento"] = txtTipoDocumento.Text;
                Session["Documento"] = txtDocumento.Text;



                Response.Redirect("frmReporteRegistro.aspx");
            
            

        }

        protected void btnRegistrarActividad_Click(object sender, EventArgs e)
        {
            tblInscritoTableAdapter adapter = new tblInscritoTableAdapter();
            adapter.SP_InsertActividad(dpFechaActividad.SelectedDate, int.Parse(txtEstadoActividad.Text), txtDescripcion.Text);
        }
    }
}