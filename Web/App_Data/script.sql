USE [master]
GO
/****** Object:  Database [PortraitStudioDeveloper]    Script Date: 20.01.2016 09:39:03 ******/
CREATE DATABASE [PortraitStudioDeveloper]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PortraitStudioDeveloper.mdf', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PortraitStudioDeveloper.mdf' , SIZE = 10MB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PortraitStudioDeveloper_log.ldf', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PortraitStudioDeveloper_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PortraitStudioDeveloper] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PortraitStudioDeveloper].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PortraitStudioDeveloper] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET ARITHABORT OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET  MULTI_USER 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PortraitStudioDeveloper] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PortraitStudioDeveloper] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PortraitStudioDeveloper]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillCancellations]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillCancellations](
	[Id] [int] NOT NULL,
	[Reason] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.BillCancellations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillHeads]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillHeads](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestHeadId] [int] NOT NULL,
	[FirstName] [nvarchar](64) NOT NULL,
	[LastName] [nvarchar](64) NOT NULL,
	[StreetPostOfficeBox] [nvarchar](64) NOT NULL,
	[HouseNumber] [nvarchar](8) NULL,
	[PostalCode] [nvarchar](16) NOT NULL,
	[City] [nvarchar](64) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[Remarks] [nvarchar](256) NULL,
	[Email] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.BillHeads] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillItems]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HeadId] [int] NOT NULL,
	[Name] [nvarchar](64) NULL,
	[RequestItemId] [int] NOT NULL,
	[Amount] [real] NOT NULL,
	[Price] [real] NOT NULL,
 CONSTRAINT [PK_dbo.BillItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PriceAdjustmentProducts]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceAdjustmentProducts](
	[PriceAdjustment_Id] [int] NOT NULL,
	[Product_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PriceAdjustmentProducts] PRIMARY KEY CLUSTERED 
(
	[PriceAdjustment_Id] ASC,
	[Product_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PriceAdjustments]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceAdjustments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Adjustment] [real] NOT NULL,
 CONSTRAINT [PK_dbo.PriceAdjustments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NULL,
 CONSTRAINT [PK_dbo.ProductCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NULL,
	[Price] [real] NOT NULL,
	[ProductCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RequestCancellations]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestCancellations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestHeadId] [int] NOT NULL,
	[Reason] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.RequestCancellations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RequestHeads]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestHeads](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](64) NOT NULL,
	[LastName] [nvarchar](64) NOT NULL,
	[StreetPostOfficeBox] [nvarchar](64) NOT NULL,
	[HouseNumber] [nvarchar](8) NULL,
	[PostalCode] [nvarchar](16) NOT NULL,
	[City] [nvarchar](64) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[Remarks] [nvarchar](256) NULL,
	[Email] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.RequestHeads] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RequestImages]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RequestImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestHeadId] [int] NOT NULL,
	[Data] [varbinary](max) NULL,
 CONSTRAINT [PK_dbo.RequestImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RequestItems]    Script Date: 20.01.2016 09:39:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequestHeadId] [int] NOT NULL,
	[Name] [nvarchar](64) NULL,
	[Amount] [real] NOT NULL,
	[Price] [real] NOT NULL,
 CONSTRAINT [PK_dbo.RequestItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 20.01.2016 09:39:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 20.01.2016 09:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 20.01.2016 09:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 20.01.2016 09:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 20.01.2016 09:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 20.01.2016 09:39:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Id]    Script Date: 20.01.2016 09:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_Id] ON [dbo].[BillCancellations]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RequestHeadId]    Script Date: 20.01.2016 09:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_RequestHeadId] ON [dbo].[BillHeads]
(
	[RequestHeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HeadId]    Script Date: 20.01.2016 09:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_HeadId] ON [dbo].[BillItems]
(
	[HeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PriceAdjustment_Id]    Script Date: 20.01.2016 09:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_PriceAdjustment_Id] ON [dbo].[PriceAdjustmentProducts]
(
	[PriceAdjustment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_Id]    Script Date: 20.01.2016 09:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_Product_Id] ON [dbo].[PriceAdjustmentProducts]
(
	[Product_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductCategoryId]    Script Date: 20.01.2016 09:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_ProductCategoryId] ON [dbo].[Products]
(
	[ProductCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RequestHeadId]    Script Date: 20.01.2016 09:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_RequestHeadId] ON [dbo].[RequestCancellations]
(
	[RequestHeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RequestHeadId]    Script Date: 20.01.2016 09:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_RequestHeadId] ON [dbo].[RequestImages]
