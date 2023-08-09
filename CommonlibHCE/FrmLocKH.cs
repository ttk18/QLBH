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

namespace CommonlibHCE
{
    public partial class FrmLocKH : DevExpress.XtraEditors.XtraForm
    {
        public FrmLocKH()
        {
            InitializeComponent();
        }
        private void btnXN_Click(object sender, EventArgs e)
        {
            FrmInDSKH frm = new FrmInDSKH();
            ClassApp.manv = txtMaNV.Text;
            ClassApp.tenkh = txtTenNV.Text;
            ClassApp.ttp = txtTP.Text;
            frm.ShowDialog();
          
        }
        
        private void FrmLocKH_Load(object sender, EventArgs e)
        {

           // manv = txtMaNV.Text;
           /* frm.TENNV = txtTenNV.Text;
            frm.TP = txtTP.Text;*/

        }
        
    }
}