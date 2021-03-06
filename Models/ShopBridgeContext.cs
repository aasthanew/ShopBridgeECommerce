using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ShopBridge.WebAPI.Models
{
    public class ShopBridgeContext : DbContext
    {
        public ShopBridgeContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Inventory> Inventory { get; set; }
    }  
}
