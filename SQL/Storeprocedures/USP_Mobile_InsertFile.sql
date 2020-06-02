USE [TPA_Staging]
GO

/****** Object:  StoredProcedure [dbo].[USP_Mobile_InsertFile]    Script Date: 20-05-2020 02:23:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

    ALTER PROC [dbo].[USP_Mobile_InsertFile]
	(
						@FileName varchar(100)
					   ,@Contents nvarchar(max)
					   ,@ContentType nvarchar(100)
					   ,@ClaimId int 
					   ,@CreatedBy int
	)
	 AS    BEGIN           
	BEGIN TRY
				INSERT INTO [dbo].[tblFiles]
					   ([FileName]
					   ,[Contents]
					   ,[ContentType]
					   ,[ClaimId]
					   ,[CreatedOn]
					   ,[CreatedBy]
					   )
				 VALUES
					   (
							@FileName
							,@Contents
						   ,@ContentType
						   ,@ClaimId
						   ,getutcdate()
						   ,@CreatedBy
						  
					   )

				SELECT @@IDENTITY as ID,1 as IsSuccess,'File saved successfully' as [Message]

		   END TRY
		   BEGIN CATCH 
				select 0,1 as IsSuccess,ERROR_MESSAGE() as [Message] ;
		   END CATCH
END

GO


