USE [RegistrosDB]
GO
ALTER TABLE [dbo].[Personas] DROP CONSTRAINT [FK_Personas_TiposIdentificacion]
GO
ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [DF_Usuarios_FechaCreacion]
GO
ALTER TABLE [dbo].[Personas] DROP CONSTRAINT [DF_Personas_FechaCreacion]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 9/10/2024 3:56:24 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
DROP TABLE [dbo].[Usuarios]
GO
/****** Object:  Table [dbo].[TiposIdentificacion]    Script Date: 9/10/2024 3:56:24 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TiposIdentificacion]') AND type in (N'U'))
DROP TABLE [dbo].[TiposIdentificacion]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 9/10/2024 3:56:24 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Personas]') AND type in (N'U'))
DROP TABLE [dbo].[Personas]
GO
USE [master]
GO
/****** Object:  Database [RegistrosDB]    Script Date: 9/10/2024 3:56:24 p. m. ******/
DROP DATABASE [RegistrosDB]
GO
/****** Object:  Database [RegistrosDB]    Script Date: 9/10/2024 3:56:24 p. m. ******/
CREATE DATABASE [RegistrosDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RegistrosDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RegistrosDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RegistrosDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RegistrosDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RegistrosDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RegistrosDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RegistrosDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RegistrosDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RegistrosDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RegistrosDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RegistrosDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [RegistrosDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RegistrosDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RegistrosDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RegistrosDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RegistrosDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RegistrosDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RegistrosDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RegistrosDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RegistrosDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RegistrosDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RegistrosDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RegistrosDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RegistrosDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RegistrosDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RegistrosDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RegistrosDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RegistrosDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RegistrosDB] SET RECOVERY FULL 
GO
ALTER DATABASE [RegistrosDB] SET  MULTI_USER 
GO
ALTER DATABASE [RegistrosDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RegistrosDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RegistrosDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RegistrosDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RegistrosDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RegistrosDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RegistrosDB', N'ON'
GO
ALTER DATABASE [RegistrosDB] SET QUERY_STORE = OFF
GO
USE [RegistrosDB]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 9/10/2024 3:56:24 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
	[Apellidos] [nvarchar](50) NOT NULL,
	[NumIdentificacion] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[IdTipoIdentificacion] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposIdentificacion]    Script Date: 9/10/2024 3:56:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposIdentificacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposIdentificacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 9/10/2024 3:56:25 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Personas] ON 

INSERT [dbo].[Personas] ([Id], [Nombres], [Apellidos], [NumIdentificacion], [Email], [IdTipoIdentificacion], [FechaCreacion], [FechaModificacion]) VALUES (1, N'Andres Felipe', N'Castañeda', N'1234567890', N'a@a.net', 1, CAST(N'2024-10-09T15:54:45.577' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Personas] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposIdentificacion] ON 

INSERT [dbo].[TiposIdentificacion] ([Id], [Descripcion]) VALUES (1, N'Cédula de Ciudadanía')
INSERT [dbo].[TiposIdentificacion] ([Id], [Descripcion]) VALUES (2, N'NIT')
INSERT [dbo].[TiposIdentificacion] ([Id], [Descripcion]) VALUES (3, N'Cédula de Extranjería')
INSERT [dbo].[TiposIdentificacion] ([Id], [Descripcion]) VALUES (4, N'Tarjeta de Identidad')
INSERT [dbo].[TiposIdentificacion] ([Id], [Descripcion]) VALUES (5, N'Pasaporte')
INSERT [dbo].[TiposIdentificacion] ([Id], [Descripcion]) VALUES (6, N'Registro Civil')
SET IDENTITY_INSERT [dbo].[TiposIdentificacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [NombreUsuario], [Password], [FechaCreacion]) VALUES (1, N'administrador', N'3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2', CAST(N'2024-10-09T15:39:19.200' AS DateTime))
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Personas] ADD  CONSTRAINT [DF_Personas_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_TiposIdentificacion] FOREIGN KEY([IdTipoIdentificacion])
REFERENCES [dbo].[TiposIdentificacion] ([Id])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_TiposIdentificacion]
GO
USE [master]
GO
ALTER DATABASE [RegistrosDB] SET  READ_WRITE 
GO
