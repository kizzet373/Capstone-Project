USE [master]
GO
/****** Object:  Database [AnatoknightStudios]    Script Date: 4/23/2016 3:33:54 PM ******/
CREATE DATABASE [AnatoknightStudios]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AnatoknightStudios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\AnatoknightStudios.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AnatoknightStudios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\AnatoknightStudios_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AnatoknightStudios] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AnatoknightStudios].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AnatoknightStudios] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET ARITHABORT OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AnatoknightStudios] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AnatoknightStudios] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AnatoknightStudios] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AnatoknightStudios] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AnatoknightStudios] SET  MULTI_USER 
GO
ALTER DATABASE [AnatoknightStudios] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AnatoknightStudios] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AnatoknightStudios] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AnatoknightStudios] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AnatoknightStudios] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AnatoknightStudios]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 4/23/2016 3:33:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/23/2016 3:33:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[IsActive] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comment]    Script Date: 4/23/2016 3:33:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[CommentDate] [datetime2](7) NOT NULL,
	[Content] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Post]    Script Date: 4/23/2016 3:33:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[PostDate] [datetime2](7) NOT NULL,
	[PostTitle] [nvarchar](max) NOT NULL,
	[PostContent] [nvarchar](max) NOT NULL,
	[Votes] [int] NOT NULL,
	[IsActive] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Post_Tag]    Script Date: 4/23/2016 3:33:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post_Tag](
	[TagId] [int] NOT NULL,
	[PostId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PostImageUrls]    Script Date: 4/23/2016 3:33:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostImageUrls](
	[PostId] [int] NOT NULL,
	[PostImageUrl] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tag]    Script Date: 4/23/2016 3:33:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](50) NOT NULL,
	[TagPopularity] [int] NOT NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([BlogId], [BlogTitle]) VALUES (1, N'Admin Blog')
INSERT [dbo].[Blog] ([BlogId], [BlogTitle]) VALUES (2, N'Contributor Blog')
SET IDENTITY_INSERT [dbo].[Blog] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName], [IsActive]) VALUES (1, N'Game 1', 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [IsActive]) VALUES (2, N'Game 2', 0)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [IsActive]) VALUES (3, N'Game 3', 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([CommentId], [PostId], [AccountId], [FirstName], [LastName], [CommentDate], [Content]) VALUES (1, 1, 1, N'Kirkland', N'Brown', CAST(N'2016-04-23 00:00:00.0000000' AS DateTime2), N'Cool Idea Man!')
INSERT [dbo].[Comment] ([CommentId], [PostId], [AccountId], [FirstName], [LastName], [CommentDate], [Content]) VALUES (2, 2, 2, N'Kaz, ', N'The Man', CAST(N'2016-04-24 00:00:00.0000000' AS DateTime2), N'Awful Idea Man..')
SET IDENTITY_INSERT [dbo].[Comment] OFF
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([PostId], [CategoryId], [FirstName], [LastName], [PostDate], [PostTitle], [PostContent], [Votes], [IsActive]) VALUES (1, 1, N'Joe', N'Shmoe', CAST(N'2016-04-21 00:00:00.0000000' AS DateTime2), N'A cooool idea.', N'This is my cool idea.', 2, 1)
INSERT [dbo].[Post] ([PostId], [CategoryId], [FirstName], [LastName], [PostDate], [PostTitle], [PostContent], [Votes], [IsActive]) VALUES (2, 3, N'Kirkland', N'Brown', CAST(N'2016-04-21 00:00:00.0000000' AS DateTime2), N'An awful Idea', N'This is my awful idea.', 40, 1)
SET IDENTITY_INSERT [dbo].[Post] OFF
INSERT [dbo].[Post_Tag] ([TagId], [PostId]) VALUES (1, 1)
INSERT [dbo].[Post_Tag] ([TagId], [PostId]) VALUES (1, 2)
INSERT [dbo].[Post_Tag] ([TagId], [PostId]) VALUES (2, 1)
INSERT [dbo].[Post_Tag] ([TagId], [PostId]) VALUES (2, 2)
INSERT [dbo].[Post_Tag] ([TagId], [PostId]) VALUES (3, 1)
SET IDENTITY_INSERT [dbo].[Tag] ON 

INSERT [dbo].[Tag] ([TagId], [TagName], [TagPopularity]) VALUES (1, N'Bleh', 4)
INSERT [dbo].[Tag] ([TagId], [TagName], [TagPopularity]) VALUES (2, N'Blah', 2)
INSERT [dbo].[Tag] ([TagId], [TagName], [TagPopularity]) VALUES (3, N'Blimp', 20)
SET IDENTITY_INSERT [dbo].[Tag] OFF
USE [master]
GO
ALTER DATABASE [AnatoknightStudios] SET  READ_WRITE 
GO
