USE [TPA_Staging]
GO

/****** Object:  Table [dbo].[tblMobileUsers]    Script Date: 16-05-2020 01:05:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblMobileUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserIdentity] [varchar](100) NULL,
	[Name] [varchar](255) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](max) NULL,
	[DOB] [datetime] NULL,
	[IsActive] [bit] NULL,
	[EmployeeId] [int] NULL,
	[Created] [datetime] NULL CONSTRAINT [DF_tblMobileUsers_Created]  DEFAULT (getutcdate()),
 CONSTRAINT [PK_tblMobileUsers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


