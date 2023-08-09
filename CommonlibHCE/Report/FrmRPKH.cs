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
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace CommonlibHCE.Report
{
    public partial class FrmRPKH : DevExpress.XtraEditors.XtraForm
    {
        public FrmRPKH()
        {
            InitializeComponent();
        }

        private void FrmRPKH_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            try
            {
                FrmInDSKH frmInDSKH = new FrmInDSKH();
                SqlCommand cmd;
                cmd = new SqlCommand();
                cmd.Connection = ConnectSql.Con; //Gán kết nối
                string query = "select * from dbo.tDanhMucKhachHang where 1=1";
                if (ClassApp.manv != "")
                    query = query + " AND cMaKhachHang Like N'%" + ClassApp.manv + "%'";
                if (ClassApp.tenkh != "")
                    query = query + " AND cTenKhachhang Like N'%" + ClassApp.tenkh + "%'";
                if (ClassApp.ttp != "")
                    query = query + " AND cTinhThanhPho Like N'%" + ClassApp.ttp + "%'";
                cmd.CommandText = query;
                /*cmd.Parameters.AddWithValue("@ma", maNV);
                cmd.Parameters.AddWithValue("@ten", tenNV);
                cmd.Parameters.AddWithValue("@tP", tP);*/
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                reportViewer1.LocalReport.ReportEmbeddedResource = "CommonlibHCE.Report.RpKH.rdlc";
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";

                rds.Value = dt;
                reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
                ClassApp.tenkh = "";
                ClassApp.manv = "";
                ClassApp.ttp = "";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private string maNV = null;
        public string maNv
        {
            get { return maNV; }
            set { maNV = value; }
        }

        private string tenNV;
        public string TENNV
        {
            get { return tenNV; }
            set { tenNV = value; }
        }

        private string tP;
        public string TP
        {
            get { return tP; }
            set { tP = value; }
        }

        private string tutrang;
        private string dentrang;

        public string Between
        {
            get
            {
                return tutrang;
            }
            set
            {
                tutrang = value;
            }
        }
        public string And
        {
            get
            {
                return dentrang;
            }
            set
            {
                dentrang = value;
            }
        }

    }
}