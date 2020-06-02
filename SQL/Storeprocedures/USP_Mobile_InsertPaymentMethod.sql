USE [TPA_Staging]
GO

/****** Object:  StoredProcedure [dbo].[USP_Mobile_InsertPaymentMethod]    Script Date: 20-05-2020 02:24:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


    ALTER PROC [dbo].[USP_Mobile_InsertPaymentMethod]
	(
		@CountryId int =NULL,
		@IBAN varchar(100) =NULL,
		@Swift_BIC varchar(100) =NULL,
		@AccountNo varchar(100)= NULL,
		@AccountName varchar(255)= NULL,
		@CurrencyId int= NULL,
		@BankName varchar(255) =NULL,
		@BankAddress varchar(300)= NULL,
		@Branch varchar(255)= NULL,
		@City varchar(255) =NULL,
		@Phone varchar(50)= NULL,
		@Email varchar(100)= NULL,
		@EmployeeId [int]= NULL
	)
	 AS    BEGIN           
	BEGIN TRY
			INSERT INTO [dbo].[tblMobilePaymentMethod]
			   ([CountryId]
			   ,[IBAN]
			   ,[Swift_BIC]
			   ,[AccountNo]
			   ,[AccountName]
			   ,[CurrencyId]
			   ,[BankName]
			   ,[BankAddress]
			   ,[Branch]
			   ,[City]
			   ,[Phone]
			   ,[Email]
			   ,[IsActive]
			   ,[EmployeeId]
			   )
				VALUES
					   (
						   @CountryId
						  ,@IBAN
						  ,@Swift_BIC
						  ,@AccountNo
						  ,@AccountName
						  ,@CurrencyId
						  ,@BankName
						  ,@BankAddress
						  ,@Branch
						  ,@City
						  ,@Phone
						  ,@Email
						  ,1
						  ,@EmployeeId
					   )

				SELECT @@IDENTITY as ID,1 as IsSuccess,'Payment method successfully saved.' as [Message]

		   END TRY
		   BEGIN CATCH 
				select 0,0 as IsSuccess,ERROR_MESSAGE() as [Message] ;
		   END CATCH
END

GO


