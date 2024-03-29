create database [LeaguerManagement]
go
USE [LeaguerManagement]
GO
/****** Object:  Table [dbo].[AccessControl]    Script Date: 9/20/2021 5:27:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessControl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccessOfRole]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessOfRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[AccessControlId] [int] NOT NULL,
	[IsActivated] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppliedDocument]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppliedDocument](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LeaguerId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[OfficialDocumentId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppliedDocumentAttachment]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppliedDocumentAttachment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppliedDocumentId] [int] NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[FilePath] [nvarchar](max) NOT NULL,
	[FileExtension] [nvarchar](max) NOT NULL,
	[FileUrl] [nvarchar](max) NULL,
	[FileSize] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedByUserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChangeOfficialDocument]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChangeOfficialDocument](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ChangeOfficialDocumentTypeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChangeOfficialDocumentType]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChangeOfficialDocumentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documentation]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentationAttachment]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentationAttachment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentationId] [int] NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[FilePath] [nvarchar](max) NOT NULL,
	[FileExtension] [nvarchar](max) NOT NULL,
	[FileUrl] [nvarchar](max) NULL,
	[FileSize] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedByUserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leaguer]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leaguer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UnitId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[BornYear] [int] NOT NULL,
	[Gender] [bit] NOT NULL,
	[Religion] [nvarchar](max) NULL,
	[Folk] [nvarchar](max) NULL,
	[HomeTown] [nvarchar](max) NULL,
	[EducationalLevel] [nvarchar](max) NULL,
	[PoliticalTheoryLevel] [nvarchar](max) NULL,
	[ForeignLanguageLevel] [nvarchar](max) NULL,
	[SpecializeMajor] [nvarchar](max) NULL,
	[BeforeEnteringCareer] [nvarchar](max) NULL,
	[CurrentCareer] [nvarchar](max) NULL,
	[Position] [nvarchar](max) NULL,
	[PreliminaryApplyDate] [datetime] NULL,
	[OfficialApplyDate] [datetime] NULL,
	[CardNumber] [varchar](10) NOT NULL,
	[BackgroundNumber] [varchar](20) NULL,
	[BadgeNumber] [varchar](20) NULL,
	[MoveOutDated] [datetime] NULL,
	[OfficeComing] [nvarchar](max) NULL,
	[MoveInDated] [datetime] NULL,
	[AtOffice] [nvarchar](max) NULL,
	[DeadDate] [datetime] NULL,
	[DeathReason] [nvarchar](max) NULL,
	[GetOutDate] [datetime] NULL,
	[FormOut] [nvarchar](max) NULL,
	[Phone] [int] NULL,
	[Notes] [nvarchar](max) NULL,
	[StatusId] [int] NOT NULL,
	[IsActivated] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaguerAttachment]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaguerAttachment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LeaguerId] [int] NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[FilePath] [nvarchar](max) NOT NULL,
	[FileExtension] [nvarchar](max) NOT NULL,
	[FileUrl] [nvarchar](max) NULL,
	[FileSize] [bigint] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[IsAvatar] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pronouns]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pronouns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RatingResult]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RatingResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [varchar](55) NOT NULL,
	[RatingId] [int] NULL,
	[LeaguerId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IdentifyNumber] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Salt] [nvarchar](max) NOT NULL,
	[IsActivated] [bit] NOT NULL,
	[JobPosition] [nvarchar](max) NULL,
	[UnitId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsActivated] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserToken]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserToken](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Token] [nvarchar](max) NOT NULL,
	[ImageToken] [nvarchar](max) NOT NULL,
	[ExpireAt] [datetime] NOT NULL,
	[IsRevoked] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccessControl] ON 

INSERT [dbo].[AccessControl] ([Id], [Name]) VALUES (1, N'Cài đặt hệ thống')
INSERT [dbo].[AccessControl] ([Id], [Name]) VALUES (2, N'Quản lý người dùng')
SET IDENTITY_INSERT [dbo].[AccessControl] OFF
GO
SET IDENTITY_INSERT [dbo].[AccessOfRole] ON 

INSERT [dbo].[AccessOfRole] ([Id], [RoleId], [AccessControlId], [IsActivated]) VALUES (1, 1, 1, 1)
INSERT [dbo].[AccessOfRole] ([Id], [RoleId], [AccessControlId], [IsActivated]) VALUES (2, 2, 1, 1)
INSERT [dbo].[AccessOfRole] ([Id], [RoleId], [AccessControlId], [IsActivated]) VALUES (3, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[AccessOfRole] OFF
GO
SET IDENTITY_INSERT [dbo].[AppliedDocument] ON 

INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1, 2, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (2, 2, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (3, 2, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (4, 2, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (5, 2, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (6, 2, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (7, 2, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (8, 2, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (9, 2, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (10, 2, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (11, 2, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (12, 3, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (13, 3, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (14, 3, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (15, 3, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (16, 3, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (17, 3, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (18, 3, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (19, 3, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (20, 3, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (21, 3, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (22, 3, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (23, 4, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (24, 4, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (25, 4, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (26, 4, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (27, 4, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (28, 4, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (29, 4, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (30, 4, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (31, 4, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (32, 4, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (33, 4, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (34, 7, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (35, 7, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (36, 7, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (37, 7, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (38, 7, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (39, 7, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (40, 7, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (41, 7, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (42, 7, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (43, 7, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (44, 7, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (45, 8, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (46, 8, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (47, 8, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (48, 8, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (49, 8, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (50, 8, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (51, 8, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (52, 8, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (53, 8, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (54, 8, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (55, 8, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (56, 9, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (57, 9, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (58, 9, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (59, 9, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (60, 9, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (61, 9, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (62, 9, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (63, 9, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (64, 9, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (65, 9, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (66, 9, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (67, 10, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (68, 10, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (69, 10, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (70, 10, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (71, 10, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (72, 10, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (73, 10, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (74, 10, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (75, 10, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (76, 10, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (77, 10, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (78, 12, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (79, 12, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (80, 12, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (81, 12, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (82, 12, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (83, 12, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (84, 12, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (85, 12, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (86, 12, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (87, 12, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (88, 12, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (89, 13, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (90, 13, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (91, 13, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (92, 13, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (93, 13, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (94, 13, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (95, 13, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (96, 13, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (97, 13, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (98, 13, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (99, 13, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
GO
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (100, 14, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (101, 14, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (102, 14, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (103, 14, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (104, 14, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (105, 14, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (106, 14, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (107, 14, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (108, 14, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (109, 14, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (110, 14, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (111, 11, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (112, 11, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (113, 11, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (114, 11, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (115, 11, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (116, 11, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (117, 11, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (118, 11, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (119, 11, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (120, 11, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (121, 11, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (122, 15, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (123, 15, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (124, 15, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (125, 15, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (126, 15, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (127, 15, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (128, 15, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (129, 15, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (130, 15, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (131, 15, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (132, 15, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (133, 16, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (134, 16, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (135, 16, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (136, 16, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (137, 16, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (138, 16, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (139, 16, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (140, 16, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (141, 16, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (142, 16, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (143, 16, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (144, 17, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (145, 17, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (146, 17, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (147, 17, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (148, 17, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (149, 17, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (150, 17, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (151, 17, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (152, 17, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (153, 17, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (154, 17, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (155, 19, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (156, 19, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (157, 19, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (158, 19, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (159, 19, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (160, 19, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (161, 19, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (162, 19, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (163, 19, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (164, 19, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (165, 19, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (166, 20, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (167, 20, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (168, 20, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (169, 20, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (170, 20, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (171, 20, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (172, 20, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (173, 20, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (174, 20, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (175, 20, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (176, 20, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (177, 21, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (178, 21, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (179, 21, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (180, 21, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (181, 21, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (182, 21, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (183, 21, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (184, 21, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (185, 21, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (186, 21, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (187, 21, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (188, 22, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (189, 22, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (190, 22, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (191, 22, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (192, 22, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (193, 22, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (194, 22, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (195, 22, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (196, 22, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (197, 22, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (198, 22, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (199, 18, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
GO
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (200, 18, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (201, 18, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (202, 18, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (203, 18, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (204, 18, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (205, 18, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (206, 18, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (207, 18, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (208, 18, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (209, 18, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (210, 23, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (211, 23, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (212, 23, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (213, 23, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (214, 23, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (215, 23, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (216, 23, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (217, 23, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (218, 23, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (219, 23, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (220, 23, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (221, 24, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (222, 24, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (223, 24, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (224, 24, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (225, 24, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (226, 24, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (227, 24, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (228, 24, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (229, 24, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (230, 24, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (231, 24, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (232, 25, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (233, 25, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (234, 25, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (235, 25, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (236, 25, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (237, 25, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (238, 25, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (239, 25, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (240, 25, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (241, 25, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (242, 25, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (243, 26, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (244, 26, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (245, 26, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (246, 26, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (247, 26, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (248, 26, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (249, 26, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (250, 26, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (251, 26, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (252, 26, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (253, 26, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (254, 27, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (255, 27, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (256, 27, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (257, 27, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (258, 27, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (259, 27, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (260, 27, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (261, 27, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (262, 27, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (263, 27, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (264, 27, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (265, 28, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (266, 28, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (267, 28, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (268, 28, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (269, 28, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (270, 28, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (271, 28, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (272, 28, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (273, 28, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (274, 28, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (275, 28, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (276, 44, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (277, 44, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (278, 44, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (279, 44, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (280, 44, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (281, 44, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (282, 44, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (283, 44, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (284, 44, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (285, 44, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (286, 44, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (287, 43, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (288, 43, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (289, 43, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (290, 43, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (291, 43, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (292, 43, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (293, 43, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (294, 43, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (295, 43, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (296, 43, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (297, 43, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (298, 5, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (299, 5, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
GO
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (300, 5, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (301, 5, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (302, 5, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (303, 5, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (304, 5, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (305, 5, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (306, 5, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (307, 5, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (308, 5, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1012, 6, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1013, 6, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1014, 6, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1015, 6, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1016, 6, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1017, 6, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1018, 6, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1019, 6, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1020, 6, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1021, 6, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1022, 6, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1023, 29, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1024, 29, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1025, 29, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1026, 29, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1027, 29, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1028, 29, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1029, 29, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1030, 29, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1031, 29, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1032, 29, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1033, 29, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1034, 30, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1035, 30, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1036, 30, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1037, 30, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1038, 30, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1039, 30, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1040, 30, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1041, 30, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1042, 30, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1043, 30, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1044, 30, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1045, 31, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1046, 31, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1047, 31, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1048, 31, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1049, 31, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1050, 31, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1051, 31, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1052, 31, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1053, 31, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1054, 31, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1055, 31, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1056, 32, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1057, 32, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1058, 32, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1059, 32, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1060, 32, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1061, 32, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1062, 32, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1063, 32, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1064, 32, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1065, 32, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1066, 32, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1067, 33, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1068, 33, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1069, 33, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1070, 33, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1071, 33, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1072, 33, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1073, 33, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1074, 33, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1075, 33, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1076, 33, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1077, 33, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1078, 34, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1079, 34, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1080, 34, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1081, 34, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1082, 34, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1083, 34, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1084, 34, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1085, 34, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1086, 34, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1087, 34, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1088, 34, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1089, 35, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1090, 35, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1091, 35, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1092, 35, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1093, 35, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1094, 35, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1095, 35, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1096, 35, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1097, 35, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1098, 35, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1099, 35, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1100, 36, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1101, 36, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1102, 36, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
GO
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1103, 36, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1104, 36, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1105, 36, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1106, 36, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1107, 36, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1108, 36, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1109, 36, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1110, 36, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1111, 37, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1112, 37, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1113, 37, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1114, 37, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1115, 37, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1116, 37, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1117, 37, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1118, 37, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1119, 37, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1120, 37, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1121, 37, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1122, 38, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1123, 38, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1124, 38, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1125, 38, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1126, 38, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1127, 38, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1128, 38, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1129, 38, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1130, 38, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1131, 38, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1132, 38, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1133, 39, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1134, 39, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1135, 39, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1136, 39, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1137, 39, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1138, 39, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1139, 39, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1140, 39, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1141, 39, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1142, 39, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1143, 39, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1144, 40, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1145, 40, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1146, 40, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1147, 40, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1148, 40, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1149, 40, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1150, 40, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1151, 40, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1152, 40, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1153, 40, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1154, 40, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1155, 41, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1156, 41, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1157, 41, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1158, 41, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1159, 41, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1160, 41, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1161, 41, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1162, 41, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1163, 41, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1164, 41, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1165, 41, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1166, 42, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1167, 42, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1168, 42, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1169, 42, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1170, 42, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1171, 42, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1172, 42, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1173, 42, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1174, 42, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1175, 42, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1176, 42, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1177, 1003, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1178, 1003, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1179, 1003, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1180, 1003, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1181, 1003, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1182, 1003, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1183, 1003, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1184, 1003, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1185, 1003, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1186, 1003, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1187, 1003, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1188, 1004, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1189, 1004, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1190, 1004, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1191, 1004, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1192, 1004, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1193, 1004, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1194, 1004, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1195, 1004, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1196, 1004, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1197, 1004, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1198, 1004, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1199, 1005, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1200, 1005, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1201, 1005, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1202, 1005, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
GO
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1203, 1005, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1204, 1005, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1205, 1005, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1206, 1005, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1207, 1005, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1208, 1005, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1209, 1005, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1210, 1006, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1211, 1006, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 2)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1212, 1006, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 3)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1213, 1006, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 4)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1214, 1006, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 5)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1215, 1006, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 6)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1216, 1006, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 7)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1217, 1006, N'Bản chính', 8)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1218, 1006, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 9)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1219, 1006, N'Phiếu Đảng viên', 10)
INSERT [dbo].[AppliedDocument] ([Id], [LeaguerId], [Name], [OfficialDocumentId]) VALUES (1220, 1006, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 11)
SET IDENTITY_INSERT [dbo].[AppliedDocument] OFF
GO
SET IDENTITY_INSERT [dbo].[ChangeOfficialDocument] ON 

INSERT [dbo].[ChangeOfficialDocument] ([Id], [Name], [ChangeOfficialDocumentTypeId]) VALUES (1, N'Bản tự kiểm điểm của đảng viên dự bị', 1)
INSERT [dbo].[ChangeOfficialDocument] ([Id], [Name], [ChangeOfficialDocumentTypeId]) VALUES (2, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 1', 1)
INSERT [dbo].[ChangeOfficialDocument] ([Id], [Name], [ChangeOfficialDocumentTypeId]) VALUES (3, N'Bản nhận xét về đảng viên dự bị của đảng viên chính thức được phân công giúp đỡ của đảng viên chính thức thứ 2', 1)
INSERT [dbo].[ChangeOfficialDocument] ([Id], [Name], [ChangeOfficialDocumentTypeId]) VALUES (4, N'Bản Tổng hợp ý kiến nhận xét của tổ chức chính trị - xã hội nơi làm việc và chi ủy nơi cư trú', 1)
INSERT [dbo].[ChangeOfficialDocument] ([Id], [Name], [ChangeOfficialDocumentTypeId]) VALUES (5, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của chi bộ', 1)
INSERT [dbo].[ChangeOfficialDocument] ([Id], [Name], [ChangeOfficialDocumentTypeId]) VALUES (6, N'Báo cáo thẩm định của đảng ủy bộ phận (nếu có)', 1)
INSERT [dbo].[ChangeOfficialDocument] ([Id], [Name], [ChangeOfficialDocumentTypeId]) VALUES (7, N'Nghị quyết xét, đề nghị công nhận đảng viên chính thức của Đảng ủy cơ sở', 1)
INSERT [dbo].[ChangeOfficialDocument] ([Id], [Name], [ChangeOfficialDocumentTypeId]) VALUES (8, N'Bản chính', 2)
INSERT [dbo].[ChangeOfficialDocument] ([Id], [Name], [ChangeOfficialDocumentTypeId]) VALUES (9, N'Biên bản họp nhận xét của Công đoàn + Đoàn Thanh niên', 3)
INSERT [dbo].[ChangeOfficialDocument] ([Id], [Name], [ChangeOfficialDocumentTypeId]) VALUES (10, N'Phiếu Đảng viên', 3)
INSERT [dbo].[ChangeOfficialDocument] ([Id], [Name], [ChangeOfficialDocumentTypeId]) VALUES (11, N'Biên bản họp chi bộ tháng thông qua nghị quyết kết nạp', 3)
SET IDENTITY_INSERT [dbo].[ChangeOfficialDocument] OFF
GO
SET IDENTITY_INSERT [dbo].[ChangeOfficialDocumentType] ON 

INSERT [dbo].[ChangeOfficialDocumentType] ([Id], [Name]) VALUES (1, N'Quyển hồ sơ công nhận đảng viên chính thức')
INSERT [dbo].[ChangeOfficialDocumentType] ([Id], [Name]) VALUES (2, N'Giấy chứng nhận học lớp bồi dưỡng đảng viên mới')
INSERT [dbo].[ChangeOfficialDocumentType] ([Id], [Name]) VALUES (3, N'Các loại giấy tờ khác')
SET IDENTITY_INSERT [dbo].[ChangeOfficialDocumentType] OFF
GO
SET IDENTITY_INSERT [dbo].[Documentation] ON 

INSERT [dbo].[Documentation] ([Id], [Name]) VALUES (6, N'Phiếu bổ sung thông tin đảng viên')
INSERT [dbo].[Documentation] ([Id], [Name]) VALUES (7, N'Tài liệu khai lý lịch quần chúng ưu tú')
INSERT [dbo].[Documentation] ([Id], [Name]) VALUES (8, N'Tài liệu hồ sơ đảng viên')
SET IDENTITY_INSERT [dbo].[Documentation] OFF
GO
SET IDENTITY_INSERT [dbo].[DocumentationAttachment] ON 

INSERT [dbo].[DocumentationAttachment] ([Id], [DocumentationId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId]) VALUES (15, 6, N'Phieu bo sung HS dang vien 2020.doc', N'Contents\Uploads\Documentations\6\15_Phieu bo sung HS dang vien 2020.doc', N'.doc', N'/images/15_Phieu bo sung HS dang vien 2020.doc', 53248, CAST(N'2021-08-05T14:17:23.417' AS DateTime), 2)
INSERT [dbo].[DocumentationAttachment] ([Id], [DocumentationId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId]) VALUES (16, 6, N'Phieu BS ho so dang vien sau khi lap gia dinh.doc', N'Contents\Uploads\Documentations\6\16_Phieu BS ho so dang vien sau khi lap gia dinh.doc', N'.doc', N'/images/16_Phieu BS ho so dang vien sau khi lap gia dinh.doc', 36352, CAST(N'2021-08-05T14:17:23.577' AS DateTime), 2)
INSERT [dbo].[DocumentationAttachment] ([Id], [DocumentationId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId]) VALUES (17, 7, N'HUONG DAN KHAI LY LICH CUA NGUOI XIN VAO DANG.docx', N'Contents\Uploads\Documentations\7\17_HUONG DAN KHAI LY LICH CUA NGUOI XIN VAO DANG.docx', N'.docx', N'/images/17_HUONG DAN KHAI LY LICH CUA NGUOI XIN VAO DANG.docx', 17162, CAST(N'2021-08-05T14:18:26.713' AS DateTime), 2)
INSERT [dbo].[DocumentationAttachment] ([Id], [DocumentationId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId]) VALUES (18, 7, N'ly-lich-cua-nguoi-xin-vao-dang_mau-2-knd_new.docx', N'Contents\Uploads\Documentations\7\18_ly-lich-cua-nguoi-xin-vao-dang_mau-2-knd_new.docx', N'.docx', N'/images/18_ly-lich-cua-nguoi-xin-vao-dang_mau-2-knd_new.docx', 35437, CAST(N'2021-08-05T14:18:26.747' AS DateTime), 2)
INSERT [dbo].[DocumentationAttachment] ([Id], [DocumentationId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId]) VALUES (19, 8, N'HUONG DAN VIET HO SO KET NAP DANG VA CAC BIEU MAU KET NAP DANG VIEN.doc', N'Contents\Uploads\Documentations\8\19_HUONG DAN VIET HO SO KET NAP DANG VA CAC BIEU MAU KET NAP DANG VIEN.doc', N'.doc', N'/images/19_HUONG DAN VIET HO SO KET NAP DANG VA CAC BIEU MAU KET NAP DANG VIEN.doc', 152064, CAST(N'2021-08-05T14:19:55.243' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[DocumentationAttachment] OFF
GO
SET IDENTITY_INSERT [dbo].[Leaguer] ON 

INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (2, 1, N'Hứa Ngọc Hòa', 1996, 1, N'Không', N'Kinh', N'Trường Xuân, Tam Kỳ, Quảng Nam', N'12/12', N'sơ cấp', N'B1', N'Cử nhân Kinh tế', N'Sinh viên', N'', N'Chuyên viên', CAST(N'2017-12-17T00:00:00.000' AS DateTime), CAST(N'2018-12-17T00:00:00.000' AS DateTime), N'39.058840', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 964471983, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (3, 1, N'Đặng Nguyễn Thục Anh', 1982, 0, N'Không', N'Kinh', N'Xã Hoà Phong, huyện Hoà Vang, thành phố Đà Nẵng', N'12/12', N'Trung cấp', N'Anh văn B và B1', N'Kỹ thuật môi trường', N'Công chức', N'Công chức', N'Phó Bí thư Chi bộ, Phó TP Khoáng sản và Tài nguyên nước', CAST(N'2013-03-27T00:00:00.000' AS DateTime), CAST(N'2014-03-27T00:00:00.000' AS DateTime), N'39.0448178', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 979777491, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (4, 1, N'Nguyễn Hồng An', 1974, 1, N'Không', N'Kinh', N'Xã Điện Hoà, huyện Điện Bàn, tỉnh Quàng Nam', N'12/12', NULL, NULL, NULL, NULL, NULL, N'Phó Bí thư Đảng ủy, Phó GĐ Sở TN và MT', CAST(N'2006-03-23T00:00:00.000' AS DateTime), CAST(N'2007-03-23T00:00:00.000' AS DateTime), N'39.032816', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (5, 1, N'Nguyễn Thị Bằng', 1974, 0, N'Không', N'Kinh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'339042765', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (6, 11, N'Nguyễn Quang Vinh', 1978, 1, N'Không', N'Kinh', NULL, N'12/12', N'Cao cấp', N'B1-Anh văn', N'Thạc sĩ Khoa học máy tính', N'Công chức', NULL, NULL, CAST(N'2007-11-22T00:00:00.000' AS DateTime), CAST(N'2008-11-22T00:00:00.000' AS DateTime), N'39.035.501', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (7, 14, N'Phạm Hương Giang', 1983, 0, N'Kinh', N'Không', N'Xã Trường Sơn, huyện Nông Cống, tỉnh Thanh Hòa', N'12/12', N'Trung cấp', N'Anh Văn C', N'', NULL, N'Chuyên viên', N'Chuyên viên', CAST(N'2015-02-03T00:00:00.000' AS DateTime), CAST(N'2016-02-03T00:00:00.000' AS DateTime), N'39052207', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 905357112, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (8, 14, N'Nguyễn Hồng Song', 1975, 1, N'Không', N'Kinh', N'Điện Hòa, Điện Bàn, Quảng Nam', N'12/12', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2003-11-28T00:00:00.000' AS DateTime), CAST(N'2004-11-28T00:00:00.000' AS DateTime), N'39027468', NULL, N'39027468', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (9, 14, N'Nguyễn Văn A', 1963, 1, N'Không', N'Kinh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'1988-01-12T00:00:00.000' AS DateTime), CAST(N'1989-01-12T00:00:00.000' AS DateTime), N'39011418', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 905358777, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (10, 14, N'Trần Bá Thành', 1973, 1, N'Không', N'Kinh', N'Hòa Châu, Hòa Vang, Đà Nẵng', NULL, N'Trung cấp', NULL, NULL, NULL, N'Phó Giám đốc', N'Phó Giám đốc Văn phòng Đăng ký đất đai thành phố', CAST(N'2007-09-10T00:00:00.000' AS DateTime), CAST(N'2008-09-10T00:00:00.000' AS DateTime), N'39035026', NULL, N'39035026', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 903595090, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (11, 14, N'Nguyễn Thị Phượng', 1981, 0, N'Không', N'Kinh', N'Hà Lam, Thăng Bình, Quảng Nam', NULL, N'Trung cấp', NULL, N'kế Toán', NULL, NULL, NULL, CAST(N'2010-10-11T00:00:00.000' AS DateTime), CAST(N'2011-10-11T00:00:00.000' AS DateTime), N'39042149', NULL, N'39042149', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 905056107, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (12, 14, N'Đỗ Thanh Huân', 1970, 1, N'Không', N'Kinh', N'Hòa Châu, Hòa Vang, Đà Nẵng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'1996-02-10T00:00:00.000' AS DateTime), CAST(N'1997-02-10T00:00:00.000' AS DateTime), N'39023734', NULL, N'39023734', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 905003123, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (13, 14, N'Bùi Văn Hưng', 1969, 1, N'Không', N'Kinh', N'Hòa Nhơn, Hòa Vang, Đà Nẵng', NULL, N'Trung cấp', NULL, NULL, NULL, N'Trưởng phòng', N'Trưởng phòng Đăng ký địa chính', CAST(N'2015-02-03T00:00:00.000' AS DateTime), CAST(N'2016-02-03T00:00:00.000' AS DateTime), N'39052206', NULL, N'39052206', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 913432340, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (14, 14, N'Hồ Văn Vinh', 1974, 1, N'Không', N'Kinh', N'Hòa Xuân, Cẩm Lệ, Đà Nẵng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2014-12-25T00:00:00.000' AS DateTime), CAST(N'2015-12-25T00:00:00.000' AS DateTime), N'39051866', NULL, N'39051866', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 905124412, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (15, 14, N'Trần Thị Việt Hà', 1971, 0, N'Không', N'Kinh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2002-12-31T00:00:00.000' AS DateTime), CAST(N'2003-12-31T00:00:00.000' AS DateTime), N'39019945', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (16, 14, N'Ông Thị Bích Liên', 1978, 0, N'Không', N'Kinh', N'Hòa Châu, Hòa Vang, Đà Nẵng', NULL, NULL, NULL, NULL, NULL, NULL, N'Kế Toán Trưởng Văn phòng Đăng ký', CAST(N'2010-10-30T00:00:00.000' AS DateTime), CAST(N'2011-10-30T00:00:00.000' AS DateTime), N'39041356', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (17, 14, N'Trần Thị Thanh Trà', 1985, 0, N'Không', N'Kinh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Chuyên viên', CAST(N'2015-02-03T00:00:00.000' AS DateTime), CAST(N'2016-02-03T00:00:00.000' AS DateTime), N'39052208', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (18, 14, N'Nguyễn Thị Anh Đào', 1977, 0, N'Không ', N'Kinh', N'Hòa Phước, Hòa Vang, Đà Nẵng', NULL, N'Trung cấp', NULL, NULL, NULL, NULL, NULL, CAST(N'2014-12-25T00:00:00.000' AS DateTime), CAST(N'2015-12-25T00:00:00.000' AS DateTime), N'39051867', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (19, 14, N'Lê Trung Huệ', 1984, 1, N'Không', N'Kinh', N'Hòa Quý, Ngũ Hành Sơn, Đà Nẵng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2005-05-03T00:00:00.000' AS DateTime), CAST(N'2006-05-03T00:00:00.000' AS DateTime), N'39031075', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (20, 14, N'Lê Văn Thành', 1972, 1, N'Không', N'Kinh', N'Hòa Tiến, Hòa Vang, Đà Nẵng', NULL, NULL, NULL, NULL, NULL, N'Chuyên viên', N'Chuyên viên', CAST(N'2016-04-25T00:00:00.000' AS DateTime), CAST(N'2017-04-25T00:00:00.000' AS DateTime), N'39055137', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (21, 14, N'Nguyễn Thị Lê Phương', 1987, 0, N'Không', N'Kinh', N'Hòa Hiệp Nam, Liên Chiểu, Đà Nẵng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2015-01-27T00:00:00.000' AS DateTime), CAST(N'2016-01-27T00:00:00.000' AS DateTime), N'39051995', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (22, 14, N'Nguyễn Thanh Hiếu Trung', 1991, 1, N'Không', N'Kinh', N'Bình Chánh, Bình Sơn, Quảng Ngãi', NULL, N'Trung cấp', NULL, NULL, NULL, NULL, NULL, CAST(N'2015-10-09T00:00:00.000' AS DateTime), CAST(N'2016-10-09T00:00:00.000' AS DateTime), N'39053420', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (23, 14, N'Nguyễn Trung Hiếu', 1989, 1, N'Không', N'Kinh', NULL, NULL, N'sơ cấp', NULL, NULL, NULL, NULL, NULL, CAST(N'2010-07-02T00:00:00.000' AS DateTime), CAST(N'2011-07-02T00:00:00.000' AS DateTime), N'55049563', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (24, 14, N'Trần Quốc Tuấn', 1978, 1, N'Không', N'Kinh', N'Quảng Thọ, Quảng Điền, Thừa Thiên Huế', NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2015-05-25T00:00:00.000' AS DateTime), CAST(N'2016-05-25T00:00:00.000' AS DateTime), N'39052753', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (25, 14, N'Nguyễn Thị Nguyên', 1976, 0, N'Không', N'Kinh', N'Hòa Tiến, Hòa Vang, Đà Nẵng', NULL, NULL, NULL, NULL, NULL, N'Chuyên viên', N'Chuyên viên', CAST(N'2009-11-14T00:00:00.000' AS DateTime), CAST(N'2010-11-14T00:00:00.000' AS DateTime), N'39039552', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (26, 14, N'Lê Phước Thương', 1973, 1, N'Không', N'Kinh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2006-05-19T00:00:00.000' AS DateTime), CAST(N'2007-05-19T00:00:00.000' AS DateTime), N'39032096', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (27, 14, N'Lê Thị Minh Tân', 1984, 0, N'Không', N'Kinh', NULL, NULL, NULL, NULL, NULL, N'Chuyên viên Chi nhánh VPĐK quận Sơn Trà', N'Chuyên viên', N'Chuyên viên', CAST(N'2015-09-25T00:00:00.000' AS DateTime), CAST(N'2016-09-25T00:00:00.000' AS DateTime), N'39052781', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (28, 14, N'Nguyễn Văn Thiện', 1995, 1, N'Không', N'Kinh', NULL, NULL, NULL, NULL, NULL, NULL, N'Chuyên viên', N'Chuyên viên', CAST(N'2016-06-10T00:00:00.000' AS DateTime), CAST(N'2017-06-10T00:00:00.000' AS DateTime), N'3956711', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (29, 7, N'Nguyễn Văn Anh', 1965, 1, N'Không', N'Kinh', N'Đại Lãnh, Đại Lộc, Quảng Nam', N'12/12', N'Cao cấp', N'Tiếng Anh', N'Kỹ sư Hóa thực phẩm', N'Công nhân viên', N'Viên chức', N'Giám đốc', CAST(N'1995-05-05T00:00:00.000' AS DateTime), CAST(N'1996-05-05T00:00:00.000' AS DateTime), N'55.008.986', NULL, N'55.008.986', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 983007698, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (30, 7, N'Phan Thị Hồng Ngân', 1982, 0, N'Không', N'Kinh', N'An Hòa Thịnh, Hương Sơn, Hà Tĩnh', N'12/12', N'Trung cấp', N'Tiếng Anh', N'Thạc sĩ Khoa học môi trường', N'Hợp đồng lao động', N'Viên chức', N'Trưởng phòng Tổng hợp - Hành chính', CAST(N'2011-12-30T00:00:00.000' AS DateTime), CAST(N'2012-12-30T00:00:00.000' AS DateTime), N'39.044.635', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 914195006, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (31, 7, N'Nguyễn Lệ Thùy Trang', 1983, 0, N'Không', N'Kinh', N'Triệu Phước,  Triệu Phong, Quảng Trị', N'12/12', N'Trung cấp', N'Tiếng Anh', N'Thạc sĩ Công nghệ môi trường', N'Hợp đồng lao động', N'Viên chức', N'Chuyên viên phòng Tư vấn và Kỹ thuật', CAST(N'2014-01-11T00:00:00.000' AS DateTime), CAST(N'2015-01-11T00:00:00.000' AS DateTime), N'39051028', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 983921883, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (32, 7, N'Chu Thị Bình', 1977, 0, N'Không', N'Kinh', N'Thanh Xuân, Thanh Chương, Nghệ A', N'12/12', N'Sơ cấp', N'Tiếng Anh', N'Cử nhân ', N'Hợp đồng lao động', N'Viên chức', N'Chuyên viên Phòng Tổng hợp - Hành chính', CAST(N'2008-05-24T00:00:00.000' AS DateTime), CAST(N'2009-05-24T00:00:00.000' AS DateTime), N'39.036234', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 979361961, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (33, 7, N'Võ Thành', 1977, 1, N'Không', N'Kinh', N'Bình An, Thăng Bình, tỉnh Quảng Nam', N'12/12', N'Trung cấp', N'Tiếng Anh', N'Kỹ sư công nghệ hóa dầu, Cử nhân quản trị kinh doanh', N'Công chức', N'Viên chức', N'Phó Giám đốc', CAST(N'2012-05-19T00:00:00.000' AS DateTime), CAST(N'2013-05-19T00:00:00.000' AS DateTime), N'39047063', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 905267949, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (34, 7, N'Nguyễn Thị Anh Đào', 1985, 0, N'Không ', N'Kinh', N'Điện Thắng Bắc, Điện Bàn, Quảng Nam', N'12/12', N'Sơ cấp', N'Tiếng Anh', N'Kỹ sư Cấp thoát nước môi trường nước', N'Hợp đồng lao động', N'Hợp đồng lao động', N'Chuyên viên Phòng Tư vấn và Kỹ thuật', CAST(N'2015-12-11T00:00:00.000' AS DateTime), CAST(N'2016-12-11T00:00:00.000' AS DateTime), N'39.053419', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 988028167, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (35, 7, N'Lương Hoàng Hải', 1987, 0, N'Không ', N'Kinh', N'Hoằng Châu, Hoằng Hóa, Thanh Hóa', N'12/12', N'Sơ cấp', N'Tiếng Anh', N'Thạc sĩ Công nghệ Môi trường', N'Hợp đồng lao động', N'Hợp đồng lao động', N'Chuyên viên phòng Giám sát và vận hành', CAST(N'2012-05-19T00:00:00.000' AS DateTime), CAST(N'2013-05-19T00:00:00.000' AS DateTime), N'39.047059', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 935590165, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (36, 7, N'Trần Thị Kim Hoa', 1978, 0, N'Không', N'Kinh', N'Thôn Phú Đông, xã Điện Quang, Thị xã Điện Bàn, tỉnh Quảng Nam', N'12/12', N'Sơ cấp', N'Tiếng Anh', N'Thạc sĩ Sinh thái học', N'Viên chức', N'Viên chức', N'Chuyên viên Phòng Quan trắc', CAST(N'2013-03-27T00:00:00.000' AS DateTime), CAST(N'2014-03-27T00:00:00.000' AS DateTime), N'39.048184', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 906408089, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (37, 7, N'Huỳnh Minh Hiền', 1984, 1, N'Không', N'Kinh', N'Ái Nghĩa, Đại Lộc, Quảng Nam', N'12/12', N'Trung cấp', N'Tiếng Anh', N'Thạc sĩ Công nghệ môi trường', N'Viên chức', N'Viên chức', N'Phó Trưởng phòng Quản lý hạ tầng', CAST(N'2019-01-22T00:00:00.000' AS DateTime), CAST(N'2020-01-22T00:00:00.000' AS DateTime), N'39060054', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 976722468, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (38, 7, N'Nguyễn Văn Lợi', 1983, 1, N'Không', N'Kinh', N'Đại An, Đại Lộc, Quảng Nam', N'12/12', N'Trung cấp', N'Tiếng Anh', N'Thạc sĩ Công nghệ môi trường', N'Hợp đồng lao động', N'Viên chức', N'Phó Trưởng phòng Tư vấn và Kỹ thuật', CAST(N'2018-10-16T00:00:00.000' AS DateTime), CAST(N'2019-10-16T00:00:00.000' AS DateTime), N'39059664', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 39059664, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (39, 7, N'Võ Thị Phượng', 1984, 0, N'Không', N'Kinh', N'Xã Hòa Tiến, Huyện Hòa Vang, TP Đà Nẵng', N'12/12', N'Sơ cấp', N'Tiếng Anh', N'Thạc sĩ Sinh thái học', N'Viên chức', N'Viên chức', N'Chuyên viên Phòng Quan trắc', CAST(N'2015-12-07T00:00:00.000' AS DateTime), CAST(N'2016-12-07T00:00:00.000' AS DateTime), N'39054017', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 905218912, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (40, 7, N'Hà Thị Kim Thanh', 1983, 0, N'Không', N'Kinh', N'Hương Chữ, Hương Trà, Thừa Thiên Huế', N'12/12', N'Sơ cấp', N'Tiếng Anh', N'Tiến sĩ Khoa học môi trường', N'Hợp đồng lao động', N'Viên chức', N'Chuyên viên phòng Tư vấn và Kỹ thuật', CAST(N'2016-03-19T00:00:00.000' AS DateTime), CAST(N'2017-03-19T00:00:00.000' AS DateTime), N'39054674', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 935346254, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (41, 7, N'Nguyễn Thị Phương Thạnh', 1994, 0, N'Không', N'Kinh', N'Xã Hòa Nhơn - Huyện Hòa Vang - Thành phố Đà Nẵng', N'12/12', N'Sơ cấp', N'Tiếng Anh', N'Kỹ sư Kỹ thuật môi trường', N'Hợp đồng lao động', N'Viên chức', N'Chuyên viên Phòng Quan trắc', CAST(N'2020-03-08T00:00:00.000' AS DateTime), CAST(N'2021-03-08T00:00:00.000' AS DateTime), N'Chua có', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 905088307, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (42, 7, N'Nguyễn Nhượng', 1965, 1, N'Không', N'Kinh', N'Xã Cẩm Châu - Thành phố Hội An - Quảng Nam', N'12/12', N'Trung cấp', N'Tiếng Anh', N'Thạc sĩ Quản trị kinh doanh', N'Viên chức', N'Viên chức', N'Phụ trách kế toán', CAST(N'2007-09-12T00:00:00.000' AS DateTime), CAST(N'2008-09-12T00:00:00.000' AS DateTime), N'39035025', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 913430798, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (43, 2, N'Nguyễn Phú Thương', 1979, 1, N'Không', N'Kinh', N'Xã Hòa Tiến, huyện Hòa Vang, thành phố Đà Nẵng', N'12/12', N'Sơ cấp', N'Trình độ C', N'Tài chính - Tín dụng', N'Chuyên viên Ban giải tỏa đền bù các dự án ĐT-XD Đà Nẵng', N'Chuyên viên', N'Chuyên viên', CAST(N'2010-11-13T00:00:00.000' AS DateTime), CAST(N'2011-11-13T00:00:00.000' AS DateTime), N'39 041119', NULL, N'39 041119', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 935162767, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (44, 2, N'Lê Văn Chung', 1978, 1, N'Không', N'Kinh', N'Phường Khuê Mỹ, quận Ngũ Hành Sơn, TP Đà Nẵng', N'12/12', N'Trung Cấp', N'C anh văn', NULL, NULL, N'236a Nguyễn Văn Cừ, TP Đà Nẵng', N'Chuyên viên', CAST(N'2013-06-06T00:00:00.000' AS DateTime), CAST(N'2014-06-06T00:00:00.000' AS DateTime), N'39.047907', NULL, N'39.047907', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 931971545, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (1003, 1, N'Nguyễn Đình Phụng', 1980, 1, N'không', N'Kinh', N'Xã Đại Đồng, Huyện Đại Lộc, Tỉnh Quảng Nam', N'12/12', N'Trung cấp lý luận chính ', N'Anh văn B1', N'Thạc sĩ Quản lý công, Cử nhân Kinh tế phát triển', N'viên chức', N'công chức', N'Chuyên viên', CAST(N'2008-05-01T00:00:00.000' AS DateTime), CAST(N'2009-05-01T00:00:00.000' AS DateTime), N'39037629', NULL, N'39037629', NULL, NULL, CAST(N'2017-06-21T00:00:00.000' AS DateTime), N'Chi bộ 9, Đảng bộ bộ phận Trung tâm Phát triển quỹ đất thuộc Đảng bộ Sở Tài nguyên và Môi trường', NULL, NULL, NULL, NULL, 989157158, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (1004, 1, N'Phạm Hoàng Phi', 1984, 1, N'Không', N'Kinh', N'phường Cẩm Châu, TP. Hội An, tỉnh Quảng Nam', N'12/12', N'Trung cấp', N'Anh văn (trình độ B)', N'Kỹ sư Công nghệ môi trường', N'Công chức', N'Công chức', N'Quyền Chánh Văn phòng', CAST(N'2014-08-19T00:00:00.000' AS DateTime), CAST(N'2015-08-19T00:00:00.000' AS DateTime), N'39.050590', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 905625878, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (1005, 1, N'Nguyễn Văn Duyên', 1980, 1, N'Không', N'Kinh', N'Thanh Tâm, Thanh Liêm, Hà Nam', N'12/12', N'Đang học Trung cấp', N'Tiếng anh B', N'Kỹ sư Địa chất thủy văn - ĐCCT; Thạc sĩ Kỹ thuật Địa chất', N'Công chức', N'Công chức', N'Chuyên viên Thanh tra', CAST(N'2010-05-07T00:00:00.000' AS DateTime), CAST(N'2011-05-07T00:00:00.000' AS DateTime), N'39.040373', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 986212988, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (1006, 1, N'Nguyễn Thị Quỳnh Như ', 1973, 0, N'Không', N'Kinh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'39.055132', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (1007, 1, N'Hoàng Văn Phước', 1989, 1, N'Không', N'Kinh', N'Phường Điện Ngọc, Thị xã Điện Bàn, Tỉnh Quảng Nam', N'12/12', N'Sơ cấp', N'B Tiếng Anh', N'Kỹ sư Công nghệ thông tin', N'Sinh viên', N'Viên chức', N'Chuyên viên', CAST(N'2016-03-24T00:00:00.000' AS DateTime), CAST(N'2017-03-24T00:00:00.000' AS DateTime), N'39.054650', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 935048058, NULL, 2, 1)
SET IDENTITY_INSERT [dbo].[Leaguer] OFF
GO
SET IDENTITY_INSERT [dbo].[LeaguerAttachment] ON 

INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (2, 2, N'anhteh.jpg', N'Contents\Uploads\2\Avatar\2_anhteh.jpg', N'.jpg', N'/images/2_anhteh.jpg', 222077, CAST(N'2021-07-09T15:40:13.557' AS DateTime), 2, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1004, 6, N'Anh Vinh 201377739.jpg', N'Contents\Uploads\6\Avatar\1004_Anh Vinh 201377739.jpg', N'.jpg', N'/images/1004_Anh Vinh 201377739.jpg', 34044, CAST(N'2021-09-06T11:09:19.497' AS DateTime), 11, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1005, 29, N'Anh.jpg', N'Contents\Uploads\29\Avatar\1005_Anh.jpg', N'.jpg', N'/images/1005_Anh.jpg', 64542, CAST(N'2021-09-07T15:07:02.740' AS DateTime), 38, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1006, 39, N'Phuong.jpg', N'Contents\Uploads\39\Avatar\1006_Phuong.jpg', N'.jpg', N'/images/1006_Phuong.jpg', 130868, CAST(N'2021-09-07T15:08:25.870' AS DateTime), 38, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1007, 34, N'Dao.jpg', N'Contents\Uploads\34\Avatar\1007_Dao.jpg', N'.jpg', N'/images/1007_Dao.jpg', 252683, CAST(N'2021-09-07T15:09:19.547' AS DateTime), 38, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1008, 35, N'Hai.jpg', N'Contents\Uploads\35\Avatar\1008_Hai.jpg', N'.jpg', N'/images/1008_Hai.jpg', 276843, CAST(N'2021-09-07T15:09:46.363' AS DateTime), 38, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1009, 38, N'Loi.jpg', N'Contents\Uploads\38\Avatar\1009_Loi.jpg', N'.jpg', N'/images/1009_Loi.jpg', 165210, CAST(N'2021-09-07T15:10:53.683' AS DateTime), 38, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1010, 33, N'2014050606260126911.jpg', N'Contents\Uploads\33\Avatar\1010_2014050606260126911.jpg', N'.jpg', N'/images/1010_2014050606260126911.jpg', 837894, CAST(N'2021-09-07T15:13:25.420' AS DateTime), 38, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1011, 30, N'2014040805163421941.jpg', N'Contents\Uploads\30\Avatar\1011_2014040805163421941.jpg', N'.jpg', N'/images/1011_2014040805163421941.jpg', 64883, CAST(N'2021-09-07T15:16:12.613' AS DateTime), 38, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1012, 31, N'2014040805253614549.jpg', N'Contents\Uploads\31\Avatar\1012_2014040805253614549.jpg', N'.jpg', N'/images/1012_2014040805253614549.jpg', 11433, CAST(N'2021-09-07T15:16:26.037' AS DateTime), 38, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1013, 32, N'2014040805230831314.jpg', N'Contents\Uploads\32\Avatar\1013_2014040805230831314.jpg', N'.jpg', N'/images/1013_2014040805230831314.jpg', 12120, CAST(N'2021-09-07T15:16:46.647' AS DateTime), 38, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1014, 36, N'201405230947442455.jpg', N'Contents\Uploads\36\Avatar\1014_201405230947442455.jpg', N'.jpg', N'/images/1014_201405230947442455.jpg', 10932, CAST(N'2021-09-07T15:24:57.480' AS DateTime), 38, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1015, 37, N'2014040805261026458.jpg', N'Contents\Uploads\37\Avatar\1015_2014040805261026458.jpg', N'.jpg', N'/images/1015_2014040805261026458.jpg', 9705, CAST(N'2021-09-07T15:25:16.763' AS DateTime), 38, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1016, 40, N'15894213965e25ec7b889972c72b88.jpg', N'Contents\Uploads\40\Avatar\1016_15894213965e25ec7b889972c72b88.jpg', N'.jpg', N'/images/1016_15894213965e25ec7b889972c72b88.jpg', 11522, CAST(N'2021-09-07T15:25:32.793' AS DateTime), 38, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1017, 41, N'1595469068Phuong_Thanh.jpg', N'Contents\Uploads\41\Avatar\1017_1595469068Phuong_Thanh.jpg', N'.jpg', N'/images/1017_1595469068Phuong_Thanh.jpg', 15945, CAST(N'2021-09-07T15:25:45.747' AS DateTime), 38, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1018, 42, N'1535596220NguyenNhuong.jpg', N'Contents\Uploads\42\Avatar\1018_1535596220NguyenNhuong.jpg', N'.jpg', N'/images/1018_1535596220NguyenNhuong.jpg', 39571, CAST(N'2021-09-07T15:26:13.023' AS DateTime), 38, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (1019, 43, N'ANH THE.png', N'Contents\Uploads\43\Avatar\1019_ANH THE.png', N'.png', N'/images/1019_ANH THE.png', 930039, CAST(N'2021-09-10T15:53:31.753' AS DateTime), 4, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (2003, 1003, N'Nguyen Dinh Phung_So Tai nguyen va Moi truong.PNG', N'Contents\Uploads\1003\Avatar\2003_Nguyen Dinh Phung_So Tai nguyen va Moi truong.PNG', N'.PNG', N'/images/2003_Nguyen Dinh Phung_So Tai nguyen va Moi truong.PNG', 795890, CAST(N'2021-09-14T08:24:21.170' AS DateTime), 3, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (2004, 1004, N'Mr Phi.JPG', N'Contents\Uploads\1004\Avatar\2004_Mr Phi.JPG', N'.JPG', N'/images/2004_Mr Phi.JPG', 20637, CAST(N'2021-09-14T08:25:05.760' AS DateTime), 3, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (2005, 1005, N'Anh the Duyen TNMT.jpg', N'Contents\Uploads\1005\Avatar\2005_Anh the Duyen TNMT.jpg', N'.jpg', N'/images/2005_Anh the Duyen TNMT.jpg', 65915, CAST(N'2021-09-14T09:33:05.177' AS DateTime), 3, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (2007, 1006, N'ANH NHU.JPG', N'Contents\Uploads\1006\Avatar\2007_ANH NHU.JPG', N'.JPG', N'/images/2007_ANH NHU.JPG', 878633, CAST(N'2021-09-15T15:27:56.970' AS DateTime), 3, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (2008, 1007, N'Phuoc 2+3.jpg', N'Contents\Uploads\1007\Avatar\2008_Phuoc 2+3.jpg', N'.jpg', N'/images/2008_Phuoc 2+3.jpg', 90279, CAST(N'2021-09-16T09:24:21.217' AS DateTime), 3, 1)
SET IDENTITY_INSERT [dbo].[LeaguerAttachment] OFF
GO
SET IDENTITY_INSERT [dbo].[Pronouns] ON 

INSERT [dbo].[Pronouns] ([Id], [Name]) VALUES (1, N'Ông')
INSERT [dbo].[Pronouns] ([Id], [Name]) VALUES (2, N'Bà')
SET IDENTITY_INSERT [dbo].[Pronouns] OFF
GO
SET IDENTITY_INSERT [dbo].[Rating] ON 

INSERT [dbo].[Rating] ([Id], [Name]) VALUES (1, N'Hoàn thành xuất sắc')
INSERT [dbo].[Rating] ([Id], [Name]) VALUES (2, N'Hoàn thành tốt')
INSERT [dbo].[Rating] ([Id], [Name]) VALUES (3, N'Hoàn thành')
INSERT [dbo].[Rating] ([Id], [Name]) VALUES (4, N'Không hoàn thành')
SET IDENTITY_INSERT [dbo].[Rating] OFF
GO
SET IDENTITY_INSERT [dbo].[RatingResult] ON 

INSERT [dbo].[RatingResult] ([Id], [Year], [RatingId], [LeaguerId]) VALUES (1, N'2020', 2, 3)
INSERT [dbo].[RatingResult] ([Id], [Year], [RatingId], [LeaguerId]) VALUES (2, N'N? ', 2, 1006)
SET IDENTITY_INSERT [dbo].[RatingResult] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Phụ trách Đảng')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (3, N'Chi bộ')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [Name]) VALUES (1, N'Đảng viên chính thức')
INSERT [dbo].[Status] ([Id], [Name]) VALUES (2, N'Đảng viên dự bị')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([Id], [Name], [IdentifyNumber]) VALUES (1, N'Văn phòng Sở', N'I')
INSERT [dbo].[Unit] ([Id], [Name], [IdentifyNumber]) VALUES (2, N'Chi cục Quản lý đất đai', N'II')
INSERT [dbo].[Unit] ([Id], [Name], [IdentifyNumber]) VALUES (4, N'Chi cục Bảo vệ môi trường', N'III')
INSERT [dbo].[Unit] ([Id], [Name], [IdentifyNumber]) VALUES (5, N'Chi cục Biển và Hải đảo', N'IV')
INSERT [dbo].[Unit] ([Id], [Name], [IdentifyNumber]) VALUES (7, N'Trung tâm Quan trắc TN&MT', N'V')
INSERT [dbo].[Unit] ([Id], [Name], [IdentifyNumber]) VALUES (9, N'Trung tâm Kỹ thuật TN&MT', N'VI')
INSERT [dbo].[Unit] ([Id], [Name], [IdentifyNumber]) VALUES (11, N'Trung tâm Công nghệ thông tin TN&MT', N'VII')
INSERT [dbo].[Unit] ([Id], [Name], [IdentifyNumber]) VALUES (13, N'Trung tâm Phát triển quỹ đất TPĐN', N'VIII')
INSERT [dbo].[Unit] ([Id], [Name], [IdentifyNumber]) VALUES (14, N'Văn phòng Đăng ký đất đai', N'IX')
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Salt], [IsActivated], [JobPosition], [UnitId]) VALUES (1, N'Nguyễn Ngọc Quỳnh', N'admin@user.com', N'5d3a085051e4f7bc9d2234f3410fc616911482728e4e37b7d42de9177048f993', N'd235db47d2a3bb0b52f34579671f71df', 1, N'Chuyên viên', NULL)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Salt], [IsActivated], [JobPosition], [UnitId]) VALUES (2, N'Hứa Ngọc Hòa', N'hoahv@user.com', N'a064e3ca9a3455629fd8d711aff9175a222073ab75e0baceef4ba01c9220258c', N'af84b9b3b2d817990f8e7620b74690fd', 0, N'A', NULL)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Salt], [IsActivated], [JobPosition], [UnitId]) VALUES (3, N'Văn phòng Sở', N'vps@tnmt.danang.vn', N'ee3dd4c1547c2b1647261b6bc585fede77299ac70604ca72fde483b9abb855c6', N'3c957352b96f989d95bd76d29633de85', 0, NULL, 1)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Salt], [IsActivated], [JobPosition], [UnitId]) VALUES (4, N'Chi cục Quản lý đất đai', N'ccqldd@tnmt.danang.vn', N'6e4ee5ed18f922fad1d3a25334cedf5a1b6ee59837e95473dc50144f7a254d23', N'04841bb72aca7295ce640522d82e9f36', 0, NULL, 2)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Salt], [IsActivated], [JobPosition], [UnitId]) VALUES (5, N'Chi cục Bảo vệ Môi trường', N'ccbvmt@tnmt.danang.vn', N'5a7c489cd6d8878eaa1f71e8f308d06e0bdd92f39cf754e53857949e22e2a6f6', N'9bf28acf0b7fbee59bbbf7c1cf1f7b08', 0, NULL, 4)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Salt], [IsActivated], [JobPosition], [UnitId]) VALUES (6, N'Chi cục Biển và Hải đảo', N'ccbhd@tnmt.danang.vn', N'aa24811b7d125074bb881df5324b94de0a2f1763ba3593bc62ddaf1c5c7b130a', N'ff92292213064f2866e6c3ed282356e0', 0, NULL, 5)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Salt], [IsActivated], [JobPosition], [UnitId]) VALUES (11, N'Trung tâm Công nghệ Thông tin', N'cntt@tnmt.danang.vn', N'e2d470825c55b257e67a579e42569c3787264cc544105e1bed000dde45ab7c15', N'518bbc4ce940b373d99be66376da7b3e', 0, NULL, 11)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Salt], [IsActivated], [JobPosition], [UnitId]) VALUES (14, N'Văn phòng Đăng ký Đất đai', N'vpdkdd@tnmt.danang.vn', N'9c0ee622eb50fd3d4a3f28a6a1fba8f17ee83dd92e0df29092a06fac49a54d64', N'b6b58e3386bce50a1059b134440f77c9', 0, NULL, 14)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Salt], [IsActivated], [JobPosition], [UnitId]) VALUES (37, N'Trung tâm Kỹ thuật TNMT', N'ttkt@tnmt.danang.vn', N'7072575c04d97135e13e6811475c0cd62a49c76e2d83386e5e2a8b519d058355', N'8787ea5f8d485df29bcb1e22e8241363', 0, NULL, 9)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Salt], [IsActivated], [JobPosition], [UnitId]) VALUES (38, N'Trung tâm Quan trắc TNMT', N'ttqt@tnmt.danang.vn', N'62af5bad7635329932d3eb78ec2fd3f8a74d2ffea3b227affd44d95d074ee9f9', N'c1d6b0582704ef1fa09c744ef3951563', 0, NULL, 7)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Salt], [IsActivated], [JobPosition], [UnitId]) VALUES (39, N'Trung tâm Phát triển Quỹ đất', N'ttptqd@tnmt.danang.vn', N'cf14c799f26a837164fe6c9319eec79effe0829da489a61c794a83b129e11416', N'71f6c8884246e04e0140d2ce31cffb36', 0, NULL, 13)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [IsActivated]) VALUES (1, 1, 1, 1)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [IsActivated]) VALUES (2, 2, 2, 1)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [IsActivated]) VALUES (3, 3, 3, 1)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [IsActivated]) VALUES (4, 3, 4, 1)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [IsActivated]) VALUES (5, 3, 5, 1)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [IsActivated]) VALUES (6, 3, 6, 1)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [IsActivated]) VALUES (7, 3, 11, 1)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [IsActivated]) VALUES (8, 3, 14, 1)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [IsActivated]) VALUES (9, 3, 37, 1)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [IsActivated]) VALUES (10, 3, 38, 1)
INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [IsActivated]) VALUES (11, 3, 39, 1)
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
SET IDENTITY_INSERT [dbo].[UserToken] ON 

INSERT [dbo].[UserToken] ([Id], [UserId], [Token], [ImageToken], [ExpireAt], [IsRevoked]) VALUES (2027, 38, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIzOCIsIlVzZXJuYW1lIjoidHRxdEB0bm10LmRhbmFuZy52biIsIkZ1bGxOYW1lIjoiVHJ1bmcgdMOibSBRdWFuIHRy4bqvYyBUTk1UIiwiUm9sZUlkIjoiMyIsIlRpbWV6b25lT2Zmc2V0IjoiLTQyMCIsIm5iZiI6MTYzMTA3MTY1OSwiZXhwIjoxNjMyMjgxMjU5LCJpYXQiOjE2MzEwNzE2NTl9.bbcLMSw26d9YuDlWc_ZQJLGAzstDA7cc9SwbCJ65PL0', N'c0a918b6-493f-4b88-bc06-2fbedbb4683b', CAST(N'2021-09-22T03:27:39.657' AS DateTime), 0)
INSERT [dbo].[UserToken] ([Id], [UserId], [Token], [ImageToken], [ExpireAt], [IsRevoked]) VALUES (2028, 4, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiI0IiwiVXNlcm5hbWUiOiJjY3FsZGRAdG5tdC5kYW5hbmcudm4iLCJGdWxsTmFtZSI6IkNoaSBj4bulYyBRdeG6o24gbMO9IMSR4bqldCDEkWFpIiwiUm9sZUlkIjoiMyIsIlRpbWV6b25lT2Zmc2V0IjoiLTQyMCIsIm5iZiI6MTYzMTI2MzczMCwiZXhwIjoxNjMyNDczMzMwLCJpYXQiOjE2MzEyNjM3MzB9.xBh8Hlqr1vd5ijglRwGHQdNkcsEiveV-Wpt2tujGGqw', N'745d7d28-8039-43ec-8962-f43ec895e926', CAST(N'2021-09-24T08:48:50.057' AS DateTime), 0)
INSERT [dbo].[UserToken] ([Id], [UserId], [Token], [ImageToken], [ExpireAt], [IsRevoked]) VALUES (3018, 3, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIzIiwiVXNlcm5hbWUiOiJ2cHNAdG5tdC5kYW5hbmcudm4iLCJGdWxsTmFtZSI6IlbEg24gcGjDsm5nIFPhu58iLCJSb2xlSWQiOiIzIiwiVGltZXpvbmVPZmZzZXQiOiItNDIwIiwibmJmIjoxNjMxNTgyMzQxLCJleHAiOjE2MzI3OTE5NDEsImlhdCI6MTYzMTU4MjM0MX0.8oFlXkzGHymaYzI4xUAOa3WNWDnDSQ0MsFnO3xlcKMw', N'ab6da5fa-1e59-4089-a9f1-cff03631983e', CAST(N'2021-09-28T01:19:01.193' AS DateTime), 0)
INSERT [dbo].[UserToken] ([Id], [UserId], [Token], [ImageToken], [ExpireAt], [IsRevoked]) VALUES (3019, 2, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIyIiwiVXNlcm5hbWUiOiJob2FodkB1c2VyLmNvbSIsIkZ1bGxOYW1lIjoiSOG7qWEgTmfhu41jIEjDsmEiLCJSb2xlSWQiOiIyIiwiVGltZXpvbmVPZmZzZXQiOiItNDIwIiwibmJmIjoxNjMxNTgzODY2LCJleHAiOjE2MzI3OTM0NjYsImlhdCI6MTYzMTU4Mzg2Nn0.afqvpOaFzzm0dg8iVQNz9i9sZv8Xfn_h0y12m-UvEqs', N'1ab02129-cb49-4bc6-acf7-6c611c6c3444', CAST(N'2021-09-28T01:44:26.177' AS DateTime), 0)
INSERT [dbo].[UserToken] ([Id], [UserId], [Token], [ImageToken], [ExpireAt], [IsRevoked]) VALUES (3020, 3, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIzIiwiVXNlcm5hbWUiOiJ2cHNAdG5tdC5kYW5hbmcudm4iLCJGdWxsTmFtZSI6IlbEg24gcGjDsm5nIFPhu58iLCJSb2xlSWQiOiIzIiwiVGltZXpvbmVPZmZzZXQiOiItNDIwIiwibmJmIjoxNjMxNTg1Njk2LCJleHAiOjE2MzI3OTUyOTYsImlhdCI6MTYzMTU4NTY5Nn0.AHQFa9eiuoM7DfJ8bBy528_zKZo0lXSN9YQv5mu0LY0', N'51adc8c7-aa5d-4a92-b9a1-470ed45883cd', CAST(N'2021-09-28T02:14:56.420' AS DateTime), 0)
INSERT [dbo].[UserToken] ([Id], [UserId], [Token], [ImageToken], [ExpireAt], [IsRevoked]) VALUES (3021, 3, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIzIiwiVXNlcm5hbWUiOiJ2cHNAdG5tdC5kYW5hbmcudm4iLCJGdWxsTmFtZSI6IlbEg24gcGjDsm5nIFPhu58iLCJSb2xlSWQiOiIzIiwiVGltZXpvbmVPZmZzZXQiOiItNDIwIiwibmJmIjoxNjMxNjkzNTg5LCJleHAiOjE2MzI5MDMxODksImlhdCI6MTYzMTY5MzU4OX0.91YTsavXGxJq9_SP9xRkyUCSDMiUNxL9f_ty8Pt6Jtk', N'4ace9dd8-3a41-48fb-9f68-3ef590836b7b', CAST(N'2021-09-29T08:13:09.073' AS DateTime), 0)
INSERT [dbo].[UserToken] ([Id], [UserId], [Token], [ImageToken], [ExpireAt], [IsRevoked]) VALUES (3024, 1, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIxIiwiVXNlcm5hbWUiOiJhZG1pbkB1c2VyLmNvbSIsIkZ1bGxOYW1lIjoiTmd1eeG7hW4gTmfhu41jIFF14buzbmgiLCJSb2xlSWQiOiIxIiwiVGltZXpvbmVPZmZzZXQiOiItNDIwIiwibmJmIjoxNjMyMTMxOTI3LCJleHAiOjE2MzIxODU5MjcsImlhdCI6MTYzMjEzMTkyN30.wknldpYuAso7jKWQ9RnjB7Y4Et-Jjbya0qvC5_L7LHY', N'cb446864-835c-4689-a387-76b17c50cc57', CAST(N'2021-09-21T00:58:47.807' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[UserToken] OFF
GO
ALTER TABLE [dbo].[AppliedDocument]  WITH CHECK ADD FOREIGN KEY([LeaguerId])
REFERENCES [dbo].[Leaguer] ([Id])
GO
ALTER TABLE [dbo].[AppliedDocumentAttachment]  WITH CHECK ADD FOREIGN KEY([AppliedDocumentId])
REFERENCES [dbo].[AppliedDocument] ([Id])
GO
ALTER TABLE [dbo].[ChangeOfficialDocument]  WITH CHECK ADD FOREIGN KEY([ChangeOfficialDocumentTypeId])
REFERENCES [dbo].[ChangeOfficialDocumentType] ([Id])
GO
ALTER TABLE [dbo].[DocumentationAttachment]  WITH CHECK ADD FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[DocumentationAttachment]  WITH CHECK ADD FOREIGN KEY([DocumentationId])
REFERENCES [dbo].[Documentation] ([Id])
GO
ALTER TABLE [dbo].[Leaguer]  WITH CHECK ADD FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Leaguer]  WITH CHECK ADD FOREIGN KEY([UnitId])
REFERENCES [dbo].[Unit] ([Id])
GO
ALTER TABLE [dbo].[LeaguerAttachment]  WITH CHECK ADD FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[LeaguerAttachment]  WITH CHECK ADD FOREIGN KEY([LeaguerId])
REFERENCES [dbo].[Leaguer] ([Id])
GO
ALTER TABLE [dbo].[RatingResult]  WITH CHECK ADD FOREIGN KEY([LeaguerId])
REFERENCES [dbo].[Leaguer] ([Id])
GO
ALTER TABLE [dbo].[RatingResult]  WITH CHECK ADD FOREIGN KEY([RatingId])
REFERENCES [dbo].[Rating] ([Id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([UnitId])
REFERENCES [dbo].[Unit] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[spExportLeaguerToExcel]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROC [dbo].[spExportLeaguerToExcel]
@unitId int
as
begin
	
If(@unitId > 0)
	begin
		-- Unit
		select * from Unit where Id = @unitId

		-- Leaguer
		select l.Name, Gender, Religion, Folk, HomeTown, BornYear,
		--
		EducationalLevel, PoliticalTheoryLevel, ForeignLanguageLevel, SpecializeMajor, 
		--
		BeforeEnteringCareer, CurrentCareer, Position, UnitId,
		--
		PreliminaryApplyDate, OfficialApplyDate, CardNumber, BackgroundNumber, BadgeNumber,
		--
		MoveOutDated, OfficeComing, MoveInDated, AtOffice, GetOutDate, FormOut, Phone, Notes
		--
		from Leaguer l where l.UnitId = @unitId
	end
Else
	begin
		-- Unit
		select * from Unit

		-- Leaguer
		select l.Name, Gender, Religion, Folk, HomeTown, BornYear,
		--
		EducationalLevel, PoliticalTheoryLevel, ForeignLanguageLevel, SpecializeMajor, 
		--
		BeforeEnteringCareer, CurrentCareer, Position, UnitId,
		--
		PreliminaryApplyDate, OfficialApplyDate, CardNumber, BackgroundNumber, BadgeNumber,
		--
		MoveOutDated, OfficeComing, MoveInDated, AtOffice, GetOutDate, FormOut, Phone, Notes
		--
		from Leaguer l
	end

End
GO
/****** Object:  StoredProcedure [dbo].[spGetAllLeaguers]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetAllLeaguers]
@unitId int
AS
BEGIN 

If(@unitId > 0) 
	begin
		Select * from Leaguer where IsActivated = 1 and UnitId = @unitId

		select Id as Value from LeaguerAttachment where IsAvatar = 1
	end
Else 
	begin
		Select * from Leaguer where IsActivated = 1

		select LeaguerId as Id, Id as Value from LeaguerAttachment where IsAvatar = 1
	end
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCurrentLeaguers]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetCurrentLeaguers]
@unitId int
AS
BEGIN 

if(@unitId > 0)
	begin
		Select * from Leaguer l 
		where l.IsActivated = 1 and l.UnitId = @unitId
	end
else 
	begin
		Select * from Leaguer l 
		where l.IsActivated = 1
	end
END
GO
/****** Object:  StoredProcedure [dbo].[spGetCurrentUser]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetCurrentUser]
@UserId int
AS
BEGIN 

select u.Id, u.[Name], u.Email, ur.RoleId from dbo.[User] u
join dbo.UserRole ur on u.Id = ur.UserId
where u.Id = @UserId and ur.IsActivated = 1

select ar.AccessControlId as Id from UserRole ur
join dbo.AccessOfRole ar on ur.RoleId = ar.RoleId
where ur.UserId = @UserId and ur.IsActivated = 1

END


GO
/****** Object:  StoredProcedure [dbo].[spGetDocumentations]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[spGetDocumentations] 
AS
BEGIN

Select * from Documentation

Select *, DocumentationId as ReferenceId, 'documentation' as ReferenceName from DocumentationAttachment

END
GO
/****** Object:  StoredProcedure [dbo].[spGetLeaguer]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetLeaguer]
@Id int
AS
BEGIN 


select * from Leaguer where Id = @Id and IsActivated = 1

select *, LeaguerId as ReferenceId, 'avatar' as ReferenceName from LeaguerAttachment where LeaguerId = @Id and IsAvatar = 1

select *, LeaguerId as ReferenceId, 'general' as ReferenceName from LeaguerAttachment where LeaguerId = @Id and IsAvatar = 0

select ad.*,  cod.ChangeOfficialDocumentTypeId
from AppliedDocument ad join ChangeOfficialDocument cod on ad.OfficialDocumentId = cod.Id
where LeaguerId = @Id

select ada.*, AppliedDocumentId as ReferenceId, 'official' as ReferenceName
from AppliedDocumentAttachment ada join AppliedDocument ad on ada.AppliedDocumentId = ad.Id
where LeaguerId = @Id

END

GO
/****** Object:  StoredProcedure [dbo].[spGetOfficialDocuments]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spGetOfficialDocuments]
@LeaguerId int
as
begin

-- applied documents
select ad.*, d.ChangeOfficialDocumentTypeId
from AppliedDocument ad 
join ChangeOfficialDocument d on ad.OfficialDocumentId = d.Id
where ad.LeaguerId = @LeaguerId

-- attachments

select ada.*, AppliedDocumentId as ReferenceId, 'official' as ReferenceName 
from AppliedDocumentAttachment ada join AppliedDocument ad on ada.AppliedDocumentId = ad.Id
join Leaguer l on ad.LeaguerId = l.Id
where l.Id = @LeaguerId and l.IsActivated = 1

end

GO
/****** Object:  StoredProcedure [dbo].[spGetRoles]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[spGetRoles]
as
begin

select * from dbo.[Role]

select RoleId, AccessControlId from dbo.AccessOfRole where IsActivated = 1

end


GO
/****** Object:  StoredProcedure [dbo].[spRemoveExpiredTokens]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRemoveExpiredTokens]
	@dateExpired datetime 
AS
Begin
	Delete from [UserToken] Where ExpireAt < @dateExpired;
End


GO
/****** Object:  StoredProcedure [dbo].[spRevokeToken]    Script Date: 9/20/2021 5:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spRevokeToken]
	@id int
AS
Begin
	Update [UserToken] Set IsRevoked = 1 Where Id = @id;
End


GO
