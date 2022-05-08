using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderBLL;
using OrderBLL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        [HttpGet("itemcount/{id}")]
        public ActionResult<int> Get(int id)
        {
            Cart cart = new();
            return Ok(cart.ItemCount(id));
        }

        [HttpGet("getcart/{id}")]
        public ActionResult<IEnumerable<OrderProduct>> GetCart(int id)
        {
            Cart cart = new();
            return Ok(cart.GetCart(id));
        }


        [HttpPost("Add")]
        public ActionResult Add(int Uid, int Pid, int Amount)
        {
            Cart cart = new();
            bool check = cart.AddToCart(Uid,Pid,Amount);
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
        public ActionResult Complete(int Uid, DateTime date)
        {
            OrderInfo order = new();
            bool check = order.CompleteOrder(Uid, date);
            if (check)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("Del")]
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
