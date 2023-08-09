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
    public partial class FrmTimKiemPN : DevExpress.XtraEditors.XtraForm
    {
        public FrmTimKiemPN()
        {
            InitializeComponent();
        }

        private void FrmTimKiemPN_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            //string query = "select * from HoaDon where NgayLapHD BETWEEN  '" + ClassApp.tn + "' AND '" + ClassApp.dn + "'";
            string query = "select * from PhieuNhap";
            ConnectSql.GetDataToTable1(query, "PhieuNhap");
            dgvPN.DataSource = ConnectSql.ds.Tables["PhieuNhap"];
            ChangColumn();

        }
        private void ChangColumn()
        {
            dgvPN.Columns[0].HeaderText = "Mã phiếu nhập";
            dgvPN.Columns[1].HeaderText = "Số phiếu nhập";
            dgvPN.Columns[2].HeaderText = "Mã nhân viên";
            dgvPN.Columns[3].HeaderText = "Tên nhân viên";
            dgvPN.Columns[4].HeaderText = "Ngày lập phiếu";
            dgvPN.Columns[5].HeaderText = "Mã nhà cung cấp";
            dgvPN.Columns[6].HeaderText = "Tên nhà cung cấp";
         

        }
        private void TKPhieuNhap()
        {
            string NHD = Convert.ToDateTime(txtTenHH.EditValue).ToString("yyyy-MM-dd") + " 00:00:00.000";
            //  string query = "SELECT * FROM HoaDon where NgayLapHD = '" + NHD.ToString() + "' and dNgayChungTu BETWEEN  '" + ClassApp.tn + "' AND '" + ClassApp.dn + "' ";
            string query = "SELECT * FROM PhieuNhap where NgayNhap = '" + NHD.ToString() + "'";
            ConnectSql.GetDataToTable1(query, "PhieuNhap");
            dgvPN.DataSource = ConnectSql.ds.Tables["PhieuNhap"];
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

        private void dgvPN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmHoaDon.Pos = e.RowIndex;
            Close();
            string query = "select * from PhieuNhap";
            //  string query = "select * from HoaDon where NgayLapHD BETWEEN  '" + ClassApp.tn + "' AND '" + ClassApp.dn + "'";
            ConnectSql.GetDataToTable1(query, "PhieuNhap");
            dgvPN.DataSource = ConnectSql.ds.Tables["PhieuNhap"];
        }
    }
}