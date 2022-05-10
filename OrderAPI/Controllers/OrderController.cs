using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderLogic;
using OrderDAL.Models;
using Newtonsoft.Json;
using OrderAPI.JTO;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        [HttpGet("itemcount")]
        public ActionResult<int> Get(int id)
        {
            Cart cart = new();
            return Ok(cart.ItemCount(id));
        }

        [HttpGet("getcart")]
        public ActionResult<IEnumerable<OrderProduct>> GetCart(int id)
        {
            Cart cart = new();
            return Ok(cart.GetCart(id));
        }


        [HttpPost("Add")]
        public ActionResult Add([FromBody] JsonElement payload)
        {
            AddProduct addproduct = JsonConvert.DeserializeObject<AddProduct>(payload.ToString());
            Cart cart = new();
            bool check = cart.AddToCart(addproduct.Uid,addproduct.Pid,addproduct.Amount);
            if (check)
            {
                return Ok();
            }
            else 
            {
                return BadRequest();
            }
        }

        [HttpPost("CompleteOrder")]
        public ActionResult Complete([FromBody] JsonElement payload)
        {
            Complete complete = JsonConvert.DeserializeObject<Complete>(payload.ToString());
            OrderInfo order = new();
            bool check = order.CompleteOrder(complete.Uid, complete.date);
            if (check)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("Del/{id}/{pid}")]
        public ActionResult Delete(int id, int pid)
        {
            Cart cart = new();
            bool check = cart.RemoveFromCart(id, pid);
            if (check)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
