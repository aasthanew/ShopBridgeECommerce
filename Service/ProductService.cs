using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopBridge.WebAPI.Models;

namespace ShopBridge.WebAPI.Service
{
    public class ProductService :IProductService
    {
        private readonly ShopBridgeContext db;

        public ProductService(ShopBridgeContext db)
        {
            this.db = db; 
        }

        public ProductService()
        {
        }

        public async Task<bool> AddProduct(Inventory product)
        {
            await db.Inventory.AddAsync(product);
             return await Save();
            
        }

        public async Task<bool> Save()
        {
            var changes = await db.SaveChangesAsync();
            return changes > 0;
            
        }

        public async Task<bool> DeleteProduct(int prodId)
        {
            bool check = await isExists(prodId);
            if (check)
            {
                   var product = await FindById(prodId);
                    db.Inventory.Remove(product);
            }
            else
            {
                return false;
            }
            return await Save();

        }
        public async Task<bool> isExists(int id)
        {
            var isExists = await db.Inventory.AnyAsync(q => q.ProductId == id);
            return isExists;
        }


        public async Task<IList<Inventory>> GetProducts()
        {
            if (db != null) 
            {
                var prod = await db.Inventory.ToListAsync();
                return prod;
            }
            return null; 
            
            
        }

        public async Task UpdateProduct(Inventory product)
        {
            if (db != null)
            {
                db.Inventory.Update(product);
                await Save();
            }
        }
       
        public async Task<Inventory> FindById(int id)
        {
            var prod = await db.Inventory          
                .FirstOrDefaultAsync(q => q.ProductId == id);
            return prod;
        }
    }
}

