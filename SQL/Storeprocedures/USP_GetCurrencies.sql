USE [TPA_Staging]
GO
/****** Object:  StoredProcedure [dbo].[USP_GetCurrencies]    Script Date: 17-05-2020 10:52:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    ALTER PROC [dbo].[USP_GetCurrencies]
	 AS    BEGIN           
	
	select ID,Country,CurrencyCode from tblCurrency

END
