USE  [SportsCompetition]

BEGIN
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspNetRoleClaims' AND TABLE_SCHEMA='dbo')
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspNetRoles' AND TABLE_SCHEMA='dbo')
BEGIN
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspNetUserClaims' AND TABLE_SCHEMA='dbo')
BEGIN
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspNetUserLogins' AND TABLE_SCHEMA='dbo')
BEGIN
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspNetUserRoles' AND TABLE_SCHEMA='dbo')
BEGIN
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspNetUsers' AND TABLE_SCHEMA='dbo')
BEGIN
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AspNetUserTokens' AND TABLE_SCHEMA='dbo')
BEGIN
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[CompetitionMembers]    Script Date: 24.8.2021. 15:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UserGroupRoles' AND TABLE_SCHEMA='dbo')
BEGIN
CREATE TABLE [dbo].[UserGroupRoles](
	[RoleId] [nvarchar](450) NOT NULL,
	[UserGroupId] [int] NOT NULL
 CONSTRAINT [PK_UserGroupRoles] PRIMARY KEY CLUSTERED 
(
	[UserGroupId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UserGroups' AND TABLE_SCHEMA='dbo')
BEGIN
CREATE TABLE [dbo].[UserGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](256) NOT NULL
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CompetitionMembers' AND TABLE_SCHEMA='dbo')
BEGIN
CREATE TABLE [dbo].[CompetitionMembers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompetitionID] [int] NOT NULL,
	[MemberID] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_CompetitionMember] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Competitions' AND TABLE_SCHEMA='dbo')
BEGIN
CREATE TABLE [dbo].[Competitions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompetitionTypeID] [int] NOT NULL,
	[VenueID] [int] NOT NULL,
	[CompetitionOrganizerID] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Competition] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CompetitionTypes' AND TABLE_SCHEMA='dbo')
BEGIN
CREATE TABLE [dbo].[CompetitionTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_CompetitionType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Countries' AND TABLE_SCHEMA='dbo')
BEGIN
CREATE TABLE [dbo].[Countries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Venues' AND TABLE_SCHEMA='dbo')
BEGIN
CREATE TABLE [dbo].[Venues](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_Venue] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_AspNetRoleClaims_AspNetRoles_RoleId]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
BEGIN
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_AspNetUserClaims_AspNetUsers_UserId]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
BEGIN
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_AspNetUserLogins_AspNetUsers_UserId]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
BEGIN
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_AspNetUserRoles_AspNetRoles_RoleId]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
BEGIN
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_AspNetUserRoles_AspNetUsers_UserId]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
BEGIN
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_AspNetUserTokens_AspNetUsers_UserId]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
BEGIN
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_CompetitionMember_AspNetUser]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
BEGIN
ALTER TABLE [dbo].[CompetitionMembers]  WITH CHECK ADD  CONSTRAINT [FK_CompetitionMember_AspNetUser] FOREIGN KEY([MemberID])
REFERENCES [dbo].[AspNetUsers] ([Id])
ALTER TABLE [dbo].[CompetitionMembers] CHECK CONSTRAINT [FK_CompetitionMember_AspNetUser]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_CompetitionMember_Competition]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
BEGIN
ALTER TABLE [dbo].[CompetitionMembers]  WITH CHECK ADD  CONSTRAINT [FK_CompetitionMember_Competition] FOREIGN KEY([CompetitionID])
REFERENCES [dbo].[Competitions] ([ID])
ALTER TABLE [dbo].[CompetitionMembers] CHECK CONSTRAINT [FK_CompetitionMember_Competition]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_Competition_AspNetUser]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
BEGIN
ALTER TABLE [dbo].[Competitions]  WITH CHECK ADD  CONSTRAINT [FK_Competition_AspNetUser] FOREIGN KEY([CompetitionOrganizerID])
REFERENCES [dbo].[AspNetUsers] ([Id])
ALTER TABLE [dbo].[Competitions] CHECK CONSTRAINT [FK_Competition_AspNetUser]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_UserGroupRoles_AspNetRoles]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
BEGIN
ALTER TABLE [dbo].[UserGroupRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserGroupRoles_AspNetRoles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ALTER TABLE [dbo].[UserGroupRoles] CHECK CONSTRAINT [FK_UserGroupRoles_AspNetRoles]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_UserGroupRoles_UserGroups]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
BEGIN
ALTER TABLE [dbo].[UserGroupRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserGroupRoles_UserGroups] FOREIGN KEY([UserGroupId])
REFERENCES [dbo].[UserGroups] ([Id])
ALTER TABLE [dbo].[UserGroupRoles] CHECK CONSTRAINT [FK_UserGroupRoles_UserGroups]
END
GO


IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_Competition_CompetitionType]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
BEGIN
ALTER TABLE [dbo].[Competitions]  WITH CHECK ADD  CONSTRAINT [FK_Competition_CompetitionType] FOREIGN KEY([CompetitionTypeID])
REFERENCES [dbo].[CompetitionTypes] ([ID])
ALTER TABLE [dbo].[Competitions] CHECK CONSTRAINT [FK_Competition_CompetitionType]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_Competition_Venue]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
BEGIN
ALTER TABLE [dbo].[Competitions]  WITH CHECK ADD  CONSTRAINT [FK_Competition_Venue] FOREIGN KEY([VenueID])
REFERENCES [dbo].[Venues] ([ID])
ALTER TABLE [dbo].[Competitions] CHECK CONSTRAINT [FK_Competition_Venue]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[dbo].[FK_Venue_Country]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
BEGIN
ALTER TABLE [dbo].[Venues]  WITH CHECK ADD  CONSTRAINT [FK_Venue_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([ID])
ALTER TABLE [dbo].[Venues] CHECK CONSTRAINT [FK_Venue_Country]
END
GO
