using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace CommonlibHCE
{
    class ClassApp
    {
        //khai báo thông số connection den dbo

        public static OleDbConnection WorkDB;
        public static OleDbConnection AdminworkDB;
        public static bool connected;
        public static string sqlStatement;
        public static bool Loginsucceeded;

        //khai báo thông số user
        public static string userole; //vai tro
        public static string usergroup; //nhom
        public static DateTime busdate; //ngaylamviec
        public static string userName; //id
        public static string userId; // login
        public static string userpw; // pw
        public static string MaXN; //ma congty
        public static string TenXN; //ten cty
        public static string userBirthday;
        public static string keypw; //ma hoa pw
        public static string mstrtext;

        //khai báo thông số chuong trinh ung dung duoi client
        public static string AppPath;
        public static string ReportPath;
        public static string settingReport; //thiet lap ket noi connection cua crystal Report

        //khai báo thông số  cac bien dung chung cho cac modul
        public static string tn;
        public static string dn;

        public static DateTime tu;
        public static DateTime den;

        //Report DMKH
        public static string manv;
        public static string tenkh;
        public static string ttp;

        //Tìm kiếm KH
        public static int vt = -1;
        public static string role;

    }
}
