using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
       
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 500;
            timer.Start();
            //dentro de timer_elapsed guardar en el archivo la fecha actual
        }

        protected override void OnStop()
        {
        }

        private void fsw_prueba_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"c:\log.txt", true);
            sw.WriteLine(e.Name + "Creado");
            sw.Flush();
            sw.Close();
        }

        private void fsw_prueba_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void fsw_prueba_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void fsw_prueba_Renamed(object sender, System.IO.RenamedEventArgs e)
        {

        }
    }
}
