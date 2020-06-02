using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPA.Common.Core.Model;

namespace TPA.Presentation.Controllers
{
    public class ReportsController : BaseController
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProviderReport()
        {
            return View();
        }

        public ActionResult PaymentReport()
        {
            return View();
        }

        public ActionResult LossRatioReport()
        {
            return View();
        }

        /// <summary>
        /// Filter Provider reports By passing model 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SearchServiceProviderReports(ReportSearchModel reportSearchModel)
        {
            try
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

                var reportsData = ApiServices.ReportService.Instance.GetServiceProviderReportsByFilters(reportSearchModel);

                var count = reportsData.Count;
                var listSerialized = new
                {
                    draw = draw,
                    recordsFiltered = count,
                    recordsTotal = count,
                    data = reportsData
                };
                return Json(listSerialized, JsonRequestBehavior.AllowGet);

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult SearchPaymentReports(ReportSearchModel reportSearchModel)
        {
            try
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

                var reportsData = ApiServices.ReportService.Instance.SearchPaymentReports(reportSearchModel);

                var count = reportsData.Count;
                var listSerialized = new
                {
                    draw = draw,
                    recordsFiltered = count,
                    recordsTotal = count,
                    data = reportsData
                };
                return Json(listSerialized, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult SearchLossRatioReport(ReportLossRatioSearchModel reportSearchModel)
        {
            try
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

                var reportsData = ApiServices.ReportService.Instance.SearchLossRatioReports(reportSearchModel);

                var count = reportsData.Count;
                var listSerialized = new
                {
                    draw = draw,
                    recordsFiltered = count,
                    recordsTotal = count,
                    data = reportsData
                };
                return Json(listSerialized, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult ServiceProviderExcel(ReportSearchModel reportSearchModel)
        {
            var reportsData = ApiServices.ReportService.Instance.GetServiceProviderReportsByFilters(reportSearchModel);
            var templist = reportsData;
            var groupdata = reportsData.GroupBy(c => new { c.InsuredName, c.Provider }).Select(gcs => new ConsolidatedData()
            {
                InsuredName = gcs.Key.InsuredName,
                Provider = gcs.Key.Provider,
                TotalPrice = gcs.Sum(x => x.price),
                TotatSharedAmount = gcs.Sum(x => x.Coshareamount),
                TotatInsured = gcs.Sum(x => x.Insured)
            }).ToList();


            decimal totalPrice = reportsData.Sum(x => x.price);
            decimal totalSharedAmount = reportsData.Sum(x => x.Coshareamount);
            decimal totalInsured = reportsData.Sum(x => x.Insured);


            DataTable dt = new DataTable();
            dt.TableName = "ProviderReport";

           //dt.Columns.Add("SearchProvider", typeof(string));
            dt.Columns.Add("ClaimNumber", typeof(string));
            dt.Columns.Add("InsuredName", typeof(string));
            dt.Columns.Add("Provider", typeof(string));
            dt.Columns.Add("Visittype", typeof(string));
            dt.Columns.Add("VisitDate", typeof(string));
            dt.Columns.Add("PaymentInfo", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("LastModified", typeof(string));
            dt.Columns.Add("ProviderNotes", typeof(string));
            dt.Columns.Add("AuditorNotes", typeof(string));
            dt.Columns.Add("ServiceName", typeof(string));
            dt.Columns.Add("ServiceType", typeof(string));
            dt.Columns.Add("Servicesubtype", typeof(string));
            dt.Columns.Add("Coshareamount", typeof(decimal));
            dt.Columns.Add("price", typeof(decimal));
            dt.Columns.Add("Insured", typeof(decimal));
            dt.Columns.Add("CoShareType", typeof(string));
            dt.Columns.Add("CoShare", typeof(string));
            dt.Columns.Add("ServiceStatus", typeof(string));
            dt.Columns.Add("Symptoms", typeof(string));
            dt.Columns.Add("InsuranceCompany", typeof(string));
            dt.Columns.Add("PolicyNumber", typeof(string));
            dt.Columns.Add("SubPolicy", typeof(string));
            dt.Columns.Add("PaymentStatus", typeof(string));
            dt.Columns.Add("DOB", typeof(string));
            dt.Columns.Add("VisitorName", typeof(string));
            dt.Columns.Add("PaymentLastmodifiedby", typeof(string));

            foreach (var grp in groupdata)
            {
                templist = reportsData.Where(x => x.InsuredName == grp.InsuredName && x.Provider == grp.Provider).ToList();

                foreach (var item in templist)
                {
                    DataRow row = dt.NewRow();
                    //row["SearchProvider"] = item.SearchProvider;
                    row["ClaimNumber"] = item.ClaimNumber;
                    row["InsuredName"] = item.InsuredName;
                    row["Provider"] = item.Provider;
                    row["Visittype"] = item.Visittype;
                    row["VisitDate"] = item.VisitDate;
                    row["PaymentInfo"] = item.PaymentInfo;
                    row["Status"] = item.Status;
                    row["LastModified"] = item.LastModified;
                    row["ProviderNotes"] = item.ProviderNotes;
                    row["AuditorNotes"] = item.AuditorNotes;
                    row["ServiceName"] = item.ServiceName;
                    row["ServiceType"] = item.ServiceType;
                    row["Servicesubtype"] = item.Servicesubtype;
                    row["Coshareamount"] = item.Coshareamount;
                    row["Insured"] = item.Insured;
                    row["price"] = item.price;
                    row["CoShare"] = item.CoShare;
                    row["CoShareType"] = item.CoShareType;
                    row["ServiceStatus"] = item.ServiceStatus;
                    row["Symptoms"] = String.IsNullOrEmpty(item.Symptoms) ? "": item.Symptoms.Trim();
                    row["InsuranceCompany"] = item.InsuranceCompany;
                    row["PolicyNumber"] = item.PolicyNumber;
                    row["SubPolicy"] = item.SubPolicy;
                    row["PaymentStatus"] = item.PaymentStatus;
                    row["PaymentLastmodifiedby"] = item.PaymentLastmodifiedby;
                    dt.Rows.Add(row);
                }
                DataRow rowgrp = dt.NewRow();

                //rowgrp["SearchProvider"] = "";
                rowgrp["ClaimNumber"] = "";
                rowgrp["InsuredName"] = "";
                rowgrp["Provider"] = "";
                rowgrp["Visittype"] = "";
                rowgrp["VisitDate"] = "";
                rowgrp["PaymentInfo"] = "";
                rowgrp["Status"] = "";
                rowgrp["LastModified"] = "";
                rowgrp["ProviderNotes"] = "";
                rowgrp["AuditorNotes"] = "";
                rowgrp["ServiceName"] = "";
                rowgrp["ServiceType"] = "";
                rowgrp["Servicesubtype"] = "Total Calculations: ";
                rowgrp["price"] = grp.TotalPrice;
                rowgrp["Coshareamount"] = grp.TotatSharedAmount;
                rowgrp["Insured"] = grp.TotatInsured;
                rowgrp["CoShare"] = "";
                rowgrp["CoShareType"] = "";
                rowgrp["ServiceStatus"] = "";
                rowgrp["Symptoms"] = "";
                rowgrp["InsuranceCompany"] = "";
                rowgrp["PolicyNumber"] = "";
                rowgrp["SubPolicy"] = "";
                rowgrp["PaymentStatus"] = "";
                rowgrp["PaymentLastmodifiedby"] = "";
                dt.Rows.Add(rowgrp);
                dt.Rows.Add();

            }
            dt.Rows.Add();

            DataRow rowTotal = dt.NewRow();
            rowTotal["InsuredName"] = "Total Claim: " + groupdata.Count;
            rowTotal["Provider"] = "Total Price: " + totalPrice;
            rowTotal["PaymentInfo"] = "Total Co-Share: " + totalSharedAmount;
            rowTotal["ServiceName"] = "Total Insured: " + totalInsured;
            dt.Rows.Add(rowTotal);

            string filename = "Provider.xlsx";

            using (XLWorkbook wb = new XLWorkbook())
            {
                var worksheet = wb.Worksheets.Add(dt);
                wb.Worksheets.First().Columns().AdjustToContents();
                worksheet.Tables.FirstOrDefault().Theme = XLTableTheme.None;
                worksheet.Tables.FirstOrDefault().Style.Font.FontColor = XLColor.Black;

                foreach (IXLRangeRow row in worksheet.Tables.FirstOrDefault().RowsUsed())
                {
                    foreach (IXLCell cell in row.Cells())
                    {
                        if (Convert.ToString(cell.Value).Contains("Total Calculations") || Convert.ToString(cell.Value).Contains("Total Claim"))
                        {
                            row.Style.Font.Bold = true;
                        }
                    }
                    row.Style.Alignment.WrapText = true;
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformat-officedocument.spreadsheetml.sheet", filename);
                }

            }


        }

        [HttpPost]
        public ActionResult PaymentExcel(ReportSearchModel reportSearchModel)
        {
            var reportsData = ApiServices.ReportService.Instance.SearchPaymentReports(reportSearchModel);
            var templist = reportsData;
            var groupdata = reportsData.GroupBy(c => new { c.InsuredName, c.Provider }).Select(gcs => new ConsolidatedData()
            {
                InsuredName = gcs.Key.InsuredName,
                Provider = gcs.Key.Provider,
                // TotalPrice = gcs.Sum(x => x.price),
                TotatSharedAmount = gcs.Sum(x => x.Coshareamount),
                TotatInsured = gcs.Sum(x => x.Insured)
            }).ToList();


            decimal totalPrice = reportsData.Sum(x => x.Price);
            decimal totalSharedAmount = reportsData.Sum(x => x.Coshareamount);
            decimal totalInsured = reportsData.Sum(x => x.Insured);


            DataTable dt = new DataTable();
            dt.TableName = "ProviderReport";

            //dt.Columns.Add("SearchProvider", typeof(string));
            dt.Columns.Add("ClaimNumber", typeof(string));
            dt.Columns.Add("InsuredName", typeof(string));
            dt.Columns.Add("Provider", typeof(string));
            dt.Columns.Add("Visittype", typeof(string));
            dt.Columns.Add("VisitDate", typeof(string));
            dt.Columns.Add("PaymentInfo", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("LastModified", typeof(string));
            dt.Columns.Add("ProviderNotes", typeof(string));
            dt.Columns.Add("AuditorNotes", typeof(string));
            dt.Columns.Add("ServiceName", typeof(string));
            dt.Columns.Add("ServiceType", typeof(string));
            dt.Columns.Add("Servicesubtype", typeof(string));
            dt.Columns.Add("Coshareamount", typeof(decimal));
            dt.Columns.Add("price", typeof(decimal));
            dt.Columns.Add("Insured", typeof(decimal));
            dt.Columns.Add("CoShareType", typeof(string));
            dt.Columns.Add("CoShare", typeof(string));
            dt.Columns.Add("ServiceStatus", typeof(string));
            dt.Columns.Add("Symptoms", typeof(string));
            dt.Columns.Add("InsuranceCompany", typeof(string));
            dt.Columns.Add("PolicyNumber", typeof(string));
            dt.Columns.Add("SubPolicy", typeof(string));
            dt.Columns.Add("PaymentStatus", typeof(string));
            dt.Columns.Add("DOB", typeof(string));
            dt.Columns.Add("VisitorName", typeof(string));
            dt.Columns.Add("PaymentLastmodifiedby", typeof(string));
            dt.Columns.Add("PaymentDetails", typeof(string));
            dt.Columns.Add("PaymentLastmodifiedDate", typeof(string));
            dt.Columns.Add("PaymentReference", typeof(string));



            foreach (var grp in groupdata)
            {
                templist = reportsData.Where(x => x.InsuredName == grp.InsuredName && x.Provider == grp.Provider).ToList();

                foreach (var item in templist)
                {
                    DataRow row = dt.NewRow();
                    //row["SearchProvider"] = item.SearchProvider;
                    row["ClaimNumber"] = item.ClaimNumber;
                    row["InsuredName"] = item.InsuredName;
                    row["Provider"] = item.Provider;
                    row["Visittype"] = item.Visittype;
                    row["VisitDate"] = item.VisitDate;
                    row["PaymentInfo"] = item.PaymentInfo;
                    row["Status"] = item.Status;
                    row["LastModified"] = item.LastModified;
                    row["ProviderNotes"] = item.ProviderNotes;
                    row["AuditorNotes"] = item.AuditorNotes;
                    row["ServiceName"] = item.ServiceName;
                    row["ServiceType"] = item.ServiceType;
                    row["Servicesubtype"] = item.Servicesubtype;
                    row["Coshareamount"] = item.Coshareamount;
                    row["Insured"] = item.Insured;
                    row["price"] = item.Price;
                    row["CoShare"] = item.CoShare;
                    row["CoShareType"] = item.CoShareType;
                    row["ServiceStatus"] = item.ServiceStatus;
                    row["Symptoms"] = String.IsNullOrEmpty(item.Symptoms) ? "" : item.Symptoms.Trim();
                    row["InsuranceCompany"] = item.InsuranceCompany;
                    row["PolicyNumber"] = item.PolicyNumber;
                    row["SubPolicy"] = item.SubPolicy;
                    row["PaymentStatus"] = item.PaymentStatus;
                    row["PaymentLastmodifiedby"] = item.PaymentLastmodifiedby;

                    row["PaymentDetails"] = item.PaymentDetails;
                    row["PaymentLastmodifiedDate"] = item.PaymentLastmodifiedDate;
                    row["PaymentReference"] = item.PaymentReference;
                    dt.Rows.Add(row);
                }
                DataRow rowgrp = dt.NewRow();

                //rowgrp["SearchProvider"] = "";
                rowgrp["ClaimNumber"] = "";
                rowgrp["InsuredName"] = "";
                rowgrp["Provider"] = "";
                rowgrp["Visittype"] = "";
                rowgrp["VisitDate"] = "";
                rowgrp["PaymentInfo"] = "";
                rowgrp["Status"] = "";
                rowgrp["LastModified"] = "";
                rowgrp["ProviderNotes"] = "";
                rowgrp["AuditorNotes"] = "";
                rowgrp["ServiceName"] = "";
                rowgrp["ServiceType"] = "";
                rowgrp["Servicesubtype"] = "Total Calculations: ";
                rowgrp["price"] = grp.TotalPrice;
                rowgrp["Coshareamount"] = grp.TotatSharedAmount;
                rowgrp["Insured"] = grp.TotatInsured;
                rowgrp["CoShare"] = "";
                rowgrp["CoShareType"] = "";
                rowgrp["ServiceStatus"] = "";
                rowgrp["Symptoms"] = "";
                rowgrp["InsuranceCompany"] = "";
                rowgrp["PolicyNumber"] = "";
                rowgrp["SubPolicy"] = "";
                rowgrp["PaymentStatus"] = "";
                rowgrp["PaymentLastmodifiedby"] = "";

                rowgrp["PaymentDetails"] = "";
                rowgrp["PaymentLastmodifiedDate"] = "";
                rowgrp["PaymentReference"] = "";

                dt.Rows.Add(rowgrp);
                dt.Rows.Add();

            }
            dt.Rows.Add();

            DataRow rowTotal = dt.NewRow();
            rowTotal["InsuredName"] = "Total Claim: " + groupdata.Count;
            rowTotal["Provider"] = "Total Price: " + totalPrice;
            rowTotal["PaymentInfo"] = "Total Co-Share: " + totalSharedAmount;
            rowTotal["ServiceName"] = "Total Insured: " + totalInsured;
            dt.Rows.Add(rowTotal);

            string filename = "Payment.xlsx";

            using (XLWorkbook wb = new XLWorkbook())
            {
                var worksheet = wb.Worksheets.Add(dt);
                wb.Worksheets.First().Columns().AdjustToContents();
                worksheet.Tables.FirstOrDefault().ShowAutoFilter = false;
                worksheet.Tables.FirstOrDefault().Theme = XLTableTheme.None;
                worksheet.Tables.FirstOrDefault().Style.Font.FontColor = XLColor.Black;

                foreach (IXLRangeRow row in worksheet.Tables.FirstOrDefault().RowsUsed())
                {
                    foreach (IXLCell cell in row.Cells())
                    {
                        if (Convert.ToString(cell.Value).Contains("Total Calculations")|| Convert.ToString(cell.Value).Contains("Total Claim"))
                        {
                            row.Style.Font.Bold = true;
                        }
                    }
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformat-officedocument.spreadsheetml.sheet", filename);
                }

            }


        }

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase excelFile)
        {
            if (excelFile != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(excelFile.FileName));
                excelFile.SaveAs(path);
                DataTable dt = new DataTable();
                List<ProviderExcelModel> providerExcelModel = new List<ProviderExcelModel>();
                ProviderExcelModel model;

                using (XLWorkbook wb = new XLWorkbook(path))
                {
                    IXLWorksheet worksheet = wb.Worksheet(1);
                    bool isFound = false;
                    bool firstRow = true;
                    string readRange = "1:1";
                    foreach (IXLRow row in worksheet.RowsUsed())
                    {

                        if (firstRow)
                        {
                            readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                if (Convert.ToString(cell.Value) == "Claim Number" || isFound)
                                {
                                    dt.Columns.Add(Convert.ToString(cell.Value));
                                    isFound = true;
                                    firstRow = false;
                                }
                            }

                        }
                        else
                        {
                            dt.Rows.Add();
                            //int cellIndex = 0;
                            //foreach (IXLCell cell in row.Cells())
                            //{
                            //    dt.Rows[dt.Rows.Count - 1][cellIndex] = Convert.ToString(cell.Value);
                            //    cellIndex++;
                            //}
                            var cells = row.Cells().ToArray();
                            model = new ProviderExcelModel();
                            model.ClaimNumber = "";

                            model.InsuredName = Convert.ToString(cells[1].Value);
                            model.PolicyCode = Convert.ToString(cells[2].Value);
                            model.Provider = Convert.ToString(cells[3].Value);
                            model.Visittype = Convert.ToString(cells[4].Value);
                            model.VisitDate = Convert.ToString(cells[5].Value);
                            model.Status = Convert.ToString(cells[6].Value);
                            model.PaymentInfo = Convert.ToString(cells[7].Value);
                            model.LastModified = Convert.ToString(cells[8].Value);
                            model.ProviderNotes = Convert.ToString(cells[9].Value);
                            model.AuditorNotes = Convert.ToString(cells[10].Value);
                            model.ServiceName = Convert.ToString(cells[11].Value);
                            model.ServiceType = Convert.ToString(cells[12].Value);
                            model.Servicesubtype = Convert.ToString(cells[13].Value);
                            model.Price = Convert.ToString(cells[14].Value);
                            model.Coshareamount = Convert.ToString(cells[15].Value);
                            model.Insured = Convert.ToString(cells[16].Value);
                            model.CoShareType = Convert.ToString(cells[17].Value);
                            model.CoShare = Convert.ToString(cells[18].Value);
                            model.ServiceStatus = Convert.ToString(cells[19].Value);
                            model.Symptoms = Convert.ToString(cells[20].Value);
                            model.InsuranceCompany = Convert.ToString(cells[21].Value);
                            model.InsuredCompany = Convert.ToString(cells[22].Value);
                            model.PolicyNumber = Convert.ToString(cells[23].Value);
                            model.SubPolicy = Convert.ToString(cells[24].Value);
                            model.PaymentStatus = Convert.ToString(cells[25].Value);
                            model.PaymentDate = Convert.ToString(cells[26].Value);
                            model.PaymentDetails = Convert.ToString(cells[27].Value);

                            model.PaymentLastModifiedBy = Convert.ToString(cells[28].Value);
                            model.PaymentLastModifiedDate = Convert.ToString(cells[29].Value);
                            model.PaymentReference = Convert.ToString(cells[30].Value);
                            providerExcelModel.Add(model);
                        }

                    }
                }

                providerExcelModel = providerExcelModel.Where(x => x.InsuredName != "" && !x.InsuredName.Contains("Total")).ToList();

                //DataTable dtInsert = dt.AsEnumerable().Where(x => x.Field<string>("Claim Number") != ""&& !x.Field<string>("Claim Number").Contains("Total")).CopyToDataTable();

                var groupdata = providerExcelModel.GroupBy(c => new { c.PolicyCode }).Select(gcs => new ConsolidatedData()
                {

                    PolicyCode = gcs.Key.PolicyCode,
                    // TotalPrice = gcs.Sum(x => x.price),
                }).ToList();

                foreach (var item in groupdata)
                {
                    string number = ClaimsController.GenerateUniqueNumber("CL");
                    providerExcelModel.Where(w => w.PolicyCode == item.PolicyCode).ToList().ForEach(s => s.ClaimNumber = number);

                    List<ProviderExcelModel> rowsInsert = providerExcelModel.Where(x => x.PolicyCode == item.PolicyCode).ToList();
                    foreach (var rowInsert in rowsInsert)
                    {
                        ApiServices.ReportService.Instance.UpdateProviderExcel(rowInsert);
                    }
                }

                ViewBag.Message = "Excel Successfully Uploaded!";
            }
            else
            {
                ViewBag.Message = "Please select file";
            }
            return View("UploadFile");
        }

    }
    public class ConsolidatedData
    {
        public string InsuredName { get; set; }
        public string Provider { get; set; }
        public string PolicyCode { get; set; }
        public decimal TotalPrice { get; set; }

        public decimal TotatSharedAmount { get; set; }
        public decimal TotatInsured { get; set; }

    }
}