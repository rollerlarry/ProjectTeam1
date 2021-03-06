USE [master]
GO
/****** Object:  Database [QLPN]    Script Date: 05/04/2018 20:35:06 ******/
CREATE DATABASE [QLPN] ON  PRIMARY 
( NAME = N'QLPN', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\QLPN.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLPN_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\QLPN_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLPN] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLPN].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLPN] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [QLPN] SET ANSI_NULLS OFF
GO
ALTER DATABASE [QLPN] SET ANSI_PADDING OFF
GO
ALTER DATABASE [QLPN] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [QLPN] SET ARITHABORT OFF
GO
ALTER DATABASE [QLPN] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [QLPN] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [QLPN] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [QLPN] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [QLPN] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [QLPN] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [QLPN] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [QLPN] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [QLPN] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [QLPN] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [QLPN] SET  DISABLE_BROKER
GO
ALTER DATABASE [QLPN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [QLPN] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [QLPN] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [QLPN] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [QLPN] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [QLPN] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [QLPN] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [QLPN] SET  READ_WRITE
GO
ALTER DATABASE [QLPN] SET RECOVERY FULL
GO
ALTER DATABASE [QLPN] SET  MULTI_USER
GO
ALTER DATABASE [QLPN] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [QLPN] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLPN', N'ON'
GO
USE [QLPN]
GO
/****** Object:  Table [dbo].[TAIKHOANQUANTRI]    Script Date: 05/04/2018 20:35:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOANQUANTRI](
	[MaTaiKhoan] [nvarchar](50) NOT NULL,
	[TenTaiKhoan] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[TrangThaiTaiKhoan] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[TAIKHOANQUANTRI] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [TrangThaiTaiKhoan]) VALUES (N'1', N'NGUYENHAO', N'123', 0)
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 05/04/2018 20:35:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[MaTaiKhoan] [nvarchar](50) NOT NULL,
	[TenTaiKhoan] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[LoaiTaiKhoan] [nvarchar](50) NOT NULL,
	[SoTien] [float] NOT NULL,
	[TinhTrangTaiKhoan] [int] NOT NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TAIKHOAN] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [LoaiTaiKhoan], [SoTien], [TinhTrangTaiKhoan]) VALUES (N'1001', N'Can', N'NgocCan', N'Thành Viên', 60000, 1)
INSERT [dbo].[TAIKHOAN] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [LoaiTaiKhoan], [SoTien], [TinhTrangTaiKhoan]) VALUES (N'1002', N'Hao', N'VanHao', N'Nhân Viên', 0, 1)
INSERT [dbo].[TAIKHOAN] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [LoaiTaiKhoan], [SoTien], [TinhTrangTaiKhoan]) VALUES (N'1003', N'Danh', N'VanDanh', N'ThanhVien', 20000, 1)
/****** Object:  Table [dbo].[NHOMNGUOISUDUNG]    Script Date: 05/04/2018 20:35:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHOMNGUOISUDUNG](
	[MaNhom] [nvarchar](50) NOT NULL,
	[TenNhom] [nvarchar](50) NOT NULL,
	[LoaiTaiKhoan] [nvarchar](50) NOT NULL,
	[GiaTien] [float] NOT NULL,
 CONSTRAINT [PK_NHOMNGUOISUDUNG] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[NHOMNGUOISUDUNG] ([MaNhom], [TenNhom], [LoaiTaiKhoan], [GiaTien]) VALUES (N'01', N'Khách', N'Guest', 6000)
INSERT [dbo].[NHOMNGUOISUDUNG] ([MaNhom], [TenNhom], [LoaiTaiKhoan], [GiaTien]) VALUES (N'02', N'Thành viên', N'Member', 5000)
INSERT [dbo].[NHOMNGUOISUDUNG] ([MaNhom], [TenNhom], [LoaiTaiKhoan], [GiaTien]) VALUES (N'03', N'Điều hành', N'Manager', 0)
INSERT [dbo].[NHOMNGUOISUDUNG] ([MaNhom], [TenNhom], [LoaiTaiKhoan], [GiaTien]) VALUES (N'04', N'Staff', N'Staff', 0)
INSERT [dbo].[NHOMNGUOISUDUNG] ([MaNhom], [TenNhom], [LoaiTaiKhoan], [GiaTien]) VALUES (N'05', N'Tài khoản thẻ', N'Coupon', 5000)
/****** Object:  Table [dbo].[MAYTRAM]    Script Date: 05/04/2018 20:35:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAYTRAM](
	[MaMayTram] [nvarchar](50) NOT NULL,
	[TenMayTram] [nvarchar](50) NOT NULL,
	[TinhTrangMayTram] [int] NOT NULL,
	[TenTaiKhoan] [nvarchar](50) NULL,
	[ThoiGianBatDau] [datetime] NULL,
	[DaSuDung] [int] NULL,
	[ConLai] [int] NULL,
	[Tien] [int] NULL,
	[NgayHienTai] [date] NULL,
	[PhienBan] [nvarchar](50) NULL,
	[LoaiTaiKhoan] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[MAYTRAM] ([MaMayTram], [TenMayTram], [TinhTrangMayTram], [TenTaiKhoan], [ThoiGianBatDau], [DaSuDung], [ConLai], [Tien], [NgayHienTai], [PhienBan], [LoaiTaiKhoan], [GhiChu]) VALUES (N'01', N'MAY01', 0, N'nguyenthanhdanh', CAST(0x0000A84F00C670C8 AS DateTime), 40, 20, 3000, CAST(0x2E3E0B00 AS Date), N'1.1', N'Member', NULL)
INSERT [dbo].[MAYTRAM] ([MaMayTram], [TenMayTram], [TinhTrangMayTram], [TenTaiKhoan], [ThoiGianBatDau], [DaSuDung], [ConLai], [Tien], [NgayHienTai], [PhienBan], [LoaiTaiKhoan], [GhiChu]) VALUES (N'02', N'MAY02', 1, N'nguyenvanhao', CAST(0x0000A83100662C40 AS DateTime), 50, 30, 4000, CAST(0x2E3E0B00 AS Date), N'1.1', N'Member', NULL)
INSERT [dbo].[MAYTRAM] ([MaMayTram], [TenMayTram], [TinhTrangMayTram], [TenTaiKhoan], [ThoiGianBatDau], [DaSuDung], [ConLai], [Tien], [NgayHienTai], [PhienBan], [LoaiTaiKhoan], [GhiChu]) VALUES (N'03', N'MAY03', 2, N'nguyenvandanh', CAST(0x0000A8C00172C9E0 AS DateTime), 15, 30, 10000, CAST(0x2E3E0B00 AS Date), N'1.1', N'Member', NULL)
INSERT [dbo].[MAYTRAM] ([MaMayTram], [TenMayTram], [TinhTrangMayTram], [TenTaiKhoan], [ThoiGianBatDau], [DaSuDung], [ConLai], [Tien], [NgayHienTai], [PhienBan], [LoaiTaiKhoan], [GhiChu]) VALUES (N'04', N'MAY04', 1, N'leducduy', CAST(0x0000A8C000000000 AS DateTime), 10, 20, 2000, CAST(0xBA3D0B00 AS Date), N'1.1', N'Guest', NULL)
/****** Object:  Table [dbo].[GIAODICH]    Script Date: 05/04/2018 20:35:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIAODICH](
	[MaGiaoDich] [nvarchar](50) NOT NULL,
	[TenTaiKhoan] [nvarchar](50) NOT NULL,
	[NgayBatDau] [date] NOT NULL,
	[GioBatDau] [datetime] NOT NULL,
	[NgayGiaoDich] [date] NOT NULL,
	[ThoiGianGiaoDich] [datetime] NOT NULL,
	[SoTienGiaoDich] [float] NOT NULL,
	[NhanVien] [nvarchar](50) NOT NULL,
	[GhiChu] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GIAODICH] PRIMARY KEY CLUSTERED 
(
	[MaGiaoDich] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[GIAODICH] ([MaGiaoDich], [TenTaiKhoan], [NgayBatDau], [GioBatDau], [NgayGiaoDich], [ThoiGianGiaoDich], [SoTienGiaoDich], [NhanVien], [GhiChu]) VALUES (N'01', N'AN', CAST(0x393E0B00 AS Date), CAST(0x0000A9AD01576C68 AS DateTime), CAST(0x2C3E0B00 AS Date), CAST(0x0000A8D100C92688 AS DateTime), 20000, N'NGAN', N'Không')
INSERT [dbo].[GIAODICH] ([MaGiaoDich], [TenTaiKhoan], [NgayBatDau], [GioBatDau], [NgayGiaoDich], [ThoiGianGiaoDich], [SoTienGiaoDich], [NhanVien], [GhiChu]) VALUES (N'02', N'PHU', CAST(0x393E0B00 AS Date), CAST(0x0000A9AD00000000 AS DateTime), CAST(0x1B3E0B00 AS Date), CAST(0x0000A8C000000000 AS DateTime), 50000, N'LIEN', N'Không')
