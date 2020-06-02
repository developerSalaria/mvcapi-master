USE [TPA_Staging]
GO

/****** Object:  StoredProcedure [dbo].[USP_Mobile_InsertClaim]    Script Date: 20-05-2020 02:23:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

    ALTER PROC [dbo].[USP_Mobile_InsertClaim]
	(
	@PolicyCode varchar(100) NULL,
		@ClaimTypeId int= NULL,
		@ProviderId int= NULL,
		@ServiceTypeId int= NULL,
		@ClaimedAmount decimal(18, 2) =NULL,
		@ClaimReference varchar(25) NULL,
		@ServiceDate datetime NULL,
		@CurrencyId int NULL
	)
	 AS    BEGIN           
	BEGIN TRY
				INSERT INTO [dbo].[tblMobileClaims]
					   (PolicyCode
					   ,[ClaimTypeId]
					   ,[ProviderId]
					   ,[ServiceTypeId]
					   ,[ClaimedAmount]
					   ,[ClaimReference]
					   ,[ServiceDate]
					   ,[CurrencyId]
					   ,[IsApproved]
					   ,[IsActive])
				 VALUES
					   (
							@PolicyCode
							,@ClaimTypeId
						   ,@ProviderId
						   ,@ServiceTypeId
						   ,@ClaimedAmount
						   ,@ClaimReference
						   ,@ServiceDate
						   ,@CurrencyId
						   ,0
						   ,0
					   )

				SELECT @@IDENTITY as ID,1 as IsSuccess,'Claim submitted successfully' as [Message]

		   END TRY
		   BEGIN CATCH 
				select 0 as IsSuccess,ERROR_MESSAGE() as [Message] ;
		   END CATCH
END

GO


