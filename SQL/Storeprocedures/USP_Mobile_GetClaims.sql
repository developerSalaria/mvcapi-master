USE [TPA_Staging]
GO
/****** Object:  StoredProcedure [dbo].[USP_Mobile_GetUserByEmail]    Script Date: 21-05-2020 01:27:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROC [dbo].[USP_Mobile_GetClaims]
(
	@PolicyCode varchar(100)=null,
	@ClaimId int =null
)
AS
BEGIN

	select Claims.ID,CT.ClaimType,provider.Name as ProviderName,serviceType.EName as ServiceName,Claims.ClaimedAmount,Claims.ClaimReference ,
		Claims.ClaimTypeId,Claims.ProviderId,Claims.ServiceTypeId,Claims.CurrencyId,Claims.CreatedDate,Claims.ClaimReference,
		Claims.ClaimReference,Claims.ServiceDate,Claims.IsApproved,Claims.PolicyCode,'My Self' as Member	from tblMobileClaims Claims 
		JOIN tblMobileClaimType CT on Claims.ClaimTypeId=CT.ID
		JOIN tblProvider provider on Claims.ProviderId=provider.ID
		JOIN tblServiceType serviceType on Claims.ServiceTypeId=serviceType.ID
		JOIN tblCurrency currency on Claims.CurrencyId=currency.ID


 where Claims.IsActive=1 AND 
 ((@PolicyCode is null)or (@PolicyCode is not null AND Claims.PolicyCode=@PolicyCode))
 AND ((@ClaimId is null)or (@ClaimId is not null AND Claims.ID=@ClaimId))
END
