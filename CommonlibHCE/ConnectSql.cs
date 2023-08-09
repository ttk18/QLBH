using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using DevExpress.XtraEditors;



namespace CommonlibHCE
{
    public class ConnectSql
    {
        public static OleDbConnection connect = null;
        public static OleDbDataAdapter adapter1 = null;
        public static bool connectSERVERSQL(string Uname, string Upw)
        {
            string connectStr;
            bool succceed = false;
            //  connectStr = "Provider=SQLOLEDB;Data Source=DESKTOP-GEASNU8;Initial Catalog=DBAccounting;Persist Security Info=False;User ID=" + Uname + ";Password=" + Upw;
            connectStr = "Provider=SQLOLEDB;Data Source=SV12\\SQLEXPRESS;Initial Catalog=DBAccounting;Persist Security Info=False;User ID=" + Uname + ";Password=" + Upw;
            try
            {
                connect = new OleDbConnection(connectStr);
                connect.Open();
                succceed = true;
            }
            catch
            {
                String message = "Thông tin không chính xác"; string title = "Thông báo";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return succceed;
        }

        // Begin
        public static SqlConnection Con;  //Khai báo đối tượng kết nối       
        public static SqlDataAdapter adapter = null;
        public static DataSet ds = null;
        public static bool succceed = false;
        public static BindingSource bs = null;
        //public static string connstr = "Server=DESKTOP-GEASNU8;Database=DBAccounting;Integrated Security = True";
        public static bool Connect(string Uname, string Upw)
        {

           string connstr = "Server=DESKTOP-GEASNU8;Database=QLBanHang;;User ID=" + Uname + ";Password=" + Upw;
         //    string connstr = "Server=SV12\\SQLEXPRESS;Database=DBAccounting;;User ID=" + Uname + ";Password=" + Upw;
            try
            {
                Con = new SqlConnection(connstr);   //Khởi tạo đối tượng
                Con.Open();                  //Mở kết nối
                                             //Kiểm tra kết nối
                if (Con.State == ConnectionState.Open)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    succceed = true;
                }
            }
            catch (Exception)
            {
                String message = "Thông tin không chính xác"; string title = "Thông báo";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return succceed;
        }
        public static void Disconnect()
        {
            if (succceed == true)
            {
                Con.Close();   	//Đóng kết nối
                Con.Dispose(); 	//Giải phóng tài nguyên
                Con = null;
                succceed = false;
                MessageBox.Show("Đăng xuất thành công");
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập");
            }
                

        }
        //Lấy dữ liệu vào bảng
        public static DataTable GetDataToTable(string sql)
        {
            adapter = new SqlDataAdapter(sql, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static DataTable GetDataToTable1(string sql, string TABLE)
        {
            adapter = new SqlDataAdapter(sql, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.Fill(ds, TABLE);
            return ds.Tables[TABLE];


        }
        public static DataTable GetDataToTable2(string sql, string TABLE)
        {
            adapter1 = new OleDbDataAdapter(sql, connect);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter1);
            ds = new DataSet();
            adapter1.Fill(ds, TABLE);
            return ds.Tables[TABLE];
        }
        public static bool RunSql = true;
        public static void RunSQL(string sql)
        {
            SqlCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SqlCommand();
            cmd.Connection = Con; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
                //MessageBox.Show("Thành công");
                RunSql = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                RunSql = false;
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
        }

        public static void XoaNoiDung(Control ctrl)
        {
            if (ctrl is TextBox || ctrl is DateTimePicker || ctrl is DataGridView || ctrl is MaskedTextBox)
            {
                ctrl.Text = "";
            }
            foreach (Control i in ctrl.Controls)
            {
                XoaNoiDung(i);
            }
        }

     
        public static void LockControlValues(System.Windows.Forms.Control Container)
        {
            try
            {
                foreach (Control ctrl in Container.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                        ((TextBox)ctrl).Enabled = false;
                    if (ctrl.GetType() == typeof(MaskedTextBox))
                        ((MaskedTextBox)ctrl).Enabled = false;
                    if (ctrl.Controls.Count > 0)
                        LockControlValues(ctrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void UnLockControlValues(System.Windows.Forms.Control Container)
        {
            try
            {
                foreach (Control ctrl in Container.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                        ((TextBox)ctrl).Enabled = true;

                    if (ctrl.GetType() == typeof(MaskedTextBox))
                        ((MaskedTextBox)ctrl).Enabled = true;
                    if (ctrl.Controls.Count > 0)
                        UnLockControlValues(ctrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Use :LockControlValues(this)
        // End




        //Muc dinh ham ket noi voi CSDL SQL SERVER
        //INPUT
        //UNAME: Ten nguoi dung ket noi den sql server
        //UPW: mat khau ket noi den sql server
        //OUTPUT
        //TRUE: neu thanh cong
        //fasle: neu that bai





    }
}
