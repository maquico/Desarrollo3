using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teo3
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            log.Info("Hello logging world!");
            log.Error("Esto es un error");
            log.Fatal("Esto es un error mayor");
            log.Debug("Debug");
            Console.WriteLine("Hit enter");
            Console.ReadLine();

            //event
            EventLog logEvt = new EventLog();
            logEvt.Source = "Application";
            logEvt.WriteEntry("Saludo desde app", EventLogEntryType.Information);
        }
    }
}
