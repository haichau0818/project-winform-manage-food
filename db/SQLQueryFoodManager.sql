CREATE DATABASE FoodManager
GO
--DROP DATABASE FoodManager
USE FoodManager
GO 



CREATE TABLE NHANVIEN
(
	[maNV] INT IDENTITY(0,1) PRIMARY KEY (maNV),
	[hoTen] NVARCHAR(50),
	[maQuyen] INT NOT NULL ,
	[idTK] INT NOT NULL,
	[gioiTinh] BIT,
	[ngaySinh] DATE,
	[diaChi] NVARCHAR(50),
	[SDT] NCHAR(20),
	[email] NCHAR(50) ,
	CONSTRAINT FK_IDq FOREIGN KEY(maQuyen) REFERENCES PHANQUYEN(maQuyen),
	CONSTRAINT FK_IDtk FOREIGN KEY(idTK) REFERENCES TAIKHOAN(id)
);
CREATE TABLE PHANQUYEN
(	[maQuyen] INT IDENTITY(1,1) PRIMARY KEY,
	[tenQuyen] NVARCHAR(50) ,
	[ghiChu] NVARCHAR(MAX) 
);
CREATE TABLE TAIKHOAN
(	[id] INT IDENTITY(0,1)  PRIMARY KEY,
	[Username] NCHAR(20) NOT NULL,
	[passwordChar] NCHAR(20) NOT NULL
);
 --EXEC sp_rename 'TAIKHOAN.Password','passwordChar','COLUMN'
CREATE TABLE LOAISP
(
	[maLSP] INT IDENTITY(1,1) PRIMARY KEY,
	[tenLoaiSP] NVARCHAR(50),
	[ghiChu] NVARCHAR(MAX),

);
--DROP TABLE LOAISP

CREATE TABLE SANPHAM
(
	[maSP] NCHAR(10) PRIMARY KEY,
	[tenSP] NVARCHAR(50),
	[maLSP] INT NOT NULL,
	[giaNhap] DECIMAL(10,0),
	[giaBan] DECIMAL(10,0),
	[khuyenMai] INT,
	[soLuong] INT,
	[NSX] DATE,
	[HSD] DATE,
	[hinhAnh] IMAGE,
	CONSTRAINT FK_IDsp FOREIGN KEY (maLSP) REFERENCES LOAISP(maLSP)
);
--ALTER TABLE SANPHAM
--DROP CONSTRAINT FK_IDsp
--DROP TABLE SANPHAM
CREATE TABLE KHACHHANG
(
	[maKH] NCHAR(10) PRIMARY KEY,
	[hoTen] NVARCHAR(50) NOT NULL,
	[themBoiNV] INT NOT NULL,
	[gioiTinh] BIT,
	[diaChi] NVARCHAR(50),
	[SDT] NCHAR(10),
	[email] NCHAR(50),
	CONSTRAINT FK_IDnv FOREIGN KEY(themBoiNV) REFERENCES NHANVIEN(maNV)
);

CREATE TABLE HOADON
(
	[maHD] NCHAR(10) PRIMARY KEY,
	[NVLap] INT NOT NULL,
	[thongTinKH] NCHAR(10) NOT NULL,
	[maCTHD] NCHAR(10) NOT NULL,
	[NgayLap] DATETIME,
	[TongTien] DECIMAL,
	[GhiChu] NVARCHAR(MAX),
	CONSTRAINT FK_IDhd FOREIGN KEY(NVLap) REFERENCES NHANVIEN(maNV),
	CONSTRAINT FK_IDhd1 FOREIGN KEY(thongTinKH) REFERENCES KHACHHANG(maKH),
	CONSTRAINT FK_IDhd2 FOREIGN KEY(maCTHD) REFERENCES CHITIETHD(maCTHD),
);
--Thêm cột đã thanh toán
ALTER TABLE HOADON
ADD daThanhToan bit
----Thêm cột số tiền trả/số tiền thừa
ALTER TABLE HOADON
ADD soTienTra DECIMAL

