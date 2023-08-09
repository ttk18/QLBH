drop database QLBanHang
create database QLBanHang
-- su dung database
use QLBanHang;
SET DATEFORMAT dmy; 

-- tao bang

create table NhanVien
(
	MaNV nvarchar(20) not null,
	TenNV nvarchar(50),
	GioiTinh nvarchar(10),
	NgaySinh datetime,
	DiaChi nvarchar(100),
	DienThoai varchar(15),
	ChucVu nvarchar(15),
	constraint pk_NhanVien_MSNV primary key (MaNV)
);
go
create table KhachHang
(
	MaKH	nvarchar(20) not null,
	TenKH	nvarchar(50),
	DienThoai	varchar(15),
	ThanhVien	BIT,
	constraint pk_KhachHang_MSKH primary key (MaKH)
);
go
create table NhaCungCap
(
	MaNCC	nvarchar(20) not null,
	TenNCC	nvarchar(20) not null,
	DiaChi	nvarchar(100),
	TP_Tinh	nvarchar(30),
	DienThoai	varchar(15),
	constraint pk_NhaCungCap_MaNCC primary key (MaNCC)
);
go
create table MatHang
(
	MaMH	nvarchar(20),
	TenMH	nvarchar(50),
	NhomHang nvarchar(50),
	SL_Ton FLOAT,
	ThanhTien float,
	DVT	nvarchar(20),
	HSD	datetime,
	constraint pk_MatHang_MSMH primary key (MaMH)
);

go
create table HoaDon
(
	MaHD	nvarchar(20) not null,
	SoHD	varchar(10),
	MaNV	nvarchar(20) not null,
	TenNV	nvarchar(50),
	MaKH	nvarchar(20) not null,
	TenKH	nvarchar(50),
	NgayLapHD	datetime,
	constraint pk_HoaDon_MSHD primary key (MaHD),
	constraint fk_HoaDon_MSNV foreign key (MaNV) references NhanVien(MaNV),
	--constraint fk_HoaDon_MSKH foreign key (MaKH) references KhachHang(MaKH),
);
go
create table ChiTietHD
(
	MaHD	nvarchar(20) not null,
	MaSo	int,
	MaMH	nvarchar(20),
	SOLUONG	FLOAT,
	DonGia	float,
	DVT	nvarchar(20),
	ThanhTien float
	constraint pk_CT_HoaDon_MSHD primary key (MaHD,MaSo),
	constraint fk_ChiTietHD_MSHD foreign key (MaHD) references HoaDon(MaHD),
	constraint fk_ChiTietHD_MSMH foreign key (MaMH) references MatHang(MaMH)
);
go
create table PhieuNhap
(
	MaPN	nvarchar(20) not null,
	SoPN	varchar(10),
	MaNV	nvarchar(20) not null,
	TenNV	nvarchar(50),
	NgayNhap datetime,
	MaNCC	nvarchar(20) not null,
	TenNCC	nvarchar(50),
	constraint pk_PhieuNhap_MaPN primary key (MaPN),
	constraint fk_PhieuNhap_MSNV foreign key (MaNV) references NhanVien(MaNV),
	constraint fk_PhieuNhap_MaNCC foreign key (MaNCC) references NhaCungCap(MaNCC),
);
go
create table ChiTietPN
(
	MaPN	nvarchar(20) not null,
	MaSo	int,
	MaMH	nvarchar(20),
	SL_Nhap FLOAT,
	DG_Nhap	FLOAT,
	DVT	nvarchar(20),
	ThanhTien float
	constraint pk_ChiTietPN_MaPN primary key (MaPN,MaSo),
	constraint fk_ChiTietPN_MaPN foreign key (MaPN) references PhieuNhap(MaPN),
	constraint fk_ChiTietPN_HD_MaMH foreign key (MaMH) references MatHang(MaMH)
);
go
--- Them du lieu
Insert into KhachHang values('KH001',N' Nguyễn Thái Hòa',null,1);
Insert into KhachHang values('KH002',N' Nguyễn Kiên Viễn',null,1);
Insert into KhachHang values('KH003',N' Phạm Ngọc Lan','0933124456',1);
Insert into KhachHang values('KH004',N' Nguyễn Ngọc Anh Thư',NULL,1);
Insert into KhachHang values('KH005',N' Nguyễn Văn A','0918.123.123',1);
-- Them Bang Nhan Vien
set dateformat dmy;
select * from NhanVien where ChucVu = N'Nhân viên';

