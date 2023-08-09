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
    public partial class FrmLG : DevExpress.XtraEditors.XtraForm
    {
        public FrmLG()
        {
            InitializeComponent();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            if (ConnectSql.Connect(txtTennd.Text, txtMK.Text))
            {
                ConnectSql.succceed = true;
                this.Close();
            }
        }

        private void FrmLG_Load(object sender, EventArgs e)
        {
            txtTennd.Text = "sa";
            txtMK.Text = "123";
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn không muốn đăng nhập nữa?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ptbTK_Click(object sender, EventArgs e)
        {
            txtTennd.Focus();
        }

        private void ptbMK_Click(object sender, EventArgs e)
        {
            txtMK.Focus();
        }

        private void ptbHidemk_Click(object sender, EventArgs e)
        {
            if (txtMK.PasswordChar == '\0')
            {
                txtMK.PasswordChar = '*';
                ptbSmk.BringToFront();
            }
        }

        private void ptbSmk_Click(object sender, EventArgs e)
        {
            if (txtMK.PasswordChar == '*')
            {
                ptbHidemk.BringToFront();
                txtMK.PasswordChar = '\0';
            }
        }

        private void txtMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                 btnDN.PerformClick();
            
        }

        private void FrmLG_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ConnectSql.succceed == true)
            {
                FrmNSL fr = new FrmNSL();
                fr.ShowDialog();
            }
        }
    }
}
