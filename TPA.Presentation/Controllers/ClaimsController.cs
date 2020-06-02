using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TPA.Common.Core.Model;
using TPA.Presentation.ApiServices;
using TPA.Presentation.Models;

namespace TPA.Presentation.Controllers
{
    public class ClaimsController : Controller
    {
        // GET: Claims
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetClaims(string com)
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAllClaimsList(ReportSearchModel reportSearchModel)
        {
            var claims = ApiServices.TPAClaimService.Instance.GetAllClaims(reportSearchModel);
            claims.ForEach(d => d.VisitDateStr = d.VisitDate?.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture));
            return Json(new
            {
                draw = "1",
                data = claims,
                recordsFiltered = claims.Count,
                recordsTotal = claims.Count,
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddClaim()
        {
            AddClaimModel model = new AddClaimModel();
            model.Claim = new TPAClaim();
            return View(model);
        }
        

        [HttpPost]
        public ActionResult AddClaim(AddClaimModel addClaimModel)
        {
            var claim = addClaimModel.Claim;
            // save file
            if (addClaimModel.PostedFile != null)
            {
                int fileId = FileService.Instance.SaveFile(addClaimModel.PostedFile);
                claim.AttachmentId = fileId;
            }
           
            claim.ClaimNo = GenerateUniqueNumber("CL");
            int claimId = ApiServices.TPAClaimService.Instance.AddOrUpdateClaim(addClaimModel);


            AddClaimModel model = new AddClaimModel();
            model.Claim = claim;
            return View(model);
        }
        public static string GenerateUniqueNumber(string firstCharacters)
        {
            string result = (firstCharacters + DateTime.Now.Year.ToString().Substring(2) + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(2, '0')+ DateTime.Now.Ticks.ToString().PadLeft(2, '0'));
            if (result.Length > 17)
                result = result.Substring(0, 17);

            return result;

        }
        public ActionResult ViewClaim(int claimId)
        {
            TPAClaim claim = ApiServices.TPAClaimService.Instance.GetById(claimId);
            
            ViewClaimModel model = new ViewClaimModel();
            model.Claim = claim;
            model.Services = ApiServices.TPAClaimService.Instance.GetClaimServices(claimId);
            model.Symptoms = ApiServices.TPAClaimService.Instance.GetClaimSymptoms(claimId);
            return View(model);
        }

        /// <summary>
        /// use to get all the claims 
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewAllClaims()
        {
            return View();
        }

        public ActionResult ClaimDetail(string policyCode)
        {
            TPAClaim tPAClaim = new TPAClaim();
            var claim = ApiServices.TPAClaimService.Instance.GetByPolicyCode(policyCode);

            if (claim.Count > 0)
            {
                //Company Employee Info
                tPAClaim.Gender = claim.FirstOrDefault().Gender;
                tPAClaim.DOB = claim.FirstOrDefault().DOB;
                tPAClaim.EmployeeType = claim.FirstOrDefault().EmployeeType;
                tPAClaim.PersonalTelNo = claim.FirstOrDefault().PersonalTelNo;
                tPAClaim.InsureName = claim.FirstOrDefault().InsureName;
                tPAClaim.CompanyName = claim.FirstOrDefault().CompanyName;

            }

            //var items = tPAClaim.Where(p => p.id != null);
            return View(tPAClaim);
        }
        [HttpGet]
        public ActionResult SearchClaims(TPAClaim searchModel)
        {
            var draw = Request.Form.GetValues("draw") == null ? "1" : Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start") == null ? "0" : Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length") == null ? "10" : Request.Form.GetValues("length").FirstOrDefault();
            //Find Order Column

            var sortColumn = Request.Form.GetValues("order[0][column]") == null ? "" : Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]") == null ? "asc" : Request.Form.GetValues("order[0][dir]").FirstOrDefault();

            var order = $"{(sortColumn == "" ? "PolicyCode" : sortColumn)} {sortColumnDir}";
            int take = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            var claim = ApiServices.TPAClaimService.Instance.GetByPolicyCode(searchModel.PolicyCode);
            claim.ForEach(d => d.VisitDatestr = d.EntryDate.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture));

            claim = claim.Where(p => p.ClaimNo != null).ToList();

            var count = claim.Count;
            var listSerialized = new
            {
                draw = draw,
                recordsFiltered = count,
                recordsTotal = count,
                data = claim
            };
            return Json(listSerialized, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DownloadAttachment(int claimId)
        {
            // get claim
            var claim = ApiServices.TPAClaimService.Instance.GetById(claimId);

            if (claim?.AttachmentId.HasValue == true)
            {
                // get file
                FileData data = FileService.Instance.GetFile(claim.AttachmentId.Value);
                if (data != null)
                {
                    byte[] byteArray = Convert.FromBase64String(data.Contents);
                    return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Octet, data.FileName);
                }
            }

            return new EmptyResult();
        }

        public ActionResult SearchSymtoms(string q)
        {
            var symptoms = ApiServices.TPAClaimService.Instance.SearchSymtoms(q);
            return Json(symptoms, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetServiceBalanceByPolicyCode(string policyCode)
        {
            List<TPAClaimServiceBalance> symptoms = ApiServices.TPAClaimService.Instance.GetServiceBalanceByPolicyCode(policyCode);
            return Json(symptoms, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetServicesByPolicyCode(string policyCode)
        {
            List<ServiceType> services = ApiServices.ServiceTypeService.Instance.Get(policyCode);
            return Json(services, JsonRequestBehavior.AllowGet);
        }
    }
}
