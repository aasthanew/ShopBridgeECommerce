using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.WebAPI
{
   public class Inventory
    {   
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Description { get; set; }

        [Range(1, 10000000)]
        public decimal Price { get; set; }

        [Range(1, 1000)]
        public int QuantityAvail { get; set; }

        public static explicit operator Task<object>(Inventory v)
        {
            throw new NotImplementedException();
        }
    }
}
