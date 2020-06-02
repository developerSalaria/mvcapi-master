USE [TPA_Staging]
GO
/****** Object:  StoredProcedure [dbo].[USP_Mobile_GetPaymentMethod]    Script Date: 24-05-2020 12:43:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    ALTER PROC [dbo].[USP_Mobile_GetPaymentMethod]
	(
	@EmployeeCode varchar(100)=null
	)
	 AS    BEGIN           
	
	select * from tblMobilePaymentMethod where EmployeeCode=@EmployeeCode

END
