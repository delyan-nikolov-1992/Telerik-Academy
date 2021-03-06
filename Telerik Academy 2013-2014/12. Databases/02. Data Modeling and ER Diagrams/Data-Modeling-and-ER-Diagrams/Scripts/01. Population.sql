USE [master]
GO
/****** Object:  Database [Population]    Script Date: 08/23/2014 14:47:45 ******/
CREATE DATABASE [Population]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Population', FILENAME = N'F:\Programs\Microsoft SQL Server 2014 Developer\MSSQL12.MSSQLSERVER\MSSQL\DATA\Population.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Population_log', FILENAME = N'F:\Programs\Microsoft SQL Server 2014 Developer\MSSQL12.MSSQLSERVER\MSSQL\DATA\Population_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Population] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Population].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Population] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Population] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Population] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Population] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Population] SET ARITHABORT OFF 
GO
ALTER DATABASE [Population] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Population] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Population] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Population] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Population] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Population] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Population] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Population] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Population] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Population] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Population] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Population] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Population] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Population] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Population] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Population] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Population] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Population] SET RECOVERY FULL 
GO
ALTER DATABASE [Population] SET  MULTI_USER 
GO
ALTER DATABASE [Population] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Population] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Population] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Population] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Population] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Population', N'ON'
GO
USE [Population]
GO
/****** Object:  Table [dbo].[ADDRESS]    Script Date: 08/23/2014 14:47:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADDRESS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address_text] [nvarchar](50) NOT NULL,
	[town_id] [int] NOT NULL,
 CONSTRAINT [PK_ADDRESS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CONTINENT]    Script Date: 08/23/2014 14:47:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTINENT](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CONTINENT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[COUNTRY]    Script Date: 08/23/2014 14:47:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COUNTRY](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[continent_id] [int] NOT NULL,
 CONSTRAINT [PK_COUNTRY] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PERSON]    Script Date: 08/23/2014 14:47:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSON](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_PERSON] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TOWN]    Script Date: 08/23/2014 14:47:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TOWN](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_TOWN] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ADDRESS] ON 

INSERT [dbo].[ADDRESS] ([id], [address_text], [town_id]) VALUES (1, N'24, Kasturba Gandhi Marg', 1)
INSERT [dbo].[ADDRESS] ([id], [address_text], [town_id]) VALUES (2, N'60 Giza Street - Dokki', 2)
INSERT [dbo].[ADDRESS] ([id], [address_text], [town_id]) VALUES (3, N'Campos Elíseos 218 Polanco', 3)
INSERT [dbo].[ADDRESS] ([id], [address_text], [town_id]) VALUES (4, N'Rua Visconde de Porto Seguro 1238', 4)
INSERT [dbo].[ADDRESS] ([id], [address_text], [town_id]) VALUES (5, N'Aleksandar Malinov 31', 5)
SET IDENTITY_INSERT [dbo].[ADDRESS] OFF
SET IDENTITY_INSERT [dbo].[CONTINENT] ON 

INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (1, N'Asia')
INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (2, N'Africa')
INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (3, N'North America')
INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (4, N'South America')
INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (5, N'Europe')
SET IDENTITY_INSERT [dbo].[CONTINENT] OFF
SET IDENTITY_INSERT [dbo].[COUNTRY] ON 

INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (1, N'India', 1)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (2, N'Egypt', 2)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (3, N'Mexico', 3)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (4, N'Brazil', 4)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (5, N'Bulgaria', 5)
SET IDENTITY_INSERT [dbo].[COUNTRY] OFF
SET IDENTITY_INSERT [dbo].[PERSON] ON 

INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (1, N'Pranab', N'Mukherjee', 1)
INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (2, N'Abdel', N'Fattah', 2)
INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (3, N'Enrique', N'Nieto', 3)
INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (4, N'Dilma', N'Rousseff', 4)
INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (5, N'Bogomil', N'Cekov', 5)
SET IDENTITY_INSERT [dbo].[PERSON] OFF
SET IDENTITY_INSERT [dbo].[TOWN] ON 

INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (1, N'New Delhi', 1)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (2, N'Cairo', 2)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (3, N'Mexico City', 3)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (4, N'Brasilia', 4)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (5, N'Sofia', 5)
SET IDENTITY_INSERT [dbo].[TOWN] OFF
ALTER TABLE [dbo].[ADDRESS]  WITH CHECK ADD  CONSTRAINT [FK_ADDRESS_TOWN] FOREIGN KEY([town_id])
REFERENCES [dbo].[TOWN] ([id])
GO
ALTER TABLE [dbo].[ADDRESS] CHECK CONSTRAINT [FK_ADDRESS_TOWN]
GO
ALTER TABLE [dbo].[COUNTRY]  WITH CHECK ADD  CONSTRAINT [FK_COUNTRY_CONTINENT] FOREIGN KEY([continent_id])
REFERENCES [dbo].[CONTINENT] ([id])
GO
ALTER TABLE [dbo].[COUNTRY] CHECK CONSTRAINT [FK_COUNTRY_CONTINENT]
GO
ALTER TABLE [dbo].[PERSON]  WITH CHECK ADD  CONSTRAINT [FK_PERSON_ADDRESS] FOREIGN KEY([address_id])
REFERENCES [dbo].[ADDRESS] ([id])
GO
ALTER TABLE [dbo].[PERSON] CHECK CONSTRAINT [FK_PERSON_ADDRESS]
GO
ALTER TABLE [dbo].[TOWN]  WITH CHECK ADD  CONSTRAINT [FK_TOWN_COUNTRY] FOREIGN KEY([country_id])
REFERENCES [dbo].[COUNTRY] ([id])
GO
ALTER TABLE [dbo].[TOWN] CHECK CONSTRAINT [FK_TOWN_COUNTRY]
GO
USE [master]
GO
ALTER DATABASE [Population] SET  READ_WRITE 
GO
