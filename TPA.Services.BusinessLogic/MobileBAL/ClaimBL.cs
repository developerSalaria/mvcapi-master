using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.Common.Core.MobileModel;
using TPA.Data.DAL.MobileRepositories;

namespace TPA.Services.BusinessLogic.MobileBAL
{
    public class ClaimBL
    {
        private ClaimRepository _repo;
        public ClaimBL()
        {
            _repo = new ClaimRepository();
        }

        public IEnumerable<ServiceTypeModel> GetServiceType(string EmployeeCode)
        {
            return _repo.GetServiceType(EmployeeCode);
        }

        public IEnumerable<CountryModel> GetCountries(string EmployeeCode)
        {
            return _repo.GetCountries(EmployeeCode);
        }

        public IEnumerable<ProviderModel> GetProviders(string EmployeeCode)
        {
            return _repo.GetProviders(EmployeeCode);
        }

        public IEnumerable<CurrencyModel> GetCurrency(string EmployeeCode)
        {
            return _repo.GetCurrency(EmployeeCode);
        }

        public Result SaveClaim(ClaimModel claim)
        {
            return _repo.SaveClaim(claim);
        }

        public Result SaveFile(FileModel file)
        {
            return _repo.SaveFile(file);
        }

        public Result SavePaymentMethod(PaymentModel method)
        {
            return _repo.SavePaymentMethod(method);
        }

        public Result DeleteClaim(int ClaimId)
        {
            return _repo.DeleteClaim(ClaimId);
        }
        public IEnumerable<ClaimModel> GetClaims(string PolicyCode)
        {
            return _repo.GetClaims(PolicyCode);
        }

        public Result SubmitClaim(int ClaimId, int PaymentMethodId)
        {
            return _repo.SubmitClaim(ClaimId, PaymentMethodId);
        }

        public ClaimModel GetClaim(int ClaimId)
        {
            return _repo.GetClaim(ClaimId);
        }

        public IEnumerable<PaymentModel> GetPaymentMethod(string EmployeeCode)
        {
            return _repo.GetPaymentMethod(EmployeeCode);
        }

        public IEnumerable<FileModel> GetFiles(int ClaimId)
        {
            return _repo.GetFiles(ClaimId);
        }

        public FileModel GetFile(int FileId)
        {
            return _repo.GetFile(FileId);
        }
    }
}