(
	[RequestHeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RequestHeadId]    Script Date: 20.01.2016 09:39:04 ******/
CREATE NONCLUSTERED INDEX [IX_RequestHeadId] ON [dbo].[RequestItems]
(
	[RequestHeadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[BillCancellations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BillCancellations_dbo.BillHeads_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[BillHeads] ([Id])
GO
ALTER TABLE [dbo].[BillCancellations] CHECK CONSTRAINT [FK_dbo.BillCancellations_dbo.BillHeads_Id]
GO
ALTER TABLE [dbo].[BillHeads]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BillHeads_dbo.RequestHeads_RequestHeadId] FOREIGN KEY([RequestHeadId])
REFERENCES [dbo].[RequestHeads] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BillHeads] CHECK CONSTRAINT [FK_dbo.BillHeads_dbo.RequestHeads_RequestHeadId]
GO
ALTER TABLE [dbo].[BillItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BillItems_dbo.BillHeads_HeadId] FOREIGN KEY([HeadId])
REFERENCES [dbo].[BillHeads] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BillItems] CHECK CONSTRAINT [FK_dbo.BillItems_dbo.BillHeads_HeadId]
GO
ALTER TABLE [dbo].[PriceAdjustmentProducts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PriceAdjustmentProducts_dbo.PriceAdjustments_PriceAdjustment_Id] FOREIGN KEY([PriceAdjustment_Id])
REFERENCES [dbo].[PriceAdjustments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PriceAdjustmentProducts] CHECK CONSTRAINT [FK_dbo.PriceAdjustmentProducts_dbo.PriceAdjustments_PriceAdjustment_Id]
GO
ALTER TABLE [dbo].[PriceAdjustmentProducts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PriceAdjustmentProducts_dbo.Products_Product_Id] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PriceAdjustmentProducts] CHECK CONSTRAINT [FK_dbo.PriceAdjustmentProducts_dbo.Products_Product_Id]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.ProductCategories_ProductCategoryId] FOREIGN KEY([ProductCategoryId])
REFERENCES [dbo].[ProductCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.ProductCategories_ProductCategoryId]
GO
ALTER TABLE [dbo].[RequestCancellations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RequestCancellations_dbo.RequestHeads_RequestHeadId] FOREIGN KEY([RequestHeadId])
REFERENCES [dbo].[RequestHeads] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequestCancellations] CHECK CONSTRAINT [FK_dbo.RequestCancellations_dbo.RequestHeads_RequestHeadId]
GO
ALTER TABLE [dbo].[RequestImages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RequestImages_dbo.RequestHeads_RequestHeadId] FOREIGN KEY([RequestHeadId])
REFERENCES [dbo].[RequestHeads] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequestImages] CHECK CONSTRAINT [FK_dbo.RequestImages_dbo.RequestHeads_RequestHeadId]
GO
ALTER TABLE [dbo].[RequestItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RequestItems_dbo.RequestHeads_RequestHeadId] FOREIGN KEY([RequestHeadId])
REFERENCES [dbo].[RequestHeads] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequestItems] CHECK CONSTRAINT [FK_dbo.RequestItems_dbo.RequestHeads_RequestHeadId]
GO
USE [master]
GO
ALTER DATABASE [PortraitStudioDeveloper] SET  READ_WRITE 
GO

USE [PortraitStudioDeveloper]

GO

INSERT INTO [dbo].[ProductCategories]
           ([Name])
     VALUES
           ('Portrait')
GO

INSERT INTO [dbo].[ProductCategories]
           ([Name])
     VALUES
           ('Größe')
GO

INSERT INTO [dbo].[ProductCategories]
           ([Name])
     VALUES
           ('Person oder Subject')
GO

INSERT INTO [dbo].[Products]
           ([Name]
           ,[Price]
           ,[ProductCategoryId])
     VALUES
           ('Person oder Subjekt'
           ,20
           ,3)
GO

INSERT INTO [dbo].[Products]
           ([Name]
           ,[Price]
           ,[ProductCategoryId])
     VALUES
           ('Bleistift-Portrait'
           ,60
           ,1)
GO

INSERT INTO [dbo].[Products]
           ([Name]
           ,[Price]
           ,[ProductCategoryId])
     VALUES
           ('Buntstift-Portrait'
           ,80
           ,1)
GO

INSERT INTO [dbo].[Products]
           ([Name]
           ,[Price]
           ,[ProductCategoryId])
     VALUES
           ('A4'
           ,0
           ,2)
GO

INSERT INTO [dbo].[Products]
           ([Name]
           ,[Price]
           ,[ProductCategoryId])
     VALUES
           ('A3'
           ,30
           ,2)
GO

INSERT INTO [dbo].[Products]
           ([Name]
           ,[Price]
           ,[ProductCategoryId])
     VALUES
           ('A2'
           ,60
           ,2)
GO

INSERT INTO [dbo].[PriceAdjustments]
           ([Name]
           ,[Adjustment])
     VALUES
           ('Erste Person oder Subjekt inkl.'
           ,-20)
GO

INSERT INTO [dbo].[PriceAdjustmentProducts]
           ([PriceAdjustment_Id]
           ,[Product_Id])
     VALUES
           (1
           ,1)
GO

DBCC CHECKIDENT('BillHeads', RESEED, 2)

GO
