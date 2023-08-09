namespace Acounting
{
    partial class MdiFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdiFrm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnDN = new DevExpress.XtraBars.BarButtonItem();
            this.btnTDMK = new DevExpress.XtraBars.BarButtonItem();
            this.btnNSL = new DevExpress.XtraBars.BarButtonItem();
            this.btnKH = new DevExpress.XtraBars.BarButtonItem();
            this.btnDX = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.btnTK = new DevExpress.XtraBars.BarButtonItem();
            this.btnHH = new DevExpress.XtraBars.BarButtonItem();
            this.btnKho = new DevExpress.XtraBars.BarButtonItem();
            this.barMdiChildrenListItem1 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.btnPhieuXuat = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhieuNhap = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhieuThu = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhieuChi = new DevExpress.XtraBars.BarButtonItem();
            this.btnThongKeDT = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnChiPhiNhapHang = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnDN,
            this.btnTDMK,
            this.btnNSL,
            this.btnKH,
            this.btnDX,
            this.btnThoat,
            this.btnTK,
            this.btnHH,
            this.btnKho,
            this.barMdiChildrenListItem1,
            this.btnPhieuXuat,
            this.btnPhieuNhap,
            this.btnPhieuThu,
            this.btnPhieuChi,
            this.btnThongKeDT,
            this.barButtonItem2,
            this.btnChiPhiNhapHang});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 20;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbon.Size = new System.Drawing.Size(850, 158);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnDN
            // 
            this.btnDN.Caption = "Đăng nhập";
            this.btnDN.Id = 1;
            this.btnDN.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDN.ImageOptions.Image")));
            this.btnDN.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDN.ImageOptions.LargeImage")));
            this.btnDN.Name = "btnDN";
            this.btnDN.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDN_ItemClick);
            // 
            // btnTDMK
            // 
            this.btnTDMK.Caption = "Thay đổi mật khẩu";
            this.btnTDMK.Id = 2;
            this.btnTDMK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTDMK.ImageOptions.Image")));
            this.btnTDMK.Name = "btnTDMK";
            this.btnTDMK.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnNSL
            // 
            this.btnNSL.Caption = "Chọn ngày đang số liệu";
            this.btnNSL.Id = 3;
            this.btnNSL.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNSL.ImageOptions.Image")));
            this.btnNSL.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNSL.ImageOptions.LargeImage")));
            this.btnNSL.Name = "btnNSL";
            this.btnNSL.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNSL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNSL_ItemClick);
            // 
            // btnKH
            // 
            this.btnKH.Caption = "Khách hàng";
            this.btnKH.Id = 5;
            this.btnKH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKH.ImageOptions.Image")));
            this.btnKH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKH.ImageOptions.LargeImage")));
            this.btnKH.Name = "btnKH";
            this.btnKH.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnKH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKH_ItemClick);
            // 
            // btnDX
            // 
            this.btnDX.Caption = "Đăng xuất";
            this.btnDX.Id = 6;
            this.btnDX.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDX.ImageOptions.Image")));
            this.btnDX.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDX.ImageOptions.LargeImage")));
            this.btnDX.Name = "btnDX";
            this.btnDX.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDX_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 7;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.LargeImage")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // btnTK
            // 
            this.btnTK.Caption = "Nhà cung cấp";
            this.btnTK.Id = 8;
            this.btnTK.ImageOptions.SvgImage = global::Acounting.Properties.Resources.bo_vendor;
            this.btnTK.Name = "btnTK";
            this.btnTK.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTK_ItemClick);
            // 
            // btnHH
            // 
            this.btnHH.Caption = "Hàng hóa";
            this.btnHH.Id = 9;
            this.btnHH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHH.ImageOptions.Image")));
            this.btnHH.Name = "btnHH";
            this.btnHH.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnHH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHH_ItemClick);
            // 
            // btnKho
            // 
            this.btnKho.Caption = "Nhân Viên";
            this.btnKho.Id = 10;
            this.btnKho.ImageOptions.SvgImage = global::Acounting.Properties.Resources.bo_lead;
            this.btnKho.Name = "btnKho";
            this.btnKho.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnKho.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKho_ItemClick);
            // 
            // barMdiChildrenListItem1
            // 
            this.barMdiChildrenListItem1.Caption = "barMdiChildrenListItem1";
            this.barMdiChildrenListItem1.Id = 12;
            this.barMdiChildrenListItem1.Name = "barMdiChildrenListItem1";
            // 
            // btnPhieuXuat
            // 
            this.btnPhieuXuat.Caption = "Hóa Đơn";
            this.btnPhieuXuat.Id = 13;
            this.btnPhieuXuat.ImageOptions.Image = global::Acounting.Properties.Resources.salesperiodyear_16x16;
            this.btnPhieuXuat.ImageOptions.LargeImage = global::Acounting.Properties.Resources.salesperiodyear_32x32;
            this.btnPhieuXuat.Name = "btnPhieuXuat";
            this.btnPhieuXuat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPhieuXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhieuXuat_ItemClick);
            // 
            // btnPhieuNhap
            // 
            this.btnPhieuNhap.Caption = "Phiếu nhập";
            this.btnPhieuNhap.Id = 14;
            this.btnPhieuNhap.ImageOptions.Image = global::Acounting.Properties.Resources.salesperiodmonth_16x16;
            this.btnPhieuNhap.ImageOptions.LargeImage = global::Acounting.Properties.Resources.salesperiodmonth_32x32;
            this.btnPhieuNhap.Name = "btnPhieuNhap";
            this.btnPhieuNhap.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPhieuNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhieuNhap_ItemClick);
            // 
            // btnPhieuThu
            // 
            this.btnPhieuThu.Caption = "Phiếu thu";
            this.btnPhieuThu.Id = 15;
            this.btnPhieuThu.ImageOptions.SvgImage = global::Acounting.Properties.Resources.purpledatabargradient;
            this.btnPhieuThu.Name = "btnPhieuThu";
            this.btnPhieuThu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnPhieuChi
            // 
            this.btnPhieuChi.Caption = "Phiếu chi";
            this.btnPhieuChi.Id = 16;
            this.btnPhieuChi.ImageOptions.SvgImage = global::Acounting.Properties.Resources.purpledatabarsolid;
            this.btnPhieuChi.Name = "btnPhieuChi";
            this.btnPhieuChi.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnThongKeDT
            // 
            this.btnThongKeDT.Caption = "Doanh thu bán hàng";
            this.btnThongKeDT.Id = 17;
            this.btnThongKeDT.ImageOptions.SvgImage = global::Acounting.Properties.Resources.chart;
            this.btnThongKeDT.Name = "btnThongKeDT";
            this.btnThongKeDT.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnThongKeDT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThongKeDT_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 18;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btnChiPhiNhapHang
            // 
            this.btnChiPhiNhapHang.Caption = "Chi phí nhập hàng";
            this.btnChiPhiNhapHang.Id = 19;
            this.btnChiPhiNhapHang.ImageOptions.SvgImage = global::Acounting.Properties.Resources.employeetasklist;
            this.btnChiPhiNhapHang.Name = "btnChiPhiNhapHang";
            this.btnChiPhiNhapHang.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChiPhiNhapHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChiPhiNhapHang_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Hệ thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDN, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnTDMK, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNSL, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDX, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnThoat, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Hệ thống";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Danh mục";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ribbonPageGroup2.ImageOptions.SvgImage")));
            this.ribbonPageGroup2.ItemLinks.Add(this.btnKH, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnTK, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnHH, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnKho, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Danh mục";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Chứng từ";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnPhieuNhap, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnPhieuXuat, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnPhieuThu, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnPhieuChi, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnThongKeDT, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnChiPhiNhapHang);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Chứng từ";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 438);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(850, 24);
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbon;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // MdiFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 462);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "MdiFrm";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Phần mềm quản lý bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MdiFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnDN;
        private DevExpress.XtraBars.BarButtonItem btnTDMK;
        private DevExpress.XtraBars.BarButtonItem btnNSL;
        private DevExpress.XtraBars.BarButtonItem btnKH;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem btnDX;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarButtonItem btnTK;
        private DevExpress.XtraBars.BarButtonItem btnHH;
        private DevExpress.XtraBars.BarButtonItem btnKho;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarMdiChildrenListItem barMdiChildrenListItem1;
        private DevExpress.XtraBars.BarButtonItem btnPhieuXuat;
        private DevExpress.XtraBars.BarButtonItem btnPhieuNhap;
        private DevExpress.XtraBars.BarButtonItem btnPhieuThu;
        private DevExpress.XtraBars.BarButtonItem btnPhieuChi;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnThongKeDT;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnChiPhiNhapHang;
    }
}