ALTER TABLE HOADON
ADD soTienThua DECIMAL
-----Thay đổi kiểu date thành datetime cột ngày lặp
ALTER TABLE HOADON
ALTER COLUMN NgayLap DATETIME


alter TABLE HOADON 
drop CONSTRAINT FK_IDhd2;


CREATE TABLE CHITIETHD
(	
	[maCTHD] NCHAR(10) PRIMARY KEY,
	[maSP] NCHAR(10) NOT NULL,
	[soLuong] FLOAT(50),
	[giaBan] DECIMAL,
	[khuyenMai] INT,
	[thanhTien] DECIMAL,
	CONSTRAINT FK_IDcthd FOREIGN KEY(maSP) REFERENCES SANPHAM(maSP),
);

ALTER TABLE CHITIETHD

ADD CONSTRAINT FK_IDcthd1
FOREIGN KEY (maHD) REFERENCES HOADON(maHD);
ADD maHD NCHAR(10)

GO
--
DECLARE @user NCHAR(50)='admin'
DECLARE @pass NCHAR(50)='admin'


SELECT TK.Username,TK.passwordChar,NV.hoTen,PQ.tenQuyen FROM ((TAIKHOAN AS TK JOIN NHANVIEN AS NV ON TK.id=NV.idTK) JOIN PHANQUYEN AS PQ ON PQ.maQuyen=NV.maQuyen) WHERE Username=@user AND passwordChar=@pass
GO


--CREATE PROC LOGIN_USP
--@user NCHAR(50),
--@pass NCHAR(50),
--@hoTen nchar(50),
--@tenQ nchar(50)
--AS
--BEGIN
--SELECT TK.Username=@user,TK.passwordChar=@pass,NV.hoTen=@hoTen,PQ.tenQuyen=@tenQ FROM ((TAIKHOAN AS TK JOIN NHANVIEN AS NV ON TK.id=NV.idTK) JOIN PHANQUYEN AS PQ ON PQ.maQuyen=NV.maQuyen) WHERE Username=@user AND passwordChar=@pass
--END
select * from TAIKHOAN

UPDATE TAIKHOAN SET passwordChar='1234' WHERE Username='NV01'
DECLARE @userName NCHAR(50)='nv01'
DECLARE @pass NCHAR(50)='12345'
UPDATE TAIKHOAN SET passwordChar=@pass WHERE Username=@userName

-------------------------------------------------------SANPHAM-------------------------------------------------------------------------------
--ShowDATAPRODUCT

--SHOWDATA LOAI SAN PHAM
CREATE PROC LISTPRODUCTTYPE
AS 
SELECT * FROM LOAISP ORDER BY tenLoaiSP ASC
EXEC LISTPRODUCTTYPE

--INSERT PRODUCT
DROP PROC INSERTDATAPRODUCT
CREATE PROC INSERTDATAPRODUCT
@maSP NCHAR(10),
@tenSP NVARCHAR(50),
@maLSP INT,
@giaNhap DECIMAL(10,0),
@giaBan DECIMAL(10,0),
@soLuong INT,
@khuyenMai INT,
@NSX DATE,
@HSD DATE,
@hinhAnh IMAGE
AS
INSERT INTO SANPHAM VALUES(@maSP,@tenSP,@maLSP,@giaNhap,@giaBan,@khuyenMai,@soLuong,@NSX,@HSD,@hinhAnh)

EXEC INSERTDATAPRODUCT 'SP01',N'BÁNH CAM',1,1000,10000,0,30,'2020-12-11','2020-12-20',NULL



SELECT*FROM SANPHAM
INSERT INTO SANPHAM(maSP,tenSP,maLSP,giaNhap,giaBan,khuyenMai,soLuong,NSX,HSD,hinhAnh) VALUES('SP00',N'BÁNH MÌ','L00',5000,10000,0,20,'2020-12-11','2020-12-20',NULL)

