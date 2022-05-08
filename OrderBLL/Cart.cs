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
        OrderInfo oi;
        Products prod;
        OrderBLLContext context;
        public Cart()
        {
            context = new(ConfigureSQL.Options);
             oi = new();
             prod = new();
        }

        public Cart(OrderBLLContext inputcontext)
        {
            context = inputcontext;
             oi = new(context);
             prod = new(context);
        }

        public int ItemCount(int id)
        {
            int orderid = oi.GetOrderID(id);
            return context.OrderProducts.Where(p => p.OrderId == orderid).ToList().Count();
        }

        public IEnumerable<OrderProduct> GetCart(int id) 
        {
            int orderid = oi.GetOrderID(id);
            return context.OrderProducts.Where(p => p.OrderId == orderid).Include(m => m.product).ToList();
        }

        public bool AddToCart(int id, int prodid,int amount)
        {
            int orderid = oi.GetOrderID(id);
            OrderProduct oproduct = new();
            oproduct.OrderId = orderid;
            oproduct.picked = false;
            oproduct.Amount = amount;
            oproduct.product = prod.GetProduct(prodid);
            context.OrderProducts.Add(oproduct) ;
            context.SaveChanges();
            return true;
        }

        public bool RemoveFromCart(int id, int prodid)
        {
            int orderid = oi.GetOrderID(id);
            Product product = prod.GetProduct(prodid);
            List<OrderProduct> op = context.OrderProducts.Where(d => d.product == product & d.OrderId == orderid).ToList();
            context.OrderProducts.RemoveRange(op);
            context.SaveChanges();
            return true;
        }

    }
}