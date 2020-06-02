ALTER TABLE [dbo].[tblMobilePaymentMethod]
ADD [EmployeeCode] [varchar](100) NULL


ALTER TABLE [dbo].[tblMobileClaims]
ADD [IsSubmitted] [bit] NULL


ALTER TABLE [dbo].[tblMobileClaims]
ADD [PaymentMethodId] [int] NULL
