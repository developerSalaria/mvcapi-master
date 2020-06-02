using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Data.DAL
{
    public enum StoreProcedures
    {
        spGetSampleTests,
        spGetSampleTestById,
        spDeleteSampleTest,
        spUpdateSampleTest,
        spInsertSampleTest,
        spGetLastId,
        spGetSampleTestsSample,
        sp_GetSampleTestsName,
        sp_GetByIdSampleTestName,
        sp_IsSampleTestExist,
        sp_InsertSampleTestName,
        sp_UpdateSampleTestName,
        sp_DeleteSampleTestName,
        spProductShow,
        spProductById,
        spProductDelete,
        spProductUpdate,
        spProductInsert,
        sp_GetAllProduct,
        sp_GetEmp,

        sp_Nationalty_Update,
        sp_Nationalty_Get,
        sp_Nationalty_Delete,
        sp_Nationalty_Insert,
        sp_CustomerType_Update,
        sp_CustomerType_Get,
        sp_CustomerType_Insert,
        sp_CustomerType_Delete,
        sp_Customer_Update,
        sp_Customer_Get,
        sp_Customer_Search_Grid,
        sp_Customer_Insert,
        sp_Customer_Delete,
        sp_AspNetUserLogins_Get,
        sp_AspNetUserLogins_Insert,
        sp_AspNetUserLogins_Delete,
        sp_AspNetUserClaims_Get,
        sp_AspNetUserClaims_Delete,
        sp_AspNetUsers_Get,
        sp_AspNetUsers_Delete,
        sp_AspNetUserRoles_Get,
        sp_AspNetUserRoles_Insert,
        sp_AspNetUserRoles_Delete,
        sp_AspNetRoles_Update,
        sp_AspNetRoles_Insert,
        sp_AspNetRoles_Get,
        sp_AspNetRoles_Delete,
        sp_CustomerDocument_Update,
        sp_CustomerDocument_Get,
        sp_CustomerDocument_GetByCustomerId,
        sp_CustomerDocument_Insert,
        sp_CustomerDocument_Delete,
        sp_City_Update,
        sp_City_Get,
        sp_City_Insert,
        sp_City_Delete,
        sp_Country_Update,
        sp_Country_Get,
        sp_Country_Insert,
        sp_Country_Delete,
        sp_Gender_Update,
        sp_Gender_Insert,
        sp_Gender_Get,
        sp_Gender_Delete,
        sp_Currency_Update,
        sp_Currency_Get,
        sp_Currency_Insert,
        sp_Currency_Delete,

        sp_DocumentType_Update,
        sp_DocumentType_Get,
        sp_DocumentType_Insert,
        sp_DocumentType_Delete,
        sp_TotalCount_ByTable,
        // TPA 
        USP_GetTPAClaimDetail,
        usp_SaveUpdateClaim,
        usp_InsertUpdateTPAClaimServicesType,
        usp_InsertUpdateTPAClaimSymptoms,
        USP_GETTPAPolicyCodeDetails,
        //Serach  Report
        usp_GetTPAClaimsReportForServiceProvider,
        //Get All Claims By filter
        usp_GetTPAViewClaimsByFilter,
        usp_GetTPAClaimsReportForPaymentReport,
        usp_GetTPAReportForLossRatio,
        usp_GetTPAViewClaimSymptoms,
        usp_GetTPAViewClaimServices,
        usp_SaveUpdateFile,
        //Provider
        USP_GetTPAProviderServices,
        usp_GetSaveUpdateTPAProvider,
        // Customers
        USP_GetTPACustomersInsured,
        USP_GetTPAPolicys,
        usp_InsertProviderClaimExcelData,
        USP_GetTPASubPolicy,
        USP_GETTPAClaimServiceBalance,
        
        USP_GetTPAPolicyByPolicyNo,
        usp_GetTPAInsurancePolicy
    }

    public enum MobileStoreProcedures
    {
        USP_Mobile_GetUserByEmail,
        USP_Mobile_Register,
        USP_GetCountries,
        USP_GetTPAProviders,
        USP_GetCurrencies,
        USP_Mobile_ServiceType,
        USP_Mobile_InsertClaim,
        USP_Mobile_InsertPaymentMethod,
        USP_Mobile_InsertFile,
        USP_Mobile_DeleteClaim,
        USP_Mobile_GetClaims,
        USP_Mobile_SubmitClaim,
        USP_Mobile_GetPaymentMethod,
        USP_Mobile_GetFiles

    }
}
