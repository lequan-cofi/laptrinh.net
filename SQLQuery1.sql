-- Bảng Khách hàng
CREATE TABLE [KhachHang] (
	MaKhach VARCHAR(20) NOT NULL PRIMARY KEY,
	TenKhach NVARCHAR(100) NOT NULL,
	GioiTinh NVARCHAR(10) Not Null,
	DiaChi NVARCHAR(200) NOT NULL,
	DienThoai VARCHAR(15) NOT NULL
);
GO

-- Bảng Công việc
CREATE TABLE [CongViec] (
	MaCv VARCHAR(20) NOT NULL PRIMARY KEY,
	TenCongViec NVARCHAR(100) NOT NULL
);
GO

-- Bảng Nhà cung cấp
CREATE TABLE [NhaCungCap] (
	MaNCC VARCHAR(20) NOT NULL PRIMARY KEY,
	TenNhaCungCap NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(200) NOT NULL,
	DienThoai VARCHAR(15) NOT NULL
);
GO

-- Bảng Ngôn ngữ
CREATE TABLE [NgonNgu] (
	MaNgonNgu VARCHAR(20) NOT NULL PRIMARY KEY,
	TenNgonNgu NVARCHAR(100) NOT NULL
);
GO

-- Bảng Nhà xuất bản
CREATE TABLE [NhaXuatBan] (
	MaNXB VARCHAR(20) NOT NULL PRIMARY KEY,
	TenNXB NVARCHAR(100) NOT NULL,
	SDT CHAR(10) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(200) NOT NULL
);
GO

-- Bảng Loại sách
CREATE TABLE [LoaiSach] (
	MaLoaiSach VARCHAR(20) NOT NULL PRIMARY KEY,
	TenLoai NVARCHAR(100) NOT NULL
);
GO

-- Bảng Tác giả
CREATE TABLE [TacGia] (
	MaTacGia VARCHAR(20) NOT NULL PRIMARY KEY,
	TenTacGia NVARCHAR(100) NOT NULL,
	NgaySinh DATE NOT NULL,
	GioiTinh NVARCHAR(10) NOT NULL,
	DiaChi NVARCHAR(200) NOT NULL
);
GO

-- Bảng Lĩnh vực
CREATE TABLE [LinhVuc] (
	MaLinhVuc VARCHAR(20) NOT NULL PRIMARY KEY,
	TenLinhVuc NVARCHAR(100) NOT NULL
);
GO

-- Bảng Kho sách
CREATE TABLE [KhoSach] (
	MaSach VARCHAR(20) NOT NULL PRIMARY KEY,
	TenSach NVARCHAR(100) NOT NULL,
	SoLuong INT NOT NULL,
	DonGiaNhap VARCHAR(20) NOT NULL,
	DonGiaBan VARCHAR(20) NOT NULL,
	MaLoaiSach VARCHAR(20) NOT NULL,
	MaTacGia VARCHAR(20) NOT NULL,
	MaNXB VARCHAR(20) NOT NULL,
	MaLinhVuc VARCHAR(20) NOT NULL,
	MaNgonNgu VARCHAR(20) NOT NULL,
	Anh VARCHAR(200) NOT NULL,
	SoTrang INT NOT NULL
);
GO

-- Chỉ mục cho Kho sách
CREATE INDEX IX_KhoSach_MaSach ON KhoSach(MaSach);
GO

-- Bảng Mất sách
CREATE TABLE [MatSach] (
	MaLanMat INT IDENTITY PRIMARY KEY,
	MaSach VARCHAR(20) NOT NULL,
	SLMat INT NOT NULL,
	NgayMat DATE NOT NULL
);
GO

CREATE INDEX IX_MatSach_MaSach ON MatSach(MaSach);
GO

-- Bảng Nhân viên
CREATE TABLE [NhanVien] (
	MaNhanVien VARCHAR(20) NOT NULL PRIMARY KEY,
	TenNhanVien NVARCHAR(100) NOT NULL,
	DienThoai VARCHAR(15) NOT NULL,
	DiaChi NVARCHAR(200) NOT NULL,
	MaCv VARCHAR(20) NOT NULL
);
GO

