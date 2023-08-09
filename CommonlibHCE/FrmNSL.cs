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
    public partial class FrmNSL : DevExpress.XtraEditors.XtraForm
    {
        public FrmNSL()
        {
            InitializeComponent();
        }

        private void btnXN_Click(object sender, EventArgs e)
        {
            DateTime dtuNgay;
            DateTime ddenngay;
           
            try
            {
                if ((dtuNgay = DateTime.Parse(mboxTungay.Text)) > DateTime.Today)
                {
                    mboxTungay.Text = DateTime.Today.ToShortDateString();
                    dtuNgay = DateTime.Parse(mboxTungay.Text);
                    return;
                }
                if ((ddenngay = DateTime.Parse(mboxDenngay.Text)) > DateTime.Today 
                    || (dtuNgay = DateTime.Parse(mboxTungay.Text)) >
                    (ddenngay = DateTime.Parse(mboxDenngay.Text)))
                {
                    mboxDenngay.Text = DateTime.Today.ToShortDateString();
                    ddenngay = DateTime.Parse(mboxDenngay.Text);
                    return;
                }
                ClassApp.tn = Convert.ToDateTime(dtuNgay).ToString("yyyy-MM-dd");
                ClassApp.dn = Convert.ToDateTime(ddenngay).ToString("yyyy-MM-dd");
                Close();

            }
            catch (Exception)
            {
                //throw;
                if (!DateTime.TryParse(mboxTungay.Text, out dtuNgay))
                {
                    MessageBox.Show("Nhập sai ngày tháng");
                    mboxTungay.Focus();
                    return;
                }

                if (!DateTime.TryParse(mboxDenngay.Text, out ddenngay))
                {
                    MessageBox.Show("Nhập sai ngày tháng");
                    mboxDenngay.Focus();
                    return;
                }
                
            }

            

        }

        private void FrmNSL_Load(object sender, EventArgs e)
        {
            mboxDenngay.Focus();
        }
    }
        
}