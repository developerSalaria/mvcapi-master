USE [TPA_Staging]
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTPAProviders]    Script Date: 19-05-2020 07:59:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    ALTER PROC [dbo].[USP_GetTPAProviders]
	(
	@EmployeeCode varchar(100)=null
	)
	 AS    BEGIN           
	
	select ID,Name from tblProvider 

END
