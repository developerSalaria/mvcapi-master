using TPA.Common.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPA.Common.Core.Model
{
    public class Customer : BaseModel
    {
        public CustomerDocument CustomerDocument { get; set; }
        public int CustomerId { get; set; }
        public int TotalCount { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.CustomerType), ResourceType = typeof(Resources.Common))]
        public int CustomerTypeId { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.CustomerClass), ResourceType = typeof(Resources.Common))]
        public int CustomerClassId { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.Currency), ResourceType = typeof(Resources.Common))]
        public int CurrencyId { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.CustomerNameArabic), ResourceType = typeof(Resources.Common))]
        public string CustomerNameA { get; set; }
        public string CustomerName {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return CustomerNameE;
                }
                else
                {
                    return CustomerNameA;
                }
            }
        }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.CustomerNameEnglish), ResourceType = typeof(Resources.Common))]
        public string CustomerNameE { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.Country), ResourceType = typeof(Resources.Common))]
        public int CountryId { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.City), ResourceType = typeof(Resources.Common))]
        [Range(0.9, Double.MaxValue, ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        public int CityId { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.Nationality), ResourceType = typeof(Resources.Common))]
        public int NationalityId { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.PhoneNumber), ResourceType = typeof(Resources.Common))]
        public string Phone { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.Email), ResourceType = typeof(Resources.Common))]
        [EmailAddress(ErrorMessageResourceName = "IsInvalid", ErrorMessageResourceType = typeof(Resources.Common))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.Gender), ResourceType = typeof(Resources.Common))]
        public bool IsMale { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.Street), ResourceType = typeof(Resources.Common))]
        public string Street { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.Suburb), ResourceType = typeof(Resources.Common))]
        public string Suburb { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.PostCode), ResourceType = typeof(Resources.Common))]
        public string PostCode { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.State), ResourceType = typeof(Resources.Common))]
        public string State { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Resources.Common))]
        [Display(Name = nameof(Resources.Common.DateOfBirth), ResourceType = typeof(Resources.Common))]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public string CustomerClassNameA { get; set; }
        public string CustomerClassNameE { get; set; }
        public string CustomerClassName
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return CustomerClassNameE;
                }
                else
                {
                    return CustomerClassNameA;
                }
            }
        }

        public string CityNameA { get; set; }
        public string CityNameE { get; set; }
        public string CityName
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return CityNameE;
                }
                else
                {
                    return CityNameA;
                }
            }
        }
        public string CountryNameA { get; set; }
        public string CountryNameE { get; set; }
        public string CountryName
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return CountryNameE;
                }
                else
                {
                    return CountryNameA;
                }
            }
        }

        public string CustomerTypeNameA { get; set; }
        public string CustomerTypeNameE { get; set; }
        public string CustomerTypeName
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return CustomerTypeNameE;
                }
                else
                {
                    return CustomerTypeNameA;
                }
            }
        }

        public string DocumentTypeA { get; set; }
        public string DocumentTypeE { get; set; }
        public string DocumentTypeName
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return DocumentTypeE;
                }
                else
                {
                    return DocumentTypeA;
                }
            }
        }

        public string NationalityNameA { get; set; }
        public string NationalityNameE { get; set; }
        public string NationalityName
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return NationalityNameE;
                }
                else
                {
                    return NationalityNameA;
                }
            }
        }
        public int GenderId
        {
            get
            {
                if (IsMale)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }
        public string GenderNameA { get; set; }
        public string GenderNameE { get; set; }
        public string GenderName
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return GenderNameE;
                }
                else
                {
                    return GenderNameA;
                }
            }
        }
        public int DocumentId { get; set; }
        public string CurrencyNameA { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyNameE { get; set; }
        public string CurrencyName
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return CurrencyNameE;
                }
                else
                {
                    return CurrencyNameA;
                }
            }
        }
        public string AddressArb { get; set; }
        public string AddressEng { get; set; }
        public string Occupation { get; set; }
        public string AnotherPhone { get; set; }
        public bool CustomerFlag { get; set; }
        public bool AuthorizedFlag { get; set; }
        public bool VerifiedCheck { get; set; }
        public bool PrepareFlag { get; set; }
    }

    public class CustomerViewModel : BaseModel
    {
        public List<Customer> CustomerList { get; set; }
    }

    public class CustomerAccount
    {
        public int CustomerAccountId { get; set; }
    }
}
