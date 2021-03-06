USE [master]
GO
/****** Object:  Database [KuryeProje]    Script Date: 13.05.2021 17:57:20 ******/
CREATE DATABASE [KuryeProje]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KuryeProje', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\KuryeProje.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KuryeProje_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\KuryeProje_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [KuryeProje] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KuryeProje].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KuryeProje] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KuryeProje] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KuryeProje] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KuryeProje] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KuryeProje] SET ARITHABORT OFF 
GO
ALTER DATABASE [KuryeProje] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KuryeProje] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KuryeProje] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KuryeProje] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KuryeProje] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KuryeProje] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KuryeProje] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KuryeProje] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KuryeProje] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KuryeProje] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KuryeProje] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KuryeProje] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KuryeProje] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KuryeProje] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KuryeProje] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KuryeProje] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KuryeProje] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KuryeProje] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KuryeProje] SET  MULTI_USER 
GO
ALTER DATABASE [KuryeProje] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KuryeProje] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KuryeProje] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KuryeProje] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KuryeProje] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KuryeProje] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [KuryeProje] SET QUERY_STORE = OFF
GO
USE [KuryeProje]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 13.05.2021 17:57:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[CityId] [bigint] NOT NULL,
	[CountryId] [bigint] NOT NULL,
	[AddressDetail] [nvarchar](250) NOT NULL,
	[PostalCode] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 13.05.2021 17:57:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CountryId] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 13.05.2021 17:57:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deliveries]    Script Date: 13.05.2021 17:57:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deliveries](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[AddressId] [bigint] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Vehicle] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Deliveries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 13.05.2021 17:57:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_OperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 13.05.2021 17:57:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Weight] [decimal](18, 2) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Price] [money] NULL,
	[CreateDate] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receivers]    Script Date: 13.05.2021 17:57:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receivers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DeliveryId] [bigint] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [int] NOT NULL,
	[AddressDetail] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Receivers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 13.05.2021 17:57:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
 CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13.05.2021 17:57:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [CreateDate], [Active]) VALUES (1, 1, N'string', CAST(N'2021-05-13T13:17:25.520' AS DateTime), 1)
INSERT [dbo].[Cities] ([Id], [CountryId], [Name], [CreateDate], [Active]) VALUES (2, 1, N'aadana', CAST(N'2021-05-13T13:17:25.520' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name], [CreateDate], [Active]) VALUES (1, N'Türkiye2', CAST(N'2021-05-11T15:47:45.620' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 

INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (2, N'Kurye')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (3, N'Müşteri')
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Weight], [Name], [Code], [Price], [CreateDate], [Active]) VALUES (2, CAST(100.00 AS Decimal(18, 2)), N'string', N'stri', 0.0000, CAST(N'2021-05-13T12:38:41.180' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [Weight], [Name], [Code], [Price], [CreateDate], [Active]) VALUES (3, CAST(0.00 AS Decimal(18, 2)), N'strinsadag', N'stri', 0.0000, CAST(N'2021-05-13T13:16:33.370' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 

INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (1, 4, 1)
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (4, N'Eren', N'Kara', N'erenkaraaa47@gmail.com', 0xACC901792B955B39A2352769EAFB43BC23EB8A3FFD21C76D39519551ACF75BDFE63A2BF1507DAAA49CBBF5BAB84877538C95EDEC4F722D7537B32B4D25734BB6, 0x6310B441D3B1C91A57C2A02FA2E57885A28865E318EA992635B1265BD38C859FF4E0EFD6797CF6A6EBA77A46E7A26D18BF73A94D624FB08350A705FC874350093D396F91186CB1B7DAFDAF3A1455D7B9616BB2CD3A1F6E1032D90EE89282AF654CB53240798631B20C24A2C833051E99B66D71CF9730CF251FCA69E953D77D19, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (5, N'Ahmet', N'Kara', N'ahmetkara@gmail.com', 0x7B2D0793AB661225601F9C116895932AB7816FE79D28B98050B485ED1EE6DD07FD0DD31B3997D7AB9141710BB620E8DF04598D8A3C4091C8890B2969A0BD8C3D, 0x311E9918B0FBE644598774DF9F0A8EE935E3AEC0AB117E02183F26BEB57BD3C5CED6FE26D16B18C1D55A10014133B4032519FF23391FEAA8E6216E4D7598C1ED25E7214CC7ACB1286D1F12A1D61511D4C1B2743AF0BABD655A47ED561C27EF73D7109F0F6F1CEF91FE1A5161F58A177AC9CB026779B8BBC81C8F7D5B73A1AE0B, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF_Addresses_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF_Addresses_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Cities] ADD  CONSTRAINT [DF_Cities_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Cities] ADD  CONSTRAINT [DF_Cities_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Countries] ADD  CONSTRAINT [DF_Countries_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Countries] ADD  CONSTRAINT [DF_Countries_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Deliveries] ADD  CONSTRAINT [DF_Deliveries_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Deliveries] ADD  CONSTRAINT [DF_Deliveries_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Cities] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Cities]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Countries]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Users1] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Users1]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Countries]
GO
ALTER TABLE [dbo].[Deliveries]  WITH CHECK ADD  CONSTRAINT [FK_Deliveries_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([Id])
GO
ALTER TABLE [dbo].[Deliveries] CHECK CONSTRAINT [FK_Deliveries_Addresses]
GO
ALTER TABLE [dbo].[Deliveries]  WITH CHECK ADD  CONSTRAINT [FK_Deliveries_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Deliveries] CHECK CONSTRAINT [FK_Deliveries_Products]
GO
ALTER TABLE [dbo].[Deliveries]  WITH CHECK ADD  CONSTRAINT [FK_Deliveries_Users1] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Deliveries] CHECK CONSTRAINT [FK_Deliveries_Users1]
GO
ALTER TABLE [dbo].[Receivers]  WITH CHECK ADD  CONSTRAINT [FK_Receivers_Deliveries] FOREIGN KEY([DeliveryId])
REFERENCES [dbo].[Deliveries] ([Id])
GO
ALTER TABLE [dbo].[Receivers] CHECK CONSTRAINT [FK_Receivers_Deliveries]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_OperationClaims] FOREIGN KEY([OperationClaimId])
REFERENCES [dbo].[OperationClaims] ([Id])
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_OperationClaims]
GO
ALTER TABLE [dbo].[UserOperationClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserOperationClaims_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserOperationClaims] CHECK CONSTRAINT [FK_UserOperationClaims_Users]
GO
USE [master]
GO
ALTER DATABASE [KuryeProje] SET  READ_WRITE 
GO
