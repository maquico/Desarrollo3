using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teo8.DS_Teo8TableAdapters;

namespace Teo8
{
    public partial class frmMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            tblVisitaTableAdapter adapter = new tblVisitaTableAdapter();
            adapter.SP_InsertarVisita(txtNombres.Text, txtApellidos.Text, fuImagen.FileName);
            fuImagen.SaveAs(MapPath("Foto") + "\\" + fuImagen.FileName);
            imgImagen.ImageUrl = "Foto/" + fuImagen.FileName;
            Session["ID"] = txtId.Text;
        }
    }
}