USE [TPA_Staging]
GO
/****** Object:  StoredProcedure [dbo].[USP_Mobile_GetUserByEmail]    Script Date: 15-05-2020 10:08:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[USP_Mobile_Register]
(
	@Email varchar(100),
	@Password varchar(max),
	@UserIdentity varchar(100),
	@Name varchar(255),
	@DOB datetime
)
AS
BEGIN
BEGIN TRY
		DECLARE @EmployeeId varchar(100)=null;
		DECLARE @Count int=0;
		DECLARE @userId varchar(100)=null;

		select top 1 @EmployeeId=ID from [dbo].[tblCompanyEmployee] where NationalIDNo=@UserIdentity

		IF @EmployeeId is null
			BEGIN
		
				SELECT 0 as IsSuccess,'Incorrect User Id' as [Message]

			END
		ELSE
			BEGIN
			
			select top 1 @Count=Count(*) from tblMobileUsers where Email=@Email
			IF @Count=0
				BEGIN
					
				select top 1 @userId=UserIdentity from tblMobileUsers where UserIdentity=@UserIdentity
				IF @userId is null
					BEGIN
							INSERT INTO [dbo].[tblMobileUsers]
								   ([UserIdentity]
								   ,[Name]
								   ,[Email]
								   ,[Password]
								   ,[DOB]
								   ,[IsActive]
								   ,[EmployeeId]
								   )
							 VALUES
								   (@UserIdentity
								   ,@Name
								   ,@Email
								   ,@Password
								   ,@DOB
								   ,1
								   ,@EmployeeId
								   )

								SELECT 1 as IsSuccess,'Registered successfully' as [Message]
					END
					ELSE
						BEGIN
							SELECT 0 as IsSuccess,'A user is already registerd with this user id.' as [Message]
						END
				END
			ELSE
				BEGIN
					SELECT 0 as IsSuccess,'Email Id already exist' as [Message]
				END
			END
END TRY
BEGIN CATCH 
	select 0,ERROR_MESSAGE() as [Message] ;
END CATCH
END