Insert into NhanVien values('NV001',N'Nguyễn Văn Bi',N'Nam','15/07/1979',N'16/11 Trần Hưng Đạo','0918299583',N'Nhân viên');
Insert into NhanVien values('NV002',N'Nguyễn Thị Na',N'Nữ','22/09/1980',N'250 Tô hiệu','0903923370',N'Nhân viên');
Insert into NhanVien values('NV003',N'Nguyễn Văn Bin',N'Nam','12/06/1979',N'16 Tô hiến Thành','',N'Nhân viên');
Insert into NhanVien values('NV004',N'Trần Văn Anh',N'Nam','12/06/1980',N'161 Gò xoài','',N'Nhân viên');
Insert into NhanVien values('NV005',N'Trần Thúy Trinh',N'Nữ','02/06/1981',N'Tây Ninh','',N'Nhân viên');
Insert into NhanVien values('NV006',N'Nguyễn Thị Kim Chi',N'Nữ','22/06/1980',N'Tiền Giang','',N'Quản lý');
--- Them bang Mat Hang
Insert into MatHang values('R0001',N'Ớt siêu cay',N'Rau củ',49,2000000,N'Gói','');
Insert into MatHang values('T0002',N'Bò CoBe',N'Thịt',49,1500000,N'Miếng','');
Insert into MatHang values('H0003',N'Đầu cá mập',N'Hải sản',49,2000000,N'Chiếc','');
Insert into MatHang values('T0001',N'Trứng cá sấu',N'Trứng',99,80000,N'Qủa','');
Insert into MatHang values('B0001',N'BING CHILL ING',N'Bing chilling',10,300000,N'Cây','');
Insert into MatHang values('B0001',N'Bánh Phồng Tôm',N'Bánh kẹo',0,56000,N'Gói','');
Insert into MatHang values('S0002',N'Sữa Vinamilk',N'Sữa',99,120000,N'Thùng','');

-- Them bang Nhà cung cấp
Insert into NhaCungCap values('NCC001',N' Trần Văn Hòa',N'305 Đại lộ 3',N'Hà Nội',null);
Insert into NhaCungCap values('NCC002',N' Nguyễn Ngọc Viễn',N'30 vườn chuối',N'Đồng Nai',null);
Insert into NhaCungCap values('NCC003',N' Phạm Ngọc Lan',N'11 Bùi Thị Xuân',N'Bình Dương','0933124456');
Insert into NhaCungCap values('NCC004',N' Nguyễn Ngọc Anh Thư',N'HCM',N'TP/HCM',null);
Insert into NhaCungCap values('NCC005',N' Nguyễn Hòa A',N'215 Điện Biên Phủ',N'Bình Thuận','0918.123.123');

/* cập nhật hàng trong kho sau khi đặt hàng hoặc cập nhật */
CREATE TRIGGER trg_HoaDonCT ON ChiTietHD AFTER INSERT AS 
BEGIN
	UPDATE MatHang
	SET SL_Ton = SL_Ton - (
		SELECT SOLUONG
		FROM inserted
		WHERE MaMH = MatHang.MaMH
	)
	FROM MatHang
	JOIN inserted ON MatHang.MaMH = inserted.MaMH
END
GO
/* cập nhật hàng trong kho sau khi cập nhật đặt hàng */
CREATE TRIGGER trg_CapNhatHoaDonCT on ChiTietHD after update AS
BEGIN
   UPDATE MatHang SET SL_Ton = SL_Ton -
	   (SELECT SOLUONG FROM inserted WHERE MaMH = MatHang.MaMH) +
	   (SELECT SOLUONG FROM deleted WHERE MaMH = MatHang.MaMH)
   FROM MatHang 
   JOIN deleted ON MatHang.MaMH = deleted.MaMH
end
GO
/* cập nhật hàng trong kho sau khi hủy đặt hàng */
create TRIGGER trg_HuyDatHang ON ChiTietHD FOR DELETE AS 
BEGIN
	UPDATE MatHang
	SET SL_Ton = SL_Ton + (SELECT SOLUONG FROM deleted WHERE MaMH = MatHang.MaMH)
	FROM MatHang 
	JOIN deleted ON MatHang.MaMH = deleted.MaMH
END



/* cập nhật hàng trong kho sau khi nhập hàng hoặc cập nhật */
CREATE TRIGGER trg_PhieuNhapCT ON ChiTietPN AFTER INSERT AS 
BEGIN
	UPDATE MatHang
	SET SL_Ton = SL_Ton + (
		SELECT SL_Nhap
		FROM inserted
		WHERE MaMH = MatHang.MaMH
	)
	FROM MatHang
	JOIN inserted ON MatHang.MaMH = inserted.MaMH
END
GO

/* cập nhật hàng trong kho sau khi cập nhật nhập hàng */
CREATE TRIGGER trg_CapNhatPhieuNhapCT on ChiTietPN after update AS
BEGIN
   UPDATE MatHang SET SL_Ton = SL_Ton +
	   (SELECT SL_Nhap FROM inserted WHERE MaMH = MatHang.MaMH) -
	   (SELECT SL_Nhap FROM deleted WHERE MaMH = MatHang.MaMH)
   FROM MatHang 
   JOIN deleted ON MatHang.MaMH = deleted.MaMH
end
GO
/* cập nhật hàng trong kho sau khi hủy nhập hàng */
create TRIGGER trg_HuyNhapHang ON ChiTietPN FOR DELETE AS 
BEGIN
	UPDATE MatHang
	SET SL_Ton = SL_Ton - (SELECT SL_Nhap FROM deleted WHERE MaMH = MatHang.MaMH)
	FROM MatHang 
	JOIN deleted ON MatHang.MaMH = deleted.MaMH
END




