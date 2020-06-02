USE [TPA_Staging]
GO

/****** Object:  Table [dbo].[tblMobileClaims]    Script Date: 19-05-2020 12:45:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblMobileClaims](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PolicyCode] [varchar](100) NULL,
	[ClaimTypeId] [int] NULL,
	[ProviderId] [int] NULL,
	[ServiceTypeId] [int] NULL,
	[ClaimedAmount] [decimal](18, 2) NULL,
	[ClaimReference] [varchar](25) NULL,
	[ServiceDate] [datetime] NULL,
	[CurrencyId] [int] NULL,
	[IsApproved] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_tblMobileClaims] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[tblMobileClaims] ADD  CONSTRAINT [DF_tblMobileClaims_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO


