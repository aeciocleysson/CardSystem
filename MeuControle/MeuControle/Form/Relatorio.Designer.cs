namespace MeuControle
{
    partial class Relatorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Relatorio));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.meucontroleDataSet = new MeuControle.meucontroleDataSet();
            this.controle_lojaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.controle_lojaTableAdapter = new MeuControle.meucontroleDataSetTableAdapters.controle_lojaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.meucontroleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controle_lojaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSLojas";
            reportDataSource1.Value = this.controle_lojaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MeuControle.Relatorio.ReportLojas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(689, 731);
            this.reportViewer1.TabIndex = 0;
            // 
            // meucontroleDataSet
            // 
            this.meucontroleDataSet.DataSetName = "meucontroleDataSet";
            this.meucontroleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // controle_lojaBindingSource
            // 
            this.controle_lojaBindingSource.DataMember = "controle_loja";
            this.controle_lojaBindingSource.DataSource = this.meucontroleDataSet;
            // 
            // controle_lojaTableAdapter
            // 
            this.controle_lojaTableAdapter.ClearBeforeFill = true;
            // 
            // Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 731);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Relatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorio - Controle";
            this.Load += new System.EventHandler(this.Relatorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.meucontroleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controle_lojaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource controle_lojaBindingSource;
        private meucontroleDataSet meucontroleDataSet;
        private meucontroleDataSetTableAdapters.controle_lojaTableAdapter controle_lojaTableAdapter;

    }
}