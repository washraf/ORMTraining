USE [master]
GO
/****** Object:  Database [Designer_table_per_type]    Script Date: 04-Apr-17 9:59:43 PM ******/
CREATE DATABASE [Designer_table_per_type]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Designer_table_per_type', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Designer_table_per_type.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Designer_table_per_type_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Designer_table_per_type_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Designer_table_per_type] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Designer_table_per_type].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Designer_table_per_type] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET ARITHABORT OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Designer_table_per_type] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Designer_table_per_type] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Designer_table_per_type] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Designer_table_per_type] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET RECOVERY FULL 
GO
ALTER DATABASE [Designer_table_per_type] SET  MULTI_USER 
GO
ALTER DATABASE [Designer_table_per_type] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Designer_table_per_type] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Designer_table_per_type] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Designer_table_per_type] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Designer_table_per_type] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Designer_table_per_type', N'ON'
GO
USE [Designer_table_per_type]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 04-Apr-17 9:59:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](50) NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses_LabCourse]    Script Date: 04-Apr-17 9:59:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses_LabCourse](
	[Location] [nvarchar](50) NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_Courses_LabCourse] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses_OnlineCourse]    Script Date: 04-Apr-17 9:59:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses_OnlineCourse](
	[SelfPaced] [bit] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_Courses_OnlineCourse] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseId], [CourseName], [Price]) VALUES (1, N'Added In time 04-Apr-17 9:58:26 PM', 123)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Price]) VALUES (2, N'Added In time 04-Apr-17 9:58:26 PM', 123)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Price]) VALUES (3, N'Added In time 04-Apr-17 9:58:39 PM', 123)
INSERT [dbo].[Courses] ([CourseId], [CourseName], [Price]) VALUES (4, N'Added In time 04-Apr-17 9:58:39 PM', 123)
SET IDENTITY_INSERT [dbo].[Courses] OFF
INSERT [dbo].[Courses_LabCourse] ([Location], [CourseId]) VALUES (N'Home Center', 2)
INSERT [dbo].[Courses_LabCourse] ([Location], [CourseId]) VALUES (N'Home Center', 4)
INSERT [dbo].[Courses_OnlineCourse] ([SelfPaced], [CourseId]) VALUES (1, 1)
INSERT [dbo].[Courses_OnlineCourse] ([SelfPaced], [CourseId]) VALUES (1, 3)
ALTER TABLE [dbo].[Courses_LabCourse]  WITH CHECK ADD  CONSTRAINT [FK_LabCourse_inherits_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Courses_LabCourse] CHECK CONSTRAINT [FK_LabCourse_inherits_Course]
GO
ALTER TABLE [dbo].[Courses_OnlineCourse]  WITH CHECK ADD  CONSTRAINT [FK_OnlineCourse_inherits_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Courses_OnlineCourse] CHECK CONSTRAINT [FK_OnlineCourse_inherits_Course]
GO
USE [master]
GO
ALTER DATABASE [Designer_table_per_type] SET  READ_WRITE 
GO
