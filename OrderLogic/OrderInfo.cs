using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDAL.Models;
using OrderDAL.Data;

namespace OrderLogic
{
    public class OrderInfo
    {
        OrderDALContext context;
        public OrderInfo()
        {
            context = new(ConfigureSQL.Options);
        }

        public OrderInfo(OrderDALContext inputcontext)
        {
            context = inputcontext;
        }

        public int GetOrderID(int ID)
        {
            List<Order> orders = context.Orders.Where(p => p.UserId == ID).ToList();
            foreach (var order in orders)
            {
                if (order.Complete == false)
                {
                    return order.Id;
                }
            }
            return nwo(ID);

        }

        public bool CompleteOrder(int id, DateTime date) 
        {
            
            int orderid = GetOrderID(id);
            Order order = context.Orders.FirstOrDefault(item => item.Id == orderid);
            order.Complete = true;
            order.Pickup = date;
            context.SaveChanges();
            return true;
        }

        private int nwo(int ID) 
        {
            Order neworder = new();
            neworder.UserId = ID;
            neworder.Complete = false;
            neworder.picked = false;
            neworder.Date = DateTime.Now;
            context.Orders.Add(neworder);
            context.SaveChanges();
            return neworder.Id;
        }
    }
}