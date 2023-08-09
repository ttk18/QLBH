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
    public partial class FrmTimKiemNV : DevExpress.XtraEditors.XtraForm
    {
        public FrmTimKiemNV()
        {
            InitializeComponent();
        }

        private void btnTKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TKHangHoa();
        }

        private void btnDungTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void FrmTimKiemNV_Load(object sender, EventArgs e)
        {
            LoadData();
            FrmNhanVien.index = -1;
            FrmNhanVien.x = 0;
            ClassApp.vt = -1;
        }
        private void LoadData()
        {
            if (ClassApp.role == "Quản lý")
            {
                string query = "select * from NhanVien where ChucVu = N'Quản lý'";

                ConnectSql.GetDataToTable1(query, "NhanVien");
                dgvNV.DataSource = ConnectSql.ds.Tables["NhanVien"];
                ChangColumn();
            }
            else
            {
                string query = "select * from NhanVien where ChucVu = N'Nhân viên'";

                ConnectSql.GetDataToTable1(query, "NhanVien");
                dgvNV.DataSource = ConnectSql.ds.Tables["NhanVien"];
                ChangColumn();
            }
          
        }
        private void ChangColumn()
        {
            dgvNV.Columns[0].HeaderText = "Mã nhân viên";
            dgvNV.Columns[1].HeaderText = "Tên nhân viên";
            dgvNV.Columns[2].HeaderText = "Giới tính";
            dgvNV.Columns[3].HeaderText = "Ngày sinh";
            dgvNV.Columns[4].HeaderText = "Địa chỉ";
            dgvNV.Columns[5].HeaderText = "Số điện thoại";
            dgvNV.Columns[6].HeaderText = "Chức vụ";
        }

        private void TKHangHoa()
        {
            string query = "SELECT * FROM NhanVien where TenNV like N'%" + txtTenHH.EditValue + "%'";
            ConnectSql.GetDataToTable1(query, "NhanVien");
            dgvNV.DataSource = ConnectSql.ds.Tables["NhanVien"];
            ChangColumn();
            if (dgvNV.RowCount < 2)
            {
                MessageBox.Show("Không tìm thấy thông tin");
                LoadData();
            }
        }
        private void txtTenHH_EditValueChanged(object sender, EventArgs e)
        {
            btnTKiem.PerformClick();
        }

        private void FrmTimKiemNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTKiem.PerformClick();
            }
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClassApp.vt = e.RowIndex;
            FrmNhanVien.value = dgvNV.Rows[ClassApp.vt].Cells[0].Value.ToString();

            FrmHoaDon.MaNVB = dgvNV.Rows[ClassApp.vt].Cells[0].Value.ToString();
            FrmHoaDon.TenNVB = dgvNV.Rows[ClassApp.vt].Cells[1].Value.ToString();

            FrmPNHH.MaNVM = dgvNV.Rows[ClassApp.vt].Cells[0].Value.ToString();
            FrmPNHH.TenNVM = dgvNV.Rows[ClassApp.vt].Cells[1].Value.ToString();
        }

        private void dgvNV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FrmNhanVien.index = ClassApp.vt;
            Close();
            string query = "SELECT * FROM NhanVien";
            ConnectSql.GetDataToTable1(query, "NhanVien");
            dgvNV.DataSource = ConnectSql.ds.Tables["NhanVien"];
        }
    }
}