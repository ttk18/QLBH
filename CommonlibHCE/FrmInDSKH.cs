using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace CommonlibHCE
{
    public partial class FrmInDSKH : DevExpress.XtraEditors.XtraForm
    {
        public FrmInDSKH()
        {
            InitializeComponent();
        }

        private void FrmDMHH_Load(object sender, EventArgs e)
        {
            btnChonFile.Enabled = false;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text file (*.txt)|*.txt|XML file (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Title = "Where do you want to save the file?";
            saveFileDialog1.FileName = txtXratep.Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
            }
            else
            {
                MessageBox.Show("You hit cancel or closed the dialog.");
            }
        }



        private void btnInan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        
          


        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rbtXuatraMH.Checked)
            {
                Report.FrmRPKH frm = new Report.FrmRPKH();
                frm.maNv = ClassApp.manv;
                frm.TENNV = ClassApp.tenkh;
                frm.TP = ClassApp.ttp;
                frm.Between = txtTutrang.Text;
                frm.And = txtDentrang.Text;
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            if (rbtXuatraTT.Checked)
            {
                
            }
           /* Report.FrmRPKH frm = new Report.FrmRPKH();
            frm.maNv = ClassApp.manv;
            frm.TENNV = ClassApp.tenkh;
            frm.TP = ClassApp.ttp;
            frm.Between = txtTutrang.Text;
            frm.And = txtDentrang.Text;
            frm.MdiParent = this.MdiParent;
            frm.Show();*/
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void rbtXuatraTT_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtXuatraTT.Checked)
            {
                btnChonFile.Enabled = true;
            }
            else
            {
                btnChonFile.Enabled = false;
            }
        }
    }
}