using Microsoft.EntityFrameworkCore;
using OrderBLL;
using OrderBLL.Data;
using OrderBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestProject
{
    public class CartTest
    {
        [Fact]
        public void ItemCount_Succes()
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderBLLContext>()
                .UseInMemoryDatabase(databaseName: "ItemCount_Succes")
                .Options;
            var context = new OrderBLLContext(options);
            Order o1 = new();
            o1.UserId = 7;
            o1.Complete = false;
            context.Orders.Add(o1);
            Product p1 = new();
            p1.Name = "test";
            Product p2 = new();
            p2.Name = "nem";
            context.Products.Add(p1);
            context.Products.Add(p2);
            OrderProduct op1 = new();
            op1.Amount = 2;
            op1.OrderId = 1;
            op1.product = p1;
            context.OrderProducts.Add(op1);
            OrderProduct op2 = new();
            op2.Amount = 4;
            op2.OrderId = 1;
            op2.product = p2;
            context.OrderProducts.Add(op2);
            context.SaveChanges();
            Cart cart = new(context);

            // act
            int total = cart.ItemCount(7);


            // asssert
            Assert.Equal(2, total);
            
        }

        [Fact]
        public void GetCart_Succes()
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderBLLContext>()
                .UseInMemoryDatabase(databaseName: "GetCart_Succes")
                .Options;
            var context = new OrderBLLContext(options);
            Order o1 = new();
            o1.UserId = 7;
            o1.Complete = false;
            context.Orders.Add(o1);
            Product p1 = new();
            p1.Name = "test";
            Product p2 = new();
            p2.Name = "nem";
            context.Products.Add(p1);
            context.Products.Add(p2);
            OrderProduct op1 = new();
            op1.Amount = 2;
            op1.OrderId = 1;
            op1.product = p1;
            context.OrderProducts.Add(op1);
            OrderProduct op2 = new();
            op2.Amount = 4;
            op2.OrderId = 1;
            op2.product = p2;
            context.OrderProducts.Add(op2);
            context.SaveChanges();
            Cart cart = new(context);

            // act
            IEnumerable<OrderProduct> li = cart.GetCart(7);


            // asssert
            Assert.Equal(2, li.Count());
        }

        [Fact]
        public void AddToCart_Succes()
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderBLLContext>()
                .UseInMemoryDatabase(databaseName: "AddToCart_Succes")
                .Options;
            var context = new OrderBLLContext(options);
            Order o1 = new();
            o1.UserId = 7;
            o1.Complete = false;
            context.Orders.Add(o1);
            Product p1 = new();
            p1.Name = "test";
            Product p2 = new();
            p2.Name = "nem";
            Product p3 = new();
            p3.Name = "toev";
            context.Products.Add(p1);
            context.Products.Add(p2);
            context.Products.Add(p3);
            OrderProduct op1 = new();
            op1.Amount = 2;
            op1.OrderId = 1;
            op1.product = p1;
            context.OrderProducts.Add(op1);
            OrderProduct op2 = new();
            op2.Amount = 4;
            op2.OrderId = 1;
            op2.product = p2;
            context.OrderProducts.Add(op2);
            context.SaveChanges();
            Cart cart = new(context);

            // act
            bool check = cart.AddToCart(7,3,4);


            // asssert
            Assert.True(check);
            Assert.Equal(3,cart.ItemCount(7));

        }

        [Fact]
        public void RemoveFromCart_Succes_1()
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderBLLContext>()
                .UseInMemoryDatabase(databaseName: "RemoveFromCart_Succes_1")
                .Options;
            var context = new OrderBLLContext(options);
            Order o1 = new();
            o1.UserId = 7;
            o1.Complete = false;
            context.Orders.Add(o1);
            Product p1 = new();
            p1.Name = "test";
            Product p2 = new();
            p2.Name = "nem";
            Product p3 = new();
            p3.Name = "toev";
            context.Products.Add(p1);
            context.Products.Add(p2);
            context.Products.Add(p3);
            OrderProduct op1 = new();
            op1.Amount = 2;
            op1.OrderId = 1;
            op1.product = p1;
            context.OrderProducts.Add(op1);
            OrderProduct op2 = new();
            op2.Amount = 4;
            op2.OrderId = 1;
            op2.product = p2;
            context.OrderProducts.Add(op2);
            OrderProduct op3 = new();
            op3.Amount = 1;
            op3.OrderId = 1;
            op3.product = p3;
            context.OrderProducts.Add(op3);
            context.SaveChanges();
            Cart cart = new(context);

            // act
            bool check = cart.RemoveFromCart(7,3);


            // asssert
            Assert.True(check);
            Assert.Equal(2, cart.ItemCount(7));

        }

        [Fact]
        public void RemoveFromCart_Succes_2()
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderBLLContext>()
                .UseInMemoryDatabase(databaseName: "RemoveFromCart_Succes_2")
                .Options;
            var context = new OrderBLLContext(options);
            Order o1 = new();
            o1.UserId = 7;
            o1.Complete = false;
            context.Orders.Add(o1);
            Product p1 = new();
            p1.Name = "test";
            Product p2 = new();
            p2.Name = "nem";
            Product p3 = new();
            p3.Name = "toev";
            context.Products.Add(p1);
            context.Products.Add(p2);
            context.Products.Add(p3);
            OrderProduct op1 = new();
            op1.Amount = 2;
            op1.OrderId = 1;
            op1.product = p1;
            context.OrderProducts.Add(op1);
            OrderProduct op2 = new();
            op2.Amount = 4;
            op2.OrderId = 1;
            op2.product = p2;
            context.OrderProducts.Add(op2);
            OrderProduct op3 = new();
            op3.Amount = 1;
            op3.OrderId = 1;
            op3.product = p3;
            OrderProduct op4 = new();
            op4.Amount = 2;
            op4.OrderId = 1;
            op4.product = p3;
            context.OrderProducts.Add(op3);
            context.OrderProducts.Add(op4);
            context.SaveChanges();
            Cart cart = new(context);

            // act
            bool check = cart.RemoveFromCart(7, 3);


            // asssert
            Assert.True(check);
            Assert.Equal(2, cart.ItemCount(7));

        }

        [Fact]
        public void RemoveFromCart_Succes_DifferentCart()
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderBLLContext>()
                .UseInMemoryDatabase(databaseName: "RemoveFromCart_Succes_DifferentCart")
                .Options;
            var context = new OrderBLLContext(options);
            Order o1 = new();
            o1.UserId = 7;
            o1.Complete = false;
            context.Orders.Add(o1);
            Order o2 = new();
            o2.UserId = 6;
            o2.Complete = false;
            context.Orders.Add(o2);
            Product p1 = new();
            p1.Name = "test";
            Product p2 = new();
            p2.Name = "nem";
            Product p3 = new();
            p3.Name = "toev";
            context.Products.Add(p1);
            context.Products.Add(p2);
            context.Products.Add(p3);
            OrderProduct op1 = new();
            op1.Amount = 2;
            op1.OrderId = 1;
            op1.product = p1;
            context.OrderProducts.Add(op1);
            OrderProduct op2 = new();
            op2.Amount = 4;
            op2.OrderId = 1;
            op2.product = p2;
            context.OrderProducts.Add(op2);
            OrderProduct op3 = new();
            op3.Amount = 1;
            op3.OrderId = 2;
            op3.product = p2;
            OrderProduct op4 = new();
            op4.Amount = 2;
            op4.OrderId = 2;
            op4.product = p3;
            context.OrderProducts.Add(op3);
            context.OrderProducts.Add(op4);
            context.SaveChanges();
            Cart cart = new(context);

            // act
            bool check = cart.RemoveFromCart(7, 2);


            // asssert
            Assert.True(check);
            Assert.Equal(1, cart.ItemCount(7));
            Assert.Equal(2, cart.ItemCount(6));

        }
    }
}
