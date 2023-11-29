using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain;

namespace Web.Services
{
    public interface IProductService
    {
        public Product AddProduct(Product product);
        public Product UpdateProduct(Product product);
        public Product DeleteProduct(int id);
        public Product GetProduct(int productId);
        public List<Product> GetAllProducts();  
    }
}
