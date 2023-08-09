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
using DevExpress.CodeParser;

namespace CommonlibHCE
{
    public partial class FrmTimKiemHH : DevExpress.XtraEditors.XtraForm
    {
        public FrmTimKiemHH()
        {
            InitializeComponent();
        }

        private void FrmTimKiemHH_Load(object sender, EventArgs e)
        {
            LoadData();
            FrmDMHH.index = -1;
            FrmDMHH.x = 0;
            ClassApp.vt = -1;
        }
        private void LoadData()
        {
            string query = "select * from MatHang";
            ConnectSql.GetDataToTable1(query, "MatHang");
            dgvHH.DataSource = ConnectSql.ds.Tables["MatHang"];
            ChangColumn();

        }
        private void ChangColumn()
        {
            dgvHH.Columns[0].HeaderText = "Mã Hàng";
            dgvHH.Columns[1].HeaderText = "Tên hàng";
            dgvHH.Columns[2].HeaderText = "Nhóm hàng";
            dgvHH.Columns[3].HeaderText = "Số lượng";
            dgvHH.Columns[4].HeaderText = "Thành tiền";
            dgvHH.Columns[5].HeaderText = "Đơn vị tính";
            dgvHH.Columns[6].HeaderText = "Hạn sử dụng";
        }

        private void TKHangHoa()
        {
            string query = "SELECT * FROM MatHang where TenMH like N'%" + txtTenHH.EditValue + "%'";
            ConnectSql.GetDataToTable1(query, "MatHang");
            dgvHH.DataSource = ConnectSql.ds.Tables["MatHang"];
            ChangColumn();
            if (dgvHH.RowCount < 2)
            {
                MessageBox.Show("Không tìm thấy thông tin");
                LoadData();
            }
        }

        private void btnTKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TKHangHoa();
        }

      

        private void btnDừngTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void dgvHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                ClassApp.vt = e.RowIndex;
                FrmDMHH.value = dgvHH.Rows[ClassApp.vt].Cells[0].Value.ToString();
              

                FrmHoaDon.MH = dgvHH.Rows[ClassApp.vt].Cells[0].Value.ToString();
                FrmHoaDon.DVT = dgvHH.Rows[ClassApp.vt].Cells[5].Value.ToString();
                float DG = float.Parse(dgvHH.Rows[ClassApp.vt].Cells[4].Value.ToString()) / float.Parse(dgvHH.Rows[ClassApp.vt].Cells[3].Value.ToString());
                FrmHoaDon.DG = DG.ToString();


                FrmPNHH.MH = dgvHH.Rows[ClassApp.vt].Cells[0].Value.ToString();
                FrmPNHH.DVT = dgvHH.Rows[ClassApp.vt].Cells[5].Value.ToString();
               // float DG = float.Parse(dgvHH.Rows[ClassApp.vt].Cells[4].Value.ToString()) / float.Parse(dgvHH.Rows[ClassApp.vt].Cells[3].Value.ToString());
                FrmPNHH.DG = DG.ToString();
            }
            catch (Exception)
            {

                return;
            }
           

        
            //  MessageBox.Show(dgvHH.Rows[ClassApp.vt].Cells[0].Value.ToString());
          
        }



        private void dgvHH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmDMHH.index = ClassApp.vt;
                Close();
                string query = "select * from MatHang";
                ConnectSql.GetDataToTable1(query, "MatHang");
                dgvHH.DataSource = ConnectSql.ds.Tables["MatHang"];
            }
        }

        private void dgvHH_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FrmDMHH.index = ClassApp.vt;
            Close();
            string query = "select * from MatHang";
            ConnectSql.GetDataToTable1(query, "MatHang");
            dgvHH.DataSource = ConnectSql.ds.Tables["MatHang"];
        }

        private void FrmTimKiemHH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTKiem.PerformClick();
            }
        }

        private void txtTenHH_EditValueChanged(object sender, EventArgs e)
        {
            btnTKiem.PerformClick();
        }
    }
}