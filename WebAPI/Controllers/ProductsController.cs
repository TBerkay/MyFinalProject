using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{                                                  //ControllerName
    [Route("api/[controller]")] // url deki ../api/Products
    [ApiController] // Attribute  -- // Web api olması için gerekli ApiController, ControllerBase
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")] // isim verdik
        public IActionResult GetAll()
        {
           
            var result = _productService.GetAll();
            
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

            //return new List<Product>
            //{
            //   new Product{ProductId=1, ProductName="Kavun"},
            //   new Product{ProductId=2, ProductName="Karpuz"}
            //};
        }

        [HttpGet("getbyid")] // isim verdik
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);

            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
            
        }
    }
}
