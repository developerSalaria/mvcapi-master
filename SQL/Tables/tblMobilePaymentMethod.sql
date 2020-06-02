USE [TPA_Staging]
GO

/****** Object:  Table [dbo].[tblMobilePaymentMethod]    Script Date: 19-05-2020 12:46:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblMobilePaymentMethod](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NULL,
	[IBAN] [varchar](100) NULL,
	[Swift_BIC] [varchar](100) NULL,
	[AccountNo] [varchar](100) NULL,
	[AccountName] [varchar](255) NULL,
	[CurrencyId] [int] NULL,
	[BankName] [varchar](255) NULL,
	[BankAddress] [varchar](300) NULL,
	[Branch] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [date] NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK_tblMobilePaymentMethod] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