-- Bảng Hóa đơn nhập
CREATE TABLE [HoaDonNhap] (
	SoHDNhap VARCHAR(20) NOT NULL PRIMARY KEY,
	MaNhanVien VARCHAR(20) NOT NULL,
	NgayNhap DATE NOT NULL,
	MaNCC VARCHAR(20) NOT NULL,
	TongTien FLOAT NOT NULL
);
GO

-- Bảng Chi tiết hóa đơn nhập
CREATE TABLE [ChiTietHDNhap] (
	SoHDNhap VARCHAR(20) NOT NULL,
	MaSach VARCHAR(20) NOT NULL,
	SLNhap INT NOT NULL,
	DonGiaNhap FLOAT NOT NULL,
	KhuyenMai FLOAT NOT NULL,
	ThanhTien FLOAT NOT NULL,
	PRIMARY KEY (SoHDNhap, MaSach)
);
GO

-- Bảng Hóa đơn bán
CREATE TABLE [HoaDonBan] (
	SoHDBan VARCHAR(20) NOT NULL PRIMARY KEY,
	MaNhanVien VARCHAR(20) NOT NULL,
	NgayBan DATE NOT NULL,
	MaKhach VARCHAR(20) NOT NULL,
	TongTien FLOAT NOT NULL
);
GO

-- Bảng Chi tiết hóa đơn bán
CREATE TABLE [ChiTietHDBan] (
	SoHDBan VARCHAR(20) NOT NULL,
	MaSach VARCHAR(20) NOT NULL,
	SLBan INT NOT NULL,
	KhuyenMai FLOAT NOT NULL,
	ThanhTien FLOAT NOT NULL,
	PRIMARY KEY (SoHDBan, MaSach)
);
GO

-- RÀNG BUỘC KHOÁ NGOẠI
ALTER TABLE KhoSach
	ADD FOREIGN KEY (MaLoaiSach) REFERENCES LoaiSach(MaLoaiSach),
		FOREIGN KEY (MaTacGia) REFERENCES TacGia(MaTacGia),
		FOREIGN KEY (MaNXB) REFERENCES NhaXuatBan(MaNXB),
		FOREIGN KEY (MaLinhVuc) REFERENCES LinhVuc(MaLinhVuc),
		FOREIGN KEY (MaNgonNgu) REFERENCES NgonNgu(MaNgonNgu);
GO

ALTER TABLE MatSach
	ADD FOREIGN KEY (MaSach) REFERENCES KhoSach(MaSach);
GO

ALTER TABLE NhanVien
	ADD FOREIGN KEY (MaCv) REFERENCES CongViec(MaCv);
GO

ALTER TABLE HoaDonNhap
	ADD FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
		FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC);
GO

ALTER TABLE ChiTietHDNhap
	ADD FOREIGN KEY (SoHDNhap) REFERENCES HoaDonNhap(SoHDNhap),
		FOREIGN KEY (MaSach) REFERENCES KhoSach(MaSach);
GO

ALTER TABLE HoaDonBan
	ADD FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
		FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach);
GO

ALTER TABLE ChiTietHDBan
	ADD FOREIGN KEY (SoHDBan) REFERENCES HoaDonBan(SoHDBan),
		FOREIGN KEY (MaSach) REFERENCES KhoSach(MaSach);
GO
INSERT INTO KhachHang VALUES
('KH01', N'Nguyễn Văn A', N'Nam', N'Hà Nội', '0912345678'),
('KH02', N'Trần Thị B',N'Nữ', N'Hải Phòng', '0923456789'),
('KH03', N'Lê Văn C', N'Nam', N'Nam Định', '0934567890'),
('KH04', N'Phạm Thị D',N'Nữ', N'HCM', '0945678901'),
('KH05', N'Hoàng Văn E', N'Nam', N'Cần Thơ', '0956789012'),
('KH06', N'Ngô Thị F',N'Nữ', N'Đà Nẵng', '0967890123'),
('KH07', N'Đỗ Văn G', N'Nam', N'Hà Nam', '0978901234'),
('KH08', N'Bùi Thị H',N'Nữ', N'Ninh Bình', '0989012345'),
('KH09', N'Phan Văn I', N'Nam', N'Hà Tĩnh', '0990123456'),
('KH10', N'Đinh Thị J',N'Nữ', N'Hải Dương', '0901234567');

