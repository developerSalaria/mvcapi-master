USE [TPA_Staging]
GO
/****** Object:  StoredProcedure [dbo].[USP_Mobile_DeleteClaim]    Script Date: 21-05-2020 02:53:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    ALTER PROC [dbo].[USP_Mobile_DeleteClaim]
	(
	@ClaimId int
	)
	 AS    BEGIN           
	BEGIN TRY
				UPDATE [dbo].[tblMobileClaims] SET IsActive=0 WHERE ID=@ClaimId

				SELECT @ClaimId as ID,1 as IsSuccess,'Claim deleted successfully' as [Message]

		   END TRY
		   BEGIN CATCH 
				select 0 as IsSuccess,ERROR_MESSAGE() as [Message] ;
		   END CATCH
END
