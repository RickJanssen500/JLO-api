using Microsoft.EntityFrameworkCore;
using OrderLogic;
using OrderDAL.Data;
using OrderDAL.Models;
using System;
using System.Linq;
using Xunit;

namespace TestProject
{
    public class OrderInfoTest
    {
        [Fact]
        public void GetOrderID_NotCompleted()
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderDALContext>()
                .UseInMemoryDatabase(databaseName: "GetOrderID_NotCompleted")
                .Options;
            var context = new OrderDALContext(options);
            Order o1 = new();
            o1.Complete = false;
            o1.UserId = 1;
            context.Orders.Add(o1);
            context.SaveChanges();
            OrderInfo orderInfo = new(context);

            // act
            int id = orderInfo.GetOrderID(1);


            // asssert
            Assert.Equal(1, id);
        }

        [Fact]
        public void GetOrderID_Completed()
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderDALContext>()
                .UseInMemoryDatabase(databaseName: "GetOrderID_Completed")
                .Options;
            var context = new OrderDALContext(options);
            Order o1 = new();
            o1.Complete = true;
            o1.UserId = 1;
            context.Orders.Add(o1);
            context.SaveChanges();
            OrderInfo orderInfo = new(context);

            // act
            int id = orderInfo.GetOrderID(1);


            // asssert
            Assert.Equal(2, id);
        }

        [Fact]
        public void CompleteOrder_Succes()
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderDALContext>()
                .UseInMemoryDatabase(databaseName: "CompleteOrder_Succes")
                .Options;
            var context = new OrderDALContext(options);
            Order o1 = new();
            o1.Complete = false;
            o1.UserId = 2;
            context.Orders.Add(o1);
            context.SaveChanges();
            OrderInfo orderInfo = new(context);
            DateTime date = new();
            date = DateTime.Now;

            // act
            bool check = orderInfo.CompleteOrder(2, date);
            Order o2 = context.Orders.FirstOrDefault(item => item.Id == 1);


            // asssert
            Assert.True(check);
            Assert.Equal(date, o2.Pickup);
            Assert.True(o2.Complete);
        }
    }
}
