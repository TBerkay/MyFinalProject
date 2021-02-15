using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{                                                  //ControllerName
    [Route("api/[controller]")] // url deki ../api/Products
    [ApiController] // Attribute  -- // Web api olması için gerekli ApiController, ControllerBase
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public List<Product> Get()
        {
            return new List<Product>
            {
               new Product{ProductId=1, ProductName="Kavun"},
               new Product{ProductId=2, ProductName="Karpuz"}
            };
        }
    }
}