GO
--EDIT PRODUCT
CREATE PROC EDITPRODUCT
@maSP NCHAR(10),
@tenSP NVARCHAR(50),
@maLSP INT,
@giaNhap DECIMAL(10,0),
@giaBan DECIMAL(10,0),
@soLuong INT,
@khuyenMai INT,
@NSX DATE,
@HSD DATE,
@hinhAnh IMAGE
AS
UPDATE SANPHAM SET tenSP=@tenSP,MaLSP=@maLSP,giaNhap=@giaNhap,giaBan=@giaBan,khuyenMai=@khuyenMai,soLuong=@soLuong,NSX=@NSX,HSD=@HSD,hinhAnh=@hinhAnh WHERE maSP=@maSP


EXEC EDITPRODUCT 'SP01', N'NƯỚC CAM',2,1000,2000,10,10,'2020/10/11','2020/1/20',null
GO
CREATE PROC DELETEDPRODUCT
@maSP CHAR(10)
AS 
DELETE FROM SANPHAM
WHERE maSP=@maSP
EXEC DELETEDPRODUCT 'SP00'

SELECT * FROM LOAISP

DROP PROC SHOWDATAPRODUCT
CREATE PROC SHOWDATAPRODUCT
AS
SELECT maSP as [Mã sản phẩm],tenSP as [Tên sản phẩm],tenLoaiSP as [Tên loại sản phẩm],
replace(convert(varchar,cast(floor(giaNhap) as money),1), '.00', '') as [Giá nhập],
replace(convert(varchar,cast(floor(giaBan) as money),1), '.00', '') as [Giá bán],
khuyenMai as [Khuyến mãi],soLuong as [Số lượng],NSX as [Ngày sản xuất],HSD as [Hạn sử dụng],hinhAnh as [Hình ảnh]
FROM SANPHAM INNER JOIN LOAISP ON LOAISP.maLSP=SANPHAM.maLSP
exec SHOWDATAPRODUCT
drop proc SHOWDATAPRODUCT
---searchProduct
SELECT maSP as [Mã sản phẩm],tenSP as [Tên sản phẩm],tenLoaiSP as [Tên loại sản phẩm],giaNhap as [Giá nhập],giaBan as [Giá bán],khuyenMai as [Khuyến mãi],soLuong as [Số lượng],NSX as [Ngày sản xuất],HSD as [Hạn sử dụng],hinhAnh as [Hình ảnh]
FROM (SANPHAM INNER JOIN LOAISP ON LOAISP.maLSP=SANPHAM.maLSP) WHERE maSP LIKE '%02%' OR tenSP LIKE '%%'

-- Show TÊN SẢN PHẨM , GIÁ SẢN PHẨM, KHUYẾN MÃI, Hình ảnh

replace(convert(varchar,cast(floor(giaBan) as money),1), '.00', '') as
--PROC SẢN PHẨM KHUYẾN MÃI
CREATE PROC SHOWPRODUCTSALE
AS
SELECT tenSP,replace(convert(varchar,cast(floor(giaBan) as money),1), '.00', '') as giaBan,soLuong,khuyenMai,hinhAnh FROM SANPHAM
WHERE khuyenMai>0

DROP PROC SHOWPRODUCTSALE
 
EXEC SHOWPRODUCTSALE
--PROC TẤT CẢ SẢN PHẨM
CREATE PROC SHOWPRODUCTAll
AS
SELECT tenSP,replace(convert(varchar,cast(floor(giaBan) as money),1), '.00', '') as giaBan,soLuong,khuyenMai,hinhAnh FROM SANPHAM
EXEC SHOWPRODUCTAll
drop proc SHOWPRODUCTAll
--PROC ĐỒ ĂN
CREATE PROC SHOWPRODUCTFOOD
AS
SELECT tenSP,replace(convert(varchar,cast(floor(giaBan) as money),1), '.00', '') as giaBan,soLuong,khuyenMai,hinhAnh FROM (SANPHAM AS SP JOIN LOAISP AS LSP 
ON SP.maLSP=LSP.maLSP)
WHERE tenLoaiSP LIKE N'ĐỒ ĂN%'

