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
    public partial class FrmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        public static int index = -1;
        public static int x;
        static string strFormState;
        public static string value = null;
        private void FrmNhanVien_Activated(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnDung.Enabled = false;
            btnAnTT.Enabled = false;

            LoadData();
            strFormState = "NORMAL";
            splitContainer1.Panel1Collapsed = true;
        }

        private void AnTT()
        {
            if (splitContainer1.Panel1Collapsed == false)
            {
                btnAnTT.Enabled = true;
            }

        }
        private void LoadData()
        {
            string query = "select * from NhanVien";
            ConnectSql.GetDataToTable1(query, "NhanVien");
            dgvNV.DataSource = ConnectSql.ds.Tables["NhanVien"];
            ChangColumn();
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
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;

            btnThoat.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnIn.Enabled = false;
            btnXoa.Enabled = false;
            strFormState = "ADDING";

            btnLuu.Enabled = true;
            btnDung.Enabled = true;
            //   btnAnTT.Enabled = true;
            ConnectSql.XoaNoiDung(groupControl1);
            AnTT();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult warn = MessageBox.Show("Are you sure ?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (warn == DialogResult.Yes)
            {
                DataRow row = ConnectSql.ds.Tables["NhanVien"].Rows[ClassApp.vt];
                row.Delete();
                int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["NhanVien"]);
                if (rs > 0)
                {
                    MessageBox.Show("Xóa dữ liệu thành công!");
                    ConnectSql.XoaNoiDung(this);
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu thất bại!");
                }
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThoat.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnIn.Enabled = false;
            btnXoa.Enabled = false;
            strFormState = "EDITTING";

            btnLuu.Enabled = true;
            btnDung.Enabled = true;
            AnTT();
        }
        private bool textEmpty()
        {
            /* float sl;
             float tt;

             if (!float.TryParse(txtSltd.Text, out sl))
             {
                 errorProvider1.SetError(txtSltd, "Số lượng phải là số");
                 return false;
             }
             else { errorProvider1.Clear(); }
             if (!float.TryParse(txtTttd.Text, out tt))
             {
                 errorProvider1.SetError(txtTttd, "Thành tiền phải là số");
                 return false;
             }
             else { errorProvider1.Clear(); }*/
            if (txtNgaySinh.Text == maskedTextBox1.Text)
            {
                errorProvider1.SetError(txtNgaySinh, "Yêu cầu nhập");
                return false;
            }
            else { errorProvider1.Clear(); }
            return true;
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (strFormState == "ADDING" && textEmpty())
            {

                string NS;
                NS = Convert.ToDateTime(txtNgaySinh.Text).ToString("yyyy-MM-dd");
                DataRow row = ConnectSql.ds.Tables["NhanVien"].NewRow();
                row["MaNV"] = "NV" + (ConnectSql.ds.Tables["NhanVien"].Rows.Count + 1).ToString("D4");
                row["TenNV"] = txtTenNV.Text.Trim();
                row["GioiTinh"] = txtGT.Text.Trim();
                row["ChucVu"] = txtCV.Text.Trim();
                row["DiaChi"] = txtDC.Text.Trim();
                row["DienThoai"] = txtSDT.Text.Trim();
                row["NgaySinh"] = NS;
                try
                {
                    ConnectSql.ds.Tables["NhanVien"].Rows.Add(row);
                    int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["NhanVien"]);
                    if (rs > 0)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công!");
                        ConnectSql.XoaNoiDung(this);
                        btnDung.PerformClick();
                    }

                    else
                    {
                        MessageBox.Show("Thêm dữ liệu thất bại!");
                    }
                    LoadData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Trùng mã nhân viên");
                    LoadData();

                }
            }
            else if (strFormState == "EDITTING" && textEmpty())
            {
                DataRow row = ConnectSql.ds.Tables["NhanVien"].Rows[ClassApp.vt];
                row.BeginEdit();
                string NS;
                NS = Convert.ToDateTime(txtNgaySinh.Text).ToString("yyyy-MM-dd");
                row["MaNV"] = txtMaNV.Text.Trim();
                row["TenNV"] = txtTenNV.Text.Trim();
                row["GioiTinh"] = txtGT.Text.Trim();
                row["ChucVu"] = txtCV.Text.Trim();
                row["DiaChi"] = txtDC.Text.Trim();
                row["DienThoai"] = txtSDT.Text.Trim();
                row["NgaySinh"] = NS;

                row.EndEdit();
                try
                {

                    int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["NhanVien"]);
                    if (rs > 0)
                    {
                        MessageBox.Show("Chỉnh sửa liệu thành công!!");
                       
                        btnDung.PerformClick();
                    }

                    else
                    {
                        MessageBox.Show("Chỉnh sửa dữ liệu thất bại!i!");
                    }
                    LoadData();
                }
                catch (Exception)
                {
                    /* MessageBox.Show("Trùng mã nhân viên");
                     LoadData();*/
                    throw;

                }
               // ConnectSql.XoaNoiDung(this);
            }
        } 

        private void btnDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            errorProvider1.Clear();
            btnThoat.Enabled = true;
            btnDung.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnIn.Enabled = true;
            btnXoa.Enabled = true;
            btnSQL.Enabled = true;
            btnLuu.Enabled = false;
        }
        private void textboxLoad()
        {
            ClassApp.vt = index;
            DataRow row = ConnectSql.ds.Tables["NhanVien"].Rows[ClassApp.vt];
            txtMaNV.Text = row["MaNV"].ToString();
            txtTenNV.Text = row["TenNV"].ToString();
            txtGT.Text = row["GioiTinh"].ToString();
            txtDC.Text = row["DiaChi"].ToString();
            txtSDT.Text = row["DienThoai"].ToString();
            txtCV.Text = row["ChucVu"].ToString();
            txtNgaySinh.Text = row["NgaySinh"].ToString();

            dgvNV.Rows[ClassApp.vt].Selected = true;
        }
        private void btnSQL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTimKiemNV frm = new FrmTimKiemNV();
            frm.ShowDialog();
            splitContainer1.Panel1Collapsed = false;
            if (index > -1)
            {
                dgvNV.Rows[index].Cells[0].Selected = true;
                while (dgvNV.Rows[x].Cells[0].Value.ToString() != value)
                {
                    x++;
                }
                {
                    index = x;
                    textboxLoad();
                }
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmLocKH frm = new FrmLocKH();
            frm.ShowDialog();
        }

        private void btnAnTT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            btnAnTT.Enabled = false;
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ClassApp.vt = e.RowIndex;
                if (ClassApp.vt == -1 || ClassApp.vt == ConnectSql.ds.Tables["NhanVien"].Rows.Count) return;
                DataRow row = ConnectSql.ds.Tables["NhanVien"].Rows[ClassApp.vt];
                txtMaNV.Text = row["MaNV"].ToString();
                txtTenNV.Text = row["TenNV"].ToString();
                txtGT.Text = row["GioiTinh"].ToString();
                txtDC.Text = row["DiaChi"].ToString();
                txtSDT.Text = row["DienThoai"].ToString();
                txtCV.Text = row["ChucVu"].ToString();
                txtNgaySinh.Text = row["NgaySinh"].ToString();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void dgvNV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            btnAnTT.Enabled = true;
        }
    }
}