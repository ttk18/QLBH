using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using CommonlibHCE;
using System.Data.SqlClient;

namespace Acounting
{
    public partial class MdiFrm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MdiFrm()
        {
            InitializeComponent();
        }
        void openFrm(Type typeForm)
        {
            foreach (var frm in MdiChildren)
            {
                if (frm.GetType()==typeForm)
                {
                    frm.Activate();
                    return;
                }
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent = this;
            f.Show();

        }
        
        private void btnDN_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            if (ConnectSql.succceed == false)
            {
                FrmLG frm = new FrmLG();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Bạn đã đăng nhập");
           
            

        }

        private void MdiFrm_Load(object sender, EventArgs e)
        {

        }

        private void btnKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ConnectSql.succceed == false)
            {
                DialogResult result = MessageBox.Show("Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    FrmLG frm = new FrmLG();
                    frm.ShowDialog();
                    
                }
            }
            else
            {
                openFrm(typeof(FrmDMKH));
            }
        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình không", "Thoát", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnHH_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ConnectSql.succceed == false)
            {
                DialogResult result = MessageBox.Show("Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    FrmLG frm = new FrmLG();
                    frm.ShowDialog();

                }
            }
            else
            {
                openFrm(typeof(FrmDMHH));
            }
        }

        private void btnNSL_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (ConnectSql.succceed == false)
            {
                DialogResult result = MessageBox.Show("Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    FrmLG frm = new FrmLG();
                    frm.ShowDialog();

                }
            }
            else
            {
                FrmNSL frm = new FrmNSL();
                frm.ShowDialog();
            }
           
        }

        private void btnDX_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn đăng xuất", "Thông báo", MessageBoxButtons.OKCancel,
                 MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                ConnectSql.Disconnect();
                ConnectSql.succceed = false;
            }
        }

        private void btnTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ConnectSql.succceed == false)
            {
                DialogResult result = MessageBox.Show("Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    FrmLG frm = new FrmLG();
                    frm.ShowDialog();

                }
            }
            else
            {
                openFrm(typeof(FrmDMNCC));
            }
        }

        private void btnKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ConnectSql.succceed == false)
            {
                DialogResult result = MessageBox.Show("Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    FrmLG frm = new FrmLG();
                    frm.ShowDialog();

                }
            }
            else
            {
                openFrm(typeof(FrmNhanVien));
            }
        }

        private void btnPhieuNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ConnectSql.succceed == false)
            {
                DialogResult result = MessageBox.Show("Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    FrmLG frm = new FrmLG();
                    frm.ShowDialog();

                }
            }
            else
            {
                openFrm(typeof(FrmPNHH));
            }
        }

        private void btnPhieuXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ConnectSql.succceed == false)
            {
                DialogResult result = MessageBox.Show("Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    FrmLG frm = new FrmLG();
                    frm.ShowDialog();

                }
            }
            else
            {
                openFrm(typeof(FrmHoaDon));
            }
        }

        private void btnThongKeDT_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ConnectSql.succceed == false)
            {
                DialogResult result = MessageBox.Show("Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    FrmLG frm = new FrmLG();
                    frm.ShowDialog();

                }
            }
            else
            {
                //lấy dữ liệu cho reporrt 
                SqlCommand cmd;
                cmd = new SqlCommand();
                cmd.Connection = ConnectSql.Con; //Gán kết nối
                string query = "select ChiTietHD.MaHD, ChiTietHD.MaMH , "
                    +"ChiTietHD.SOLUONG, ChiTietHD.DonGia , ChiTietHD.DVT,"+
                    "ChiTietHD.ThanhTien,MatHang.TenMH from ChiTietHD,"+
                    " MatHang where ChiTietHD.MaMH = MatHang.MaMH";

                // cmd.Parameters.Clear();
                cmd.CommandText = query;
                // cmd.Parameters.AddWithValue("@mapn", txtMaPN.Text);

                DataTable dt = new DataTable("BangDoanhThu");
                dt.Load(cmd.ExecuteReader());
                RptDoanhThu baocao = new RptDoanhThu();
                baocao.SetDataSource(dt);
                FrmInDThu DT = new FrmInDThu();
                DT.crtrpInDoanhThu.ReportSource = baocao;
                DT.ShowDialog();
            }
           
        }

        private void btnChiPhiNhapHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ConnectSql.succceed == false)
            {
                DialogResult result = MessageBox.Show("Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    FrmLG frm = new FrmLG();
                    frm.ShowDialog();

                }
            }
            else
            {
                //lấy dữ liệu cho reporrt 
                SqlCommand cmd;
                cmd = new SqlCommand();
                cmd.Connection = ConnectSql.Con; //Gán kết nối
                string query = "select ChiTietPN.MaPN, ChiTietPN.MaMH , "
                    + "ChiTietPN.SL_Nhap, ChiTietPN.DG_Nhap , ChiTietPN.DVT," +
                    "ChiTietPN.ThanhTien,MatHang.TenMH from ChiTietPN," +
                    " MatHang where ChiTietPN.MaMH = MatHang.MaMH";

                // cmd.Parameters.Clear();
                cmd.CommandText = query;
                // cmd.Parameters.AddWithValue("@mapn", txtMaPN.Text);

                DataTable dt = new DataTable("BangChiPhi");
                dt.Load(cmd.ExecuteReader());
                RptCpNH baocao = new RptCpNH();
                baocao.SetDataSource(dt);
                FrmInChiPhiNH DT = new FrmInChiPhiNH();
                DT.crpinChiPhi.ReportSource = baocao;
                DT.ShowDialog();
            }
        }
    }
}