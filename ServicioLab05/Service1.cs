using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServicioLab05
{
    public partial class Service1 : ServiceBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            
        }

        protected override void OnStop()
        {
        }

        private void fsw_lab05_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            conexion.Open();
            SqlCommand comando = new SqlCommand($"SP_InsertArchivo", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Nombre", e.Name);
            comando.ExecuteNonQuery();
            log.Info("se registro bien, jevi");
        }

        private void fsw_lab05_Changed(object sender, FileSystemEventArgs e)
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            conexion.Open();
            SqlCommand comando = new SqlCommand($"SP_InsertArchivo", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", e.Name);
            comando.ExecuteNonQuery();
            log.Info("se registro bien, jevi");
        }

        private void fsw_lab05_Deleted(object sender, FileSystemEventArgs e)
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            conexion.Open();
            SqlCommand comando = new SqlCommand($"SP_InsertArchivo", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", e.Name);
            comando.ExecuteNonQuery();
            log.Info("se registro bien, jevi");
        }

        private void fsw_lab05_Renamed(object sender, RenamedEventArgs e)
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            conexion.Open();
            SqlCommand comando = new SqlCommand($"SP_InsertArchivo", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", e.Name);
            comando.ExecuteNonQuery();
            log.Info("se registro bien, jevi");
        }
    }
}