EXEC SHOWPRODUCTFOOD
drop proc SHOWPRODUCTFOOD


EXEC SHOWPRODUCTAll
SELECT *FROM LOAISP

---PROC NƯỚC UỐNG

CREATE PROC SHOWPRODUCTDRINK
AS
SELECT tenSP,replace(convert(varchar,cast(floor(giaBan) as money),1), '.00', '') as giaBan,soLuong,khuyenMai,hinhAnh FROM (SANPHAM AS SP JOIN LOAISP AS LSP 
ON SP.maLSP=LSP.maLSP)
WHERE tenLoaiSP LIKE N'NƯỚC%'

drop proc SHOWPRODUCTDRINK
---PROC BÁN CHẠY
----Tìm kiếm sản phẩm
SELECT * FROM SANPHAM WHERE maSP LIKE '%02%' OR tenSP like N'%khoai%'
SELECT * FROM NHANVIEN WHERE hoTen like N'%Châu%'
-----------------
replace(convert(varchar,cast(floor(giaBan) as money),1), '.00', '') as 


SELECT tenSP,replace(convert(varchar,cast(floor(giaBan) as money),1), '.00', '')as giaBan,soLuong,khuyenMai,hinhAnh FROM SANPHAM WHERE maSP LIKE '%01%'
------------------------------------------------------NHANVIEN-------------------------------------------------------------------------------
--SHOW DATA STAFF
CREATE PROC SHOWDATASTAFF
AS SELECT * FROM NHANVIEN
EXEC SHOWDATASTAFF

select * from NHANVIEN
GO
--INSERT STAFF
SELECT* FROM NHANVIEN
CREATE PROC INSERTSTAFF

@hoTen NVARCHAR(50),
@maQuyen NCHAR(10),
@idTK int,
@gioiTinh bit,
@ngaySinh date,
@diaChi NVARCHAR(50),
@SDT NCHAR(10),
@Email nchar(50)
as
INSERT INTO NHANVIEN values(@hoTen,@maQuyen,@idTK,@gioiTinh,@ngaySinh,@diaChi,@sdt,@email)

EXEC INSERTSTAFF N'Thái Văn Ân','2','1','1','1990-12-23',N'Ô Môn Cần Thơ','092881832','adadd@gmail.com'
drop proc INSERTSTAFF

--EDIT STAFF
SELECT *FROM NHANVIEN
DROP PROC EDITSTAFF
CREATE PROC EDITSTAFF
@hoTen NVARCHAR(50),
@maQuyen NCHAR(10),
@idTK int,
@gioiTinh bit,
@ngaySinh date,
@diaChi NVARCHAR(50),
@SDT NCHAR(10),
@Email nchar(50),
@maNV INT
AS 
UPDATE NHANVIEN SET hoTen=@hoTen,maQuyen= @maQuyen,idTK= @idTK,gioiTinh= @gioiTinh,ngaySinh= @ngaySinh,diaChi= @diaChi,SDT= @sdt,email= @email WHERE maNV=@maNV

EXEC EDITSTAFF N'Thái Ân','2','1',1,'1990-12-23',N'Ô Môn Cần Thơ','092881832','adadd@gmail.com',2

--DELETED STAFF
CREATE PROC DELECTEDSTAFF
@maNV INT
AS 
DELETE FROM NHANVIEN WHERE maNV=@maNV

EXEC DELECTEDSTAFF 2

--LIỆT KÊ QUYỀN

CREATE PROC LISTROLE
AS
SELECT * FROM PHANQUYEN ORDER BY tenQuyen ASC

EXEC LISTROLE
--LIỆT KÊ USERS
CREATE PROC LISTACCOUNT
AS 
SELECT * FROM TAIKHOAN ORDER BY Username ASC

