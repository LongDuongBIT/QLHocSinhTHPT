namespace QuanLyTruongCap3.Reports
{
    partial class frptDanhSachGiaoVien
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
            this.bSDSGiaoVien = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewerDSGV = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bSDSGiaoVien)).BeginInit();
            this.SuspendLayout();
            // 
            // bSDSGiaoVien
            // 
            this.bSDSGiaoVien.DataSource = typeof(QuanLyTruongCap3.DTO.GiaoVienDTO);
            // 
            // reportViewerDSGV
            // 
            this.reportViewerDSGV.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "QuanLyTruongCap3_Bussiness_GiaoVienInfo";
            reportDataSource1.Value = this.bSDSGiaoVien;
            this.reportViewerDSGV.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerDSGV.LocalReport.ReportEmbeddedResource = "QuanLyTruongCap3.Reports.rptDanhSachGiaoVien.rdlc";
            this.reportViewerDSGV.Location = new System.Drawing.Point(0, 0);
            this.reportViewerDSGV.Name = "reportViewerDSGV";
            this.reportViewerDSGV.Size = new System.Drawing.Size(792, 466);
            this.reportViewerDSGV.TabIndex = 1;
            // 
            // frptDanhSachGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 466);
            this.Controls.Add(this.reportViewerDSGV);
            this.Name = "frptDanhSachGiaoVien";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DANH S�CH GI�O VI�N";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frptDanhSachGiaoVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bSDSGiaoVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bSDSGiaoVien;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerDSGV;
    }
}