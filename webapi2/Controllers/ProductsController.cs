using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi2.Models;

namespace webapi2.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        List<Product> products = new List<Product>()
        {
            new Product
            {
                Id =  1,
                Name = "Austin",
                Description = "English Car",
                Price = 10000
            },
            new Product
            {
                Id =  2,
                Name = "Audi",
                Description = "german Car",
                Price = 20000
            },
            new Product
            {
                Id =  3,
                Name = "Fiat",
                Description = "Italian Car",
                Price = 13000
            },
             new Product
            {
                Id =  4,
                Name = "Citroen",
                Description = "French Car",
                Price = 14000
            },
        };
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = products.Find(p => p.Id == id);
            return product;
        }

    }
}
