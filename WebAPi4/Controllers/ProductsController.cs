using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi4.Models;

namespace WebAPi4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
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
        public ActionResult<IEnumerable<Product>> Get()
        {
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
                return NotFound();
            return product;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            if(products.Exists(p => p.Id == product.Id))
            {
                return Conflict();
            }
            products.Add(product);
            return CreatedAtAction(nameof(Get), new { Id = product.Id }, products);
        }
        [HttpPut]
        public ActionResult<IEnumerable<Product>> Put(int id, [FromBody] Product product)
        {
            if(id != product.Id)
            {
                return BadRequest();
            }
            var existingProduct = products.Where(p => p.Id == id);
            products = products.Except(existingProduct).ToList();
            products.Add(product);
            return products;
        }
    }
}
