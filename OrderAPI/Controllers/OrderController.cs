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
using OrderDAL.Data;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        Cart cart = new();
        OrderInfo order = new();
      

        [HttpGet("itemcount")]
        public ActionResult<int> Get(int id)
        {
            return Ok(cart.ItemCount(id));
        }

        [HttpGet("getcart")]
        public ActionResult<IEnumerable<OrderProduct>> GetCart(int id)
        {
            return Ok(cart.GetCart(id));
        }


        [HttpPost("Add")]
        public ActionResult Add([FromBody] JsonElement payload)
        {
            AddProduct addproduct = JsonConvert.DeserializeObject<AddProduct>(payload.ToString());
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
