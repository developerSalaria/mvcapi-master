USE [TPA_Staging]
GO
/****** Object:  StoredProcedure [dbo].[USP_Mobile_SubmitClaim]    Script Date: 24-05-2020 12:36:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    ALTER PROC [dbo].[USP_Mobile_SubmitClaim]
	(
	@ClaimId int,
	@PaymentMethodId int
	)
	 AS    BEGIN           
	BEGIN TRY
				UPDATE [dbo].[tblMobileClaims] SET IsSubmitted=1,PaymentMethodId=@PaymentMethodId,Modified=GETUTCDATE() WHERE ID=@ClaimId

				SELECT @ClaimId as ID,1 as IsSuccess,'Claim submitted successfully' as [Message]

		   END TRY
		   BEGIN CATCH 
				select 0 as IsSuccess,ERROR_MESSAGE() as [Message] ;
		   END CATCH
END
