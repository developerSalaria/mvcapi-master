using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.MobileModel;
using TPA.Common.Core.Model;

namespace TPA.Data.DAL.MobileRepositories
{
    public class ClaimRepository:BaseRepository,IDisposable
    {
        public IEnumerable<ServiceTypeModel> GetServiceType(string EmployeeCode)
        {
            return QueryExecutor.Query<ServiceTypeModel>(MobileStoreProcedures.USP_Mobile_ServiceType.ToString(),new { EmployeeCode= EmployeeCode }, CommandType.StoredProcedure).ToList();
        }

        public IEnumerable<CountryModel> GetCountries(string EmployeeCode)
        {
            return QueryExecutor.Query<CountryModel>(MobileStoreProcedures.USP_GetCountries.ToString(), new { EmployeeCode = EmployeeCode }, CommandType.StoredProcedure).ToList();
        }

        public IEnumerable<ProviderModel> GetProviders(string EmployeeCode)
        {
            return QueryExecutor.Query<ProviderModel>(MobileStoreProcedures.USP_GetTPAProviders.ToString(), new { EmployeeCode = EmployeeCode }, CommandType.StoredProcedure).ToList();
        }

        public IEnumerable<CurrencyModel> GetCurrency(string EmployeeCode)
        {
            return QueryExecutor.Query<CurrencyModel>(MobileStoreProcedures.USP_GetCurrencies.ToString(), new { EmployeeCode = EmployeeCode }, CommandType.StoredProcedure).ToList();
        }

        public Result SaveClaim(ClaimModel claim)
        {
            var obj = new
            {
                PolicyCode = claim.PolicyCode,
                ClaimTypeId = claim.ClaimTypeId,
                ProviderId = claim.ProviderId,
                ServiceTypeId = claim.ServiceTypeId,
                ClaimedAmount = claim.ClaimedAmount,
                ClaimReference = claim.ClaimReference,
                ServiceDate = claim.ServiceDate,
                CurrencyId = claim.CurrencyId,
            };
            return QueryExecutor.QueryFirst<Result>(MobileStoreProcedures.USP_Mobile_InsertClaim.ToString(), obj, CommandType.StoredProcedure);

        }

        public Result SaveFile(FileModel file)
        {
            var obj = new
            {
                FileName = file.FileName,
                Contents = file.Contents,
                ContentType = file.ContentType,
                ClaimId = file.ClaimId,
                CreatedBy = file.CreatedBy,
               
            };
            return QueryExecutor.QueryFirst<Result>(MobileStoreProcedures.USP_Mobile_InsertFile.ToString(), obj, CommandType.StoredProcedure);

        }

        public Result SavePaymentMethod(PaymentModel model)
        {
            var obj = new
            {
                CountryId    = model.CountryId,
                IBAN = model.IBAN,
                Swift_BIC = model.Swift_BIC,
                AccountNo = model.AccountNo,
                AccountName = model.AccountName,
                CurrencyId = model.CurrencyId,
                BankName = model.BankName,
                BankAddress = model.BankAddress,
                Branch = model.Branch,
                City = model.City,
                Phone = model.Phone,
                Email = model.Email,
                EmployeeId=model.EmployeeId
            };
            return QueryExecutor.QueryFirst<Result>(MobileStoreProcedures.USP_Mobile_InsertPaymentMethod.ToString(), obj, CommandType.StoredProcedure);

        }

        public Result DeleteClaim(int  ClaimId)
        {
            var obj = new
            {
                ClaimId = ClaimId,
            };
            return QueryExecutor.QueryFirst<Result>(MobileStoreProcedures.USP_Mobile_DeleteClaim.ToString(), obj, CommandType.StoredProcedure);

        }

        public IEnumerable<ClaimModel> GetClaims(string PolicyCode)
        {
            return QueryExecutor.Query<ClaimModel>(MobileStoreProcedures.USP_Mobile_GetClaims.ToString(), new { @PolicyCode = PolicyCode }, CommandType.StoredProcedure).ToList();
        }

        public ClaimModel GetClaim(int ClaimId)
        {
            var obj = new
            {
                ClaimId = ClaimId,
            };
            return QueryExecutor.QueryFirst<ClaimModel>(MobileStoreProcedures.USP_Mobile_GetClaims.ToString(), obj, CommandType.StoredProcedure);

        }

        public Result SubmitClaim(int ClaimId,int PaymentMethodId)
        {
            var obj = new
            {
                ClaimId = ClaimId,
                PaymentMethodId= PaymentMethodId
            };
            return QueryExecutor.QueryFirst<Result>(MobileStoreProcedures.USP_Mobile_SubmitClaim.ToString(), obj, CommandType.StoredProcedure);

        }

        public IEnumerable<PaymentModel> GetPaymentMethod(string EmployeeCode)
        {
            var obj = new
            {
                EmployeeCode = EmployeeCode,
            };
            return QueryExecutor.Query<PaymentModel>(MobileStoreProcedures.USP_Mobile_GetPaymentMethod.ToString(), obj, CommandType.StoredProcedure).ToList();

        }

        public IEnumerable<FileModel> GetFiles(int ClaimId)
        {
            var obj = new
            {
                ClaimId = ClaimId,
            };
            return QueryExecutor.Query<FileModel>(MobileStoreProcedures.USP_Mobile_GetFiles.ToString(), obj, CommandType.StoredProcedure);

        }

        public FileModel GetFile(int FileId)
        {
            var obj = new
            {
                FileId = FileId,
            };
            return QueryExecutor.QueryFirst<FileModel>(MobileStoreProcedures.USP_Mobile_GetFiles.ToString(), obj, CommandType.StoredProcedure);
        }



        public void Dispose()
        {

        }
    }
}
