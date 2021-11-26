using ShopBridge.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.WebAPI.Models
{
   public interface IProductService
    {
        public Task<IList<Inventory>> GetProducts();
        public Task<bool> AddProduct(Inventory product);
        public Task UpdateProduct(Inventory product);
        public Task<bool> DeleteProduct(int id);
        public Task<bool> Save();
        public Task<bool> isExists(int id);
        public Task<Inventory> FindById(int id);
    }
}