EXEC LISTACCOUNT
--Show data 
SELECT maNV,hoTen,tenQuyen,Username,gioiTinh,ngaySinh,SDT,email
FROM NHANVIEN
INNER JOIN PHANQUYEN ON NHANVIEN.maQuyen=PHANQUYEN.maQuyen
INNER JOIN TAIKHOAN ON NHANVIEN.idTK=TAIKHOAN.id

--ss
DROP PROC SHOWDATASTAFF
CREATE PROC SHOWDATASTAFF
AS
SELECT maNV as [Mã nhân viên],hoTen as [Họ tên],tenQuyen as [Quyền],Username as [Tài khoản],gioiTinh as [Giới tính],ngaySinh as [Ngày sinh],diaChi as [Địa chỉ],SDT as [Số điện thoại],email as [Email]
FROM NHANVIEN
INNER JOIN PHANQUYEN ON NHANVIEN.maQuyen=PHANQUYEN.maQuyen
INNER JOIN TAIKHOAN ON NHANVIEN.idTK=TAIKHOAN.id

exec SHOWDATASTAFF

---searchstaff
SELECT maNV as [Mã nhân viên],hoTen as [Họ tên],tenQuyen as [Quyền],Username as [Tài khoản],gioiTinh as [Giới tính],ngaySinh as [Ngày sinh],diaChi as [Địa chỉ],SDT as [Số điện thoại],email as [Email]
FROM ((NHANVIEN INNER JOIN PHANQUYEN ON NHANVIEN.maQuyen=PHANQUYEN.maQuyen) INNER JOIN TAIKHOAN ON NHANVIEN.idTK=TAIKHOAN.id)
WHERE hoTen like N'%Trần%'
--------------------------------------------------KHÁCH HÀNG-----------------------------------------------------------------------------
SELECT * FROM KHACHHANG
SELECT * FROM NHANVIEN
--PROC SHOWDATACUSTOMER
CREATE PROC SHOWDATACUSTOMER
AS
SELECT maKH AS [Mã khách hàng],KH.hoTen AS [Họ Tên],NV.hoTen AS [Thêm bởi],KH.gioiTinh as [Giới tính],KH.diaChi as [Địa chỉ],KH.SDT as [Số điện thoại],KH.email as [Email]
FROM KHACHHANG AS KH
INNER JOIN NHANVIEN AS NV ON NV.maNV=KH.themBoiNV

exec SHOWDATACUSTOMER
DROP PROC SHOWDATACUSTOMER
-------Search khách hàng
SELECT maKH AS [Mã khách hàng],KH.hoTen AS [Họ Tên],NV.hoTen AS [Thêm bởi],KH.gioiTinh as [Giới tính],KH.diaChi as [Địa chỉ],KH.SDT as [Số điện thoại],KH.email as [Email]
FROM (KHACHHANG AS KH INNER JOIN NHANVIEN AS NV ON NV.maNV=KH.themBoiNV) where kh.maKH like '%02%' OR KH.hoTen LIKE N'%phạm%'

--PROC LIET KÊ TÊN NV
CREATE PROC LISTSTAFF
AS
SELECT * FROM NHANVIEN ORDER BY hoTen ASC
EXEC LISTSTAFF
---PROC INSERT CUSTOMER
CREATE PROC INSERTCUSTOMER
@maKH NCHAR(10),
@hoTen NVARCHAR(50),
@themBoi INT,
@gioiTinh bit,
@diaChi NVARCHAR(50),
@SDT NCHAR(10),
@Email nchar(50)
as
INSERT INTO KHACHHANG values(@maKH ,@hoTen,@themBoi,@gioiTinh,@diaChi,@sdt,@email)

EXEC INSERTCUSTOMER 'KH00',N'TRẦN VĂN HEO',1,'1',N'CẦN THƠ','092837783','vanheo@gmail.com'

