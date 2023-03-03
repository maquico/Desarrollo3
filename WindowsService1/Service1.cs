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
        Timer timer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 5000;
            timer.Start();
            //dentro de timer_elapsed guardar en el archivo la fecha actual
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"c:\jevi\log.txt", true);
            sw.WriteLine(DateTime.Now.ToLongTimeString());
            sw.Flush();
            sw.Close();
       
        }

        protected override void OnStop()
        {
        }

        private void fsw_prueba_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"c:\jevi\log.txt", true);
            sw.WriteLine(e.Name + "Creado");
            sw.Flush();
            sw.Close();
        }

        private void fsw_prueba_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"c:\jevi\log.txt", true);
            sw.WriteLine(e.Name + "Alterado");
            sw.Flush();
            sw.Close();
        }

        private void fsw_prueba_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"c:\jevi\log.txt", true);
            sw.WriteLine(e.Name + "Borrado");
            sw.Flush();
            sw.Close();
        }

        private void fsw_prueba_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"c:\jevi\log.txt", true);
            sw.WriteLine(e.Name + "Renombrado" + e.OldName);
            sw.Flush();
            sw.Close();
        }
    }
}
