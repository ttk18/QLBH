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
    public partial class FrmDMHH : DevExpress.XtraEditors.XtraForm
    {
        public FrmDMHH()
        {
            InitializeComponent();
        }
        public static int index = -1;
        public static int x;
        static string strFormState;
        public static string value = null;
        private void FrmHH_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnDung.Enabled = false;
            btnAnTT.Enabled = false;
           
            LoadData();
            strFormState = "NORMAL";
            splitContainer1.Panel1Collapsed = true;
        }
        private void LoadData()
        {
            string query = "select * from MatHang";
            ConnectSql.GetDataToTable1(query, "MatHang");
            dgvHH.DataSource = ConnectSql.ds.Tables["MatHang"];
            ChangColumn();
        }
     
        private void AnTT()
        {
            if (splitContainer1.Panel1Collapsed == false)
            {
                btnAnTT.Enabled = true;
            }

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
                DataRow row = ConnectSql.ds.Tables["MatHang"].Rows[ClassApp.vt];
                row.Delete();
                int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["MatHang"]);
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
            float sl;
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
            else { errorProvider1.Clear(); }
            if (txtHSD.Text == maskedTextBox1.Text)
            {
                errorProvider1.SetError(txtHSD, "Yêu cầu nhập");
                return false;
            }
            else { errorProvider1.Clear(); }
            return true;
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            if (strFormState == "ADDING" && textEmpty())
            {
               
                string HSD;
                HSD = Convert.ToDateTime(txtHSD.Text).ToString("yyyy-MM-dd");
                DataRow row = ConnectSql.ds.Tables["MatHang"].NewRow();
                row["MaMH"] = txtnh.Text.Trim().Substring(0,1) + (ConnectSql.ds.Tables["MatHang"].Rows.Count + 1).ToString("D4");
                row["TenMH"] = txtTenhh.Text.Trim();
                row["NhomHang"] = txtnh.Text.Trim();
                row["DVT"] = txtdvt.Text.Trim();
                row["SL_Ton"] = txtSltd.Text.Trim();
                row["ThanhTien"] = txtTttd.Text.Trim();
                row["HSD"] = HSD;
                try
                {
                    ConnectSql.ds.Tables["MatHang"].Rows.Add(row);
                    int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["MatHang"]);
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
                    MessageBox.Show("Trùng mã hàng hóa");
                    LoadData();

                }
            }
            else if (strFormState == "EDITTING" && textEmpty())
            {
                DataRow row = ConnectSql.ds.Tables["MatHang"].Rows[ClassApp.vt];
                row.BeginEdit();
                string HSD;
                HSD = Convert.ToDateTime(txtHSD.Text).ToString("yyyy-MM-dd");
                row["MaMH"] = txtMahh.Text.Trim();
                row["TenMH"] = txtTenhh.Text.Trim();
                row["NhomHang"] = txtnh.Text.Trim();
                row["DVT"] = txtdvt.Text.Trim();
                row["SL_Ton"] = txtSltd.Text.Trim();
                row["ThanhTien"] = txtTttd.Text.Trim();
                row["HSD"] = HSD;

                row.EndEdit();
                try
                {

                    int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["MatHang"]);
                    if (rs > 0)
                    {
                        MessageBox.Show("Chỉnh sửa liệu thành công!!");
                        ConnectSql.XoaNoiDung(this);
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
                    MessageBox.Show("Trùng mã hàng hóa");
                    LoadData();

                }
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
            DataRow row = ConnectSql.ds.Tables["MatHang"].Rows[ClassApp.vt];
            txtMahh.Text = row["MaMH"].ToString();
            txtTenhh.Text = row["TenMH"].ToString();
            txtnh.Text = row["NhomHang"].ToString();
            txtdvt.Text = row["DVT"].ToString();
            txtSltd.Text = row["SL_Ton"].ToString();
            txtTttd.Text = row["ThanhTien"].ToString();
            dgvHH.Rows[ClassApp.vt].Selected = true;
            txtHSD.Text = row["HSD"].ToString();
        }
        private void btnSQL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTimKiemHH frm = new FrmTimKiemHH();
            frm.ShowDialog();
            splitContainer1.Panel1Collapsed = false;
            if (index > -1)
            {
                dgvHH.Rows[index].Cells[0].Selected = true;
                while (dgvHH.Rows[x].Cells[0].Value.ToString() != value)
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

        private void dgvHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            btnAnTT.Enabled = true;
            try
            {
                ClassApp.vt = e.RowIndex;
                if (ClassApp.vt == -1 || ClassApp.vt == ConnectSql.ds.Tables["MatHang"].Rows.Count) return;
                DataRow row = ConnectSql.ds.Tables["MatHang"].Rows[ClassApp.vt];
                txtMahh.Text = row["MaMH"].ToString();
                txtTenhh.Text = row["TenMH"].ToString();
                txtnh.Text = row["NhomHang"].ToString();
                txtdvt.Text = row["DVT"].ToString();
                txtSltd.Text = row["SL_Ton"].ToString();
                txtTttd.Text = row["ThanhTien"].ToString();
                txtHSD.Text = row["HSD"].ToString();
            }
            catch (Exception)
            {
                return;
            }
         
           
        }

        private void btnAnTT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            btnAnTT.Enabled = false;
        }

        private void dgvHH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FrmDMHH_Activated(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}