----PROC EDIT CUSTOMER
CREATE PROC EDITCUSTOMER
@maKH NCHAR(10),
@hoTen NVARCHAR(50),
@themBoi INT,
@gioiTinh bit,
@diaChi NVARCHAR(50),
@SDT NCHAR(10),
@Email nchar(50)
as
UPDATE KHACHHANG SET hoTen= @hoTen,themBoiNV= @themBoi,gioiTinh=@gioiTinh,diaChi=@diaChi,SDT=@sdt,email=@email WHERE maKH=@maKH

EXEC EDITCUSTOMER 'KH00', N'TRẦN VĂN d',1,'1',N'CỦ CHI','09837722','DAD@GMAIL.COM'
select * from KHACHHANG
---PROC DELETE CUSTOMER
CREATE PROC DELETEDCUSTOMER
@maKH NCHAR(10)
AS
DELETE FROM KHACHHANG WHERE maKH=@maKH
EXEC DELETEDCUSTOMER 'KH01'


--------tìm
SELECT hoTen,SDT FROM KHACHHANG WHERE SDT LIKE '%" +keyword + "%' OR hoTen LIKE N'%" + keyword + "%'
--------------------------------------------------------------------------HÓA ĐƠN--------------------------------------------------------
SELECT * FROM HOADON
SELECT * FROM CHITIETHD
---SEARCH CUSTOMER
SELECT * FROM KHACHHANG
SELECT *FROM SANPHAM

SELECT hoTen,diaChi,SDT,email FROM KHACHHANG
WHERE hoTen LIKE N'%dẦN%'
EXEC SEARCHCUS 'KH01'


SELECT hoTen,diaChi,SDT,email
FROM KHACHHANG
WHERE maKH LIKE '%''%' OR hoTen LIKE N'%''%'  

---SEARCH PRODUCT
SELECT tenSP,giaBan,soLuong,khuyenMai,hinhAnh FROM SANPHAM
WHERE maSP LIKE '%SP0%' OR tenSP LIKE N'%BÁNH%' 

--INSERT BILL
SELECT MAX(maHD) as maHD FROM HOADON

CREATE PROC INSERTDATABILL
@nvLap INT,
@thongTinKH NCHAR(10),
@ngayLap datetime,
@tongTien DECIMAL(10,0),
@daThanhToan bit,
@soTienTra decimal,
@soTienThua decimal
AS
INSERT INTO HOADON VALUES(@nvLap,@thongTinKH,@ngayLap,@tongTien,@daThanhToan,@soTienTra,@soTienThua)

drop proc INSERTDATABILL

EXEC INSERTDATABILL 'HD01',1,'KH01',1000,10000,0,30,'2020-12-11','2020-12-20',NULL

-- INSERT DATA BILL DETAIL
USE FoodManager
SELECT * FROM CHITIETHD
CREATE PROC INSERTDATABILLDETAIL

@maSP NCHAR(10),
@soLuong INT,
@giaBan DECIMAL(10,0),
@khuyenMai INT,
@thanhTien DECIMAL(10,0),
@maHD INT

AS 
INSERT INTO CHITIETHD VALUES(@maSP,@soLuong,@giaBan,@khuyenMai,@thanhTien,@maHD)

DROP PROC INSERTDATABILLDETAIL

SELECT * FROM CHITIETHD
SELECT maSP  FROM SANPHAM WHERE  tenSP = N'BÁNH RÁNG'
SELECT maSP FROM SANPHAM WHERE tenSP=N'BÁNH RÁNG'
SELECT*FROM SANPHAM 

SELECT maKH FROM KHACHHANG WHERE hoTen = N'TRẦN DẦN'
SELECT maSP FROM SANPHAM WHERE tenSP = N'BÁNH RÁNG '
select * from HOADON
GO
-----------------------------------------------------------------------------THỐNG KÊ------------------------------------------------------------------------------------------

