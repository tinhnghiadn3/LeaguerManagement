USE [LeaguerManagement]
GO
/****** Object:  Table [dbo].[AccessControl]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  Table [dbo].[AccessOfRole]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  Table [dbo].[AppliedDocument]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  Table [dbo].[AppliedDocumentAttachment]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  Table [dbo].[ChangeOfficialDocument]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  Table [dbo].[ChangeOfficialDocumentType]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  Table [dbo].[Leaguer]    Script Date: 09-Jul-21 3:53:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LeaguerAttachment]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  Table [dbo].[Pronouns]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  Table [dbo].[Status]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  Table [dbo].[Unit]    Script Date: 09-Jul-21 3:53:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  Table [dbo].[UserToken]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
SET IDENTITY_INSERT [dbo].[AccessControl] OFF
SET IDENTITY_INSERT [dbo].[AccessOfRole] ON 

INSERT [dbo].[AccessOfRole] ([Id], [RoleId], [AccessControlId], [IsActivated]) VALUES (1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[AccessOfRole] OFF
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
SET IDENTITY_INSERT [dbo].[AppliedDocument] OFF
SET IDENTITY_INSERT [dbo].[AppliedDocumentAttachment] ON 

INSERT [dbo].[AppliedDocumentAttachment] ([Id], [AppliedDocumentId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId]) VALUES (2, 3, N'bug.png', N'Contents\Uploads\2\Official\2_bug.png', N'.png', N'/images/2_bug.png', 189841, CAST(N'2021-07-09 02:52:34.533' AS DateTime), 1)
INSERT [dbo].[AppliedDocumentAttachment] ([Id], [AppliedDocumentId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId]) VALUES (3, 1, N'2.png', N'Contents\Uploads\2\Official\3_2.png', N'.png', N'/images/3_2.png', 168574, CAST(N'2021-07-09 02:52:39.120' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[AppliedDocumentAttachment] OFF
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
SET IDENTITY_INSERT [dbo].[ChangeOfficialDocumentType] ON 

INSERT [dbo].[ChangeOfficialDocumentType] ([Id], [Name]) VALUES (1, N'Quyển hồ sơ công nhận đảng viên chính thức')
INSERT [dbo].[ChangeOfficialDocumentType] ([Id], [Name]) VALUES (2, N'Giấy chứng nhận học lớp bồi dưỡng đảng viên mới')
INSERT [dbo].[ChangeOfficialDocumentType] ([Id], [Name]) VALUES (3, N'Các loại giấy tờ khác')
SET IDENTITY_INSERT [dbo].[ChangeOfficialDocumentType] OFF
SET IDENTITY_INSERT [dbo].[Leaguer] ON 

INSERT [dbo].[Leaguer] ([Id], [UnitId], [Name], [BornYear], [Gender], [Religion], [Folk], [HomeTown], [EducationalLevel], [PoliticalTheoryLevel], [ForeignLanguageLevel], [SpecializeMajor], [BeforeEnteringCareer], [CurrentCareer], [Position], [PreliminaryApplyDate], [OfficialApplyDate], [CardNumber], [BackgroundNumber], [BadgeNumber], [MoveOutDated], [OfficeComing], [MoveInDated], [AtOffice], [DeadDate], [DeathReason], [GetOutDate], [FormOut], [Phone], [Notes], [StatusId], [IsActivated]) VALUES (2, 5, N'Phạm Thị Chín', 1968, 0, N'Không', N'Kinh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'30371', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
SET IDENTITY_INSERT [dbo].[Leaguer] OFF
SET IDENTITY_INSERT [dbo].[LeaguerAttachment] ON 

INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (5, 2, N'ptc_bhd.png', N'Contents\Uploads\2\Avatar\5_ptc_bhd.png', N'.png', N'/images/5_ptc_bhd.png', 100035, CAST(N'2021-07-06 13:48:55.390' AS DateTime), 1, 1)
INSERT [dbo].[LeaguerAttachment] ([Id], [LeaguerId], [FileName], [FilePath], [FileExtension], [FileUrl], [FileSize], [CreatedDate], [CreatedByUserId], [IsAvatar]) VALUES (6, 2, N'aaat3.png', N'Contents\Uploads\2\Information\6_aaat3.png', N'.png', N'/images/6_ate.png', 69795, CAST(N'2021-07-09 02:52:05.860' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[LeaguerAttachment] OFF
SET IDENTITY_INSERT [dbo].[Pronouns] ON 

INSERT [dbo].[Pronouns] ([Id], [Name]) VALUES (1, N'Ông')
INSERT [dbo].[Pronouns] ([Id], [Name]) VALUES (2, N'Bà')
SET IDENTITY_INSERT [dbo].[Pronouns] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Chuyên viên')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [Name]) VALUES (1, N'Đảng viên chính thức')
INSERT [dbo].[Status] ([Id], [Name]) VALUES (2, N'Đảng viên dự bị')
INSERT [dbo].[Status] ([Id], [Name]) VALUES (3, N'Ra khỏi Đảng')
INSERT [dbo].[Status] ([Id], [Name]) VALUES (4, N'Từ trần')
SET IDENTITY_INSERT [dbo].[Status] OFF
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
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Salt], [IsActivated], [JobPosition]) VALUES (1, N'Nguyễn Ngọc Quỳnh', N'admin@user.com', N'5d3a085051e4f7bc9d2234f3410fc616911482728e4e37b7d42de9177048f993', N'd235db47d2a3bb0b52f34579671f71df', 1, N'Chuyên viên')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [IsActivated]) VALUES (1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[UserRole] OFF
SET IDENTITY_INSERT [dbo].[UserToken] ON 

INSERT [dbo].[UserToken] ([Id], [UserId], [Token], [ImageToken], [ExpireAt], [IsRevoked]) VALUES (1010, 1, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIxIiwiVXNlcm5hbWUiOiJhZG1pbkB1c2VyLmNvbSIsIkZ1bGxOYW1lIjoiTmd1eeG7hW4gTmfhu41jIFF14buzbmgiLCJSb2xlSWQiOiIxIiwiVGltZXpvbmVPZmZzZXQiOiItNDIwIiwibmJmIjoxNjI1NzY3Mzg4LCJleHAiOjE2MjU4MjEzODgsImlhdCI6MTYyNTc2NzM4OH0.1FFMLy7yzcpyyaNjxgX1duJQRJWPMp4eY79Hd2mxgV4', N'71e12968-a1cc-4d01-a349-f2ebc1bef017', CAST(N'2021-07-09 09:03:08.503' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[UserToken] OFF
ALTER TABLE [dbo].[AppliedDocument]  WITH CHECK ADD FOREIGN KEY([LeaguerId])
REFERENCES [dbo].[Leaguer] ([Id])
GO
ALTER TABLE [dbo].[AppliedDocumentAttachment]  WITH CHECK ADD FOREIGN KEY([AppliedDocumentId])
REFERENCES [dbo].[AppliedDocument] ([Id])
GO
ALTER TABLE [dbo].[ChangeOfficialDocument]  WITH CHECK ADD FOREIGN KEY([ChangeOfficialDocumentTypeId])
REFERENCES [dbo].[ChangeOfficialDocumentType] ([Id])
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
/****** Object:  StoredProcedure [dbo].[spGetAllLeaguers]    Script Date: 09-Jul-21 3:53:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetAllLeaguers]
AS
BEGIN 

	Select l.*, la.Id as AvatarId
	from Leaguer l 
	join LeaguerAttachment la on l.Id = la.LeaguerId
	where l.IsActivated = 1 and la.IsAvatar = 1

END

GO
/****** Object:  StoredProcedure [dbo].[spGetCurrentLeaguers]    Script Date: 09-Jul-21 3:53:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spGetCurrentLeaguers]
AS
BEGIN 

	Select * from Leaguer l 
	where l.IsActivated = 1

END

GO
/****** Object:  StoredProcedure [dbo].[spGetCurrentUser]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetLeaguer]    Script Date: 09-Jul-21 3:53:50 AM ******/
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

END


GO
/****** Object:  StoredProcedure [dbo].[spGetOfficialDocuments]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetRoles]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spRemoveExpiredTokens]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spRevokeToken]    Script Date: 09-Jul-21 3:53:50 AM ******/
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
