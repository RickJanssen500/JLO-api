using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderLogic;
using OrderDAL.Models;
using Microsoft.AspNetCore.Cors;
using OrderDAL.Data;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public Products products = new();
   



        [HttpGet("get")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(products.GetAll());
        }

        
        [HttpGet("getone")]
        public ActionResult<Product> Get(int id)
        {
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
