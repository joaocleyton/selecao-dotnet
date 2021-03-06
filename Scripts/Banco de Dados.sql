USE [master]
GO
/****** Object:  Database [bd_indra]    Script Date: 10/07/2020 01:45:13 ******/
CREATE DATABASE [bd_indra]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'shop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\shop.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'shop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\shop_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [bd_indra] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bd_indra].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bd_indra] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bd_indra] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bd_indra] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bd_indra] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bd_indra] SET ARITHABORT OFF 
GO
ALTER DATABASE [bd_indra] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bd_indra] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bd_indra] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bd_indra] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bd_indra] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bd_indra] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bd_indra] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bd_indra] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bd_indra] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bd_indra] SET  ENABLE_BROKER 
GO
ALTER DATABASE [bd_indra] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bd_indra] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bd_indra] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bd_indra] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bd_indra] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bd_indra] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bd_indra] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bd_indra] SET RECOVERY FULL 
GO
ALTER DATABASE [bd_indra] SET  MULTI_USER 
GO
ALTER DATABASE [bd_indra] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bd_indra] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bd_indra] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bd_indra] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'bd_indra', N'ON'
GO
USE [bd_indra]
GO
/****** Object:  Table [dbo].[Cartoes]    Script Date: 10/07/2020 01:45:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cartoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[numero] [varchar](50) NOT NULL,
	[nome] [varchar](50) NULL,
	[vencimento] [varchar](6) NULL,
	[codseguranca] [varchar](5) NULL,
	[EstudanteId] [int] NOT NULL,
 CONSTRAINT [PK_Cartoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 10/07/2020 01:45:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 10/07/2020 01:45:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](60) NOT NULL,
	[Description] [nvarchar](1024) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estudantes]    Script Date: 10/07/2020 01:45:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudantes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](100) NOT NULL,
	[email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Estudantes2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Matriculas]    Script Date: 10/07/2020 01:45:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matriculas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[status] [varchar](50) NULL,
	[dataMatricula] [date] NOT NULL,
	[EstudanteId] [int] NOT NULL,
	[CursoId] [int] NOT NULL,
 CONSTRAINT [PK_Matriculas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Cartoes] ON 

INSERT [dbo].[Cartoes] ([Id], [numero], [nome], [vencimento], [codseguranca], [EstudanteId]) VALUES (1, N'1464-1316', N'', N'062020', N'13', 1)
INSERT [dbo].[Cartoes] ([Id], [numero], [nome], [vencimento], [codseguranca], [EstudanteId]) VALUES (2, N'1464-1316', N'', N'062020', N'13', 1)
SET IDENTITY_INSERT [dbo].[Cartoes] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Title]) VALUES (1, N'Categoria 001')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Cursos] ON 

INSERT [dbo].[Cursos] ([Id], [Title], [Description], [Price], [CategoryId]) VALUES (1, N'Produto da categoria 01', N'Descrição do Produto da Categoria 01', CAST(100.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Cursos] OFF
SET IDENTITY_INSERT [dbo].[Estudantes] ON 

INSERT [dbo].[Estudantes] ([id], [nome], [email]) VALUES (1, N'estudante 01', N'1234@161')
SET IDENTITY_INSERT [dbo].[Estudantes] OFF
SET IDENTITY_INSERT [dbo].[Matriculas] ON 

INSERT [dbo].[Matriculas] ([Id], [status], [dataMatricula], [EstudanteId], [CursoId]) VALUES (1, N'01', CAST(N'2020-07-08' AS Date), 1, 1)
SET IDENTITY_INSERT [dbo].[Matriculas] OFF
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 10/07/2020 01:45:14 ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Cursos]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cursos] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [bd_indra] SET  READ_WRITE 
GO
