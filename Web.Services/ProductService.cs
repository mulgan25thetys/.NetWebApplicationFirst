using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain;
using Web.Data.Infrastructures;

namespace Web.Services
{
    public class ProductService : IProductService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IRepository<Product> _productsRepository;
        public ProductService(IUnitOfWork unitOf) {
            this._unitOfWork = unitOf;
            this._productsRepository   = this._unitOfWork.GetRepository<Product>();
        }

        public Product AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
