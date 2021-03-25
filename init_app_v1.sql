USE [LeaguerManagement]
GO
/****** Object:  Table [dbo].[AccessControl]    Script Date: 3/25/2021 2:47:32 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccessOfRole]    Script Date: 3/25/2021 2:47:32 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppliedDocument]    Script Date: 3/25/2021 2:47:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppliedDocument](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LeaguerId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Amount] [int] NULL,
	[DistrictId] [int] NULL,
	[Unit] [nvarchar](max) NULL,
	[Purpose] [nvarchar](max) NULL,
	[PointTypeId] [int] NULL,
	[PointValue] [int] NULL,
	[IsAttachment] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppliedDocumentAttachment]    Script Date: 3/25/2021 2:47:32 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leaguer]    Script Date: 3/25/2021 2:47:32 PM ******/
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
	[PreliminaryApplyDate] [datetime] NOT NULL,
	[OfficialApplyDate] [datetime] NOT NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pronouns]    Script Date: 3/25/2021 2:47:32 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/25/2021 2:47:32 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 3/25/2021 2:47:32 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 3/25/2021 2:47:32 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/25/2021 2:47:32 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 3/25/2021 2:47:32 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserToken]    Script Date: 3/25/2021 2:47:32 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccessControl] ON 

INSERT [dbo].[AccessControl] ([Id], [Name]) VALUES (1, N'Cài đặt hệ thống')
SET IDENTITY_INSERT [dbo].[AccessControl] OFF
GO
SET IDENTITY_INSERT [dbo].[AccessOfRole] ON 

INSERT [dbo].[AccessOfRole] ([Id], [RoleId], [AccessControlId], [IsActivated]) VALUES (1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[AccessOfRole] OFF
GO
SET IDENTITY_INSERT [dbo].[Pronouns] ON 

INSERT [dbo].[Pronouns] ([Id], [Name]) VALUES (1, N'Ông')
INSERT [dbo].[Pronouns] ([Id], [Name]) VALUES (2, N'Bà')
SET IDENTITY_INSERT [dbo].[Pronouns] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Chuyên viên')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Salt], [IsActivated], [JobPosition]) VALUES (1, N'Nguyễn Ngọc Quỳnh', N'admin@user.com', N'6efb5283a3acc2b97344f27238b182cef1335d987d7848ac0119505439af66e0', N'asfjiasoifja9sakslfj9', 1, N'Chuyên viên')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [RoleId], [UserId], [IsActivated]) VALUES (1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
ALTER TABLE [dbo].[AppliedDocument]  WITH CHECK ADD FOREIGN KEY([LeaguerId])
REFERENCES [dbo].[Leaguer] ([Id])
GO
ALTER TABLE [dbo].[AppliedDocumentAttachment]  WITH CHECK ADD FOREIGN KEY([AppliedDocumentId])
REFERENCES [dbo].[AppliedDocument] ([Id])
GO
ALTER TABLE [dbo].[Leaguer]  WITH CHECK ADD FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Leaguer]  WITH CHECK ADD FOREIGN KEY([UnitId])
REFERENCES [dbo].[Unit] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[spGetCurrentUser]    Script Date: 3/25/2021 2:47:32 PM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetRoles]    Script Date: 3/25/2021 2:47:32 PM ******/
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
/****** Object:  StoredProcedure [dbo].[spRemoveExpiredTokens]    Script Date: 3/25/2021 2:47:32 PM ******/
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
/****** Object:  StoredProcedure [dbo].[spRevokeToken]    Script Date: 3/25/2021 2:47:32 PM ******/
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
