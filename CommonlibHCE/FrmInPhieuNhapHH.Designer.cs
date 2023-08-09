namespace CommonlibHCE
{
    partial class FrmInPhieuNhapHH
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
            this.ctprPNHH = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ctprPNHH
            // 
            this.ctprPNHH.ActiveViewIndex = -1;
            this.ctprPNHH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctprPNHH.Cursor = System.Windows.Forms.Cursors.Default;
            this.ctprPNHH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctprPNHH.Location = new System.Drawing.Point(0, 0);
            this.ctprPNHH.Name = "ctprPNHH";
            this.ctprPNHH.Size = new System.Drawing.Size(661, 320);
            this.ctprPNHH.TabIndex = 0;
            // 
            // FrmInPhieuNhapHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 320);
            this.Controls.Add(this.ctprPNHH);
            this.Name = "FrmInPhieuNhapHH";
            this.Text = "In phiếu nhập hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInPhieuNhapHH_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer ctprPNHH;
    }
}