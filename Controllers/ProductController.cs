using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopBridge.WebAPI.Models;
///using ShopBridge.DAL;
//using ShopBridge.DAL.Models;
//using ShopBridge.Entities;
//using ShopBridge.Entities.Models;


namespace ShopBridge.WebAPI.Controllers
{ //  [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
       // private ShopBridge.UnitTest.Service.IProductServiceTest service1;

        /*public ProductController(ShopBridge.UnitTest.Service.IProductServiceTest service1)
        {
            this.service1 = service1;
        }*/

        

         public ProductController(IProductService service)
         {
    this.service = service;
         }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var lst = await service.GetProducts();
                return Ok(lst);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await service.FindById(id);
            if (item != null)
            {
                return Ok();
            }
            else return NotFound();
        }
        //Add new Product
        [HttpPost]
         public async Task<IActionResult> AddProducts([FromBody]Inventory products)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var isSuccess = await service.AddProduct(products);
                    if (isSuccess == false)
                    {
                        return StatusCode(500, "Something went wrong. Please contact the Administrator");
                    }
                    
                }
                catch (Exception)
                {
                    return BadRequest();
                }
                return Created("GetProducts", new { products });
            }
            return BadRequest();
            
        }
       
        // DELETE: api/Products/5
          [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteProducts(int id)
          {
            bool status = false;
            try
            {
                status = await service.DeleteProduct(id);
                if (status)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }
            
          }

       

        [HttpPut]
        public async Task<IActionResult> PutProducts([FromBody]Inventory products)
           {
            if(ModelState.IsValid)
            {
                try
                {
                    await service.UpdateProduct(products);

                    return Ok();
                }
                catch (Exception)
                {                    
                    return BadRequest();
                }
            }
            return BadRequest();

            
        }

       
    }
}
