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
    public partial class FrmTimKiemCTPN : DevExpress.XtraEditors.XtraForm
    {
        public FrmTimKiemCTPN()
        {
            InitializeComponent();
        }

        private void FrmTimKiemCTPN_Load(object sender, EventArgs e)
        {
            ShowAllHangHoa();
            ClassApp.vt = -1;
        }
        DataTable tbhh;
        private void ShowAllHangHoa()
        {
            string query = "select tPhieuNhapHangHoaChiTiet.*, tDanhMucHangHoa.cTenHang from tPhieuNhapHangHoaChiTiet, tDanhMucHangHoa where tPhieuNhapHangHoaChiTiet.cMaHang = tDanhMucHangHoa.cMaHang ";
            tbhh =  ConnectSql.GetDataToTable(query);
            dgvHH.DataSource = tbhh;
            ChangColumn();

        }
        private void ChangColumn()
        {
            dgvHH.Columns[0].HeaderText = "Mã chứng từ";
            dgvHH.Columns[1].HeaderText = "Mã số";
            dgvHH.Columns[2].HeaderText = "Mã Hàng";
            dgvHH.Columns[3].HeaderText = "Đơn vị tính";
            dgvHH.Columns[4].HeaderText = "Số lượng";
            dgvHH.Columns[5].HeaderText = "Đơn giá";
            dgvHH.Columns[6].HeaderText = "Thành tiền";
            dgvHH.Columns[6].HeaderText = "Tên hàng";
        }

        private void TKHangHoa()
        {
            string query = "select tPhieuNhapHangHoaChiTiet.*, tDanhMucHangHoa.cTenHang from tPhieuNhapHangHoaChiTiet, tDanhMucHangHoa where tPhieuNhapHangHoaChiTiet.cMaHang = tDanhMucHangHoa.cMaHang and cTenHang like N'%" + txtTenHH.EditValue + "%' ";
            tbhh = ConnectSql.GetDataToTable(query);
            dgvHH.DataSource = tbhh;
            ChangColumn();
            if (dgvHH.RowCount < 2)
            {
                MessageBox.Show("Không tìm thấy thông tin");
                ShowAllHangHoa();
            }
        }

        private void btnTKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TKHangHoa();
        }

        private void btnDungTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAllHangHoa();
        }


        private void dgvHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClassApp.vt = e.RowIndex;
            float DG = float.Parse(dgvHH.Rows[ClassApp.vt].Cells[6].Value.ToString()) / float.Parse(dgvHH.Rows[ClassApp.vt].Cells[4].Value.ToString());
            FrmHoaDon.MH = dgvHH.Rows[ClassApp.vt].Cells[2].Value.ToString();
            FrmHoaDon.DVT = dgvHH.Rows[ClassApp.vt].Cells[3].Value.ToString();
            FrmHoaDon.DG = DG.ToString();
         //   FrmHoaDon.MCTN = dgvHH.Rows[ClassApp.vt].Cells[0].Value.ToString();
        }

        private void dgvHH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                Close();
               
            }
        }

        private void dgvHH_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Close();
        }

        private void txtTenHH_EditValueChanged(object sender, EventArgs e)
        {
            btnTKiem.PerformClick();
        }
    }
}