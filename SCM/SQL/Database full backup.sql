USE [SCMdb_Dev]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 02/08/2020 00:57:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 02/08/2020 00:57:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[Name] [nvarchar](150) NOT NULL,
	[TeacherName] [nvarchar](150) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
	[Capacity] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCourses]    Script Date: 02/08/2020 00:57:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourses](
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_StudentCourses] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 02/08/2020 00:57:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[ChangeDate] [datetime2](7) NULL,
	[DeleteDate] [datetime2](7) NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[Surname] [nvarchar](120) NOT NULL,
	[Gender] [int] NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[FirstAddress] [nvarchar](200) NOT NULL,
	[SecondAddress] [nvarchar](200) NULL,
	[ThirdAddress] [nvarchar](200) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200802030316_001', N'3.1.6')
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [Name], [TeacherName], [StartDate], [EndDate], [Code], [Capacity]) VALUES (1, CAST(N'2020-08-02T00:29:22.0525437' AS DateTime2), NULL, NULL, N'Golf Management', N'Gulfy Boy', CAST(N'2020-08-01T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-01T00:00:00.0000000' AS DateTime2), N'IWQZJ5X4QLR3', 5)
INSERT [dbo].[Courses] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [Name], [TeacherName], [StartDate], [EndDate], [Code], [Capacity]) VALUES (2, CAST(N'2020-08-02T00:29:52.8863055' AS DateTime2), CAST(N'2020-08-02T00:48:02.5216074' AS DateTime2), CAST(N'2020-08-02T00:48:02.5216026' AS DateTime2), N'Ethical Hacking', N'Mr. Robot', CAST(N'2020-09-12T00:00:00.0000000' AS DateTime2), CAST(N'2020-10-12T00:00:00.0000000' AS DateTime2), N'S75TDT3AC9B5', 5)
INSERT [dbo].[Courses] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [Name], [TeacherName], [StartDate], [EndDate], [Code], [Capacity]) VALUES (3, CAST(N'2020-08-02T00:30:45.3014785' AS DateTime2), NULL, NULL, N'Cruise Management', N'Tom', CAST(N'2021-02-10T00:00:00.0000000' AS DateTime2), CAST(N'2021-06-01T00:00:00.0000000' AS DateTime2), N'HY8Q97293XS8', 2)
INSERT [dbo].[Courses] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [Name], [TeacherName], [StartDate], [EndDate], [Code], [Capacity]) VALUES (4, CAST(N'2020-08-02T00:32:11.0248828' AS DateTime2), NULL, NULL, N'Oenology', N'Carl Drunko', CAST(N'2020-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2020-10-01T00:00:00.0000000' AS DateTime2), N'3OKR2AKFY23S', 8)
INSERT [dbo].[Courses] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [Name], [TeacherName], [StartDate], [EndDate], [Code], [Capacity]) VALUES (5, CAST(N'2020-08-02T00:32:43.8228486' AS DateTime2), NULL, NULL, N'Animal Behaviour and Psychology', N'BoJack', CAST(N'2020-08-20T00:00:00.0000000' AS DateTime2), CAST(N'2020-08-20T00:00:00.0000000' AS DateTime2), N'L5433SIMT0A2', 20)
INSERT [dbo].[Courses] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [Name], [TeacherName], [StartDate], [EndDate], [Code], [Capacity]) VALUES (6, CAST(N'2020-08-02T00:33:39.9561838' AS DateTime2), NULL, NULL, N'Fire Engineering', N'Sr. Charizard', CAST(N'2020-11-22T00:00:00.0000000' AS DateTime2), CAST(N'2021-03-24T00:00:00.0000000' AS DateTime2), N'YG5FHKLAOKJ5', 12)
INSERT [dbo].[Courses] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [Name], [TeacherName], [StartDate], [EndDate], [Code], [Capacity]) VALUES (7, CAST(N'2020-08-02T00:34:48.6076845' AS DateTime2), NULL, NULL, N'Floral Design', N'Ms. Poison Ivy', CAST(N'2021-01-26T00:00:00.0000000' AS DateTime2), CAST(N'2024-01-30T00:00:00.0000000' AS DateTime2), N'5JBJJ6700TVL', 5)
INSERT [dbo].[Courses] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [Name], [TeacherName], [StartDate], [EndDate], [Code], [Capacity]) VALUES (8, CAST(N'2020-08-02T00:36:00.1816597' AS DateTime2), NULL, NULL, N'Puppetry Design and Performance', N'Sr. Kermit Pig', CAST(N'2020-04-04T00:00:00.0000000' AS DateTime2), CAST(N'2022-04-05T00:00:00.0000000' AS DateTime2), N'CHP1C255U6AT', 12)
INSERT [dbo].[Courses] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [Name], [TeacherName], [StartDate], [EndDate], [Code], [Capacity]) VALUES (9, CAST(N'2020-08-02T00:36:44.5838714' AS DateTime2), NULL, NULL, N'Surf Science and Technology', N'Medina O''Cool', CAST(N'2021-08-12T00:00:00.0000000' AS DateTime2), CAST(N'2023-08-29T00:00:00.0000000' AS DateTime2), N'DVT07Z3RCYWV', 1)
INSERT [dbo].[Courses] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [Name], [TeacherName], [StartDate], [EndDate], [Code], [Capacity]) VALUES (10, CAST(N'2020-08-02T00:37:52.7567605' AS DateTime2), NULL, NULL, N'Ecogastronomy', N'Ms. Thunberg', CAST(N'2020-08-19T00:00:00.0000000' AS DateTime2), CAST(N'2050-08-20T00:00:00.0000000' AS DateTime2), N'60RZC2KECLHG', 10000)
INSERT [dbo].[Courses] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [Name], [TeacherName], [StartDate], [EndDate], [Code], [Capacity]) VALUES (11, CAST(N'2020-08-02T00:47:51.0330282' AS DateTime2), NULL, NULL, N'Psychometrics', N'Mr. Bore', CAST(N'2019-08-26T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-08T00:00:00.0000000' AS DateTime2), N'069LQG5WO8QV', 33)
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (2, 1)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (4, 1)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (5, 1)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (8, 1)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (17, 1)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (3, 2)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (2, 3)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (11, 3)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (5, 4)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (6, 4)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (8, 4)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (13, 4)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (15, 4)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (17, 4)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (21, 4)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (1, 5)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (7, 5)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (8, 5)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (11, 5)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (13, 5)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (14, 5)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (15, 5)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (3, 6)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (4, 6)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (8, 6)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (11, 6)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (13, 6)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (1, 7)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (2, 7)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (3, 7)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (8, 7)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (2, 8)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (21, 8)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (11, 9)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (1, 10)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (16, 10)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (18, 10)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (20, 10)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (21, 10)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (3, 11)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (7, 11)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (16, 11)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (20, 11)
INSERT [dbo].[StudentCourses] ([StudentId], [CourseId]) VALUES (21, 11)
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (1, CAST(N'2020-08-02T00:05:58.8669717' AS DateTime2), CAST(N'2020-08-02T00:38:25.4653925' AS DateTime2), NULL, N'Panda', N'Hyper Cute', 2, CAST(N'1995-08-08T00:00:00.0000000' AS DateTime2), N'Bambu Av. nº 123', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (2, CAST(N'2020-08-02T00:06:45.9471045' AS DateTime2), CAST(N'2020-08-02T00:41:52.3955360' AS DateTime2), NULL, N'Duckling', N'Graceful', 2, CAST(N'1997-09-05T00:00:00.0000000' AS DateTime2), N'Closest Pond, no number, UK', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (3, CAST(N'2020-08-02T00:07:59.5272651' AS DateTime2), CAST(N'2020-08-02T00:49:34.5923884' AS DateTime2), NULL, N'Crocodile', N'Nothso Ferocious', 4, CAST(N'2002-04-03T00:00:00.0000000' AS DateTime2), N'Your pool, Florida - US', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (4, CAST(N'2020-08-02T00:09:08.4170823' AS DateTime2), CAST(N'2020-08-02T00:49:41.4609350' AS DateTime2), NULL, N'Deer', N'Oh-My', 2, CAST(N'2001-08-03T00:00:00.0000000' AS DateTime2), N'Phoenix Park, Dublin - DRoI', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (5, CAST(N'2020-08-02T00:10:20.6218658' AS DateTime2), CAST(N'2020-08-02T00:49:55.9468596' AS DateTime2), NULL, N'Hedgehog', N'Buthnot Hug', 3, CAST(N'2009-05-09T00:00:00.0000000' AS DateTime2), N'In My Heart Rd. nº90', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (6, CAST(N'2020-08-02T00:11:23.1897858' AS DateTime2), CAST(N'2020-08-02T00:50:01.2207401' AS DateTime2), NULL, N'Lamb', N'O''Curly', 5, CAST(N'1998-08-12T00:00:00.0000000' AS DateTime2), N'Great Mountain Rd. - Close to the Fence County', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (7, CAST(N'2020-08-02T00:12:15.9583136' AS DateTime2), CAST(N'2020-08-02T00:50:06.2646265' AS DateTime2), NULL, N'Sloth', N'MacSlow', 3, CAST(N'1980-03-07T00:00:00.0000000' AS DateTime2), N'Still moving, nº 70B', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (8, CAST(N'2020-08-02T00:13:51.6598745' AS DateTime2), CAST(N'2020-08-02T00:50:18.7731605' AS DateTime2), NULL, N'Seal', N'Tomorro''', 6, CAST(N'1991-08-24T00:00:00.0000000' AS DateTime2), N'Arctic n Cold, Norway', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (9, CAST(N'2020-08-02T00:14:59.8278523' AS DateTime2), CAST(N'2020-08-02T00:48:12.4401258' AS DateTime2), CAST(N'2020-08-02T00:48:12.4401233' AS DateTime2), N'Skunk', N'Smil', 0, CAST(N'2008-09-25T00:00:00.0000000' AS DateTime2), N'A bit further away, please', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (10, CAST(N'2020-08-02T00:15:36.7935988' AS DateTime2), NULL, NULL, N'Fox', N'A''Million', 5, CAST(N'2020-05-12T00:00:00.0000000' AS DateTime2), N'Disguised Road, Not Sure number', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (11, CAST(N'2020-08-02T00:17:03.2882339' AS DateTime2), CAST(N'2020-08-02T00:45:49.1125209' AS DateTime2), NULL, N'Owl', N'MaGosh', 0, CAST(N'2014-08-18T00:00:00.0000000' AS DateTime2), N'Forest Gump Av, 90 - US', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (12, CAST(N'2020-08-02T00:19:47.9433519' AS DateTime2), NULL, NULL, N'Hippo', N'NotCampus', 1, CAST(N'1973-08-18T00:00:00.0000000' AS DateTime2), N'Giant Lake, the cool one - Uganda', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (13, CAST(N'2020-08-02T00:20:43.8667333' AS DateTime2), CAST(N'2020-08-02T00:51:00.9108260' AS DateTime2), NULL, N'Chameleon', N'NotLion', 0, CAST(N'2018-08-24T00:00:00.0000000' AS DateTime2), N'We actually don''t know', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (14, CAST(N'2020-08-02T00:21:28.0651534' AS DateTime2), CAST(N'2020-08-02T00:51:05.9645483' AS DateTime2), NULL, N'Beluga', N'Whyle', 2, CAST(N'2000-07-04T00:00:00.0000000' AS DateTime2), N'Coast Of Iceland', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (15, CAST(N'2020-08-02T00:22:17.6514289' AS DateTime2), CAST(N'2020-08-02T00:51:12.0727013' AS DateTime2), NULL, N'Alpaca', N'Mia', 2, CAST(N'2002-04-25T00:00:00.0000000' AS DateTime2), N'Seeing the Whole Chile Rd. 111 - CH', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (16, CAST(N'2020-08-02T00:23:31.1135497' AS DateTime2), CAST(N'2020-08-02T00:51:17.5916815' AS DateTime2), NULL, N'Clam', N'Giganto', 4, CAST(N'2009-01-18T00:00:00.0000000' AS DateTime2), N'Clumsy Or Not Av. 900 - South Ocean', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (17, CAST(N'2020-08-02T00:24:23.1526179' AS DateTime2), CAST(N'2020-08-02T00:51:24.7633763' AS DateTime2), NULL, N'Jellyfish', N'Orabag', 4, CAST(N'2020-02-25T00:00:00.0000000' AS DateTime2), N'Rumbling arround Av. All the Ocean - Forever N Ever', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (18, CAST(N'2020-08-02T00:25:25.1514763' AS DateTime2), CAST(N'2020-08-02T00:51:28.8954443' AS DateTime2), NULL, N'Ladybug', N'Pokma', 2, CAST(N'1957-08-25T00:00:00.0000000' AS DateTime2), N'Amazon Forest and My Room St. 444', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (19, CAST(N'2020-08-02T00:26:04.6067025' AS DateTime2), NULL, NULL, N'Toucan', N'Ornot Tucan', 0, CAST(N'1999-08-03T00:00:00.0000000' AS DateTime2), N'Fly Awa'' St. no number - BR', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (20, CAST(N'2020-08-02T00:27:10.2626429' AS DateTime2), CAST(N'2020-08-02T00:51:33.0720359' AS DateTime2), NULL, N'Dingo', N'OwBells', 6, CAST(N'1992-04-04T00:00:00.0000000' AS DateTime2), N'All the way - Xmas Rd.', NULL, NULL)
INSERT [dbo].[Students] ([Id], [CreationDate], [ChangeDate], [DeleteDate], [FirstName], [Surname], [Gender], [DateOfBirth], [FirstAddress], [SecondAddress], [ThirdAddress]) VALUES (21, CAST(N'2020-08-02T00:46:35.1881748' AS DateTime2), CAST(N'2020-08-02T00:51:43.0798191' AS DateTime2), NULL, N'Pangolin', N'Pangow', 0, CAST(N'1992-08-31T00:00:00.0000000' AS DateTime2), N'Farfrom-u St. 900', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
ALTER TABLE [dbo].[StudentCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourses_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentCourses] CHECK CONSTRAINT [FK_StudentCourses_Courses_CourseId]
GO
ALTER TABLE [dbo].[StudentCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourses_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentCourses] CHECK CONSTRAINT [FK_StudentCourses_Students_StudentId]
GO
