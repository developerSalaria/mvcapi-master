using TPA.Common.Core.Model;
using TPA.Presentation.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPA.Common.Core.Resources;

namespace TPA.Presentation
{
    public class Dropdowns
    {
        public static List<SelectListItem> Country(int countryId = 0)
        {
            List<Country> list = new CountryService().Get();
            List<SelectListItem> ddlList = new List<SelectListItem>();

            foreach (var item in list)
            {
                SelectListItem be = new SelectListItem();
                be.Text = item.EName;
                be.Value = item.Id.ToString();
                be.Selected = countryId != 0 && countryId == item.Id ? true : false;
                ddlList.Add(be);
            }
            return ddlList;
        }

        public static List<SelectListItem> City(int cityId = 0, int countryId = 0)
        {

            if (cityId == 0 && countryId == 0)
            {
                return new List<SelectListItem>();
            }

            List<City> list = new CityService().Get();
            if (countryId != 0)
            {
                list = list.Where(x => x.CountryId == countryId).ToList();
            }
            List<SelectListItem> ddlList = new List<SelectListItem>();
            foreach (var item in list)
            {
                SelectListItem be = new SelectListItem();
                be.Text = item.CityName;
                be.Value = item.CityId.ToString();
                be.Selected = cityId != 0 && cityId == item.CityId ? true : false;
                ddlList.Add(be);
            }
            if (ddlList == null || ddlList.Count == 0)
            {
                ddlList = new List<SelectListItem>() { new SelectListItem() { Text = Common.Core.Resources.Common.NotFound, Value = "0", Selected = true } };
            }
            return ddlList;
        }

        public static List<SelectListItem> CustomerTypes(int customerTypeId = 0)
        {
            List<CustomerType> list = new CustomerTypeService().Get();
            List<SelectListItem> ddlList = new List<SelectListItem>();

            foreach (var item in list)
            {
                SelectListItem be = new SelectListItem();
                be.Text = item.CustomerTypeName;
                be.Value = item.CustomerTypeId.ToString();
                be.Selected = customerTypeId != 0 && customerTypeId == item.CustomerTypeId ? true : false;
                ddlList.Add(be);
            }
            return ddlList;
        }

        public static List<SelectListItem> DocumentTypes(int documentTypeId = 0)
        {
            List<DocumentType> list = new DocumentTypeService().Get();
            List<SelectListItem> ddlList = new List<SelectListItem>();

            foreach (var item in list)
            {
                SelectListItem be = new SelectListItem();
                be.Text = item.DocumentTypeName;
                be.Value = item.DocumentTypeId.ToString();
                be.Selected = documentTypeId != 0 && documentTypeId == item.DocumentTypeId ? true : false;
                ddlList.Add(be);
            }
            return ddlList;
        }

        public static List<SelectListItem> Currency(int currencyId = 0)
        {
            List<Currency> list = new CurrencyService().Get();
            List<SelectListItem> ddlList = new List<SelectListItem>();

            foreach (var item in list)
            {
                SelectListItem be = new SelectListItem();
                be.Text = item.CurrencyCode + " - " + item.CurrencyName;
                be.Value = item.CurrencyId.ToString();
                be.Selected = currencyId != 0 && currencyId == item.CurrencyId ? true : false;
                ddlList.Add(be);
            }
            return ddlList;
        }

        public static List<SelectListItem> Nationality(int nationaltyId = 0)
        {
            List<Nationalty> list = new NationaltyService().Get();
            List<SelectListItem> ddlList = new List<SelectListItem>();

            foreach (var item in list)
            {
                SelectListItem be = new SelectListItem();
                be.Text = item.NationalityName;
                be.Value = item.NationalityId.ToString();
                be.Selected = nationaltyId != 0 && nationaltyId == item.NationalityId ? true : false;
                ddlList.Add(be);
            }
            return ddlList;
        }

        public static List<SelectListItem> Gender(int genderId = 0)
        {
            List<Gender> list = new GenderService().Get();
            List<SelectListItem> ddlList = new List<SelectListItem>();

            foreach (var item in list)
            {
                SelectListItem be = new SelectListItem();
                be.Text = item.GenderName;
                be.Value = item.GenderId.ToString();
                be.Selected = genderId != 0 && genderId == item.GenderId ? true : false;
                ddlList.Add(be);
            }
            return ddlList;
        }

        public static List<SelectListItem> CustomerState()
        {
            List<SelectListItem> ddlList = new List<SelectListItem>();

            if (CultureHelper.IsEnglishCulture)
            {
                ddlList = new List<SelectListItem>() { 
                    //new SelectListItem() { Text="Account State", Value="0", Selected=false },
                    new SelectListItem() { Text="Special Secondary", Value="1", Selected=false },
                    new SelectListItem() { Text="General Secondary", Value="2", Selected=false },
                };
            }
            else
            {
                ddlList = new List<SelectListItem>() {
                    //new SelectListItem() { Text="حالة الحســــاب", Value="0", Selected=true },
                    new SelectListItem() { Text="حساب ثانوي خاص", Value="1", Selected=false },
                    new SelectListItem() { Text="حساب ثانوي عام", Value="2", Selected=false },
                };
            }

            return ddlList;
        }

