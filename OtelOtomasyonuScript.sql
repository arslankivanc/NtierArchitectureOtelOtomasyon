USE [master]
GO
/****** Object:  Database [OtelOtomasyon]    Script Date: 13.01.2019 01:34:49 ******/
CREATE DATABASE [OtelOtomasyon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OtelOtomasyon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\OtelOtomasyon.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OtelOtomasyon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\OtelOtomasyon_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OtelOtomasyon] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OtelOtomasyon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OtelOtomasyon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET ARITHABORT OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OtelOtomasyon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OtelOtomasyon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OtelOtomasyon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OtelOtomasyon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET RECOVERY FULL 
GO
ALTER DATABASE [OtelOtomasyon] SET  MULTI_USER 
GO
ALTER DATABASE [OtelOtomasyon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OtelOtomasyon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OtelOtomasyon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OtelOtomasyon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OtelOtomasyon] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'OtelOtomasyon', N'ON'
GO
ALTER DATABASE [OtelOtomasyon] SET QUERY_STORE = OFF
GO
USE [OtelOtomasyon]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [OtelOtomasyon]
GO
/****** Object:  Table [dbo].[BirimTipleri]    Script Date: 13.01.2019 01:34:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BirimTipleri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_BirimTipleri] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoluOda]    Script Date: 13.01.2019 01:34:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoluOda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MusteriID] [int] NOT NULL,
	[OdaID] [int] NOT NULL,
 CONSTRAINT [PK_DoluOda] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kasa]    Script Date: 13.01.2019 01:34:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kasa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NULL,
	[Aciklama] [nvarchar](500) NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_Kasa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KasaHareket]    Script Date: 13.01.2019 01:34:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KasaHareket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KasaID] [int] NULL,
	[KasaHareketTipID] [int] NOT NULL,
	[Tutar] [money] NULL,
	[Tarih] [datetime] NULL,
	[Kdvsiz] [money] NULL,
 CONSTRAINT [PK_KasaHareket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KasaHareketTip]    Script Date: 13.01.2019 01:34:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KasaHareketTip](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_KasaHareketTip] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategoriler]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategoriler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_Kategoriler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteriler]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteriler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NULL,
	[Soyadi] [nvarchar](50) NULL,
	[SirketAdi] [nvarchar](250) NULL,
	[Tckn] [char](11) NOT NULL,
	[TelNo] [char](14) NULL,
	[DogumTarihi] [date] NULL,
	[MedeniDurum] [tinyint] NULL,
	[Cinsiyet] [tinyint] NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_Musteriler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Odalar]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Odalar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[Aciklama] [nvarchar](500) NULL,
	[OdaTurID] [int] NOT NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_Odalar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OdaOzellikleri]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OdaOzellikleri](
	[OdaID] [int] NOT NULL,
	[OzellikID] [int] NOT NULL,
	[Deger] [smallint] NULL,
 CONSTRAINT [PK_OdaOzellikleri] PRIMARY KEY CLUSTERED 
(
	[OdaID] ASC,
	[OzellikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OdaTurleri]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OdaTurleri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](150) NOT NULL,
	[Aciklama] [nvarchar](500) NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_Odaturleri] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ozellikler]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ozellikler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NULL,
	[Aciklama] [nvarchar](500) NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_Ozellikler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personeller]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personeller](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NULL,
	[Soyadi] [nvarchar](50) NULL,
	[Tckn] [char](11) NOT NULL,
	[TelNo] [char](14) NULL,
	[Adres] [nvarchar](500) NULL,
	[DogumTarihi] [date] NULL,
	[IseGirisTarihi] [datetime] NULL,
	[Maas] [money] NULL,
	[KullaniciAdi] [nvarchar](50) NOT NULL,
	[Parola] [nvarchar](15) NOT NULL,
	[Aktif] [bit] NOT NULL,
	[YetkiID] [int] NOT NULL,
 CONSTRAINT [PK_Personeller] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatinAlma]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatinAlma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TedarikciID] [int] NULL,
	[SatinAlmaTarihi] [date] NULL,
	[PersonelID] [int] NULL,
 CONSTRAINT [PK_SatinAlma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatinAlmaDetay]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatinAlmaDetay](
	[SatinAlmaID] [int] NOT NULL,
	[UrunID] [int] NOT NULL,
	[Miktar] [float] NULL,
	[AlisFiyati] [money] NULL,
 CONSTRAINT [PK_SatinAlmaDetay] PRIMARY KEY CLUSTERED 
(
	[SatinAlmaID] ASC,
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Satis]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satis](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MusteriID] [int] NOT NULL,
	[PersonelID] [int] NOT NULL,
	[OdaID] [int] NOT NULL,
	[OdaFiyati] [money] NULL,
	[SatisTarihi] [datetime] NULL,
 CONSTRAINT [PK_Satis] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatisDetay]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatisDetay](
	[SatisID] [int] NOT NULL,
	[UrunID] [int] NOT NULL,
	[Miktar] [float] NULL,
	[Fiyat] [money] NULL,
	[Indirim] [float] NULL,
 CONSTRAINT [PK_SatisDetay] PRIMARY KEY CLUSTERED 
(
	[SatisID] ASC,
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tedarikciler]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tedarikciler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NULL,
	[Soyadi] [nvarchar](50) NULL,
	[SirketAdi] [nvarchar](250) NULL,
	[TelNo] [char](14) NULL,
	[Adres] [nvarchar](500) NULL,
	[Mail] [nvarchar](50) NULL,
	[Aktif] [bit] NULL,
 CONSTRAINT [PK_Tedarikciler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urunler]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NULL,
	[Fiyat] [money] NULL,
	[Miktar] [float] NULL,
	[KategoriID] [int] NULL,
	[BirimTipID] [int] NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_Urunler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yetki]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yetki](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[YetkiAdi] [nvarchar](50) NULL,
 CONSTRAINT [PK_Yetki] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BirimTipleri] ON 

INSERT [dbo].[BirimTipleri] ([Id], [Adi], [Aktif]) VALUES (1, N'Adet', 1)
INSERT [dbo].[BirimTipleri] ([Id], [Adi], [Aktif]) VALUES (3, N'Miktar', 1)
INSERT [dbo].[BirimTipleri] ([Id], [Adi], [Aktif]) VALUES (8, N'Kg', 1)
SET IDENTITY_INSERT [dbo].[BirimTipleri] OFF
SET IDENTITY_INSERT [dbo].[Kasa] ON 

INSERT [dbo].[Kasa] ([Id], [Adi], [Aciklama], [Aktif]) VALUES (1, N'Nakit Kasa', N'Şirket içi Fiziksel Kasa', 1)
INSERT [dbo].[Kasa] ([Id], [Adi], [Aciklama], [Aktif]) VALUES (2, N'Banka Hesabı', N'Ziraat Banka Hesabı', 1)
INSERT [dbo].[Kasa] ([Id], [Adi], [Aciklama], [Aktif]) VALUES (4, N'Deneme Kasa', N'', 1)
INSERT [dbo].[Kasa] ([Id], [Adi], [Aciklama], [Aktif]) VALUES (5, N'Denem Kasa', N'', 0)
SET IDENTITY_INSERT [dbo].[Kasa] OFF
SET IDENTITY_INSERT [dbo].[KasaHareket] ON 

INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (13, 2, 2, 2500.0000, CAST(N'2019-01-07T00:31:19.597' AS DateTime), 2050.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (14, 2, 1, 400.0000, CAST(N'2019-01-07T01:27:01.220' AS DateTime), 328.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (40, 2, 1, 80.0000, CAST(N'2019-01-07T03:36:36.073' AS DateTime), 65.6000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (50, 2, 1, 500.0000, CAST(N'2019-01-07T18:05:18.350' AS DateTime), 410.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (51, 2, 1, 20.0000, CAST(N'2019-01-07T18:10:16.507' AS DateTime), 16.4000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (52, 2, 2, 400.0000, CAST(N'2019-01-07T19:06:58.760' AS DateTime), 328.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (53, 2, 2, 200.0000, CAST(N'2019-01-07T19:11:12.163' AS DateTime), 164.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (60, 2, 1, 50.0000, CAST(N'2019-01-09T17:09:55.933' AS DateTime), 41.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (68, 2, 2, 15000.0000, CAST(N'2019-01-10T01:02:05.343' AS DateTime), 12300.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (69, 2, 2, 22.0000, CAST(N'2019-01-10T17:05:36.063' AS DateTime), 18.0400)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (70, 2, 1, 50.0000, CAST(N'2019-01-11T21:00:02.487' AS DateTime), 41.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (71, 2, 1, 50.0000, CAST(N'2019-01-11T21:59:18.713' AS DateTime), 41.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (72, 2, 1, 88.0000, CAST(N'2019-01-11T22:14:32.690' AS DateTime), 72.1600)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (73, 2, 1, 99.0000, CAST(N'2019-01-11T23:04:47.013' AS DateTime), 81.1800)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (74, 2, 1, 41.8000, CAST(N'2019-01-11T23:05:28.603' AS DateTime), 34.2760)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (75, 2, 1, 9.5000, CAST(N'2019-01-11T23:05:28.650' AS DateTime), 7.7900)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (76, 2, 1, 22.0000, CAST(N'2019-01-11T23:08:03.510' AS DateTime), 18.0400)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (77, 2, 1, 50.0000, CAST(N'2019-01-11T23:08:03.553' AS DateTime), 41.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (78, 2, 1, 20.0000, CAST(N'2019-01-11T23:08:03.587' AS DateTime), 16.4000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (79, 2, 1, 10.0000, CAST(N'2019-01-11T23:08:03.613' AS DateTime), 8.2000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (80, 2, 1, 10.0000, CAST(N'2019-01-11T23:09:44.070' AS DateTime), 8.2000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (81, 2, 1, 50.0000, CAST(N'2019-01-11T23:12:55.513' AS DateTime), 41.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (82, 2, 1, 50.0000, CAST(N'2019-01-11T23:13:18.433' AS DateTime), 41.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (83, 2, 1, 10.0000, CAST(N'2019-01-11T23:15:53.497' AS DateTime), 8.2000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (84, 2, 1, 40.0000, CAST(N'2019-01-12T21:46:25.017' AS DateTime), 32.8000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (85, 2, 1, 54.0000, CAST(N'2019-01-12T23:15:45.163' AS DateTime), 44.2800)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (86, 2, 1, 120.0000, CAST(N'2019-01-12T23:15:45.207' AS DateTime), 98.4000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (87, 2, 1, 10.0000, CAST(N'2019-01-12T23:18:48.830' AS DateTime), 8.2000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (88, 2, 1, 50.0000, CAST(N'2019-01-12T23:19:12.913' AS DateTime), 41.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (89, 2, 1, 20.0000, CAST(N'2019-01-12T23:19:12.943' AS DateTime), 16.4000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (90, 2, 1, 10.0000, CAST(N'2019-01-12T23:19:12.973' AS DateTime), 8.2000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (91, 1, 1, 0.0000, CAST(N'2019-01-12T23:32:20.210' AS DateTime), 0.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (92, 1, 1, 50000.0000, CAST(N'2019-01-12T23:41:24.200' AS DateTime), 0.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (93, 2, 2, 2000.0000, CAST(N'2019-01-13T01:01:59.973' AS DateTime), 1640.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (94, 2, 2, 500.0000, CAST(N'2019-01-13T01:02:00.023' AS DateTime), 410.0000)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (95, 2, 1, 36.0000, CAST(N'2019-01-13T01:04:07.747' AS DateTime), 29.5200)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (96, 2, 1, 36.0000, CAST(N'2019-01-13T01:05:38.103' AS DateTime), 29.5200)
INSERT [dbo].[KasaHareket] ([Id], [KasaID], [KasaHareketTipID], [Tutar], [Tarih], [Kdvsiz]) VALUES (97, 2, 1, 90.0000, CAST(N'2019-01-13T01:05:38.140' AS DateTime), 73.8000)
SET IDENTITY_INSERT [dbo].[KasaHareket] OFF
SET IDENTITY_INSERT [dbo].[KasaHareketTip] ON 

INSERT [dbo].[KasaHareketTip] ([Id], [Adi], [Aktif]) VALUES (1, N'Gelir', 1)
INSERT [dbo].[KasaHareketTip] ([Id], [Adi], [Aktif]) VALUES (2, N'Gider', 1)
INSERT [dbo].[KasaHareketTip] ([Id], [Adi], [Aktif]) VALUES (6, N'Alacak Hesaplar', 0)
SET IDENTITY_INSERT [dbo].[KasaHareketTip] OFF
SET IDENTITY_INSERT [dbo].[Kategoriler] ON 

INSERT [dbo].[Kategoriler] ([Id], [Adi], [Aktif]) VALUES (1, N'Günlük Ürünler', 1)
INSERT [dbo].[Kategoriler] ([Id], [Adi], [Aktif]) VALUES (2, N'Kahvaltı', 0)
INSERT [dbo].[Kategoriler] ([Id], [Adi], [Aktif]) VALUES (3, N'Eğlence', 1)
INSERT [dbo].[Kategoriler] ([Id], [Adi], [Aktif]) VALUES (5, N'Günlük Çekiliş', 1)
INSERT [dbo].[Kategoriler] ([Id], [Adi], [Aktif]) VALUES (6, N'Deneme Ad', 1)
INSERT [dbo].[Kategoriler] ([Id], [Adi], [Aktif]) VALUES (7, N'Eglence', 0)
INSERT [dbo].[Kategoriler] ([Id], [Adi], [Aktif]) VALUES (8, N'Oda Servisi', 1)
INSERT [dbo].[Kategoriler] ([Id], [Adi], [Aktif]) VALUES (9, N'Fsdfdsf', 0)
SET IDENTITY_INSERT [dbo].[Kategoriler] OFF
SET IDENTITY_INSERT [dbo].[Musteriler] ON 

INSERT [dbo].[Musteriler] ([Id], [Adi], [Soyadi], [SirketAdi], [Tckn], [TelNo], [DogumTarihi], [MedeniDurum], [Cinsiyet], [Aktif]) VALUES (1, N'Kıvanç', N'Arslan', N'Dynamics 365', N'41710706714', N'(546) 939-7778', CAST(N'1990-01-01' AS Date), 1, 2, 1)
INSERT [dbo].[Musteriler] ([Id], [Adi], [Soyadi], [SirketAdi], [Tckn], [TelNo], [DogumTarihi], [MedeniDurum], [Cinsiyet], [Aktif]) VALUES (2, N'Deneme', N'Soyad', N'Deneme', N'36465268426', N'(546) 887-8525', CAST(N'1989-02-01' AS Date), 2, 1, 1)
INSERT [dbo].[Musteriler] ([Id], [Adi], [Soyadi], [SirketAdi], [Tckn], [TelNo], [DogumTarihi], [MedeniDurum], [Cinsiyet], [Aktif]) VALUES (10, N'İsim', N'Soyisim', N'Sirket', N'49016744218', N'(344) 234-2461', CAST(N'1988-12-30' AS Date), 1, 1, 1)
INSERT [dbo].[Musteriler] ([Id], [Adi], [Soyadi], [SirketAdi], [Tckn], [TelNo], [DogumTarihi], [MedeniDurum], [Cinsiyet], [Aktif]) VALUES (12, N'Musteri', N'Deneme', N'Musterideneme', N'34821854320', N'(333) 333-3333', CAST(N'1998-12-28' AS Date), 1, 2, 1)
SET IDENTITY_INSERT [dbo].[Musteriler] OFF
SET IDENTITY_INSERT [dbo].[Odalar] ON 

INSERT [dbo].[Odalar] ([Id], [Adi], [Aciklama], [OdaTurID], [Aktif]) VALUES (1, N'1', N'1 numaralı oda', 1, 1)
INSERT [dbo].[Odalar] ([Id], [Adi], [Aciklama], [OdaTurID], [Aktif]) VALUES (2, N'5', N'5 numaralı oda', 1, 1)
INSERT [dbo].[Odalar] ([Id], [Adi], [Aciklama], [OdaTurID], [Aktif]) VALUES (3, N'110', N'110 numaralı oda', 1, 1)
INSERT [dbo].[Odalar] ([Id], [Adi], [Aciklama], [OdaTurID], [Aktif]) VALUES (4, N'122 Suit', N'Suit', 2, 1)
INSERT [dbo].[Odalar] ([Id], [Adi], [Aciklama], [OdaTurID], [Aktif]) VALUES (5, N'111', N'', 1, 0)
INSERT [dbo].[Odalar] ([Id], [Adi], [Aciklama], [OdaTurID], [Aktif]) VALUES (6, N'4', N'', 1, 1)
INSERT [dbo].[Odalar] ([Id], [Adi], [Aciklama], [OdaTurID], [Aktif]) VALUES (7, N'161', N'161 Nolu Oda', 2, 1)
INSERT [dbo].[Odalar] ([Id], [Adi], [Aciklama], [OdaTurID], [Aktif]) VALUES (8, N'149', N'150 Nolu', 2, 1)
INSERT [dbo].[Odalar] ([Id], [Adi], [Aciklama], [OdaTurID], [Aktif]) VALUES (9, N'170', N'sad', 1, 0)
SET IDENTITY_INSERT [dbo].[Odalar] OFF
INSERT [dbo].[OdaOzellikleri] ([OdaID], [OzellikID], [Deger]) VALUES (2, 1, 2)
INSERT [dbo].[OdaOzellikleri] ([OdaID], [OzellikID], [Deger]) VALUES (2, 2, 0)
INSERT [dbo].[OdaOzellikleri] ([OdaID], [OzellikID], [Deger]) VALUES (2, 4, 2)
INSERT [dbo].[OdaOzellikleri] ([OdaID], [OzellikID], [Deger]) VALUES (3, 2, 0)
INSERT [dbo].[OdaOzellikleri] ([OdaID], [OzellikID], [Deger]) VALUES (3, 4, 8)
SET IDENTITY_INSERT [dbo].[OdaTurleri] ON 

INSERT [dbo].[OdaTurleri] ([Id], [Adi], [Aciklama], [Aktif]) VALUES (1, N'Tek Kişilik Oda', N'Mevcut Kapasite', 1)
INSERT [dbo].[OdaTurleri] ([Id], [Adi], [Aciklama], [Aktif]) VALUES (2, N'Çift Kişilik Oda', N'Kapasite', 1)
INSERT [dbo].[OdaTurleri] ([Id], [Adi], [Aciklama], [Aktif]) VALUES (3, N'8 Kişilik Room', N'Büyük Huge', 1)
SET IDENTITY_INSERT [dbo].[OdaTurleri] OFF
SET IDENTITY_INSERT [dbo].[Ozellikler] ON 

INSERT [dbo].[Ozellikler] ([Id], [Adi], [Aciklama], [Aktif]) VALUES (1, N'Banyo', N'', 1)
INSERT [dbo].[Ozellikler] ([Id], [Adi], [Aciklama], [Aktif]) VALUES (2, N'Televizyon', N'', 1)
INSERT [dbo].[Ozellikler] ([Id], [Adi], [Aciklama], [Aktif]) VALUES (3, N'Güney Cephe', N'', 1)
INSERT [dbo].[Ozellikler] ([Id], [Adi], [Aciklama], [Aktif]) VALUES (4, N'Kat Numarası', N'', 1)
INSERT [dbo].[Ozellikler] ([Id], [Adi], [Aciklama], [Aktif]) VALUES (5, N'İnternet', N'Yok', 1)
SET IDENTITY_INSERT [dbo].[Ozellikler] OFF
SET IDENTITY_INSERT [dbo].[Personeller] ON 

INSERT [dbo].[Personeller] ([Id], [Adi], [Soyadi], [Tckn], [TelNo], [Adres], [DogumTarihi], [IseGirisTarihi], [Maas], [KullaniciAdi], [Parola], [Aktif], [YetkiID]) VALUES (1, N'Super', N'Yetki', N'24098490758', N'(444) 544-5454', N'Çarşıbaşı/Trabzon', CAST(N'1993-01-01' AS Date), CAST(N'2018-01-01T20:55:22.000' AS DateTime), 2500.0000, N'Super', N'123456', 1, 1)
INSERT [dbo].[Personeller] ([Id], [Adi], [Soyadi], [Tckn], [TelNo], [Adres], [DogumTarihi], [IseGirisTarihi], [Maas], [KullaniciAdi], [Parola], [Aktif], [YetkiID]) VALUES (2, N'Personel', N'Calisan', N'15512480332', N'(242) 342-3424', N'İstanbul', CAST(N'1995-11-24' AS Date), CAST(N'2019-01-03T11:24:38.000' AS DateTime), 2222.0000, N'Personel', N'123456', 1, 3)
INSERT [dbo].[Personeller] ([Id], [Adi], [Soyadi], [Tckn], [TelNo], [Adres], [DogumTarihi], [IseGirisTarihi], [Maas], [KullaniciAdi], [Parola], [Aktif], [YetkiID]) VALUES (3, N'Admin', N'Müdür', N'99706187276', N'(234) 242-4242', N'İstanbul', CAST(N'1980-01-03' AS Date), CAST(N'2019-01-03T11:42:24.000' AS DateTime), 5555.0000, N'Admin', N'123456', 1, 2)
INSERT [dbo].[Personeller] ([Id], [Adi], [Soyadi], [Tckn], [TelNo], [Adres], [DogumTarihi], [IseGirisTarihi], [Maas], [KullaniciAdi], [Parola], [Aktif], [YetkiID]) VALUES (11, N'Personel', N'Persoyad', N'75929188290', N'(234) 444-4444', N'İstanbul Beşiktaş', CAST(N'1988-12-27' AS Date), CAST(N'2019-01-10T00:40:35.383' AS DateTime), 4500.0000, N'Per', N'123456', 0, 3)
SET IDENTITY_INSERT [dbo].[Personeller] OFF
SET IDENTITY_INSERT [dbo].[SatinAlma] ON 

INSERT [dbo].[SatinAlma] ([Id], [TedarikciID], [SatinAlmaTarihi], [PersonelID]) VALUES (33, 1, CAST(N'2019-01-07' AS Date), 1)
INSERT [dbo].[SatinAlma] ([Id], [TedarikciID], [SatinAlmaTarihi], [PersonelID]) VALUES (34, 1, CAST(N'2019-01-10' AS Date), 1)
INSERT [dbo].[SatinAlma] ([Id], [TedarikciID], [SatinAlmaTarihi], [PersonelID]) VALUES (35, 1, CAST(N'2019-01-10' AS Date), 1)
INSERT [dbo].[SatinAlma] ([Id], [TedarikciID], [SatinAlmaTarihi], [PersonelID]) VALUES (36, 1, CAST(N'2019-01-13' AS Date), 1)
INSERT [dbo].[SatinAlma] ([Id], [TedarikciID], [SatinAlmaTarihi], [PersonelID]) VALUES (37, 1, CAST(N'2019-01-13' AS Date), 1)
SET IDENTITY_INSERT [dbo].[SatinAlma] OFF
INSERT [dbo].[SatinAlmaDetay] ([SatinAlmaID], [UrunID], [Miktar], [AlisFiyati]) VALUES (33, 1, 10, 40.0000)
INSERT [dbo].[SatinAlmaDetay] ([SatinAlmaID], [UrunID], [Miktar], [AlisFiyati]) VALUES (33, 2, 20, 10.0000)
INSERT [dbo].[SatinAlmaDetay] ([SatinAlmaID], [UrunID], [Miktar], [AlisFiyati]) VALUES (34, 3, 5, 3000.0000)
INSERT [dbo].[SatinAlmaDetay] ([SatinAlmaID], [UrunID], [Miktar], [AlisFiyati]) VALUES (35, 4, 1, 22.0000)
INSERT [dbo].[SatinAlmaDetay] ([SatinAlmaID], [UrunID], [Miktar], [AlisFiyati]) VALUES (37, 2, 100, 20.0000)
INSERT [dbo].[SatinAlmaDetay] ([SatinAlmaID], [UrunID], [Miktar], [AlisFiyati]) VALUES (37, 3, 50, 10.0000)
SET IDENTITY_INSERT [dbo].[Satis] ON 

INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (56, 1, 1, 5, 100.0000, CAST(N'2019-01-07T18:03:24.537' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (72, 1, 1, 3, 99.0000, CAST(N'2019-01-11T23:04:45.760' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (73, 1, 1, 3, 0.0000, CAST(N'2019-01-11T23:05:22.233' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (74, 1, 1, 3, 0.0000, CAST(N'2019-01-11T23:08:02.493' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (75, 1, 1, 3, 0.0000, CAST(N'2019-01-11T23:09:42.960' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (76, 1, 1, 3, 0.0000, CAST(N'2019-01-11T23:12:54.403' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (77, 1, 1, 3, 0.0000, CAST(N'2019-01-11T23:13:17.050' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (78, 1, 1, 1, 0.0000, CAST(N'2019-01-11T23:15:48.983' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (79, 1, 1, 1, 0.0000, CAST(N'2019-01-11T23:15:52.273' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (80, 1, 1, 1, 0.0000, CAST(N'2019-01-12T21:45:37.193' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (81, 1, 1, 1, 0.0000, CAST(N'2019-01-12T21:46:23.787' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (82, 1, 2, 1, 0.0000, CAST(N'2019-01-12T23:15:43.733' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (83, 2, 2, 1, 0.0000, CAST(N'2019-01-12T23:18:47.963' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (84, 2, 2, 1, 0.0000, CAST(N'2019-01-12T23:19:11.837' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (85, 12, 1, 3, 0.0000, CAST(N'2019-01-13T01:04:05.440' AS DateTime))
INSERT [dbo].[Satis] ([Id], [MusteriID], [PersonelID], [OdaID], [OdaFiyati], [SatisTarihi]) VALUES (86, 12, 1, 3, 0.0000, CAST(N'2019-01-13T01:05:21.983' AS DateTime))
SET IDENTITY_INSERT [dbo].[Satis] OFF
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (73, 3, 1, 10.0000, 5)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (73, 4, 2, 22.0000, 5)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (74, 1, 1, 50.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (74, 2, 1, 20.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (74, 3, 1, 10.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (74, 4, 1, 22.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (75, 3, 1, 10.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (76, 1, 1, 50.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (77, 1, 1, 50.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (79, 3, 1, 10.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (80, 4, 2, 22.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (81, 2, 2, 20.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (82, 1, 3, 50.0000, 20)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (82, 2, 3, 20.0000, 10)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (83, 3, 1, 10.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (83, 4, 2, 22.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (84, 1, 1, 50.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (84, 2, 1, 20.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (84, 3, 1, 10.0000, 0)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (85, 2, 2, 20.0000, 10)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (85, 4, 2, 22.0000, 10)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (86, 1, 3, 50.0000, 40)
INSERT [dbo].[SatisDetay] ([SatisID], [UrunID], [Miktar], [Fiyat], [Indirim]) VALUES (86, 2, 2, 20.0000, 10)
SET IDENTITY_INSERT [dbo].[Tedarikciler] ON 

INSERT [dbo].[Tedarikciler] ([Id], [Adi], [Soyadi], [SirketAdi], [TelNo], [Adres], [Mail], [Aktif]) VALUES (1, N'Margarine', N'Unie', N'Dove', N'(655) 656-5656', N'İstanbul', N'margarin@gmail.com', 1)
INSERT [dbo].[Tedarikciler] ([Id], [Adi], [Soyadi], [SirketAdi], [TelNo], [Adres], [Mail], [Aktif]) VALUES (2, N'Balık', N'Yemek', N'Black Sea', N'(545) 887-5478', N'Maltepe   Fısfısevler  Zartzurt Sok. No:61 İstanbul', N'balik@gmail.com', 1)
INSERT [dbo].[Tedarikciler] ([Id], [Adi], [Soyadi], [SirketAdi], [TelNo], [Adres], [Mail], [Aktif]) VALUES (3, N'Bill', N'Gat', N'It', N'(213) 131-2313', N'', N'deneme@gmail.com', 0)
INSERT [dbo].[Tedarikciler] ([Id], [Adi], [Soyadi], [SirketAdi], [TelNo], [Adres], [Mail], [Aktif]) VALUES (4, N'Deneme', N'Densoyad', N'Deneme', N'(231) 313-1313', N'Ankara', N'asaad@gmail.com', 0)
INSERT [dbo].[Tedarikciler] ([Id], [Adi], [Soyadi], [SirketAdi], [TelNo], [Adres], [Mail], [Aktif]) VALUES (5, N'Altın', N'Başak', N'Altınbaşak', N'(323) 432-4234', N'Denizli / Türkiye', N'altinbasak@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[Tedarikciler] OFF
SET IDENTITY_INSERT [dbo].[Urunler] ON 

INSERT [dbo].[Urunler] ([Id], [Adi], [Fiyat], [Miktar], [KategoriID], [BirimTipID], [Aktif]) VALUES (1, N'Havlu', 50.0000, 256, 1, 1, 1)
INSERT [dbo].[Urunler] ([Id], [Adi], [Fiyat], [Miktar], [KategoriID], [BirimTipID], [Aktif]) VALUES (2, N'Şampuan', 20.0000, 533, 1, 1, 1)
INSERT [dbo].[Urunler] ([Id], [Adi], [Fiyat], [Miktar], [KategoriID], [BirimTipID], [Aktif]) VALUES (3, N'Sigara', 10.0000, 79, 2, 8, 1)
INSERT [dbo].[Urunler] ([Id], [Adi], [Fiyat], [Miktar], [KategoriID], [BirimTipID], [Aktif]) VALUES (4, N'Krem', 22.0000, 1, 1, 1, 1)
INSERT [dbo].[Urunler] ([Id], [Adi], [Fiyat], [Miktar], [KategoriID], [BirimTipID], [Aktif]) VALUES (6, N'Özel Servis', 50.0000, 1, 8, 3, 0)
SET IDENTITY_INSERT [dbo].[Urunler] OFF
SET IDENTITY_INSERT [dbo].[Yetki] ON 

INSERT [dbo].[Yetki] ([Id], [YetkiAdi]) VALUES (1, N'SuperAdmin')
INSERT [dbo].[Yetki] ([Id], [YetkiAdi]) VALUES (2, N'Admin')
INSERT [dbo].[Yetki] ([Id], [YetkiAdi]) VALUES (3, N'Personel')
SET IDENTITY_INSERT [dbo].[Yetki] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Musteriler_Tckn]    Script Date: 13.01.2019 01:34:51 ******/
ALTER TABLE [dbo].[Musteriler] ADD  CONSTRAINT [IX_Musteriler_Tckn] UNIQUE NONCLUSTERED 
(
	[Tckn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Personeller_Tckn]    Script Date: 13.01.2019 01:34:51 ******/
ALTER TABLE [dbo].[Personeller] ADD  CONSTRAINT [IX_Personeller_Tckn] UNIQUE NONCLUSTERED 
(
	[Tckn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BirimTipleri] ADD  CONSTRAINT [DF_BirimTipleri_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
ALTER TABLE [dbo].[Kasa] ADD  CONSTRAINT [DF_Kasa_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
ALTER TABLE [dbo].[KasaHareketTip] ADD  CONSTRAINT [DF_KasaHareketTip_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
ALTER TABLE [dbo].[Kategoriler] ADD  CONSTRAINT [DF_Kategoriler_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
ALTER TABLE [dbo].[Musteriler] ADD  CONSTRAINT [DF_Musteriler_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
ALTER TABLE [dbo].[Odalar] ADD  CONSTRAINT [DF_Odalar_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
ALTER TABLE [dbo].[OdaTurleri] ADD  CONSTRAINT [DF_Odaturleri_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
ALTER TABLE [dbo].[Ozellikler] ADD  CONSTRAINT [DF_Ozellikler_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
ALTER TABLE [dbo].[Personeller] ADD  CONSTRAINT [DF_Personeller_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
ALTER TABLE [dbo].[Satis] ADD  CONSTRAINT [DF_Satis_SatisTarihi]  DEFAULT (getdate()) FOR [SatisTarihi]
GO
ALTER TABLE [dbo].[Tedarikciler] ADD  CONSTRAINT [DF_Tedarikciler_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
ALTER TABLE [dbo].[Urunler] ADD  CONSTRAINT [DF_Urunler_Aktif]  DEFAULT ((1)) FOR [Aktif]
GO
ALTER TABLE [dbo].[KasaHareket]  WITH CHECK ADD  CONSTRAINT [FK_KasaHareket_Kasa] FOREIGN KEY([KasaID])
REFERENCES [dbo].[Kasa] ([Id])
GO
ALTER TABLE [dbo].[KasaHareket] CHECK CONSTRAINT [FK_KasaHareket_Kasa]
GO
ALTER TABLE [dbo].[KasaHareket]  WITH CHECK ADD  CONSTRAINT [FK_KasaHareket_KasaHareketTip] FOREIGN KEY([KasaHareketTipID])
REFERENCES [dbo].[KasaHareketTip] ([Id])
GO
ALTER TABLE [dbo].[KasaHareket] CHECK CONSTRAINT [FK_KasaHareket_KasaHareketTip]
GO
ALTER TABLE [dbo].[Odalar]  WITH CHECK ADD  CONSTRAINT [FK_Odalar_Odaturleri] FOREIGN KEY([OdaTurID])
REFERENCES [dbo].[OdaTurleri] ([Id])
GO
ALTER TABLE [dbo].[Odalar] CHECK CONSTRAINT [FK_Odalar_Odaturleri]
GO
ALTER TABLE [dbo].[OdaOzellikleri]  WITH CHECK ADD  CONSTRAINT [FK_OdaOzellikleri_Odalar] FOREIGN KEY([OdaID])
REFERENCES [dbo].[Odalar] ([Id])
GO
ALTER TABLE [dbo].[OdaOzellikleri] CHECK CONSTRAINT [FK_OdaOzellikleri_Odalar]
GO
ALTER TABLE [dbo].[OdaOzellikleri]  WITH CHECK ADD  CONSTRAINT [FK_OdaOzellikleri_Ozellikler] FOREIGN KEY([OzellikID])
REFERENCES [dbo].[Ozellikler] ([Id])
GO
ALTER TABLE [dbo].[OdaOzellikleri] CHECK CONSTRAINT [FK_OdaOzellikleri_Ozellikler]
GO
ALTER TABLE [dbo].[Personeller]  WITH CHECK ADD  CONSTRAINT [FK_Personeller_Yetki] FOREIGN KEY([YetkiID])
REFERENCES [dbo].[Yetki] ([Id])
GO
ALTER TABLE [dbo].[Personeller] CHECK CONSTRAINT [FK_Personeller_Yetki]
GO
ALTER TABLE [dbo].[SatinAlma]  WITH CHECK ADD  CONSTRAINT [FK_SatinAlma_Personeller] FOREIGN KEY([PersonelID])
REFERENCES [dbo].[Personeller] ([Id])
GO
ALTER TABLE [dbo].[SatinAlma] CHECK CONSTRAINT [FK_SatinAlma_Personeller]
GO
ALTER TABLE [dbo].[SatinAlma]  WITH CHECK ADD  CONSTRAINT [FK_SatinAlma_Tedarikciler] FOREIGN KEY([TedarikciID])
REFERENCES [dbo].[Tedarikciler] ([Id])
GO
ALTER TABLE [dbo].[SatinAlma] CHECK CONSTRAINT [FK_SatinAlma_Tedarikciler]
GO
ALTER TABLE [dbo].[SatinAlmaDetay]  WITH CHECK ADD  CONSTRAINT [FK_SatinAlmaDetay_SatinAlma] FOREIGN KEY([SatinAlmaID])
REFERENCES [dbo].[SatinAlma] ([Id])
GO
ALTER TABLE [dbo].[SatinAlmaDetay] CHECK CONSTRAINT [FK_SatinAlmaDetay_SatinAlma]
GO
ALTER TABLE [dbo].[SatinAlmaDetay]  WITH CHECK ADD  CONSTRAINT [FK_SatinAlmaDetay_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([Id])
GO
ALTER TABLE [dbo].[SatinAlmaDetay] CHECK CONSTRAINT [FK_SatinAlmaDetay_Urunler]
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Musteriler] FOREIGN KEY([MusteriID])
REFERENCES [dbo].[Musteriler] ([Id])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Musteriler]
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Odalar] FOREIGN KEY([OdaID])
REFERENCES [dbo].[Odalar] ([Id])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Odalar]
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Personeller] FOREIGN KEY([PersonelID])
REFERENCES [dbo].[Personeller] ([Id])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Personeller]
GO
ALTER TABLE [dbo].[SatisDetay]  WITH CHECK ADD  CONSTRAINT [FK_SatisDetay_Satis] FOREIGN KEY([SatisID])
REFERENCES [dbo].[Satis] ([Id])
GO
ALTER TABLE [dbo].[SatisDetay] CHECK CONSTRAINT [FK_SatisDetay_Satis]
GO
ALTER TABLE [dbo].[SatisDetay]  WITH CHECK ADD  CONSTRAINT [FK_SatisDetay_Urunler] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urunler] ([Id])
GO
ALTER TABLE [dbo].[SatisDetay] CHECK CONSTRAINT [FK_SatisDetay_Urunler]
GO
ALTER TABLE [dbo].[Urunler]  WITH CHECK ADD  CONSTRAINT [FK_Urunler_BirimTipleri] FOREIGN KEY([BirimTipID])
REFERENCES [dbo].[BirimTipleri] ([Id])
GO
ALTER TABLE [dbo].[Urunler] CHECK CONSTRAINT [FK_Urunler_BirimTipleri]
GO
ALTER TABLE [dbo].[Urunler]  WITH CHECK ADD  CONSTRAINT [FK_Urunler_Kategoriler] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[Kategoriler] ([Id])
GO
ALTER TABLE [dbo].[Urunler] CHECK CONSTRAINT [FK_Urunler_Kategoriler]
GO
ALTER TABLE [dbo].[Musteriler]  WITH CHECK ADD  CONSTRAINT [CK_Musteriler_DogumTarihi] CHECK  (([DogumTarihi]<getdate()))
GO
ALTER TABLE [dbo].[Musteriler] CHECK CONSTRAINT [CK_Musteriler_DogumTarihi]
GO
ALTER TABLE [dbo].[Personeller]  WITH CHECK ADD  CONSTRAINT [CK_Personeller_DogumTarihi] CHECK  (([DogumTarihi]<getdate()))
GO
ALTER TABLE [dbo].[Personeller] CHECK CONSTRAINT [CK_Personeller_DogumTarihi]
GO
/****** Object:  StoredProcedure [dbo].[prc_Admin_Select]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Admin_Select]
as
select * from Yetki where Yetki.Id=2 and Yetki.Id=3
GO
/****** Object:  StoredProcedure [dbo].[prc_BirimTipleri_Delete]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_BirimTipleri_Delete]
@Id int
as
update BirimTipleri set Aktif=0 where Id=@Id
 
GO
/****** Object:  StoredProcedure [dbo].[prc_BirimTipleri_Insert]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_BirimTipleri_Insert]
@Adi nvarchar(50),
@Aktif bit
as
if(exists(select *from BirimTipleri where Adi=LTRIM(rtrim(@Adi))))
begin
update BirimTipleri set Aktif=1 where Adi=@Adi
end
else
begin
insert BirimTipleri values(@Adi,@Aktif)
end
GO
/****** Object:  StoredProcedure [dbo].[prc_BirimTipleri_Select]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_BirimTipleri_Select]
as
select * from BirimTipleri where Aktif=1
GO
/****** Object:  StoredProcedure [dbo].[prc_BirimTipleri_Updated]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_BirimTipleri_Updated]
@Id int,
@Adi nvarchar(50),
@Aktif bit
as
update BirimTipleri set Adi=@Adi where  Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Kasa_Delete]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Kasa_Delete]
@Id int
as
update Kasa set Aktif =0 where Id=@Id 
GO
/****** Object:  StoredProcedure [dbo].[prc_Kasa_Insert]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[prc_Kasa_Insert]
@Adi nvarchar(50),
@Aciklama nvarchar(500),
@Aktif bit
as
if(exists(select *from Kasa where Adi=LTRIM(rtrim(@Adi))))
begin
update Kasa set Aktif=1 where Adi=@Adi
end
else
begin
insert Kasa values(@Adi,@Aciklama,@Aktif)
end
GO
/****** Object:  StoredProcedure [dbo].[prc_Kasa_Select]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Kasa_Select]
as
select *from Kasa where Aktif=1
GO
/****** Object:  StoredProcedure [dbo].[prc_Kasa_Updated]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Kasa_Updated]
@Id int,
@Adi nvarchar(50),
@Aciklama nvarchar(500),
@Aktif bit
as
update Kasa set Adi=@Adi,Aciklama=@Aciklama where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_KasaHareket_Insert]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_KasaHareket_Insert]
@KasaID int,
@KasaHareketTipID int,
@Tutar money,
@Tarih datetime,
@Kdvsiz money
as
insert KasaHareket values(@KasaID,@KasaHareketTipID,@Tutar,@Tarih,@Kdvsiz)
GO
/****** Object:  StoredProcedure [dbo].[prc_KasaHareket_Select]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_KasaHareket_Select]
as
select kh.Id,(select k.Adi from Kasa k where k.Id=kh.KasaID) as 'Kasa Adı',(select kht.Adi from KasaHareketTip kht where kht.Id=kh.KasaHareketTipID) as 'Kasa Hareketi',kh.Tutar,kh.Tarih from KasaHareket kh order by kh.Tarih desc
GO
/****** Object:  StoredProcedure [dbo].[prc_KasaHareketTip_Delete]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_KasaHareketTip_Delete]
@Id int
as
update KasaHareketTip set Aktif=0 where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_KasaHareketTip_Insert]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_KasaHareketTip_Insert]
@Adi nvarchar(50),
@Aktif bit
as
if(exists(select *from KasaHareketTip where Adi=LTRIM(rtrim(@Adi))))
begin
update KasaHareketTip set Aktif=1 where Adi=@Adi
end
else
begin
insert KasaHareketTip values(@Adi,@Aktif)
end
GO
/****** Object:  StoredProcedure [dbo].[prc_KasaHareketTip_Select]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_KasaHareketTip_Select]
as
select * from KasaHareketTip
GO
/****** Object:  StoredProcedure [dbo].[prc_KasaHareketTip_Updated]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_KasaHareketTip_Updated]
@Id int,
@Adi nvarchar(50),
@Aktif bit
as
update KasaHareketTip set Adi=@Adi where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Kategoriler_Delete]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Kategoriler_Delete]
@Id int
as
update Kategoriler set Aktif=0 where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Kategoriler_Insert]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Kategoriler_Insert]
@Adi nvarchar(50),
@Aktif bit 
as
if(exists(select *from Kategoriler where Adi=LTRIM(rtrim(@Adi))))
begin
update Kategoriler set Aktif=1 where Adi=@Adi
end
else
begin
insert Kategoriler values(@Adi,@Aktif)
end
GO
/****** Object:  StoredProcedure [dbo].[prc_Kategoriler_Select]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Kategoriler_Select]
as
select * from Kategoriler where Aktif=1
GO
/****** Object:  StoredProcedure [dbo].[prc_Kategoriler_Updated]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Kategoriler_Updated]
@Id int,
@Adi nvarchar(50),
@Aktif bit
as
update Kategoriler set Adi=@Adi where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Musteriler_Delete]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Musteriler_Delete]
@Id int
as
update Musteriler set Aktif=0 where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Musteriler_Insert]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Musteriler_Insert]
@Adi nvarchar(50),
@Soyadi nvarchar(50),
@SirketAdi nvarchar(50),
@DogumTarihi date,
@Tckn char(11),
@Telno char(14),
@MedeniDurum tinyint,
@Cinsiyet tinyint,
@Aktif bit
as
if(exists(select *from Musteriler where Tckn=LTRIM(rtrim(@Tckn))))
begin
update Musteriler set Adi=@Adi,Soyadi=@Soyadi,SirketAdi=@SirketAdi,DogumTarihi=@DogumTarihi,Tckn=@Tckn,TelNo=@Telno,MedeniDurum=@MedeniDurum,Cinsiyet=@Cinsiyet,Aktif=@Aktif where Tckn=@Tckn
end
else
begin
insert Musteriler values(@Adi,@Soyadi,@SirketAdi,@Tckn,@Telno,@DogumTarihi,@MedeniDurum,@Cinsiyet,@Aktif)
end
GO
/****** Object:  StoredProcedure [dbo].[prc_Musteriler_Select]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Musteriler_Select]
as
select Id,Adi,Soyadi,SirketAdi,Tckn,TelNo,DogumTarihi, 
case MedeniDurum
when 1 then 'Bekar'
when 2 then 'Evli'
end as MedeniDurum,
case Cinsiyet
when 1 then 'Kadın'
when 2 then 'Erkek'
end as Cinsiyet,
Aktif
from Musteriler where Aktif=1
GO
/****** Object:  StoredProcedure [dbo].[prc_Musteriler_Updated]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Musteriler_Updated]
@Id int,
@Adi nvarchar(50),
@Soyadi nvarchar(50),
@SirketAdi nvarchar(50),
@DogumTarihi date,
@Tckn char(11),
@Telno char(14),
@MedeniDurum tinyint,
@Cinsiyet tinyint,
@Aktif bit
as
update Musteriler set Adi=@Adi,Soyadi=@Soyadi,SirketAdi=@SirketAdi,DogumTarihi=@DogumTarihi,
Tckn=@Tckn,TelNo=@Telno,MedeniDurum=@MedeniDurum,Cinsiyet=@Cinsiyet where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Odalar_Delete]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Odalar_Delete]
@Id int 
as
update Odalar set Aktif=0 where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Odalar_Insert]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Odalar_Insert]
@Adi nvarchar(50),
@Aciklama nvarchar(200),
@OdaTurID int,
@Aktif bit
as
if(exists(select *from Odalar where Adi=LTRIM(rtrim(@Adi))))
begin
update Odalar set Aktif=1 where Adi=@Adi
end
else
begin
insert Odalar values(@Adi,@Aciklama,@OdaTurID,@Aktif)
end
GO
/****** Object:  StoredProcedure [dbo].[prc_Odalar_Select]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Odalar_Select]
as
select * from Odalar where Aktif=1
GO
/****** Object:  StoredProcedure [dbo].[prc_Odalar_Updated]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Odalar_Updated]
@Id int,
@Adi nvarchar(50),
@Aciklama nvarchar(500),
@OdaTurID int,
@Aktif bit
as
update Odalar set Adi=@Adi,Aciklama=@Aciklama,OdaTurID=@OdaTurID where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_OdaOzellikleri_Insert]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_OdaOzellikleri_Insert]
@OdaID int,
@OzellikID int,
@Deger smallint
as
insert OdaOzellikleri values(@OdaID,@OzellikID,@Deger)
GO
/****** Object:  StoredProcedure [dbo].[prc_OdaTurleri_Delete]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_OdaTurleri_Delete]
@Id int
as
update OdaTurleri set Aktif=0 where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_OdaTurleri_Insert]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_OdaTurleri_Insert]
@Adi nvarchar(50),
@Aciklama nvarchar(50),
@Aktif bit
as
if(exists(select *from OdaTurleri where Adi=LTRIM(rtrim(@Adi))))
begin
update OdaTurleri set Aktif=1 where Adi=@Adi
end
else
begin
insert OdaTurleri  values(@Adi,@Aciklama,@Aktif)
end
GO
/****** Object:  StoredProcedure [dbo].[prc_OdaTurleri_Select]    Script Date: 13.01.2019 01:34:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_OdaTurleri_Select]
as
select * from OdaTurleri where Aktif = 1
GO
/****** Object:  StoredProcedure [dbo].[prc_OdaTurleri_Updated]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_OdaTurleri_Updated]
@Id int,
@Adi nvarchar(150),
@Aciklama nvarchar(500),
@Aktif bit
as
update OdaTurleri set Adi=@Adi,Aciklama=@Aciklama where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Ozellikler_Delete]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Ozellikler_Delete]
@Id int
as
update Ozellikler set Aktif=0 where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Ozellikler_Insert]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Ozellikler_Insert]
@Adi nvarchar(50),
@Aciklama nvarchar(250),
@Aktif bit
as
if(exists(select *from Ozellikler where Adi=LTRIM(rtrim(@Adi))))
begin
update Ozellikler set Aktif=1 where Adi=@Adi
end
else
begin
insert Ozellikler values(@Adi,@Aciklama,@Aktif)
end
GO
/****** Object:  StoredProcedure [dbo].[prc_Ozellikler_Select]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Ozellikler_Select]
as
select * from Ozellikler where Aktif=1
GO
/****** Object:  StoredProcedure [dbo].[prc_Ozellikler_Updated]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Ozellikler_Updated]
@Id int,
@Adi nvarchar(50),
@Aciklama nvarchar(500),
@Aktif bit
as
update Ozellikler set Adi=@Adi,Aciklama=@Aciklama where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Personeller_Delete]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Personeller_Delete]
@Id int
as
update Personeller set Aktif=0 where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Personeller_Giris]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Personeller_Giris]
@ka nvarchar(50),
@prl nvarchar(15)
as
select * from Personeller where KullaniciAdi=@ka and Parola=@prl
GO
/****** Object:  StoredProcedure [dbo].[prc_Personeller_Insert]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Personeller_Insert]
@Adi nvarchar(50),
@Soyadi nvarchar(50),
@Tckn char(11),
@TelNo char(15),
@Adres nvarchar(150),
@DogumTarihi date,
@IseGirisTarihi datetime,
@Maas money,
@KullaniciAdi nvarchar(50),
@Parola nvarchar(15),
@Aktif bit,
@YetkiID int
as
if(exists(select *from Personeller where Tckn=LTRIM(rtrim(@Tckn))))
begin
update Personeller set Adi=@Adi,Soyadi=@Soyadi,TelNo=@TelNo,Adres=@Adres,DogumTarihi=@DogumTarihi,IseGirisTarihi=@IseGirisTarihi,Maas=@Maas,KullaniciAdi=@KullaniciAdi,Parola=@Parola,Aktif=@Aktif,YetkiID=@YetkiID where Tckn=@Tckn
end
else
begin
insert Personeller values(@Adi,@Soyadi,@Tckn,@TelNo,
@Adres,@DogumTarihi,@IseGirisTarihi,@Maas,
@KullaniciAdi,@Parola,@Aktif,@YetkiID)
end
GO
/****** Object:  StoredProcedure [dbo].[prc_Personeller_Select]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Personeller_Select]
as
select * from Personeller where Aktif=1
GO
/****** Object:  StoredProcedure [dbo].[prc_Personeller_Updated]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Personeller_Updated]
@Id int,
@Adi nvarchar(50),
@Soyadi nvarchar(50),
@Tckn char(11),
@TelNo char(15),
@Adres nvarchar(150),
@DogumTarihi date,
@IseGirisTarihi datetime,
@Maas money,
@KullaniciAdi nvarchar(50),
@Parola nvarchar(15),
@Aktif bit,
@YetkiID int
as
update Personeller set Adi=@Adi,Soyadi=@Soyadi,Tckn=@Tckn,TelNo=@TelNo,Adres=@Adres,DogumTarihi=@DogumTarihi,
IseGirisTarihi=@IseGirisTarihi,Maas=@Maas,KullaniciAdi=@KullaniciAdi,Parola=@Parola,YetkiID=@YetkiID where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_SatinAlma_Insert]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_SatinAlma_Insert]
@TedarikciID int,
@SatinAlmaTarihi date,
@PersonelID int
as
insert SatinAlma values(@TedarikciID,@SatinAlmaTarihi,@PersonelID)
select SCOPE_Identity()
GO
/****** Object:  StoredProcedure [dbo].[prc_SatinAlmaDetay_Insert]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_SatinAlmaDetay_Insert]
@SatinAlmaID int,
@UrunID int,
@Miktar float,
@AlisFiyati money
as
insert SatinAlmaDetay values(@SatinAlmaID,@UrunID,@Miktar,@AlisFiyati)
GO
/****** Object:  StoredProcedure [dbo].[prc_Satis_Insert]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Satis_Insert]
@MusteriID int,
@OdaID int,
@PersonelID int,
@SatisTarihi datetime,
@OdaFiyati money
as
insert Satis values(@MusteriID,@PersonelID,@OdaID,@OdaFiyati,@SatisTarihi)
select SCOPE_Identity()
GO
/****** Object:  StoredProcedure [dbo].[prc_SatisDetay_Insert]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[prc_SatisDetay_Insert]
@SatisID int,
@UrunID int,
@Miktar float,
@Fiyat money,
@Indirim float
as
insert SatisDetay values(@SatisID,@UrunID,@Miktar,@Fiyat,@Indirim)
GO
/****** Object:  StoredProcedure [dbo].[prc_SatisDetay_Select]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_SatisDetay_Select]
as
select (select m.Adi+' '+m.Soyadi from Musteriler m where s.MusteriID=m.Id) as 'Müşteri Adı' ,
(select p.Adi+' '+p.Soyadi as 'Personel Adı' from Personeller p where s.PersonelID=p.Id) as 'Personel Adı',
(select u.Adi as 'Satılan Ürün' from Urunler u where sd.UrunID=u.Id) as 'Ürün Adı',
sd.Miktar,sd.Fiyat,sd.Indirim,CAST(((sd.Miktar*sd.Fiyat)-((sd.Miktar*sd.Fiyat*sd.Indirim)/100)) as decimal(11,2)) as 'Toplam Satış',
s.SatisTarihi as 'Satış Tarihi'
 from Satis s inner join SatisDetay sd on sd.SatisID=s.Id order by s.SatisTarihi desc
GO
/****** Object:  StoredProcedure [dbo].[prc_Super_Select]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Super_Select]
as
select * from Yetki 
GO
/****** Object:  StoredProcedure [dbo].[prc_Tedarikciler_Delete]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Tedarikciler_Delete]
@Id int
as
update Tedarikciler set Aktif=0 where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Tedarikciler_Insert]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Tedarikciler_Insert]
@Adi nvarchar(50),
@Soyadi nvarchar(50),
@SirketAdi nvarchar(250),
@TelNo char(14),
@Adres nvarchar(500),
@Mail nvarchar(50),
@Aktif bit
as
insert Tedarikciler values(@Adi,@Soyadi,@SirketAdi,@TelNo,@Adres,@Mail,@Aktif)
GO
/****** Object:  StoredProcedure [dbo].[prc_Tedarikciler_Select]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Tedarikciler_Select]
as
select * from Tedarikciler where Aktif=1

GO
/****** Object:  StoredProcedure [dbo].[prc_Tedarikciler_Updated]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Tedarikciler_Updated]
@Id int,
@Adi nvarchar(50),
@Soyadi nvarchar(50),
@SirketAdi nvarchar(250),
@TelNo char(14),
@Adres nvarchar(500),
@Mail nvarchar(50),
@Aktif bit
as
update Tedarikciler set Adi=@Adi,Soyadi=@Soyadi,SirketAdi=@SirketAdi,TelNo=@TelNo,Adres=@Adres,Mail=@Mail,Aktif=@Aktif  where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Urunler_Delete]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Urunler_Delete]
@Id int
as
update Urunler set Aktif = 0 where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Urunler_Insert]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Urunler_Insert]
@Adi nvarchar(50),
@Fiyat money,
@Miktar float,
@KategoriID int,
@BirimTipID int,
@Aktif bit
as
if(exists(select *from Urunler where Adi=LTRIM(rtrim(@Adi))))
begin
update Urunler set Aktif=1 where Adi=@Adi
end
else
begin
insert Urunler values(@Adi,@Fiyat,@Miktar,@KategoriID,@BirimTipID,@Aktif)
end
GO
/****** Object:  StoredProcedure [dbo].[prc_Urunler_Select]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Urunler_Select]
as
select u.Id,u.Adi,u.Fiyat,u.Miktar,
(select k.Adi from Kategoriler k where k.Id=u.KategoriID) as 'Kategori',
(select bt.Adi from BirimTipleri bt where bt.Id=u.BirimTipID) as 'Birim Tipi',u.KategoriID,u.BirimTipID, u.Aktif from Urunler u where u.Aktif=1
GO
/****** Object:  StoredProcedure [dbo].[prc_Urunler_Update]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Urunler_Update]
@Id int ,
@Miktar float
as
DECLARE @Sayi float = (select Miktar from Urunler u where u.Id=@Id);
if(@Sayi<-@Miktar)
begin
print 'Stokda ürün kalmamıştır'
end
else
begin
update  Urunler set Miktar =@Sayi+@Miktar where Id=@Id
end
GO
/****** Object:  StoredProcedure [dbo].[prc_Urunler_Updated]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[prc_Urunler_Updated]
@Id int,
@Adi nvarchar(50),
@Fiyat money,
@Miktar float,
@KategoriID int,
@BirimTipID int,
@Aktif bit
as
update Urunler set Adi=@Adi,Fiyat=@Fiyat,Miktar=@Miktar where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[prc_Yetki_Select]    Script Date: 13.01.2019 01:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[prc_Yetki_Select]
as
select * from Yetki where Yetki.Id=3
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IX_Musteriler_Index_Tckn' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Musteriler', @level2type=N'CONSTRAINT',@level2name=N'IX_Musteriler_Tckn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IX_Personeller_Index_Tckn' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Personeller', @level2type=N'CONSTRAINT',@level2name=N'IX_Personeller_Tckn'
GO
USE [master]
GO
ALTER DATABASE [OtelOtomasyon] SET  READ_WRITE 
GO
