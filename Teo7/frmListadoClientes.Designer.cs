namespace Teo7
{
    partial class frmListadoClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tblClientesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtTipoDoc = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dSClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS_Clientes = new Teo7.DS_Clientes();
            this.tblClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblClientesTableAdapter = new Teo7.DS_ClientesTableAdapters.tblClientesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tblClientesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSClientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Clientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblClientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tblClientesBindingSource1
            // 
            this.tblClientesBindingSource1.DataMember = "tblClientes";
            this.tblClientesBindingSource1.DataSource = this.dSClientesBindingSource;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DS_Clientes";
            reportDataSource1.Value = this.tblClientesBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Teo7.rptCliente.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(29, 66);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(736, 372);
            this.reportViewer1.TabIndex = 0;
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(39, 30);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(101, 13);
            this.lblTipoDoc.TabIndex = 1;
            this.lblTipoDoc.Text = "Tipo de Documento";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(267, 30);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(62, 13);
            this.lblDocumento.TabIndex = 2;
            this.lblDocumento.Text = "Documento";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(335, 27);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtDocumento.TabIndex = 3;
            // 
            // txtTipoDoc
            // 
            this.txtTipoDoc.Location = new System.Drawing.Point(146, 27);
            this.txtTipoDoc.Name = "txtTipoDoc";
            this.txtTipoDoc.Size = new System.Drawing.Size(100, 20);
            this.txtTipoDoc.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(465, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dSClientesBindingSource
            // 
            this.dSClientesBindingSource.DataSource = this.dS_Clientes;
            this.dSClientesBindingSource.Position = 0;
            // 
            // dS_Clientes
            // 
            this.dS_Clientes.DataSetName = "DS_Clientes";
            this.dS_Clientes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblClientesBindingSource
            // 
            this.tblClientesBindingSource.DataMember = "tblClientes";
            this.tblClientesBindingSource.DataSource = this.dS_Clientes;
            // 
            // tblClientesTableAdapter
            // 
            this.tblClientesTableAdapter.ClearBeforeFill = true;
            // 
            // frmListadoClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtTipoDoc);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.lblDocumento);
            this.Controls.Add(this.lblTipoDoc);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmListadoClientes";
            this.Text = "frmListadoClientes";
            this.Load += new System.EventHandler(this.frmListadoClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblClientesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSClientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Clientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblClientesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DS_Clientes dS_Clientes;
        private System.Windows.Forms.BindingSource tblClientesBindingSource;
        private DS_ClientesTableAdapters.tblClientesTableAdapter tblClientesTableAdapter;
        private System.Windows.Forms.BindingSource dSClientesBindingSource;
        private System.Windows.Forms.BindingSource tblClientesBindingSource1;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtTipoDoc;
        private System.Windows.Forms.Button btnBuscar;
    }
}