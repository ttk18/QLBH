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
    public partial class FrmTimKiemHD : DevExpress.XtraEditors.XtraForm
    {
        public FrmTimKiemHD()
        {
            InitializeComponent();
        }

        private void FrmTimKiemHD_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            //string query = "select * from HoaDon where NgayLapHD BETWEEN  '" + ClassApp.tn + "' AND '" + ClassApp.dn + "'";
            string query = "select * from HoaDon";
            ConnectSql.GetDataToTable1(query, "HoaDon");
            dgvPN.DataSource = ConnectSql.ds.Tables["HoaDon"];
            ChangColumn();

        }
        private void ChangColumn()
        {
            dgvPN.Columns[0].HeaderText = "Mã hóa đơn";
            dgvPN.Columns[1].HeaderText = "Số hóa đơn";
            dgvPN.Columns[2].HeaderText = "Mã nhân viên";
            dgvPN.Columns[3].HeaderText = "Tên nhân viên";
            dgvPN.Columns[4].HeaderText = "Mã khách hàng";
            dgvPN.Columns[5].HeaderText = "Tên khách hàng";
            dgvPN.Columns[6].HeaderText = "Ngày lập hóa đơn";

        }
        private void TKPhieuNhap()
        {
            string NHD = Convert.ToDateTime(txtTenHH.EditValue).ToString("yyyy-MM-dd") + " 00:00:00.000";
            //  string query = "SELECT * FROM HoaDon where NgayLapHD = '" + NHD.ToString() + "' and dNgayChungTu BETWEEN  '" + ClassApp.tn + "' AND '" + ClassApp.dn + "' ";
            string query = "SELECT * FROM HoaDon where NgayLapHD = '" + NHD.ToString() + "'";
            ConnectSql.GetDataToTable1(query, "HoaDon");
            dgvPN.DataSource = ConnectSql.ds.Tables["HoaDon"];
            ChangColumn();
            if (dgvPN.RowCount < 2)
            {
                MessageBox.Show("Không tìm thấy thông tin");
                LoadData();
            }
        }
        private void btnTKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TKPhieuNhap();
        }

        private void btnDungTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void txtTenHH_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmHoaDon.Pos = e.RowIndex;
            Close();
            string query = "select * from HoaDon";
          //  string query = "select * from HoaDon where NgayLapHD BETWEEN  '" + ClassApp.tn + "' AND '" + ClassApp.dn + "'";
            ConnectSql.GetDataToTable1(query, "HoaDon");
            dgvPN.DataSource = ConnectSql.ds.Tables["HoaDon"];
        }
    }
}