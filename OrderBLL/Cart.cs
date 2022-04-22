using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBLL.Models;
using OrderBLL.Data;
using Microsoft.EntityFrameworkCore;

namespace OrderBLL
{
    public class Cart
    {
        OrderBLLContext context;
        public Cart()
        {
            context = new();
        }

        public int ItemCount(int id)
        {
            OrderInfo oi = new();
            int orderid = oi.GetOrderID(id);
            return context.OrderProducts.Where(p => p.OrderId == orderid).ToList().Count();
        }

        public IEnumerable<OrderProduct> GetCart(int id) 
        {
            OrderInfo oi = new();
            int orderid = oi.GetOrderID(id);
            return context.OrderProducts.Where(p => p.OrderId == orderid).Include(m => m.product).ToList();
        }

  
    }
}