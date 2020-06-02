USE [TPA_Staging]
GO
/****** Object:  StoredProcedure [dbo].[USP_Mobile_ServiceType]    Script Date: 23-05-2020 10:51:48 PM ******/
--[dbo].[USP_Mobile_GetFiles] null,29
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    ALTER PROC [dbo].[USP_Mobile_GetFiles] --null,29
	(
	@ClaimId int=null,
	@FileId int=null
	)
	 AS    BEGIN           
	
	select 
	ID,FileName,ContentType,
	CASE WHEN @FileId is NULL THEN '' ELSE Contents END as Contents 
	
	from tblFiles where 
	((@ClaimId is null)or (@ClaimId is not null AND ClaimId=@ClaimId))
 AND ((@FileId is null)or (@FileId is not null AND ID=@FileId))

END
