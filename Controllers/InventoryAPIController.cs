using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using ShopBridge.DAL;
//using ShopBridge.DAL.Models;
using ShopBridge.Entities.Models;
using ShopBridge.Entities;
using System.Net;

namespace ShopBridge.WebAPI.Controllers
{
    /*[Route("api/[controller]")]
    [ApiController]*/
   /* public class InventoryAPIController : Controller
    {
        private ShopBridgeRepo repo;

        public InventoryAPIController()
        {
            repo = new ShopBridgeRepo();
        }
        [HttpGet]
           public JsonResult getProduct()
           {
               List<Product> prodList = new List<Product>();
               try {
                   prodList = repo.getProduct();
               }
               catch(Exception ex)
               {
                   prodList = null;
               // Console.WriteLine(ex);
               }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound,ex);
            return Json(prodList);
           }

        [HttpPost]
        public JsonResult addProduct(string prodName, string prodDesc,decimal price,int quant)
        { 
            Guid id;
            string msg;
            try
            {
                bool status = repo.AddProduct(prodName, price, prodDesc, quant, out id);
                if (status)
                {
                    msg = "Product added successfully with product id :{0}" + id;

                }
                else
                {
                    msg = "Unsuccessfull operation";
                }
            }
            catch(Exception ex)
            {
                msg = "Some error occured" + ex;
            }
            return Json(msg);
        }

        *//* [HttpDelete]
         public void deleteProduct() { 
         }
        *//*
        [HttpPut]
        public bool UpdateProductByAPIModels(Product product)
        {
            bool status = false;

            try
            {

                Product prodObj = new Product();
                prodObj.Id = product.Id;
                prodObj.Name = product.Name;
                
                prodObj.Price = product.Price;
                prodObj.QuantityAvail = product.QuantityAvail;
                status = repo.UpdateProduct(prodObj);
            }

            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

    }*/


}
    

