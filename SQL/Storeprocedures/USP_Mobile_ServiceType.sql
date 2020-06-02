USE [TPA_Staging]
GO
/****** Object:  StoredProcedure [dbo].[USP_Mobile_ServiceType]    Script Date: 23-05-2020 05:24:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    ALTER PROC [dbo].[USP_Mobile_ServiceType]
	(
	@EmployeeCode varchar(100)=null
	)
	 AS    BEGIN           
	
	select t.ID, t.EName,c.AmountLimit ServiceAmount,c.CoShare CoShareAmount,c.Percentage CoSharePercentage,0 InsuredAmount 
from tblCompanyEmployee emp  inner join tblCompany on tblCompany.ID = emp.CompanyID   inner join tblinsurancepolicy p on p.id = policyid  inner join tblInsurancePlan pl on pl.ID = p.PlanID inner join tblInsurancePlanCoverage c on c.PlanID = p.PlanID  inner join tblServiceType t 
on t.ID=c.ServiceTypeID  where emp.EmployeeCode =@EmployeeCode and tblCompany.StatusID=1 

END
