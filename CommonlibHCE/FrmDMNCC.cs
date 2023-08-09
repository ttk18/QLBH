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
    public partial class FrmDMNCC : DevExpress.XtraEditors.XtraForm
    {
        public FrmDMNCC()
        {
            InitializeComponent();
        }
        static string strFormState;
        private void FrmDMTK_Load(object sender, EventArgs e)
        {
          
            splitContainer1.Panel1Collapsed = true;
            btnLuu.Enabled = false;
            btnDung.Enabled = false;
            btnAnTT.Enabled = false;
            LoadData();
            strFormState = "NORMAL";
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
        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            btnAnTT.Enabled = true;
            try
            {
            ClassApp.vt = e.RowIndex;
                
            if (ClassApp.vt == -1 || ClassApp.vt == ConnectSql.ds.Tables["NhaCungCap"].Rows.Count) return;
              
            DataRow row = ConnectSql.ds.Tables["NhaCungCap"].Rows[ClassApp.vt];
            txtMaNcc.Text = row["MaNCC"].ToString();
            txtTenNcc.Text = row["TenNCC"].ToString();
            txtDC.Text = row["DiaChi"].ToString();
            txtTTP.Text = row["TP_Tinh"].ToString();
            txtDC.Text = row["DienThoai"].ToString();
          
            }
            catch (Exception)
            {
             
                return;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConnectSql.XoaNoiDung(groupControl1);
            btnSQL.Enabled = false;
            btnThoat.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnIn.Enabled = false;
            btnXoa.Enabled = false;
            btnSQL.Enabled = false;
            strFormState = "ADDING";

            btnLuu.Enabled = true;
            btnDung.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult warn = MessageBox.Show("Are you sure ?", "Warning!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (warn == DialogResult.Yes)
            {
                DataRow row = ConnectSql.ds.Tables["NhaCungCap"].Rows[ClassApp.vt];
                row.Delete();
                int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["NhaCungCap"]);
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
            btnSQL.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnIn.Enabled = false;
            btnXoa.Enabled = false;
            btnSQL.Enabled = false;
            strFormState = "EDITTING";

            btnLuu.Enabled = true;
            btnDung.Enabled = true;
        }
        private bool textEmpty()
        {
            float SDND;
            float SDCD;
            /* if (txtMaNcc.Text == "") { errorProvider1.SetError(txtMaNcc, "Yêu cầu nhập"); return false; }
             else { errorProvider1.Clear(); }
             if (!float.TryParse(txtSdnd.Text, out SDND))
             {
                 errorProvider1.SetError(txtSdnd, "Số lượng phải là số");
                 return false;
             }
             else { errorProvider1.Clear(); }
             if (!float.TryParse(txtDC.Text, out SDCD))
             {
                 errorProvider1.SetError(txtDC, "Thành tiền phải là số");
                 return false;
             }
             else { errorProvider1.Clear(); }
             if (txtNsd.Text == maskedTextBox1.Text)
             {
                 errorProvider1.SetError(txtNsd, "Yêu cầu nhập");
                 return false;
             }
             else { errorProvider1.Clear(); }*/
            return true;
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (strFormState == "ADDING" && textEmpty())
            {
                DataRow row = ConnectSql.ds.Tables["NhaCungCap"].NewRow();
                row["MaNCC"] = "NCC" + (ConnectSql.ds.Tables["NhaCungCap"].Rows.Count + 1).ToString("D3");
                row["TenNCC"] = txtTenNcc.Text.Trim();
                row["DiaChi"] = txtDC.Text.Trim();
                row["TP_Tinh"] = txtTTP.Text.Trim();
                row["DienThoai"] = txtDT.Text.Trim();

                try
                {
                    ConnectSql.ds.Tables["NhaCungCap"].Rows.Add(row);
                    int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["NhaCungCap"]);
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
                    MessageBox.Show("Trùng mã nhà cung cấp");
                    LoadData();

                }
            }
            else if (strFormState == "EDITTING" && textEmpty())
            {
               
                DataRow row = ConnectSql.ds.Tables["NhaCungCap"].Rows[ClassApp.vt];
                row.BeginEdit();
                row["MaNCC"] = txtMaNcc.Text.Trim();
                row["TenNCC"] = txtTenNcc.Text.Trim();
                row["DiaChi"] = txtDC.Text.Trim();
                row["TP_Tinh"] = txtTTP.Text.Trim();
                row["DienThoai"] = txtDT.Text.Trim();
                row.EndEdit();
                try
                {

                    int rs = ConnectSql.adapter.Update(ConnectSql.ds.Tables["NhaCungCap"]);
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
                    MessageBox.Show("Trùng mã nhà cung cấp");
                    LoadData();

                }
            }
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmLocKH frm = new FrmLocKH();
            frm.ShowDialog();
        }

        private void dgvKT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnAnTT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            btnAnTT.Enabled = false;
        }
        public static int x;
        public static int index = -1;
        public static string value = null;
        private void textboxLoad()
        {
            ClassApp.vt = index;
            DataRow row = ConnectSql.ds.Tables["NhaCungCap"].Rows[ClassApp.vt];
            txtMaNcc.Text = row["MaNCC"].ToString();
            txtTenNcc.Text = row["TenNCC"].ToString();
            txtDC.Text = row["DiaChi"].ToString();
            txtTTP.Text = row["TP_Tinh"].ToString();
            txtDC.Text = row["DienThoai"].ToString();
            dgvNCC.Rows[ClassApp.vt].Selected = true;
        }
        private void btnSQL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTimKiemNCC frm = new FrmTimKiemNCC();
            frm.ShowDialog();
            splitContainer1.Panel1Collapsed = false;
            if (index > -1)
            {
                dgvNCC.Rows[index].Cells[0].Selected = true;
                while (dgvNCC.Rows[x].Cells[0].Value.ToString() != value)
                {
                    x++;
                }
                {
                    index = x;
                    textboxLoad();
                }
            }
        }

        private void FrmDMNCC_Activated(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}