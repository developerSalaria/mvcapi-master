using TPA.Common.Core.Model;
using TPA.Data.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA.Services.BusinessLogic.Classes
{
    public class ProductBL 
    {
        private ProductRepository _productRepository;
        public ProductBL()
        {
            _productRepository = new ProductRepository();
        }

        public int DeleteById(int productId)
        {
            return _productRepository.DeleteById(productId);
        }

        public List<Product> Get()
        {
            return _productRepository.Get();
        }

        public Product GetById(int productId)
        {
            return _productRepository.GetById(productId);
        }

        public int Insert(Product obj)
        {
            return _productRepository.Insert(obj);
        }

        public int Update(Product obj)
        {
            return _productRepository.Update(obj);
        }
    }
}
