using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Lab07.ds_lab7TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab07
{
    public partial class frmPrincipal : Form
    {
        Estudiante estudiante = new Estudiante();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnExplorar_Click(object sender, EventArgs e)
        {
            string fotoPath = ofdArchivo.FileName;
            int celebridadInt = 0;
            bool celebridad;
            ofdArchivo.ShowDialog();
            pbEstudiante.ImageLocation = ofdArchivo.FileName;
            String photo = ofdArchivo.FileName;
            Amazon.Rekognition.Model.Image image = new Amazon.Rekognition.Model.Image();
            try
            {
                using (FileStream fs = new FileStream(photo, FileMode.Open, FileAccess.Read))
                {
                    byte[] data = null;
                    data = new byte[fs.Length];
                    fs.Read(data, 0, (int)fs.Length);
                    image.Bytes = new MemoryStream(data);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load file" + photo);
                throw;
            }

            AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient("AKIAIE5LZMZN4CR6IO5Q", "xUtzMH5IxZmuZYrc9KSN83JE+pgf5J60+FajM65J", RegionEndpoint.USEast1);

            DetectTextRequest detectTextRequest = new DetectTextRequest()
            {
                Image = image
            };

            DetectTextResponse detectTextResponse = rekognitionClient.DetectText(detectTextRequest);

            bool textoDetectado = (detectTextResponse.TextDetections.Count() > 0);

            DetectFacesRequest detectFacesRequest = new DetectFacesRequest()
            {
                Image = image
            };

            DetectFacesResponse detectFacesResponse = rekognitionClient.DetectFaces(detectFacesRequest);

            bool rostroDetectado = (detectFacesResponse.FaceDetails.Count() > 0);

            DetectModerationLabelsRequest detectLabelsRequest = new DetectModerationLabelsRequest()
            {
                Image = image
            };

            DetectModerationLabelsResponse detectLabelsResponse = rekognitionClient.DetectModerationLabels(detectLabelsRequest);

            bool imagenApta = true;
            foreach (var item in detectLabelsResponse.ModerationLabels)
            {
                if (item.Confidence > 90)
                {
                    imagenApta = false;
                    break;
                }
            }

            if (imagenApta && textoDetectado == false && rostroDetectado)
            {
                RecognizeCelebritiesRequest celebridadesRequest = new RecognizeCelebritiesRequest() { Image = image };

                RecognizeCelebritiesResponse celebridadesResponse = rekognitionClient.RecognizeCelebrities(celebridadesRequest);

                celebridad = (celebridadesResponse.CelebrityFaces.Count() > 0);
                if (celebridad == true) celebridadInt = 1;
                else celebridadInt = 0;

                pbEstudiante.ImageLocation = fotoPath;
            }
            else
            {
                MessageBox.Show("La imagen ingresada no es valida para introducir en el sistema", "Error");
            }

                estudiante.TipoDocumento = int.Parse(txbTipoDocumento.Text);
                estudiante.Documento = txbDocumento.Text;
                estudiante.Nombres = txbNombres.Text;
                estudiante.Apellidos = txbApellidos.Text;
                estudiante.FechaNacimiento = dpFechaNacimiento.Value;
                estudiante.Celebridad = celebridadInt;
                estudiante.Estado = int.Parse(txbEstado.Text);
                estudiante.Foto = fotoPath;
        }

        
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int celebridad = 0;

            tblEstudiantesTableAdapter adapter = new tblEstudiantesTableAdapter();
            adapter.Connection.Open();
            SqlTransaction transaction = adapter.Connection.BeginTransaction();
            adapter.Transaction = transaction;

            try
            {
                adapter.SP_InsertEstudiante(estudiante.TipoDocumento, estudiante.Documento, estudiante.Nombres, estudiante.Apellidos,
                   estudiante.FechaNacimiento, estudiante.Celebridad, estudiante.Estado, estudiante.Foto);
                transaction.Commit();

            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            frmReporteEstudiantecs frm = new frmReporteEstudiantecs(estudiante.TipoDocumento, estudiante.Documento);
            frm.Show();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }
    }
}
