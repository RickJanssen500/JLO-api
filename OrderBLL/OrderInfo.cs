﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBLL.Models;
using OrderBLL.Data;

namespace OrderBLL
{
    public class OrderInfo
    {
        OrderBLLContext context;
        public OrderInfo()
        {
            context = new();
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

        private int nwo(int ID) 
        {
            Order neworder = new();
            neworder.UserId = ID;
            neworder.Complete = false;
            neworder.Date = DateTime.Now;
            context.Orders.Add(neworder);
            context.SaveChanges();
            return neworder.Id;
        }
    }
}