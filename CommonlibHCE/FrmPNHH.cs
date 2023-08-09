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
    public partial class FrmPNHH : DevExpress.XtraEditors.XtraForm
    {
        public FrmPNHH()
        {
            InitializeComponent();
        }
        static string strFormState;
        static string strMainState;
        public static int Pos;
        private void FrmPNHH_Load(object sender, EventArgs e)
        {
            ClassApp.role = "Quản lý";
            try
            {
                Binding();
            }
            catch (Exception)
            {
                return;
            }
           
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
            string query = "select * from ChiTietPN where MaPN = '" + txtMaPN.Text +"' " ;
            ConnectSql.GetDataToTable1(query, "ChiTietPN");
            dgvPN.DataSource = ConnectSql.ds.Tables["ChiTietPN"];
            ChangColumn();
        }

        private void ShowAllTaiKhoan1()
        {
            string query = "select * from ChiTietPN";
            ConnectSql.GetDataToTable1(query, "ChiTietPN");
           
        }
        void Clearbinding()
        {
            txtMaPN.DataBindings.Clear();
            txtMaNV.DataBindings.Clear();
            txtNgayNhap.DataBindings.Clear();
            txtMaNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Clear();
            txtTenNV.DataBindings.Clear();
            txtSoPN.DataBindings.Clear();
        }
        private void Binding()
        {
            // string query = "select * from PhieuNhap where NgayNhap BETWEEN  '" + ClassApp.tn + "' AND '" + ClassApp.dn + "'";
            string query = "select * from PhieuNhap";
            ConnectSql.GetDataToTable1(query, "PhieuNhap");
            ConnectSql.bs = new BindingSource(ConnectSql.ds, "PhieuNhap");
            txtMaPN.DataBindings.Add("Text", ConnectSql.bs, "MaPN");
            txtSoPN.DataBindings.Add("Text", ConnectSql.bs, "SoPN");
            txtMaNCC.DataBindings.Add("Text", ConnectSql.bs, "MaNCC");
            txtNgayNhap.DataBindings.Add("Text", ConnectSql.bs, "NgayNhap") ;
            txtMaNV.DataBindings.Add("Text", ConnectSql.bs, "MaNV");
            txtTenNCC.DataBindings.Add("Text", ConnectSql.bs, "TenNCC");
            txtTenNV.DataBindings.Add("Text", ConnectSql.bs, "TenNV");

        }
        
        private void ChangColumn()
        {
            dgvPN.Columns[0].HeaderText = "Mã phiếu nhập";
            dgvPN.Columns[1].HeaderText = "Mã số";
            dgvPN.Columns[2].HeaderText = "Mã mặt hàng";  
            dgvPN.Columns[3].HeaderText = "Số lượng nhập";
            dgvPN.Columns[4].HeaderText = "Đơn giá nhập";
            dgvPN.Columns[5].HeaderText = "Đơn vị tính";
            dgvPN.Columns[6].HeaderText = "Thành tiền";
        }
        private bool textEmpty()
        {
            string empty = maskedTextBox1.Text;
            float tx;
            if (txtMaNCC.Text == "") { errorProvider1.SetError(txtMaNCC, "Yêu cầu nhập"); txtMaNCC.Focus();  return false; }
            else errorProvider1.Clear();
            if (txtNgayNhap.Text == empty) { errorProvider1.SetError(txtNgayNhap, "Yêu cầu nhập"); txtNgayNhap.Focus();  return false; }
            else errorProvider1.Clear();
            if (txtMahh.Text == "") { errorProvider1.SetError(txtMahh, "Yêu cầu nhập"); txtMahh.Focus(); return false; }
            else errorProvider1.Clear();
            if (txtDonVitinh.Text == "") { errorProvider1.SetError(txtDonVitinh, "Yêu cầu nhập"); txtDonVitinh.Focus(); return false; }
            else errorProvider1.Clear();
            if (!float.TryParse(txtSL.Text, out tx)) { errorProvider1.SetError(txtSL, "Yêu cầu nhập số"); txtSL.Focus(); return false; }
            else errorProvider1.Clear();
            if (!float.TryParse(txtDG.Text, out tx)) { errorProvider1.SetError(txtDG, "Yêu cầu nhập số"); txtDG.Focus(); return false; }
            else errorProvider1.Clear();

            return true;
        }
        private bool textEmptyMain()
        {
            string empty = maskedTextBox1.Text;
            float tx;
            if (txtMaNCC.Text == "") { errorProvider1.SetError(txtMaNCC, "Yêu cầu nhập"); txtMaNCC.Focus(); return false; }
            else errorProvider1.Clear();
            if (txtNgayNhap.Text == empty) { errorProvider1.SetError(txtNgayNhap, "Yêu cầu nhập"); txtNgayNhap.Focus(); return false; }
            else errorProvider1.Clear();

            return true;
        }
        private bool textEmptySub()
        {
            float tx;
            if (txtMahh.Text == "") { errorProvider1.SetError(txtMahh, "Yêu cầu nhập"); txtMahh.Focus(); return false; }
            else errorProvider1.Clear();
            if (txtDonVitinh.Text == "") { errorProvider1.SetError(txtDonVitinh, "Yêu cầu nhập"); txtDonVitinh.Focus(); return false; }
            else errorProvider1.Clear();
            if (!float.TryParse(txtSL.Text, out tx)) { errorProvider1.SetError(txtSL, "Yêu cầu nhập số"); txtSL.Focus(); return false; }
            else errorProvider1.Clear();
            if (!float.TryParse(txtDG.Text, out tx)) { errorProvider1.SetError(txtDG, "Yêu cầu nhập số"); txtDG.Focus(); return false; }
            else errorProvider1.Clear();
            return true;
        }
        
        private void dgvPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            splitContainer2.Panel1Collapsed = false;

            //sub
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            toolStrip1.Enabled = true;
            try
            {
                ClassApp.vt = e.RowIndex;
                if (ClassApp.vt == -1 || ClassApp.vt > ConnectSql.ds.Tables["ChiTietPN"].Rows.Count) return;
                DataRow row = ConnectSql.ds.Tables["ChiTietPN"].Rows[ClassApp.vt];
                txtMahh.Text = row["MaMH"].ToString();
                txtSL.Text = row["SL_Nhap"].ToString();
                txtDG.Text = row["DG_Nhap"].ToString();
                txtDonVitinh.Text = row["DVT"].ToString();
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
        
        public static string MaNb;
        public static string TenNb;
        public static string Mst;
        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTimKiemPN frm = new FrmTimKiemPN();
            frm.ShowDialog();
            ConnectSql.bs.Position = Pos;
            txtP.EditValue = (Pos + 1) + "/" + ConnectSql.bs.Count;
        }

       

       //Main
        private void btnThemP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          //  txtNgayHD.Text = DateTime.Today.ToShortDateString();
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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
            ConnectSql.UnLockControlValues(groupControl1);
            ConnectSql.UnLockControlValues(groupControl2);
            txtMaPN.ReadOnly = true;
            //txtSCT.ReadOnly = true;
            txtNgayNhap.ReadOnly = true;
            txtSoPN.ReadOnly = true;

            // txtMaNCC.ReadOnly = true;
        }

        private void btnLuuP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (strFormState == "ADDING" && strMainState == "Turn on")
            {
                if (textEmpty() == true)
                {
                    string day = DateTime.Parse(txtNgayNhap.Text).Date.ToShortDateString();
                    string dt = day.Substring(0, 6);
                    string dt2 = day.Substring(8);
                    string dt3 = dt + dt2;
                    string NCT = Convert.ToDateTime(txtNgayNhap.Text).ToString("yyyy-MM-dd");
                    string MaCT = txtMaNV.Text.Substring(3, 2) + "/" + txtMaNCC.Text.Substring(3, 2) + "/" + txtSoPN.Text.Trim() + dt3;
                    txtMaPN.Text = MaCT;
                    string sql = "INSERT INTO PhieuNhap(MaPN,MaNV,TenNV,MaNCC,TenNCC,SoPN," +
                        "NgayNhap) VALUES (N'" + txtMaPN.Text.Trim() + "',N'" + txtMaNV.Text.Trim() + "',N'" + txtTenNV.Text.Trim() +
                        "',N'" + txtMaNCC.Text.Trim() + "',N'" + txtTenNCC.Text.Trim() + "',N'" + txtSoPN.Text.Trim() + "',N'" + NCT + "')";
                    ConnectSql.RunSQL(sql);
                    //ADD SUB
                    if (ConnectSql.RunSql == true)
                    {
                        ShowAllTaiKhoan1();
                        double SL = double.Parse(txtSL.Text.Trim());
                        double DG = double.Parse(txtDG.Text.Trim());
                        DataRow row = ConnectSql.ds.Tables["ChiTietPN"].NewRow();
                        row["MaPN"] = txtMaPN.Text.Trim();
                        row["MaSo"] = ConnectSql.ds.Tables["ChiTietPN"].Rows.Count + 1;
                        row["MaMH"] = txtMahh.Text.Trim();
                        row["SL_Nhap"] = txtSL.Text.Trim();
                        row["DG_Nhap"] = txtDG.Text.Trim();
                        row["DVT"] = txtDonVitinh.Text.Trim();
                        row["ThanhTien"] = SL * DG;


                        try
                        {
                            ConnectSql.ds.Tables["ChiTietPN"].Rows.Add(row);
                            int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["ChiTietPN"]);
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
                        MessageBox.Show("Thêm phiếu nhập thành công!");
                    }
                }
            }


            else if (strFormState == "EDITTING" && strMainState == "Turn on")
            {
                if (textEmptyMain() == true)
                {
                    string day = DateTime.Parse(txtNgayNhap.Text).Date.ToShortDateString();
                    string dt = day.Substring(0, 6);
                    string dt2 = day.Substring(8);
                    string dt3 = dt + dt2;
                    string NCT = Convert.ToDateTime(txtNgayNhap.Text).ToString("yyyy-MM-dd");
                    string MaCT = txtMaNV.Text.Substring(3, 2) + "/" + txtMaNCC.Text.Substring(3, 2) + "/" + txtSoPN.Text.Trim() + dt3;
                    txtMaPN.Text = MaCT;

                    string sql = "UPDATE PhieuNhap SET MaNV = N'" + txtMaNV.Text.Trim() + "'" +
                      ",MaNCC = N'" + txtMaNCC.Text.Trim() + "'" +
                      ",NgayNhap = N'" + NCT + "'" +
                       ",TenNV = N'" + txtTenNV.Text.Trim() + "'" +
                        ",TenNCC = N'" + txtTenNCC.Text.Trim() + "'" +
                          ",SoPN = N'" + txtSoPN.Text.Trim() + "'" +
                      " where MaPN = N'" + txtMaPN.Text.Trim() + "'";
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

        //sub
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
                    DataRow row = ConnectSql.ds.Tables["ChiTietPN"].Rows[ClassApp.vt];
                    row.Delete();
                    int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["ChiTietPN"]);
                    if (rs > 0)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công!");
                        ConnectSql.XoaNoiDung(this.groupControl2);
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Xóa dữ liệu thất bại!");
                }

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Sub
            if (strFormState == "ADDING" && strMainState == "Turn off")
            {
                if (textEmptySub() == true)
                {
                    ShowAllTaiKhoan1();
                    double SL = double.Parse(txtSL.Text.Trim());
                    double DG = double.Parse(txtDG.Text.Trim());
                    DataRow row = ConnectSql.ds.Tables["ChiTietPN"].NewRow();
                    row["MaPN"] = txtMaPN.Text.Trim();
                    row["MaSo"] = ConnectSql.ds.Tables["ChiTietPN"].Rows.Count + 1;
                    row["MaMH"] = txtMahh.Text.Trim();
                    row["DVT"] = txtDonVitinh.Text.Trim();
                    row["SL_Nhap"] = txtSL.Text.Trim();
                    row["DG_Nhap"] = txtDG.Text.Trim();
                    row["ThanhTien"] = SL * DG;
                    try
                    {
                        ConnectSql.ds.Tables["ChiTietPN"].Rows.Add(row);
                        int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["PhieuNhap"]);
                        if (rs > 0)
                        {
                            MessageBox.Show("Thêm dữ liệu thành công!");

                            ConnectSql.XoaNoiDung(this.groupControl2);
                            btnDung.PerformClick();
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

                    }
                }
            }


            else if (strFormState == "EDITTING" && strMainState == "Turn off")
            {
                if (textEmptySub() == true)
                {
                    double SL = double.Parse(txtSL.Text.Trim());
                    double DG = double.Parse(txtDG.Text.Trim());
                    DataRow row = ConnectSql.ds.Tables["ChiTietPN"].Rows[ClassApp.vt];
                    row.BeginEdit();
                    row["MaPN"] = txtMaPN.Text.Trim();
                    row["MaMH"] = txtMahh.Text.Trim();
                    row["DVT"] = txtDonVitinh.Text.Trim();
                    row["SL_Nhap"] = txtSL.Text.Trim();
                    row["DG_Nhap"] = txtDG.Text.Trim();
                    row["ThanhTien"] = SL * DG;
                    row.EndEdit();
                    try
                    {

                        int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["ChiTietPN"]);
                        if (rs > 0)
                        {
                            MessageBox.Show("Chỉnh sửa liệu thành công!!");
                            ConnectSql.XoaNoiDung(this.groupControl2);
                            btnDung.PerformClick();
                        }

                        else
                        {
                           
                            MessageBox.Show("Chỉnh sửa dữ liệu thất bại!!");
                        }
                        ShowAllTaiKhoan();
                    }
                    catch (Exception)
                    {
                        throw;
                        MessageBox.Show("Trùng mã");
                        ShowAllTaiKhoan();

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

       
  

        //pos
        int x;
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

        private void btnCNgay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmNSL fr = new FrmNSL();
            fr.ShowDialog();
            FrmPNHH frm = new FrmPNHH();
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }
    

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //lấy dữ liệu cho reporrt 
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = ConnectSql.Con; //Gán kết nối
            string query = "select PhieuNhap.MaPN,SoPN,MaNV,TenNV,MaNCC,TenNCC,NgayNhap," +
                "ChiTietPN.MaSo, ChiTietPN.MaMH,ChiTietPN.SL_Nhap, ChiTietPN.DG_Nhap,ChiTietPN.DVT,ChiTietPN.ThanhTien, " +
                "MatHang.TenMH,  MatHang.MaMH " +
                "from PhieuNhap, ChiTietPN, MatHang where PhieuNhap.MaPN=ChiTietPN.MaPN " +
               " AND ChiTietPN.MaMH = MatHang.MaMH AND PhieuNhap.MaPN = @mapn";

            // cmd.Parameters.Clear();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@mapn", txtMaPN.Text);

            DataTable dt = new DataTable("BangPhieuNhap");
            dt.Load(cmd.ExecuteReader());
            RptPNHH baocao = new RptPNHH();
            baocao.SetDataSource(dt);
            FrmInPhieuNhapHH PN = new FrmInPhieuNhapHH();
            PN.ctprPNHH.ReportSource = baocao;
            PN.ShowDialog();
        }
        public static string MH;
        public static string DVT;
        public static string DG;
        public static string MaNVM;
        public static string TenNVM;
        public static string MaNCCB;
        public static string TenNCCB;
        private void txtMaNCC_KeyDown(object sender, KeyEventArgs e)
        {
            if (strFormState == "ADDING" && strMainState == "Turn on")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FrmTimKiemNCC frm = new FrmTimKiemNCC();
                    frm.ShowDialog();
                    txtMaNCC.Text = MaNCCB;
                    txtTenNCC.Text = TenNCCB;
                }
            }

            if (strFormState == "EDITTING" && strMainState == "Turn on")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FrmTimKiemNCC frm = new FrmTimKiemNCC();
                    frm.ShowDialog();
                    txtMaNCC.Text = MaNCCB;
                    txtTenNCC.Text = TenNCCB;
                }
            }
        }

        private void txtMaNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (strFormState == "ADDING" && strMainState == "Turn on")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FrmTimKiemNV frm = new FrmTimKiemNV();
                    frm.ShowDialog();
                    txtMaNV.Text = MaNVM;
                    txtTenNV.Text = TenNVM;
                }
            }

            if (strFormState == "EDITTING" && strMainState == "Turn on")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    FrmTimKiemNV frm = new FrmTimKiemNV();
                    frm.ShowDialog();
                    txtMaNV.Text = MaNVM;
                    txtTenNV.Text = TenNVM;
                }
            }
        }

        private void txtMahh_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (strFormState == "ADDING")
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

            if (strFormState == "EDITTING")
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

        private void FrmPNHH_Activated(object sender, EventArgs e)
        {
            ShowAllTaiKhoan();
            ClassApp.role = "Quản lý";
        }
    }

}