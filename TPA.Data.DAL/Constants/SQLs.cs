using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Data.DAL
{
    public static class SQLs
    {
        public const string GetSampleTest = "select * from Students";
        public const string GetSampleTestWithParameter = "select * from Students where name=&name&";
        public const string GET_ALL_PROVIDERS = "select * from tblProvider";
        public const string GET_PROVIDER_BY_ID = "select * from tblProvider where ID = @ProviderID";
        public const string GET_ALL_VISIT_TYPES = "select * from tblTPAVisitType";
        public const string GET_ALL_INSURANCE_POLICIES = "select * from tblInsurancePolicy";
        public const string GET_ALL_DOCTOR_SPECIALITIES = "select * from tblTPADoctorSpeciality";
        public const string GET_DOCTOR_SPECIALITIES_BY_ID = "select * from tblTPADoctorSpeciality where ID = @ID";
        public const string GET_ALL_STATUS = "select * from tblStatus";
        public const string GET_STATUS_BY_ID = "select * from tblStatus where ID = @ID";
        public const string GET_VISIT_TYPE_BY_ID = "select * from tblTPAVisitType where ID = @ID";
        public const string GET_ALL_SERVICE_TYPES_BYPOLICY = " select t.ID, t.EName,c.AmountLimit ServiceAmount,c.CoShare CoShareAmount,c.Percentage CoSharePercentage,0 InsuredAmount  from tblCompanyEmployee emp  inner join tblCompany on tblCompany.ID = emp.CompanyID   inner join tblinsurancepolicy p on p.id = policyid  inner join tblInsurancePlan pl on pl.ID = p.PlanID inner join tblInsurancePlanCoverage c on c.PlanID = p.PlanID  inner join tblServiceType t on t.ID=c.ServiceTypeID  where emp.EmployeeCode =@policycode and tblCompany.StatusID=1 ";
        public const string GET_ALL_SERVICE_TYPES = " select t.ID, t.EName,0 ServiceAmount,0 CoShareAmount,0 CoSharePercentage,0 InsuredAmount from tblServiceType t ";


        public const string GET_ALL_SYMPTOMS = "select ID , AShortDescription Ename,,AShortDescription AName  from tblICD";
        public const string GET_SYMPTOMS = "select ID,AShortDescription Ename,AShortDescription AName from tblICD where AShortDescription like '%'+@search+'%'";
        public const string GET_FILE = "select * from tblFiles where ID = @ID";
        public const string sp_Country_Get = "select * from tblCountry";
    }
}
