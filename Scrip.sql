USE [NhaSach]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 6/17/2022 12:20:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[madon] [int] NOT NULL,
	[masach] [int] NOT NULL,
	[soluong] [int] NULL,
	[gia] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[madon] ASC,
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 6/17/2022 12:20:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[madon] [int] IDENTITY(1,1) NOT NULL,
	[thanhtoan] [bit] NULL,
	[giaohang] [bit] NULL,
	[ngaydat] [date] NULL,
	[ngaygiao] [date] NULL,
	[makh] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[madon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/17/2022 12:20:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[makh] [int] IDENTITY(1,1) NOT NULL,
	[hoten] [nvarchar](50) NULL,
	[tendangnhap] [varchar](20) NULL,
	[matkhau] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[diachi] [nvarchar](100) NULL,
	[dienthoai] [varchar](15) NULL,
	[ngaysinh] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[makh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 6/17/2022 12:20:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[masach] [int] IDENTITY(1,1) NOT NULL,
	[maloai] [int] NULL,
	[tensach] [nvarchar](100) NOT NULL,
	[mota] [nvarchar](100) NULL,
	[hinh] [varchar](50) NULL,
	[giaban] [decimal](18, 0) NULL,
	[ngaycapnhat] [smalldatetime] NULL,
	[soluongton] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 6/17/2022 12:20:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[maloai] [int] IDENTITY(1,1) NOT NULL,
	[tenloai] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[maloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([madon])
REFERENCES [dbo].[DonHang] ([madon])
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([masach])
REFERENCES [dbo].[Sach] ([masach])
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD FOREIGN KEY([makh])
REFERENCES [dbo].[KhachHang] ([makh])
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([maloai])
REFERENCES [dbo].[TheLoai] ([maloai])
GO