INSERT INTO CongViec VALUES
('CV01', N'Quản lý'),
('CV02', N'Nhân viên bán hàng'),
('CV03', N'Thu ngân'),
('CV04', N'Kế toán'),
('CV05', N'Trưởng phòng'),
('CV06', N'Nhân viên kho'),
('CV07', N'Nhân viên nhập hàng'),
('CV08', N'Tiếp tân'),
('CV09', N'Nhân sự'),
('CV10', N'Bảo vệ');

INSERT INTO NhaCungCap VALUES
('NCC01', N'Cty Sách Alpha', N'Quận 1, HCM', '0900000001'),
('NCC02', N'Cty Sách Beta', N'Đống Đa, HN', '0900000002'),
('NCC03', N'Cty Sách Gamma', N'Thanh Xuân, HN', '0900000003'),
('NCC04', N'Cty Sách Delta', N'Quận 5, HCM', '0900000004'),
('NCC05', N'Cty Sách Epsilon', N'Long Biên, HN', '0900000005'),
('NCC06', N'Cty Sách Zeta', N'Bình Thạnh, HCM', '0900000006'),
('NCC07', N'Cty Sách Eta', N'Cầu Giấy, HN', '0900000007'),
('NCC08', N'Cty Sách Theta', N'Quận 3, HCM', '0900000008'),
('NCC09', N'Cty Sách Iota', N'Tân Bình, HCM', '0900000009'),
('NCC10', N'Cty Sách Kappa', N'Hoàn Kiếm, HN', '0900000010');

INSERT INTO NgonNgu VALUES
('NN01', N'Tiếng Việt'),
('NN02', N'Tiếng Anh'),
('NN03', N'Tiếng Pháp'),
('NN04', N'Tiếng Đức'),
('NN05', N'Tiếng Trung'),
('NN06', N'Tiếng Nhật'),
('NN07', N'Tiếng Hàn'),
('NN08', N'Tiếng Nga'),
('NN09', N'Tiếng Tây Ban Nha'),
('NN10', N'Tiếng Ý');

INSERT INTO NhaXuatBan VALUES
('NXB01', N'NXB Kim Đồng', '0901234567', 'kimdong@nxb.vn', N'Hà Nội'),
('NXB02', N'NXB Giáo Dục', '0902234567', 'giaoduc@nxb.vn', N'HCM'),
('NXB03', N'NXB Trẻ', '0903234567', 'tre@nxb.vn', N'HCM'),
('NXB04', N'NXB Hội Nhà Văn', '0904234567', 'hvn@nxb.vn', N'Hà Nội'),
('NXB05', N'NXB Lao Động', '0905234567', 'laodong@nxb.vn', N'Hà Nội'),
('NXB06', N'NXB Thanh Niên', '0906234567', 'thanhnien@nxb.vn', N'HCM'),
('NXB07', N'NXB Văn Học', '0907234567', 'vanhoc@nxb.vn', N'Hà Nội'),
('NXB08', N'NXB Phụ Nữ', '0908234567', 'phunu@nxb.vn', N'Hà Nội'),
('NXB09', N'NXB Khoa Học', '0909234567', 'khoahoc@nxb.vn', N'HCM'),
('NXB10', N'NXB Quân Đội', '0910234567', 'quandoi@nxb.vn', N'Hà Nội');


INSERT INTO LoaiSach VALUES
('LS01', N'Truyện tranh'),
('LS02', N'Sách giáo khoa'),
('LS03', N'Tiểu thuyết'),
('LS04', N'Sách kỹ năng'),
('LS05', N'Sách tham khảo'),
('LS06', N'Sách thiếu nhi'),
('LS07', N'Sách ngôn tình'),
('LS08', N'Sách văn học nước ngoài'),
('LS09', N'Từ điển'),
('LS10', N'Sách kinh tế');

