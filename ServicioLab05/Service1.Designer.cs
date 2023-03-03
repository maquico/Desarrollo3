namespace ServicioLab05
{
    partial class Service1
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.fsw_lab05 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fsw_lab05)).BeginInit();
            // 
            // fsw_lab05
            // 
            this.fsw_lab05.EnableRaisingEvents = true;
            this.fsw_lab05.Path = "c:\\MonitoreoLab05\\";
            this.fsw_lab05.Changed += new System.IO.FileSystemEventHandler(this.fsw_lab05_Changed);
            this.fsw_lab05.Created += new System.IO.FileSystemEventHandler(this.fsw_lab05_Created);
            this.fsw_lab05.Deleted += new System.IO.FileSystemEventHandler(this.fsw_lab05_Deleted);
            this.fsw_lab05.Renamed += new System.IO.RenamedEventHandler(this.fsw_lab05_Renamed);
            // 
            // Service1
            // 
            this.ServiceName = "Service1";
            ((System.ComponentModel.ISupportInitialize)(this.fsw_lab05)).EndInit();

        }

        #endregion

        private System.IO.FileSystemWatcher fsw_lab05;
    }
}
