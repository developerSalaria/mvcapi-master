using TPA.Common.Core.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TPA.Data.DAL.Repositories
{
    public class CustomerRepository : BaseRepository
    {
        public List<Customer> Get()
        {
            return QueryExecutor.Query<Customer>(StoreProcedures.sp_Customer_Get.ToString(), null, CommandType.StoredProcedure).ToList();
        }

        public CustomerViewModel CustomerDataTable(Customer c)
        {
            var model = new CustomerViewModel();
            var obj = new { SearchText = c.SearchModel.sSearch, SortColumn = c.SearchModel.iSortCol_0, SortDirection = c.SearchModel.sSortDir_0, DisplayLength = c.SearchModel.iDisplayLength, DisplayStart = c.SearchModel.iDisplayStart };
            model.CustomerList = QueryExecutor.Query<Customer>(StoreProcedures.sp_Customer_Search_Grid.ToString(), obj, CommandType.StoredProcedure).ToList();
            
            if (model.CustomerList.Count>0)
            {
                model.TotalDisplayRecords = model.CustomerList.ToList().FirstOrDefault().TotalCount;
            }
            model.TotalRecords = TotalCountOfTable("Customer");

            return model;
        }

        public Customer GetById(int CustomerId)
        {
            var Customer = QueryExecutor.Query<Customer>(StoreProcedures.sp_Customer_Get.ToString(), new { CustomerId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
            if (Customer != null)
            {
                Customer.CustomerDocument = new CustomerDocumentRepository().GetByCustomerId(CustomerId);
                if (Customer.CustomerDocument == null)
                {
                    Customer.CustomerDocument = new CustomerDocument();
                }
            }
            return Customer;
        }

        public int DeleteById(int CustomerId)
        {
            return QueryExecutor.Execute(StoreProcedures.sp_Customer_Delete.ToString(), new { CustomerId }, CommandType.StoredProcedure);
        }

        public int Update(Customer obj)
        {
          var effectedRows =  QueryExecutor.Execute(StoreProcedures.sp_Customer_Update.ToString(), new {
                obj.CustomerId,
                obj.CountryId,
                obj.CityId,
                obj.NationalityId,
                obj.CustomerTypeId,
                obj.CustomerClassId,
                obj.GenderId,
                obj.CurrencyId,
                obj.CustomerNameA,
                obj.CustomerNameE,
                obj.AddressArb,
                obj.AddressEng,
                obj.Phone,
                obj.Email,
                obj.Occupation,
                obj.AnotherPhone,
                obj.Street,
                obj.Suburb,
                obj.PostCode,
                obj.State,
                obj.BirthDate,
                obj.UpdatedBy,
                obj.UpdatedOn
            });

            if (obj.CustomerDocument != null && obj.CustomerDocument.DocumentTypeId > 0)
            {
                obj.CustomerDocument.CustomerId = Convert.ToInt32(obj.CustomerId);
                new CustomerDocumentRepository().Update(obj.CustomerDocument);
            }

            return effectedRows;
        }

        public int Insert(Customer obj)
        {
            var Id = QueryExecutor.ExecuteScalar(StoreProcedures.sp_Customer_Insert.ToString(), new {
                obj.CountryId,
                obj.CityId,
                obj.NationalityId,
                obj.CustomerTypeId,
                obj.CustomerClassId,
                obj.GenderId,
                obj.CurrencyId,
                obj.CustomerNameA,
                obj.CustomerNameE,
                obj.AddressArb,
                obj.AddressEng,
                obj.Phone,
                obj.Email,
                obj.Occupation,
                obj.AnotherPhone,
                obj.Street,
                obj.Suburb,
                obj.PostCode,
                obj.State,
                obj.BirthDate,
                obj.CreatedOn,
                obj.CreatedBy
            });

            if (obj.CustomerDocument != null && obj.CustomerDocument.DocumentTypeId > 0)
            {
                obj.CustomerDocument.CustomerId = Convert.ToInt32(Id);
                new CustomerDocumentRepository().Insert(obj.CustomerDocument);
            }
            return 1;
        }
    }
}
