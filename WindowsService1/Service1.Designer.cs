namespace WindowsService1
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
            this.fsw_prueba = new System.IO.FileSystemWatcher();
            this.process1 = new System.Diagnostics.Process();
            ((System.ComponentModel.ISupportInitialize)(this.fsw_prueba)).BeginInit();
            // 
            // fsw_prueba
            // 
            this.fsw_prueba.EnableRaisingEvents = true;
            this.fsw_prueba.Changed += new System.IO.FileSystemEventHandler(this.fsw_prueba_Changed);
            this.fsw_prueba.Created += new System.IO.FileSystemEventHandler(this.fsw_prueba_Created);
            this.fsw_prueba.Deleted += new System.IO.FileSystemEventHandler(this.fsw_prueba_Deleted);
            this.fsw_prueba.Renamed += new System.IO.RenamedEventHandler(this.fsw_prueba_Renamed);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            // 
            // Service1
            // 
            this.ServiceName = "Service1";
            ((System.ComponentModel.ISupportInitialize)(this.fsw_prueba)).EndInit();

        }

        #endregion

        private System.IO.FileSystemWatcher fsw_prueba;
        private System.Diagnostics.Process process1;
    }
}
