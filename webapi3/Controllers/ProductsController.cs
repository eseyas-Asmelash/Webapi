using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi3.Models;

namespace webapi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
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
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            products.Add(product);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = products.Where(p => p.Id == id);
            products = products.Except(product).ToList();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            var existingProduct = products.Where(p => p.Id == id);
            products = products.Except(existingProduct).ToList();
            products.Add(product);
        }
    }
}