        private static List<SelectListItem> SelectDropdown(DropdownTypes dropDownName, int selectedValue, int parentValue = 0)
        {
            var List = new List<SelectListItem>();
            switch (dropDownName)
            {
                case DropdownTypes.City:
                    List = City(selectedValue, parentValue);
                    break;
                case DropdownTypes.Country:
                    List = Country(selectedValue);
                    break;
                case DropdownTypes.CustomerTypes:
                    List = CustomerTypes(selectedValue);
                    break;
                case DropdownTypes.DocumentTypes:
                    List = DocumentTypes(selectedValue);
                    break;
                case DropdownTypes.Nationality:
                    List = Nationality(selectedValue);
                    break;
                case DropdownTypes.Genders:
                    List = Gender(selectedValue);
                    break;
                case DropdownTypes.CustomerState:
                    List = CustomerState();
                    break;
                case DropdownTypes.Currency:
                    List = Currency(selectedValue);
                    break;
                default:
                    break;
            }
            return List;
        }

        public static List<SelectListItem> GetDropdown(DropdownTypes dropDownName, int selectedValue = 0, int parentValue = 0, bool hardReload = false)
        {
            List<SelectListItem> ddlValues = HttpContext.Current.Cache[dropDownName.ToString()] as List<SelectListItem>;
            if (ddlValues == null || ddlValues.Count == 0 || hardReload || CompareCurrentLang())
            {
                var NewValues = SelectDropdown(dropDownName, selectedValue, parentValue);
                var cTime = DateTime.Now.AddMinutes(120);
                var cExp = System.Web.Caching.Cache.NoSlidingExpiration;
                var cPri = System.Web.Caching.CacheItemPriority.Normal;
                ddlValues = NewValues;
                HttpContext.Current.Cache.Insert(dropDownName.ToString(), NewValues, null, cTime, cExp, cPri, null);
            }
            if (ddlValues != null && ddlValues.Count > 0)
            {
                ddlValues = ddlValues.OrderBy(x => x.Text).ToList();
            }
            else if (ddlValues == null || ddlValues.Count == 0)
            {
                ddlValues = new List<SelectListItem>() { new SelectListItem { Text = Common.Core.Resources.Common.NotFound, Value = "0" } };
            }
            return ddlValues;
        }

        public static bool CompareCurrentLang(bool updateCache = false)
        {
            bool IsDifferent = false;
            string Lang = HttpContext.Current.Cache["SelectedLang"] as string;
            if (Lang == null || Lang != CultureHelper.CurrentCulture)
            {
                IsDifferent = true;

                if (updateCache)
                {
                    Lang = CultureHelper.CurrentCulture;
                    var cTime = DateTime.Now.AddMinutes(60);
                    var cExp = System.Web.Caching.Cache.NoSlidingExpiration;
                    var cPri = System.Web.Caching.CacheItemPriority.Normal;
                    HttpContext.Current.Cache.Insert("SelectedLang", Lang, null, cTime, cExp, cPri, null);
                }
            }
            return IsDifferent;
        }

        public static IEnumerable<SelectListItem> GetProviders()
        {
            var providers = ProviderService.Instance.Get();

            return providers.Select(provider => new SelectListItem()
            {
                Text = provider.Name,
                Value = provider.ID.ToString()
            });
        }

        public static IEnumerable<SelectListItem> GetVisitTypes()
        {
            var providers = VisitTypeService.Instance.Get();

            return providers.Select(provider => new SelectListItem()
            {
                Text = provider.EName,
                Value = provider.ID.ToString()
            });
        }

        public static string[] GetInsurancePolicyNames()
        {
            var providers = InsurancePolicyService.Instance.Get();

            return providers.Select(insurance => insurance.PolicyCode).ToArray();
        }

        public static IEnumerable<SelectListItem> GetDoctorSpecialities()
        {
            var providers = DoctorSpecialityService.Instance.Get();

            return providers.Select(provider => new SelectListItem()
            {
                Text = provider.EName,
                Value = provider.ID.ToString()
            });
        }

        public static List<Symptoms> GetSymptoms()
        {
            return SymptomsService.Instance.Get();
        }

        public static List<ServiceType> GetServiceTypes(string policycode)
        {
            return ServiceTypeService.Instance.Get(policycode);
        }
        public static IEnumerable<SelectListItem> GetStatus()
        {
            var providers = StatusService.Instance.Get();

            return providers.Select(provider => new SelectListItem()
            {
                Text = provider.Name,
                Value = provider.ID.ToString()
            });
        }

        public static void InitialAllDropdown()
        {
            GetDropdown(DropdownTypes.City);
            GetDropdown(DropdownTypes.Country);
            GetDropdown(DropdownTypes.CustomerState);
            GetDropdown(DropdownTypes.CustomerTypes);
            GetDropdown(DropdownTypes.DocumentTypes);
            GetDropdown(DropdownTypes.Genders);
        }
    }
}