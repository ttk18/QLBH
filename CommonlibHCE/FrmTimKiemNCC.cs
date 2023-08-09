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
    public partial class FrmTimKiemNCC : DevExpress.XtraEditors.XtraForm
    {
        public FrmTimKiemNCC()
        {
            InitializeComponent();
        }

        private void FrmTimKiemTK_Load(object sender, EventArgs e)
        {
            LoadData();
            FrmDMNCC.index = -1;
            FrmDMNCC.x = 0;
            ClassApp.vt = -1;
        }
        private void LoadData()
        {
            string query = "select * from NhaCungCap";
            ConnectSql.GetDataToTable1(query, "NhaCungCap");
            dgvNCC.DataSource = ConnectSql.ds.Tables["NhaCungCap"];
            ChangColumn();
        }

        private void ChangColumn()
        {
            dgvNCC.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgvNCC.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgvNCC.Columns[2].HeaderText = "Địa chỉ";
            dgvNCC.Columns[3].HeaderText = "Tỉnh - Thành phố";
            dgvNCC.Columns[4].HeaderText = "Điện thoại";
        }
        private void TKHangHoa()
        {
            string query = "SELECT * FROM NhaCungCap where TenNCC like N'%" + txtTenTK.EditValue + "%'";
            ConnectSql.GetDataToTable1(query, "NhaCungCap");
            dgvNCC.DataSource = ConnectSql.ds.Tables["NhaCungCap"];
            ChangColumn();
            if (dgvNCC.RowCount < 2)
            {
                MessageBox.Show("Không tìm thấy thông tin");
                LoadData();
            }
        }
        private void btnTKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TKHangHoa();
        }

        private void btnDungTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClassApp.vt = e.RowIndex;
            FrmDMNCC.value = dgvNCC.Rows[ClassApp.vt].Cells[0].Value.ToString();


            FrmPNHH.MaNCCB = dgvNCC.Rows[ClassApp.vt].Cells[0].Value.ToString();
            FrmPNHH.TenNCCB = dgvNCC.Rows[ClassApp.vt].Cells[1].Value.ToString();
        }

        private void dgvTK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmDMNCC.index = ClassApp.vt;
                Close();
                string query = "select * from NhaCungCap";
                ConnectSql.GetDataToTable1(query, "NhaCungCap");
                dgvNCC.DataSource = ConnectSql.ds.Tables["NhaCungCap"];
            }
        }

        private void dgvTK_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FrmDMNCC.index = ClassApp.vt;
            Close();
            string query = "select * from NhaCungCap";
            ConnectSql.GetDataToTable1(query, "NhaCungCap");
            dgvNCC.DataSource = ConnectSql.ds.Tables["NhaCungCap"];
        }

        private void FrmTimKiemTK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTKiem.PerformClick();
            }
        }

        private void txtTenTK_EditValueChanged(object sender, EventArgs e)
        {
            btnTKiem.PerformClick();
        }
    }
}