INSERT INTO TacGia VALUES
('TG01', N'Nguyễn Nhật Ánh', '1955-05-07', N'Nam', N'HCM'),
('TG02', N'Tô Hoài', '1920-09-27', N'Nam', N'Hà Nội'),
('TG03', N'J.K. Rowling', '1965-07-31', N'Nữ', N'Anh'),
('TG04', N'Haruki Murakami', '1949-01-12', N'Nam', N'Nhật Bản'),
('TG05', N'Nam Cao', '1915-10-29', N'Nam', N'Hà Nam'),
('TG06', N'Nguyễn Huy Thiệp', '1950-04-29', N'Nam', N'Hà Nội'),
('TG07', N'Margaret Atwood', '1939-11-18', N'Nữ', N'Canada'),
('TG08', N'George Orwell', '1903-06-25', N'Nam', N'Anh'),
('TG09', N'Dương Thu Hương', '1947-01-01', N'Nữ', N'Hà Nội'),
('TG10', N'Paulo Coelho', '1947-08-24', N'Nam', N'Brazil');


INSERT INTO LinhVuc VALUES
('LV01', N'Văn học'),
('LV02', N'Khoa học'),
('LV03', N'Kinh tế'),
('LV04', N'Giáo dục'),
('LV05', N'Công nghệ'),
('LV06', N'Thiếu nhi'),
('LV07', N'Lịch sử'),
('LV08', N'Tâm lý học'),
('LV09', N'Xã hội học'),
('LV10', N'Y học');


INSERT INTO KhoSach VALUES
('MS01', N'Mắt biếc', 50, '25000', '35000', 'LS03', 'TG01', 'NXB01', 'LV01', 'NN01', 'matbiec.jpg', 200),
('MS02', N'Dế mèn phiêu lưu ký', 30, '20000', '30000', 'LS06', 'TG02', 'NXB01', 'LV06', 'NN01', 'demen.jpg', 150),
('MS03', N'Harry Potter', 40, '50000', '70000', 'LS03', 'TG03', 'NXB03', 'LV01', 'NN02', 'hp.jpg', 400),
('MS04', N'Rừng Na Uy', 20, '60000', '80000', 'LS03', 'TG04', 'NXB03', 'LV01', 'NN02', 'rungnauy.jpg', 300),
('MS05', N'Lão Hạc', 60, '18000', '25000', 'LS01', 'TG05', 'NXB07', 'LV01', 'NN01', 'laohac.jpg', 100),
('MS06', N'Thiên tài bên trái', 25, '55000', '75000', 'LS04', 'TG07', 'NXB08', 'LV08', 'NN02', 'thiantai.jpg', 280),
('MS07', N'1984', 15, '50000', '70000', 'LS03', 'TG08', 'NXB07', 'LV01', 'NN02', '1984.jpg', 320),
('MS08', N'Chuyện tình Paris', 10, '45000', '65000', 'LS07', 'TG09', 'NXB06', 'LV01', 'NN01', 'paris.jpg', 210),
('MS09', N'Nhà giả kim', 35, '30000', '50000', 'LS03', 'TG10', 'NXB03', 'LV01', 'NN02', 'giakim.jpg', 220),
('MS10', N'Tiếng Việt lớp 1', 80, '10000', '12000', 'LS02', 'TG01', 'NXB02', 'LV04', 'NN01', 'tv1.jpg', 90);


INSERT INTO MatSach (MaSach, SLMat, NgayMat) VALUES
('MS01', 2, '2024-03-15'),
('MS02', 1, '2024-04-10'),
('MS03', 3, '2024-04-22'),
('MS04', 1, '2024-05-01'),
('MS05', 2, '2024-05-05'),
('MS06', 1, '2024-05-10'),
('MS07', 1, '2024-05-12'),
('MS08', 2, '2024-05-15'),
('MS09', 1, '2024-05-18'),
('MS10', 1, '2024-05-19');


INSERT INTO NhanVien VALUES
('NV01', N'Nguyễn Văn Nam', '0901122334', N'Hà Nội', 'CV01'),
('NV02', N'Lê Thị Hoa', '0902233445', N'HCM', 'CV02'),
('NV03', N'Phạm Văn Hùng', '0903344556', N'Đà Nẵng', 'CV03'),
('NV04', N'Trần Thị Lý', '0904455667', N'Hải Phòng', 'CV04'),
('NV05', N'Ngô Văn Bảo', '0905566778', N'Huế', 'CV05'),
('NV06', N'Đỗ Thị Thanh', '0906677889', N'HCM', 'CV06'),
('NV07', N'Bùi Văn Đức', '0907788990', N'Hà Nội', 'CV07'),
('NV08', N'Lê Thị Nhàn', '0908899001', N'Đồng Nai', 'CV08'),
('NV09', N'Phan Văn Khang', '0909900112', N'Hà Nội', 'CV09'),
('NV10', N'Vũ Thị Mai', '0910011223', N'Cần Thơ', 'CV10');


