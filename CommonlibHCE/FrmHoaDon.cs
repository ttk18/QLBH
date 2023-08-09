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
using System.Data.SqlClient;

namespace CommonlibHCE
{
    public partial class FrmHoaDon : DevExpress.XtraEditors.XtraForm
    {
        public FrmHoaDon()
        {
            InitializeComponent();
        }
        static string strFormState;
        static string strMainState;
        public static int Pos;
       
        private void FrmPXHH_Load(object sender, EventArgs e)
        {
            ClassApp.role = "Nhân Viên";
            Binding();
            ShowAllTaiKhoan();
            strFormState = "NORMAL";
            strMainState = "NORMAL";
            ConnectSql.bs.Position = 0;
            txtP.EditValue = (ConnectSql.bs.Position + 1) + "/" + ConnectSql.bs.Count;
            ConnectSql.LockControlValues(groupControl1);
            ConnectSql.LockControlValues(groupControl2);
            splitContainer2.Panel1Collapsed = true;
            barButtonItem2.Enabled = false;
            btnLuuP.Enabled = false;
            btnDungP.Enabled = false;

            //sub
            btnDung.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void ShowAllTaiKhoan()
        {
            string query = "select * from ChiTietHD where MaHD = '" + txtMaHD.Text + "' ";
            ConnectSql.GetDataToTable1(query, "ChiTietHD");
            dgvPN.DataSource = ConnectSql.ds.Tables["ChiTietHD"];
            ChangColumn();
        }
        private void ShowAllTaiKhoan1()
        {
            string query = "select * from ChiTietHD";
            ConnectSql.GetDataToTable1(query, "ChiTietHD");
            dgvPN.DataSource = ConnectSql.ds.Tables["ChiTietHD"];
            ChangColumn();
        }


        void Clearbinding()
        {
            txtMaHD.DataBindings.Clear();
            txtMaNV.DataBindings.Clear();
            txtNgayHD.DataBindings.Clear();
            txtMaKH.DataBindings.Clear();
            txtTenNV.DataBindings.Clear();
            txtTenKH.DataBindings.Clear();
            txtSoHD.DataBindings.Clear();
        }
        private void Binding()
        {
            string query = "select * from HoaDon ";
          //  string query = "select * from HoaDon where NgayLapHD BETWEEN '" + ClassApp.tn + "' AND '" + ClassApp.dn + "'";
            ConnectSql.GetDataToTable1(query, "HoaDon");

            ConnectSql.bs = new BindingSource(ConnectSql.ds, "HoaDon");
            txtMaHD.DataBindings.Add("Text", ConnectSql.bs, "MaHD");
            txtMaNV.DataBindings.Add("Text", ConnectSql.bs, "MaNV");
            txtNgayHD.DataBindings.Add("Text", ConnectSql.bs, "NgayLapHD"); 
            txtMaKH.DataBindings.Add("Text", ConnectSql.bs, "MaKH");
            txtTenNV.DataBindings.Add("Text", ConnectSql.bs, "TenNV");
            txtTenKH.DataBindings.Add("Text", ConnectSql.bs, "TenKH");
            txtSoHD.DataBindings.Add("Text", ConnectSql.bs, "SoHD");


        }

        private void ChangColumn()
        {
            dgvPN.Columns[0].HeaderText = "Mã hóa đơn";
            dgvPN.Columns[1].HeaderText = "Mã số";
            dgvPN.Columns[2].HeaderText = "Mã hàng";
            dgvPN.Columns[3].HeaderText = "Số lượng";
            dgvPN.Columns[4].HeaderText = "Đơn giá";
            dgvPN.Columns[5].HeaderText = "Đơn vị tính";
            dgvPN.Columns[6].HeaderText = "Thành tiền";
        }

        private bool textEmpty()
        {
            DateTime d;
            string empty = maskedTextBox1.Text;
            float tx;
            if (txtMaNV.Text == "") { errorProvider1.SetError(txtMaNV, "Yêu cầu nhập"); return false; }
            else errorProvider1.Clear();
            if (txtNgayHD.Text == empty) { errorProvider1.SetError(txtNgayHD, "Yêu cầu nhập"); return false; }
            else errorProvider1.Clear();
            if (txtMaKH.Text == "") { errorProvider1.SetError(txtMaKH, "Yêu cầu nhập"); return false; }
            else errorProvider1.Clear();
          
         
              if (txtSL.Text == "") { errorProvider1.SetError(txtSL, "Yêu cầu nhập"); return false; }
              else errorProvider1.Clear();
              if (!float.TryParse(txtSL.Text, out tx)) { errorProvider1.SetError(txtSL, "Yêu cầu nhập"); txtSL.Focus(); return false; }
              else errorProvider1.Clear();
              if (txtDG.Text == "") { errorProvider1.SetError(txtDG, "Yêu cầu nhập"); return false; }
              else errorProvider1.Clear();
              if (!float.TryParse(txtDG.Text, out tx)) { errorProvider1.SetError(txtDG, "Yêu cầu nhập"); txtDG.Focus(); return false; }
              else errorProvider1.Clear();
            return true;
        }
        private bool textEmptyMain()
        {
            string empty = maskedTextBox1.Text;
            float tx;
            if (txtMaNV.Text == "") { errorProvider1.SetError(txtMaNV, "Yêu cầu nhập"); return false; }
            else errorProvider1.Clear();
            if (txtNgayHD.Text == empty) { errorProvider1.SetError(txtNgayHD, "Yêu cầu nhập"); return false; }
            else errorProvider1.Clear();
            if (txtMaKH.Text == "") { errorProvider1.SetError(txtMaKH, "Yêu cầu nhập"); return false; }
            else errorProvider1.Clear();
            if (txtNgayHD.Text == empty) { errorProvider1.SetError(txtNgayHD, "Yêu cầu nhập"); return false; }
            else errorProvider1.Clear();
            return true;
        }
        private bool textEmptySub()
        {
            float tx;
            if (txtMahh.Text == "") { errorProvider1.SetError(txtMahh, "Yêu cầu nhập"); return false; }
            else errorProvider1.Clear();
            if (txtDonVitinh.Text == "") { errorProvider1.SetError(txtDonVitinh, "Yêu cầu nhập"); return false; }
            else errorProvider1.Clear();
            if (txtSL.Text == "") { errorProvider1.SetError(txtSL, "Yêu cầu nhập"); return false; }
            else errorProvider1.Clear();
            if (!float.TryParse(txtSL.Text, out tx)) { errorProvider1.SetError(txtSL, "Yêu cầu nhập"); txtSL.Focus(); return false; }
            else errorProvider1.Clear();
            if (txtDG.Text == "") { errorProvider1.SetError(txtDG, "Yêu cầu nhập"); return false; }
            else errorProvider1.Clear();
            if (!float.TryParse(txtDG.Text, out tx)) { errorProvider1.SetError(txtDG, "Yêu cầu nhập"); txtDG.Focus(); return false; }
            else errorProvider1.Clear();
           /* if (txtDGB.Text == "") { errorProvider1.SetError(txtDGB, "Yêu cầu nhập"); return false; }
            else errorProvider1.Clear();
            if (!float.TryParse(txtDGB.Text, out tx)) { errorProvider1.SetError(txtDGB, "Yêu cầu nhập"); txtDGB.Focus(); return false; }
            else errorProvider1.Clear();*/
            return true;
        }
        
       
      
        private void dgvPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            splitContainer2.Panel1Collapsed = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            toolStrip1.Enabled = true;
            try
            {
                ClassApp.vt = e.RowIndex;
                //   if (ClassApp.vt == -1 || ClassApp.vt > ConnectSql.ds.Tables["ChiTietHD"].Rows.Count) return;
                DataRow row = ConnectSql.ds.Tables["ChiTietHD"].Rows[ClassApp.vt];
                txtMahh.Text = row["MaMH"].ToString();
                txtDonVitinh.Text = row["DVT"].ToString();
                txtSL.Text = row["SOLUONG"].ToString();
                txtDG.Text = row["DonGia"].ToString();
                txtTT.Text = row["ThanhTien"].ToString();

            }
            catch (Exception)
            {
                return;
            }

        }

