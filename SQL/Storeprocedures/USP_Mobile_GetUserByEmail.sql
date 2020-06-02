USE [TPA_Staging]
GO
/****** Object:  StoredProcedure [dbo].[USP_Mobile_GetUserByEmail]    Script Date: 27-05-2020 11:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[USP_Mobile_GetUserByEmail]
(
	@Email varchar(100)=null
)
AS
BEGIN
select usr.UserIdentity,usr.Name,usr.Email,usr.Password,emp.PolicyCode,emp.EmployeeCode from tblMobileUsers usr join
tblCompanyEmployee emp on usr.EmployeeId=emp.ID where usr.Email=@Email
END