----------------------------------report bill-----------------------
select * from HOADON
CREATE VIEW PAYMENT
AS
SELECT hd.maHD,hd.TongTien,hd.NgayLap,hd.soTienTra,hd.soTienThua,cthd.soLuong,cthd.thanhTien,kh.hoTen,sp.tenSP,cthd.khuyenMai 
FROM HOADON AS hd INNER JOIN CHITIETHD AS cthd ON hd.maHD=cthd.maHD 
INNER JOIN SANPHAM AS sp ON cthd.maSP=sp.maSP
INNER JOIN KHACHHANG AS kh ON hd.thongTinKH=kh.maKH
select * from PAYMENT WHERE maHD=78

drop view PAYMENT
CREATE VIEW PAYMENT
AS
SELECT hd.maHD,replace(convert(varchar,cast(floor(hd.TongTien)as money),1), '.00', '') as TongTien,
hd.NgayLap,replace(convert(varchar,cast(floor(hd.soTienTra)as money),1), '.00', '') as soTienTra,replace(convert(varchar,cast(floor(hd.soTienThua)as money),1), '.00', '')as soTienThua,
cthd.soLuong,replace(convert(varchar,cast(floor(cthd.thanhTien)as money),1), '.00', '') as ThanhTien,kh.hoTen,sp.tenSP,cthd.khuyenMai 
FROM HOADON AS hd INNER JOIN CHITIETHD AS cthd ON hd.maHD=cthd.maHD 
INNER JOIN SANPHAM AS sp ON cthd.maSP=sp.maSP
INNER JOIN KHACHHANG AS kh ON hd.thongTinKH=kh.maKH
----------------------------------------------------------------------------Convert money-------------------------------------------------------------------------------------------
replace(convert(varchar,cast(floor(cthd.thanhTien)as money),1), '.00', '') as 

--------thống kê---------

---ĐẾM THỐNG KÊ

CREATE PROC STATISTICAL
@tongtien float out,
@tongsp int out,
@tongkh int out,
@tongspbc int out
as
SET @tongtien=( SELECT SUM(TongTien) AS TongTien FROM HOADON)
SET @tongsp=(SELECT COUNT(MaSP) AS TongSP FROM SANPHAM)
SET @tongkh=(SELECT COUNT(maKH) AS TongKH FROM KHACHHANG)
SET @tongspbc=(SELECT COUNT(maSP) AS SPBanChay FROM CHITIETHD WHERE soLuong>2)



---top 5 bán chạy 
CREATE PROC SELLINGPRO
AS
SELECT TOP 5 SP.tenSP AS [Tên sản phẩm], SUM(CT.soLuong) AS [Số lượng]
FROM CHITIETHD AS CT
INNER JOIN SANPHAM SP ON SP.maSP=CT.maSP
GROUP BY CT.maSP,SP.tenSP
ORDER BY COUNT(5) DESC

drop proc SELLINGPRO
EXEC SELLINGPRO

----sản phẩm theo số lượng
SELECT LSP.tenLoaiSP AS [Tên sản phẩm], COUNT(SP.maLSP) AS [Số lượng] FROM SANPHAM AS SP INNER JOIN LOAISP LSP ON SP.maLSP=LSP.maLSP GROUP BY SP.soLuong,LSP.tenLoaiSP ORDER BY COUNT(2) DESC
-----------Top 5 doanh thu theo ngày thánh năm


SELECT month(hd.NgayLap) Thang ,sum(hd.TongTien) Tong FROM HOADON hd GROUP BY month(hd.NgayLap)ORDER BY SUM(hd.TongTien) DESC


SELECT hd.NgayLap as Ngay , sum(hd.TongTien) Tong FROM HOADON hd GROUP BY hd.NgayLap ORDER BY SUM(hd.TongTien) DESC


SELECT year(hd.NgayLap) Nam , sum(hd.TongTien) Tong FROM HOADON hd GROUP BY year(hd.NgayLap)ORDER BY SUM(hd.TongTien) DESC