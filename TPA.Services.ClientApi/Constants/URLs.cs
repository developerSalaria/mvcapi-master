using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPA.Services.ClientApi
{
    public static class URLs
    {
        public static class Customer
        {
            public const string Get = "~/api/Customer/Get";
            public const string CustomerDataTable = "~/api/Customer/CustomerDataTable";
            public const string GetById = "~/api/Customer/GetById/{id}";
            public const string Delete = "~/api/Customer/Delete/{id}";
            public const string Update = "~/api/Customer/Update";
            public const string Insert = "~/api/Customer/Insert";
        }

        public static class CustomerDocument 
        {
            public const string Get = "~/api/CustomerDocument/Get";
            public const string GetById = "~/api/CustomerDocument/GetById/{id}";
            public const string Delete = "~/api/CustomerDocument/Delete";
            public const string Update = "~/api/CustomerDocument/Update";
            public const string Insert = "~/api/CustomerDocument/Insert";
        }
        public static class City 
        {
            public const string Get = "~/api/City/Get";
            public const string GetById = "~/api/City/GetById/{id}";
            public const string Delete = "~/api/City/Delete";
            public const string Update = "~/api/City/Update";
            public const string Insert = "~/api/City/Insert";
        }

        public static class FileURL
        {
            public const string SAVE_FILE = "~/api/File/Save";
            public const string GET_FILE = "~/api/File/Get";
        }

        public static class DocumentType
        {
            public const string Get = "~/api/DocumentType/Get";
            public const string GetById = "~/api/DocumentType/GetById/{id}";
            public const string Delete = "~/api/DocumentType/Delete";
            public const string Update = "~/api/DocumentType/Update";
            public const string Insert = "~/api/DocumentType/Insert";
        }

        public static class Country 
        {
            public const string Get = "~/api/Country/Get";
            public const string GetById = "~/api/Country/GetById/{id}";
            public const string Delete = "~/api/Country/Delete";
            public const string Update = "~/api/Country/Update";
            public const string Insert = "~/api/Country/Insert";
        }
        public static class Currency 
        {
            public const string Get = "~/api/Currency/Get";
            public const string GetById = "~/api/Currency/GetById/{id}";
            public const string Delete = "~/api/Currency/Delete";
            public const string Update = "~/api/Currency/Update";
            public const string Insert = "~/api/Currency/Insert";
        }
        public static class CustomerType 
        {
            public const string Get = "~/api/CustomerType/Get";
            public const string GetById = "~/api/CustomerType/GetById/{id}";
            public const string Delete = "~/api/CustomerType/Delete";
            public const string Update = "~/api/CustomerType/Update";
            public const string Insert = "~/api/CustomerType/Insert";
        }
        public static class Gender 
        {
            public const string Get = "~/api/Gender/Get";
            public const string GetById = "~/api/Gender/GetById/{id}";
            public const string Delete = "~/api/Gender/Delete";
            public const string Update = "~/api/Gender/Update";
            public const string Insert = "~/api/Gender/Insert";
        }
        public static class Nationalty 
        {
            public const string Get = "~/api/Nationalty/Get";
            public const string GetById = "~/api/Nationalty/GetById/{id}";
            public const string Delete = "~/api/Nationalty/Delete";
            public const string Update = "~/api/Nationalty/Update";
            public const string Insert = "~/api/Nationalty/Insert";
        }

        // TPA STUFF
        public static class ProviderURL
        {
            public const string Get = "~/api/Provider/Get";
            public const string GET_BY_ID = "~/api/Provider/GetById";
            public const string INSERT = "~/api/Provider/AddProvider";
        }
        public static class SymptomsURL
        {
            public const string Get = "~/api/Symptoms/Get";
        }

        public static class ServiceTypeURL
        {
            public const string Get = "~/api/ServiceType/Get";
            public const string GET_PROVIDER_SERVICES = "~/api/ServiceType/GetProviderServices";
            public const string Insert = "~/api/ServiceType/Insert";
        }


        public static class VisitTypeURL
        {
            public const string Get = "~/api/VisitType/Get";
            public const string GET_BY_ID = "~/api/VisitType/GetById";
        }

        public static class InsurancePolicyURL
        {
            public const string Get = "~/api/InsurancePolicy/Get";
        }

        public static class DoctorSpecialityURL
        {
            public const string Get = "~/api/DoctorSpeciality/Get";
            public const string GET_BY_ID = "~/api/DoctorSpeciality/GetById";
        }

        public static class ClaimURL
        {
            public const string Get = "~/api/Claim/Get";
            public const string INSERT = "~/api/Claim/Insert";
            public const string GetByPolicyCode = "~/api/Claim/GetByPolicyCode";
            public const string GetAllClaims = "~/api/Claim/GetAllClaims";
            public const string GET_CLAIM_SERVICES = "~/api/Claim/Services";
            public const string GET_CLAIM_SYMPTOMS = "~/api/Claim/Symptoms";
            public const string GetServiceBalanceByPolicyCode = "~/api/Claim/GetServiceBalanceByPolicyCode";
        }

        public static class StatusURL
        {
            public const string Get = "~/api/Status/Get";
            public const string GET_BY_ID = "~/api/Status/GetById";
            
        }

        public static class ReportURL
        {
            public const string SearchServiceProviderReport = "~/api/Report/SearchServiceProviderReport";
            public const string SearchPaymentReports = "~/api/Report/SearchPaymentReports";
            public const string SearchLossRatioReports = "~/api/Report/SearchLossRatioReports";
            public const string ProviderExcelUpload = "~/api/Report/ProviderExcelUpload";
        }

        // TPA Customers
        public static class CustomersURL
        {
            public const string GetPolicies = "~/api/Customers/GetPolicies";
            public const string GetCustomersInsured = "~/api/Customers/GetCustomersInsured";
            public const string GetSubPoliciesByPolicyNo = "~/api/Customers/GetSubPoliciesByPolicyNo";
            public const string GetPolicyByPolicyNo = "~/api/Customers/GetPolicyByPolicyNo";
            public const string UpdatePolicy = "~/api/Customers/UpdatePolicy";
        }

        //User Managemenent 
        public static class UserURL
        {
            //use url
            public const string Register = "~/api/Account/Register";
            public const string UpdateUser = "~/api/Account/UpdateUser";
            public const string GetUsers = "~/api/Account/GetUsers";
            public const string GetUserById = "~/api/Account/GetUserById";
            public const string DeleteUserById = "~/api/Account/DeleteUserById";
            public const string GetUserRolesById = "~/api/Account/GetUserRolesById";

            //role url
            public const string GetRoles = "~/api/Account/GetRoles";
            public const string GetRoleById = "~/api/Account/GetRoleById";
            public const string UpdateRole = "~/api/Account/UpdateRole";
            public const string AddNewRole = "~/api/Account/AddNewRole";
            public const string DeleteRoleById = "~/api/Account/DeleteRoleById";
        }
        }
}
