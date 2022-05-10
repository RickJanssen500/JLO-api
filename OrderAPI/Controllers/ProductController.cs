using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderLogic;
using OrderDAL.Models;
using Microsoft.AspNetCore.Cors;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        
        [HttpGet("get")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            Products products = new();
            return Ok(products.GetAll());
        }

        
        [HttpGet("getone")]
        public ActionResult<Product> Get(int id)
        {
            Products products = new();
            Product product = products.GetProduct(id);
            if (product == null)
            {
                return NotFound("no product with id : " + id);
            }
            else 
            {
                return Ok(product);
            }
        }

    }
}
