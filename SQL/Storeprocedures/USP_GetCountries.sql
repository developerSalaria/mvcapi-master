USE [TPA_Staging]
GO
/****** Object:  StoredProcedure [dbo].[USP_GetCountries]    Script Date: 19-05-2020 07:29:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    ALTER PROC [dbo].[USP_GetCountries]
	(
	@EmployeeCode varchar(100)=null
	)
	 AS    BEGIN           
	
	select ID,EName from tblCountry

END
