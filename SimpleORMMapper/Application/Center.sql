USE [master]
GO
/****** Object:  Database [Center]    Script Date: 4/29/2015 2:58:05 PM ******/
--CREATE DATABASE [Center]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'Center', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Center.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
-- LOG ON 
--( NAME = N'Center_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Center_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
--GO
ALTER DATABASE [Center] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Center].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Center] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Center] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Center] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Center] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Center] SET ARITHABORT OFF 
GO
ALTER DATABASE [Center] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Center] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Center] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Center] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Center] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Center] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Center] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Center] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Center] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Center] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Center] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Center] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Center] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Center] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Center] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Center] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Center] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Center] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Center] SET RECOVERY FULL 
GO
ALTER DATABASE [Center] SET  MULTI_USER 
GO
ALTER DATABASE [Center] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Center] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Center] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Center] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Center', N'ON'
GO
USE [Center]
GO
/****** Object:  Table [dbo].[CenterNew]    Script Date: 4/29/2015 2:58:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CenterNew](
	[New_ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Details] [nvarchar](250) NOT NULL,
	[ReleaseDate] [date] NOT NULL,
 CONSTRAINT [PK_CenterNews] PRIMARY KEY CLUSTERED 
(
	[New_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CenterNewPictures]    Script Date: 4/29/2015 2:58:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CenterNewPictures](
	[New_ID] [int] NOT NULL,
	[PictureDescription] [nvarchar](50) NOT NULL,
	[PictureLocation] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course]    Script Date: 4/29/2015 2:58:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Course_ID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](50) NOT NULL,
	[CourseDescription] [nvarchar](50) NOT NULL,
	[CourseContents] [nvarchar](500) NOT NULL,
	[CourseDuration] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Course_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Instructor]    Script Date: 4/29/2015 2:58:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Instructor](
	[Instructor_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Mobile] [nvarchar](12) NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[Gender] [char](1) NOT NULL,
	[HourRate] [int] NOT NULL,
 CONSTRAINT [PK_Instructors] PRIMARY KEY CLUSTERED 
(
	[Instructor_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InstructorTeachIntake]    Script Date: 4/29/2015 2:58:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstructorTeachIntake](
	[Intructor_ID] [int] NOT NULL,
	[Intake_ID] [int] NOT NULL,
 CONSTRAINT [PK_InstructorTeachIntake] PRIMARY KEY CLUSTERED 
(
	[Intructor_ID] ASC,
	[Intake_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Intake]    Script Date: 4/29/2015 2:58:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Intake](
	[Intake_ID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Times] [nvarchar](150) NOT NULL,
	[Course_ID] [int] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Intakes] PRIMARY KEY CLUSTERED 
(
	[Intake_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 4/29/2015 2:58:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[Lesson_ID] [int] IDENTITY(1,1) NOT NULL,
	[LessonName] [nvarchar](50) NOT NULL,
	[LessonContent] [nvarchar](50) NOT NULL,
	[Video] [nvarchar](100) NOT NULL,
	[Course_ID] [int] NOT NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[Lesson_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 4/29/2015 2:58:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Student_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Mobile] [varchar](15) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Gender] [char](1) NOT NULL,
 CONSTRAINT [PK__Students__A2F4E9AC0FD14B72] PRIMARY KEY CLUSTERED 
(
	[Student_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentTakeIntake]    Script Date: 4/29/2015 2:58:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTakeIntake](
	[Intake_ID] [int] NOT NULL,
	[Student_ID] [int] NOT NULL,
 CONSTRAINT [PK_StudentTakeIntake] PRIMARY KEY CLUSTERED 
(
	[Intake_ID] ASC,
	[Student_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Course_ID], [CourseName], [CourseDescription], [CourseContents], [CourseDuration]) VALUES (1, N'Software', N'Software', N'Software', 15)
INSERT [dbo].[Course] ([Course_ID], [CourseName], [CourseDescription], [CourseContents], [CourseDuration]) VALUES (2, N'Database', N'Database', N'Database', 10)
INSERT [dbo].[Course] ([Course_ID], [CourseName], [CourseDescription], [CourseContents], [CourseDuration]) VALUES (3, N'OS', N'OS', N'OS', 15)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Intake] ON 

INSERT [dbo].[Intake] ([Intake_ID], [StartDate], [EndDate], [Times], [Course_ID], [Price]) VALUES (2, CAST(0x0000901A00000000 AS DateTime), CAST(0x0000903A00000000 AS DateTime), N'123', 1, 100)
INSERT [dbo].[Intake] ([Intake_ID], [StartDate], [EndDate], [Times], [Course_ID], [Price]) VALUES (3, CAST(0x0000901A00000000 AS DateTime), CAST(0x0000905700000000 AS DateTime), N'123', 2, 120)
SET IDENTITY_INSERT [dbo].[Intake] OFF
SET IDENTITY_INSERT [dbo].[Lesson] ON 

INSERT [dbo].[Lesson] ([Lesson_ID], [LessonName], [LessonContent], [Video], [Course_ID]) VALUES (1, N'OOP', N'OOP', N'OOP', 1)
INSERT [dbo].[Lesson] ([Lesson_ID], [LessonName], [LessonContent], [Video], [Course_ID]) VALUES (2, N'ERD', N'ERD', N'ERD', 2)
INSERT [dbo].[Lesson] ([Lesson_ID], [LessonName], [LessonContent], [Video], [Course_ID]) VALUES (3, N'DDD', N'DDD', N'DDD', 1)
INSERT [dbo].[Lesson] ([Lesson_ID], [LessonName], [LessonContent], [Video], [Course_ID]) VALUES (4, N'SQL', N'SQL', N'SQL', 2)
SET IDENTITY_INSERT [dbo].[Lesson] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Student_ID], [Name], [Email], [Mobile], [Address], [Gender]) VALUES (1, N'mmr x', N'Mail', N'010', N'01', N'M')
INSERT [dbo].[Student] ([Student_ID], [Name], [Email], [Mobile], [Address], [Gender]) VALUES (2, N'Ahmed', N'ahmed@x.com', N'0111111111', N'Home Sweet Home', N'M')
INSERT [dbo].[Student] ([Student_ID], [Name], [Email], [Mobile], [Address], [Gender]) VALUES (3, N'Ahmed', N'ahmed@x.com', N'0111111111', N'Home Sweet Home', N'M')
INSERT [dbo].[Student] ([Student_ID], [Name], [Email], [Mobile], [Address], [Gender]) VALUES (4, N'Walid', N'x@x.com', N'0111111111', N'123', N'M')
INSERT [dbo].[Student] ([Student_ID], [Name], [Email], [Mobile], [Address], [Gender]) VALUES (6, N'Walid', N'x@x.com', N'0111111111', N'123', N'M')
INSERT [dbo].[Student] ([Student_ID], [Name], [Email], [Mobile], [Address], [Gender]) VALUES (7, N'Walid', N'x@x.com', N'0111111111', N'123', N'M')
INSERT [dbo].[Student] ([Student_ID], [Name], [Email], [Mobile], [Address], [Gender]) VALUES (8, N'Ahmed', N'ahmed@x.com', N'0111111111', N'Home Sweet Home', N'M')
SET IDENTITY_INSERT [dbo].[Student] OFF
INSERT [dbo].[StudentTakeIntake] ([Intake_ID], [Student_ID]) VALUES (2, 1)
INSERT [dbo].[StudentTakeIntake] ([Intake_ID], [Student_ID]) VALUES (3, 1)
ALTER TABLE [dbo].[CenterNewPictures]  WITH CHECK ADD  CONSTRAINT [FK_CenterNewsPictures_CenterNews1] FOREIGN KEY([New_ID])
REFERENCES [dbo].[CenterNew] ([New_ID])
GO
ALTER TABLE [dbo].[CenterNewPictures] CHECK CONSTRAINT [FK_CenterNewsPictures_CenterNews1]
GO
ALTER TABLE [dbo].[InstructorTeachIntake]  WITH CHECK ADD  CONSTRAINT [FK_InstructorTeachIntake_Instructors] FOREIGN KEY([Intructor_ID])
REFERENCES [dbo].[Instructor] ([Instructor_ID])
GO
ALTER TABLE [dbo].[InstructorTeachIntake] CHECK CONSTRAINT [FK_InstructorTeachIntake_Instructors]
GO
ALTER TABLE [dbo].[InstructorTeachIntake]  WITH CHECK ADD  CONSTRAINT [FK_InstructorTeachIntake_Intakes1] FOREIGN KEY([Intake_ID])
REFERENCES [dbo].[Intake] ([Intake_ID])
GO
ALTER TABLE [dbo].[InstructorTeachIntake] CHECK CONSTRAINT [FK_InstructorTeachIntake_Intakes1]
GO
ALTER TABLE [dbo].[Intake]  WITH CHECK ADD  CONSTRAINT [FK_Intakes_Courses] FOREIGN KEY([Course_ID])
REFERENCES [dbo].[Course] ([Course_ID])
GO
ALTER TABLE [dbo].[Intake] CHECK CONSTRAINT [FK_Intakes_Courses]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lessons_Courses] FOREIGN KEY([Course_ID])
REFERENCES [dbo].[Course] ([Course_ID])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lessons_Courses]
GO
ALTER TABLE [dbo].[StudentTakeIntake]  WITH CHECK ADD  CONSTRAINT [FK_StudentTakeIntake_Intakes] FOREIGN KEY([Intake_ID])
REFERENCES [dbo].[Intake] ([Intake_ID])
GO
ALTER TABLE [dbo].[StudentTakeIntake] CHECK CONSTRAINT [FK_StudentTakeIntake_Intakes]
GO
ALTER TABLE [dbo].[StudentTakeIntake]  WITH CHECK ADD  CONSTRAINT [FK_StudentTakeIntake_Students] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[Student] ([Student_ID])
GO
ALTER TABLE [dbo].[StudentTakeIntake] CHECK CONSTRAINT [FK_StudentTakeIntake_Students]
GO
USE [master]
GO
ALTER DATABASE [Center] SET  READ_WRITE 
GO