        private void dgvPN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
      
        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTimKiemHD frm = new FrmTimKiemHD();
            frm.ShowDialog();
            ConnectSql.bs.Position = Pos;
            txtP.EditValue = (Pos + 1) + "/" + ConnectSql.bs.Count;
        }

   

        //main
        private void btnThemP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            strFormState = "ADDING";
            strMainState = "Turn on";
            btnF.Enabled = false;
            btnP.Enabled = false;
            btnN.Enabled = false;
            btnL.Enabled = false;
            btnThemP.Enabled = false;
            btnSuaP.Enabled = false;
            btnThoat.Enabled = false;
            btnIn.Enabled = false;
            btnDungP.Enabled = true;
            btnLuuP.Enabled = true;
            splitContainer2.Panel1Collapsed = false;
            ConnectSql.UnLockControlValues(groupControl1);
            ConnectSql.UnLockControlValues(groupControl2);
            ConnectSql.XoaNoiDung(groupControl1);
            ConnectSql.XoaNoiDung(groupControl2);
            dgvPN.DataSource = null;
            toolStrip1.Enabled = false;
        }

        private void btnSuaP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            strFormState = "EDITTING";
            strMainState = "Turn on";
            btnF.Enabled = false;
            btnP.Enabled = false;
            btnN.Enabled = false;
            btnL.Enabled = false;
            btnThemP.Enabled = false;
            btnSuaP.Enabled = false;
            btnThoat.Enabled = false;
            btnIn.Enabled = false;

            btnDungP.Enabled = true;
            btnLuuP.Enabled = true;
            splitContainer2.Panel1Collapsed = false;
            ConnectSql.UnLockControlValues(groupControl1);
         //   ConnectSql.UnLockControlValues(groupControl2);
            txtMaHD.ReadOnly = true;
           // txtMaKH.ReadOnly = true;
            txtNgayHD.ReadOnly = true;
            txtSoHD.ReadOnly = true;
           // txtMaNV.ReadOnly = true;
        }

        private void btnLuuP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (strFormState == "ADDING" && strMainState == "Turn on")
            {
                if (textEmpty() == true)
                {
                    string day = DateTime.Parse(txtNgayHD.Text).Date.ToShortDateString();
                    string dt = day.Substring(0, 6);
                    string dt2 = day.Substring(8);
                    string dt3 = dt + dt2;
                    string NCT = Convert.ToDateTime(txtNgayHD.Text).ToString("yyyy-MM-dd");
                    string MaCT = txtMaNV.Text.Substring(3,2) + "/" + txtMaKH.Text.Substring(3,2) + "/" + txtSoHD.Text.Trim() + dt3 ;
                    txtMaHD.Text = MaCT;
                    string sql = "INSERT INTO HoaDon(MaHD,MaNV,TenNV,MaKH,TenKH,SoHD," +
                        "NgayLapHD) VALUES (N'" + txtMaHD.Text.Trim() + "',N'" + txtMaNV.Text.Trim() + "',N'" + txtTenNV.Text.Trim() +
                        "',N'" + txtMaKH.Text.Trim() + "',N'" + txtTenKH.Text.Trim() + "',N'" + txtSoHD.Text.Trim() + "',N'" + NCT + "')";
                    ConnectSql.RunSQL(sql);
                    //ADD SUB
                    if (ConnectSql.RunSql == true)
                    {
                        ShowAllTaiKhoan1();
                        double SL = double.Parse(txtSL.Text.Trim());
                        double DG = double.Parse(txtDG.Text.Trim());
                        DataRow row = ConnectSql.ds.Tables["ChiTietHD"].NewRow();
                        row["MaHD"] = txtMaHD.Text.Trim();
                        row["MaSo"] = ConnectSql.ds.Tables["ChiTietHD"].Rows.Count + 1;
                        row["MaMH"] = txtMahh.Text.Trim();
                        row["SOLUONG"] = txtSL.Text.Trim();
                        row["DonGia"] = txtDG.Text.Trim();
                        row["DVT"] = txtDonVitinh.Text.Trim();
                        row["ThanhTien"] = SL * DG;


                        try
                        {
                            ConnectSql.ds.Tables["ChiTietHD"].Rows.Add(row);
                            int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["ChiTietHD"]);
                            if (rs > 0)
                            {
                               // MessageBox.Show("Thêm dữ liệu thành công!");
                                btnDungP.PerformClick();
                                ConnectSql.XoaNoiDung(this.groupControl2);
                                ConnectSql.bs.ResetBindings(true);
                               

                            }

                            else
                            {
                                MessageBox.Show("Thêm dữ liệu thất bại!");
                            }
                            ConnectSql.bs.ResetBindings(true);
                            ShowAllTaiKhoan();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Trùng mã");
                            ShowAllTaiKhoan();

                        }
                        ConnectSql.XoaNoiDung(this.groupControl2);
                        MessageBox.Show("Thêm hóa đơn thành công!");
                    }
                }
            }


            else if (strFormState == "EDITTING" && strMainState == "Turn on")
            {
                if (textEmptyMain() == true)
                {
                    string day = DateTime.Parse(txtNgayHD.Text).Date.ToShortDateString();
                    string dt = day.Substring(0, 6);
                    string dt2 = day.Substring(8);
                    string dt3 = dt + dt2;
                    string NCT = Convert.ToDateTime(txtNgayHD.Text).ToString("yyyy-MM-dd");
                    string MaCT = txtMaNV.Text.Substring(3, 2) + "/" + txtMaKH.Text.Substring(3, 2) + "/" + txtSoHD.Text.Trim() + dt3;
                    txtMaHD.Text = MaCT;

                    string sql = "UPDATE HoaDon SET MaNV = N'" + txtMaNV.Text.Trim() + "'" +
                      ",MaKH = N'" + txtMaKH.Text.Trim() + "'" +
                      ",NgayLapHD = N'" + NCT + "'" +
                       ",TenNV = N'" + txtTenNV.Text.Trim() + "'" +
                        ",TenKH = N'" + txtTenKH.Text.Trim() + "'" +
                          ",SoHD = N'" + txtSoHD.Text.Trim() + "'" +
                      " where MaHD = N'" + txtMaHD.Text.Trim() + "'";
                    ConnectSql.RunSQL(sql);
                    if (ConnectSql.RunSql == true)
                    {
                        MessageBox.Show("Chỉnh sửa phiếu nhập thành công");
                        btnDungP.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Chỉnh sửa Thất bại");
                    }
                }

            }
            ConnectSql.bs.Dispose();
            Clearbinding();
            Binding();
            ShowAllTaiKhoan();
            txtP.EditValue = (ConnectSql.bs.Position + 1) + "/" + ConnectSql.bs.Count;
        }

        private void btnDungP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThemP.Enabled = true;
            btnSuaP.Enabled = true;
            btnThoat.Enabled = true;
            btnIn.Enabled = true;
            btnLuuP.Enabled = false;
            btnDungP.Enabled = false;
            btnF.Enabled = true;
            btnP.Enabled = true;
            btnN.Enabled = true;
            btnL.Enabled = true;

            ConnectSql.LockControlValues(groupControl1);
            ConnectSql.LockControlValues(groupControl2);

            ConnectSql.bs.ResetCurrentItem();
            errorProvider1.Clear();
            ShowAllTaiKhoan();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //lấy dữ liệu cho reporrt 
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = ConnectSql.Con; //Gán kết nối
            string query = "select HoaDon.MaHD,SoHD,MaNV,TenNV,MaKH,TenKH,NgayLapHD," +
                "ChiTietHD.MaSo, ChiTietHD.MaMH,ChiTietHD.SOLUONG, ChiTietHD.DonGia,ChiTietHD.DVT,ChiTietHD.ThanhTien, " +
                "MatHang.TenMH,  MatHang.MaMH " +
                "from HoaDon, ChiTietHD, MatHang where HoaDon.MaHD=ChiTietHD.MaHD " +
               " AND ChiTietHD.MaMH = MatHang.MaMH AND HoaDon.MaHD = @mahd";
         
           // cmd.Parameters.Clear();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@mahd", txtMaHD.Text);

            DataTable dt = new DataTable("BangHoaDon");
            dt.Load(cmd.ExecuteReader());
            RptHoaDon baocao = new RptHoaDon();
            baocao.SetDataSource(dt);
            FrmInHoaDon hd = new FrmInHoaDon();
            hd.crystalReportViewer1.ReportSource= baocao;
            hd.ShowDialog();
        }

   

        //Postion
        private void btnF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConnectSql.bs.Position = 0;
            txtP.EditValue = (ConnectSql.bs.Position + 1) + "/" + ConnectSql.bs.Count;
            ShowAllTaiKhoan();
        }

        private void btnP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ConnectSql.bs.Position > 0)
                ConnectSql.bs.Position--;
            txtP.EditValue = (ConnectSql.bs.Position + 1) + "/" + ConnectSql.bs.Count;
            ShowAllTaiKhoan();
        }

        private void btnN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ConnectSql.bs.Position < ConnectSql.bs.Count - 1)
                ConnectSql.bs.Position++;
            txtP.EditValue = (ConnectSql.bs.Position + 1) + "/" + ConnectSql.bs.Count;
            ShowAllTaiKhoan();
        }

        private void btnL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConnectSql.bs.Position = ConnectSql.bs.Count - 1;
            txtP.EditValue = (ConnectSql.bs.Position + 1) + "/" + ConnectSql.bs.Count;
            ShowAllTaiKhoan();
        }
        public static string MH;
        public static string DVT;
        public static string DG;
        public static string MaNVB;
        public static string TenNVB;
        public static string MaKHM;
        public static string TenKHM;
        private void txtMaNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (strFormState == "ADDING" && strMainState == "Turn on")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FrmTimKiemNV frm = new FrmTimKiemNV();
                    frm.ShowDialog();
                    txtMaNV.Text = MaNVB;
                     txtTenNV.Text = TenNVB;
                }
            }

            if (strFormState == "EDITTING" && strMainState == "Turn on")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FrmTimKiemNV frm = new FrmTimKiemNV();
                    frm.ShowDialog();
                    txtMaNV.Text = MaNVB;
                    txtTenNV.Text = TenNVB;
                }
            }

        }

        private void txtMahh_KeyDown(object sender, KeyEventArgs e)
        {
            if (strFormState == "ADDING" )
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FrmTimKiemHH frm = new FrmTimKiemHH();
                    frm.ShowDialog();
                    txtMahh.Text = MH;
                    txtDonVitinh.Text = DVT;
                    txtDG.Text = DG;
                    if (txtDG.Text == "NaN")
                    {
                        txtDG.Text = "0";
                    }
                }
            }

            if (strFormState == "EDITTING" )
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FrmTimKiemHH frm = new FrmTimKiemHH();
                    frm.ShowDialog();
                    txtMahh.Text = MH;
                    txtDonVitinh.Text = DVT;
                    txtDG.Text = DG;
                    if (txtDG.Text == "NaN")
                    {
                        txtDG.Text = "0";
                    }
                }
            }
        }

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (strFormState == "ADDING" && strMainState == "Turn on")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FrmTimKiemKH frm = new FrmTimKiemKH();
                    frm.ShowDialog();
                    txtMaKH.Text = MaKHM;
                    txtTenKH.Text = TenKHM;
                }
            }

            if (strFormState == "EDITTING" && strMainState == "Turn on")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FrmTimKiemKH frm = new FrmTimKiemKH();
                    frm.ShowDialog();
                    txtMaKH.Text = MaKHM;
                    txtTenKH.Text = TenKHM;
                }
            }
        }
      //  SUB
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnTim.Enabled = true;
            strFormState = "ADDING";
            strMainState = "Turn off";
            txtMahh.Focus();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnDung.Enabled = true;
            splitContainer2.Panel1Collapsed = false;
            ConnectSql.UnLockControlValues(groupControl2);
            ConnectSql.XoaNoiDung(groupControl2);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult warn = MessageBox.Show("Bạn có thực sự muốn xóa dòng này không?", "Cảnh báo!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (warn == DialogResult.Yes)
            {
                try
                {
                    DataRow row = ConnectSql.ds.Tables["ChiTietHD"].Rows[ClassApp.vt];
                    row.Delete();
                    int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["ChiTietHD"]);
                    if (rs > 0)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công!");
                        ConnectSql.XoaNoiDung(this.groupControl2);
                    }
                }
                catch (Exception)
                {
                    //throw;
                    MessageBox.Show("Xóa dữ liệu thất bại!");
                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnTim.Enabled = true;
            strMainState = "Turn off";
            strFormState = "EDITTING";
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnDung.Enabled = true;
            splitContainer2.Panel1Collapsed = false;
            ConnectSql.UnLockControlValues(groupControl2);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (strFormState == "ADDING" && strMainState == "Turn off")
            {
                if (textEmptySub() == true)
                {
                    ShowAllTaiKhoan1();
                    double SL = double.Parse(txtSL.Text.Trim());
                    double DG = double.Parse(txtDG.Text.Trim());
                    DataRow row = ConnectSql.ds.Tables["ChiTietHD"].NewRow();
                    row["MaHD"] = txtMaHD.Text.Trim();
                    row["MaSo"] = ConnectSql.ds.Tables["ChiTietHD"].Rows.Count + 1;
                    row["MaMH"] = txtMahh.Text.Trim();
                    row["SOLUONG"] = txtSL.Text.Trim();
                    row["DonGia"] = txtDG.Text.Trim();
                    row["DVT"] = txtDonVitinh.Text.Trim();
                    row["ThanhTien"] = SL * DG;
                    try
                    {
                        ConnectSql.ds.Tables["ChiTietHD"].Rows.Add(row);
                        int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["ChiTietHD"]);
                        if (rs > 0)
                        {
                            MessageBox.Show("Thêm dữ liệu thành công!");
                            ConnectSql.XoaNoiDung(this.groupControl2);
                            btnDung.PerformClick();
                            ShowAllTaiKhoan();
                        }

                        else
                        {
                            MessageBox.Show("Thêm dữ liệu thất bại!");
                        }
                        ShowAllTaiKhoan();
                    }
                    catch (Exception)
                    {
                       MessageBox.Show("Trùng mã");
                       ShowAllTaiKhoan();
               
                        throw;

                    }
                }
            }


            else if (strFormState == "EDITTING" && strMainState == "Turn off")
            {
                if (textEmptySub() == true)
                {
                    
                    double SL = double.Parse(txtSL.Text.Trim());
                    double DG = double.Parse(txtDG.Text.Trim());
                    DataRow row = ConnectSql.ds.Tables["ChiTietHD"].Rows[ClassApp.vt];
                    row.BeginEdit();
                    row["MaHD"] = txtMaHD.Text.Trim();
                    row["MaMH"] = txtMahh.Text.Trim();
                    row["SOLUONG"] = txtSL.Text.Trim();
                    row["DonGia"] = txtDG.Text.Trim();
                    row["DVT"] = txtDonVitinh.Text.Trim();
                    row["ThanhTien"] = SL * DG;
                    row.EndEdit();
                    try
                    {

                        int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["ChiTietHD"]);
                        if (rs > 0)
                        {
                            //  MessageBox.Show("Chỉnh sửa liệu thành công!!");
                            ConnectSql.XoaNoiDung(this.groupControl2);
                            btnDung.PerformClick();
                            ShowAllTaiKhoan();
                        }

                        else
                        {
                            MessageBox.Show("Chỉnh sửa thất bại!!");
                        }
                        
                    }
                    catch (Exception)
                    {
                         throw;
                      /*  MessageBox.Show("Trùng mã");
                        ShowAllTaiKhoan();*/

                    }
                }
            }
        }

        private void btnDung_Click(object sender, EventArgs e)
        {
            if (strMainState == "Turn off")
            {
                btnDung.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                ConnectSql.LockControlValues(groupControl2);
                btnTim.Enabled = false;

            }
        }

        private void FrmHoaDon_Activated(object sender, EventArgs e)
        {
            ShowAllTaiKhoan();
            ClassApp.role = "Nhân Viên";
        }
    }
}