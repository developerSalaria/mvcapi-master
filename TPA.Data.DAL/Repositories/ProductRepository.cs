using TPA.Common.Core.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TPA.Data.DAL.Repositories
{
   public class ProductRepository : BaseRepository
    {
        public List<Product> Get()
        {
            return QueryExecutor.Query<Product>(StoreProcedures.sp_GetAllProduct.ToString(), null, CommandType.StoredProcedure).ToList();
        }

        public Product GetById(int productId)
        {
            return QueryExecutor.Query<Product>(StoreProcedures.spProductById.ToString(), new { productId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }

        public int DeleteById(int productId)
        {
            return QueryExecutor.Execute(StoreProcedures.spProductDelete.ToString(), new { productId }, CommandType.StoredProcedure);
        }

        public int Update(Product obj)
        {
            return QueryExecutor.Execute(StoreProcedures.spProductUpdate.ToString(), new { });
        }

        public int Insert(Product obj)
        {
            return QueryExecutor.Execute(StoreProcedures.spProductInsert.ToString(), new { obj.Name, obj.Price });
        }
    }
}
