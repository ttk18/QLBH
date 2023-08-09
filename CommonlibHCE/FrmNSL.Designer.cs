namespace CommonlibHCE
{
    partial class FrmNSL
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
            this.btnXN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mboxTungay = new System.Windows.Forms.MaskedTextBox();
            this.mboxDenngay = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnXN
            // 
            this.btnXN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnXN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnXN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnXN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnXN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXN.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnXN.ForeColor = System.Drawing.Color.White;
            this.btnXN.Location = new System.Drawing.Point(123, 64);
            this.btnXN.Name = "btnXN";
            this.btnXN.Size = new System.Drawing.Size(80, 27);
            this.btnXN.TabIndex = 2;
            this.btnXN.Text = "Xác nhận";
            this.btnXN.UseVisualStyleBackColor = false;
            this.btnXN.Click += new System.EventHandler(this.btnXN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Đến ngày";
            // 
            // mboxTungay
            // 
            this.mboxTungay.Location = new System.Drawing.Point(70, 10);
            this.mboxTungay.Mask = "00/00/0000";
            this.mboxTungay.Name = "mboxTungay";
            this.mboxTungay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mboxTungay.Size = new System.Drawing.Size(198, 21);
            this.mboxTungay.TabIndex = 0;
            this.mboxTungay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mboxDenngay
            // 
            this.mboxDenngay.Location = new System.Drawing.Point(70, 37);
            this.mboxDenngay.Mask = "00/00/0000";
            this.mboxDenngay.Name = "mboxDenngay";
            this.mboxDenngay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mboxDenngay.Size = new System.Drawing.Size(198, 21);
            this.mboxDenngay.TabIndex = 1;
            this.mboxDenngay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmNSL
            // 
            this.AcceptButton = this.btnXN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 106);
            this.Controls.Add(this.mboxDenngay);
            this.Controls.Add(this.mboxTungay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmNSL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn ngày hệ thống";
            this.Load += new System.EventHandler(this.FrmNSL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnXN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mboxTungay;
        private System.Windows.Forms.MaskedTextBox mboxDenngay;
    }
}