INSERT INTO HoaDonNhap VALUES
('HDN01', 'NV01', '2024-05-01', 'NCC01', 1750000),
('HDN02', 'NV02', '2024-05-02', 'NCC02', 1200000),
('HDN03', 'NV03', '2024-05-03', 'NCC03', 1500000),
('HDN04', 'NV04', '2024-05-04', 'NCC04', 1300000),
('HDN05', 'NV05', '2024-05-05', 'NCC05', 900000),
('HDN06', 'NV06', '2024-05-06', 'NCC06', 1100000),
('HDN07', 'NV07', '2024-05-07', 'NCC07', 1250000),
('HDN08', 'NV08', '2024-05-08', 'NCC08', 950000),
('HDN09', 'NV09', '2024-05-09', 'NCC09', 1050000),
('HDN10', 'NV10', '2024-05-10', 'NCC10', 1000000);


INSERT INTO ChiTietHDNhap VALUES
('HDN01', 'MS01', 10, 25000, 0, 250000),
('HDN01', 'MS02', 10, 20000, 0, 200000),
('HDN02', 'MS03', 15, 50000, 5, 712500),
('HDN03', 'MS04', 10, 60000, 0, 600000),
('HDN04', 'MS05', 20, 18000, 0, 360000),
('HDN05', 'MS06', 5, 55000, 10, 247500),
('HDN06', 'MS07', 5, 50000, 0, 250000),
('HDN07', 'MS08', 4, 45000, 5, 171000),
('HDN08', 'MS09', 10, 30000, 0, 300000),
('HDN09', 'MS10', 20, 10000, 0, 200000);


INSERT INTO HoaDonBan VALUES
('HDB01', 'NV01', '2024-05-11', 'KH01', 700000),
('HDB02', 'NV02', '2024-05-11', 'KH02', 450000),
('HDB03', 'NV03', '2024-05-12', 'KH03', 800000),
('HDB04', 'NV04', '2024-05-12', 'KH04', 300000),
('HDB05', 'NV05', '2024-05-13', 'KH05', 500000),
('HDB06', 'NV06', '2024-05-13', 'KH06', 400000),
('HDB07', 'NV07', '2024-05-14', 'KH07', 350000),
('HDB08', 'NV08', '2024-05-14', 'KH08', 600000),
('HDB09', 'NV09', '2024-05-15', 'KH09', 750000),
('HDB10', 'NV10', '2024-05-15', 'KH10', 550000);

INSERT INTO ChiTietHDBan VALUES
('HDB01', 'MS01', 2, 0, 70000),
('HDB02', 'MS02', 1, 0, 30000),
('HDB03', 'MS03', 1, 0, 70000),
('HDB04', 'MS05', 2, 0, 50000),
('HDB05', 'MS06', 1, 10, 67500),
('HDB06', 'MS07', 1, 0, 70000),
('HDB07', 'MS08', 1, 0, 65000),
('HDB08', 'MS09', 2, 0, 100000),
('HDB09', 'MS04', 1, 0, 80000),
('HDB10', 'MS10', 5, 0, 60000);
CREATE TABLE [TaiKhoan] (
	usename VARCHAR(20) NOT NULL,
	password VARCHAR(20) NOT NULL,
	PhanQuyen int NOT NULL,
	
);

INSERT INTO TaiKhoan VALUES
('admin', 'admin123', 1),
('nv01', '123456', 2),
('nv02', '123456', 2),
('nv03', '123456', 2),
('nv04', '123456', 2),
('nv05', '123456', 2),
('nv06', '123456', 2),
('nv07', '123456', 2),
('nv08', '123456', 2),
('nv09', '123456', 2);

ALTER TABLE NhanVien
ADD GioiTinh NVARCHAR(10);


UPDATE NhanVien SET GioiTinh = N'Nam' WHERE MaNhanVien IN ('NV01', 'NV02', 'NV03', 'NV04', 'NV05');
UPDATE NhanVien SET GioiTinh = N'Nữ' WHERE MaNhanVien IN ('NV06', 'NV07', 'NV08', 'NV09', 'NV10');
