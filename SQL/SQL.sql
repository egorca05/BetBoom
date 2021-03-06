USE [master]
GO
/****** Object:  Database [BetBoom]    Script Date: 30.04.2022 22:24:37 ******/
CREATE DATABASE [BetBoom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BetBoom', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BetBoom.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BetBoom_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BetBoom_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BetBoom] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BetBoom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BetBoom] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BetBoom] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BetBoom] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BetBoom] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BetBoom] SET ARITHABORT OFF 
GO
ALTER DATABASE [BetBoom] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BetBoom] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BetBoom] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BetBoom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BetBoom] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BetBoom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BetBoom] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BetBoom] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BetBoom] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BetBoom] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BetBoom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BetBoom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BetBoom] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BetBoom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BetBoom] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BetBoom] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BetBoom] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BetBoom] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BetBoom] SET  MULTI_USER 
GO
ALTER DATABASE [BetBoom] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BetBoom] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BetBoom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BetBoom] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BetBoom] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BetBoom] SET QUERY_STORE = OFF
GO
USE [BetBoom]
GO
/****** Object:  Table [dbo].[Match]    Script Date: 30.04.2022 22:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match](
	[IdMatch] [int] IDENTITY(1,1) NOT NULL,
	[IdTeamOne] [int] NOT NULL,
	[IdTeamTwo] [int] NOT NULL,
	[IdSport] [int] NOT NULL,
	[Coefficient] [int] NOT NULL,
 CONSTRAINT [PK_Match] PRIMARY KEY CLUSTERED 
(
	[IdMatch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Refills]    Script Date: 30.04.2022 22:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Refills](
	[IdRefills] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[Sum] [decimal](7, 2) NOT NULL,
 CONSTRAINT [PK_Refills] PRIMARY KEY CLUSTERED 
(
	[IdRefills] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 30.04.2022 22:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sport]    Script Date: 30.04.2022 22:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sport](
	[IdSport] [int] IDENTITY(1,1) NOT NULL,
	[NameSport] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sport] PRIMARY KEY CLUSTERED 
(
	[IdSport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamOne]    Script Date: 30.04.2022 22:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamOne](
	[IdTeamOne] [int] IDENTITY(1,1) NOT NULL,
	[NameTeamOne] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TeamOne] PRIMARY KEY CLUSTERED 
(
	[IdTeamOne] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamTwo]    Script Date: 30.04.2022 22:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamTwo](
	[IdTeamTwo] [int] IDENTITY(1,1) NOT NULL,
	[NameTeamTwo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TeamTwo] PRIMARY KEY CLUSTERED 
(
	[IdTeamTwo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 30.04.2022 22:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[LoginUser] [nvarchar](50) NOT NULL,
	[PasswodUser] [nvarchar](50) NOT NULL,
	[Balans] [decimal](7, 2) NOT NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Match] ON 

INSERT [dbo].[Match] ([IdMatch], [IdTeamOne], [IdTeamTwo], [IdSport], [Coefficient]) VALUES (15, 1, 2, 1, 5)
INSERT [dbo].[Match] ([IdMatch], [IdTeamOne], [IdTeamTwo], [IdSport], [Coefficient]) VALUES (16, 1, 2, 1, 5)
SET IDENTITY_INSERT [dbo].[Match] OFF
GO
SET IDENTITY_INSERT [dbo].[Refills] ON 

INSERT [dbo].[Refills] ([IdRefills], [IdUser], [Sum]) VALUES (1, 2, CAST(100.00 AS Decimal(7, 2)))
INSERT [dbo].[Refills] ([IdRefills], [IdUser], [Sum]) VALUES (2, 7, CAST(50.00 AS Decimal(7, 2)))
SET IDENTITY_INSERT [dbo].[Refills] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (1, N'Администратор')
INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (2, N'Пользователь')
INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (3, N'Директор')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Sport] ON 

INSERT [dbo].[Sport] ([IdSport], [NameSport]) VALUES (1, N'Футбол')
SET IDENTITY_INSERT [dbo].[Sport] OFF
GO
SET IDENTITY_INSERT [dbo].[TeamOne] ON 

INSERT [dbo].[TeamOne] ([IdTeamOne], [NameTeamOne]) VALUES (1, N'ЦСК')
INSERT [dbo].[TeamOne] ([IdTeamOne], [NameTeamOne]) VALUES (2, N'Спартак')
SET IDENTITY_INSERT [dbo].[TeamOne] OFF
GO
SET IDENTITY_INSERT [dbo].[TeamTwo] ON 

INSERT [dbo].[TeamTwo] ([IdTeamTwo], [NameTeamTwo]) VALUES (1, N'ЦСК')
INSERT [dbo].[TeamTwo] ([IdTeamTwo], [NameTeamTwo]) VALUES (2, N'Спартак')
SET IDENTITY_INSERT [dbo].[TeamTwo] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([IdUser], [LoginUser], [PasswodUser], [Balans], [IdRole]) VALUES (2, N'adm', N'adm', CAST(6565.00 AS Decimal(7, 2)), 1)
INSERT [dbo].[User] ([IdUser], [LoginUser], [PasswodUser], [Balans], [IdRole]) VALUES (4, N'egor', N'egor', CAST(241.00 AS Decimal(7, 2)), 2)
INSERT [dbo].[User] ([IdUser], [LoginUser], [PasswodUser], [Balans], [IdRole]) VALUES (7, N'obi', N'obi', CAST(550.00 AS Decimal(7, 2)), 2)
INSERT [dbo].[User] ([IdUser], [LoginUser], [PasswodUser], [Balans], [IdRole]) VALUES (8, N'mag', N'mag', CAST(0.00 AS Decimal(7, 2)), 3)
INSERT [dbo].[User] ([IdUser], [LoginUser], [PasswodUser], [Balans], [IdRole]) VALUES (9, N'ivan', N'ivan', CAST(0.00 AS Decimal(7, 2)), 3)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Sport] FOREIGN KEY([IdSport])
REFERENCES [dbo].[Sport] ([IdSport])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Sport]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_TeamOne] FOREIGN KEY([IdTeamOne])
REFERENCES [dbo].[TeamOne] ([IdTeamOne])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_TeamOne]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_TeamTwo] FOREIGN KEY([IdTeamTwo])
REFERENCES [dbo].[TeamTwo] ([IdTeamTwo])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_TeamTwo]
GO
ALTER TABLE [dbo].[Refills]  WITH CHECK ADD  CONSTRAINT [FK_Refills_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[Refills] CHECK CONSTRAINT [FK_Refills_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([IdRole])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [BetBoom] SET  READ_WRITE 
GO
