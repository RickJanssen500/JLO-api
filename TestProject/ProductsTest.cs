using Microsoft.EntityFrameworkCore;
using OrderLogic;
using OrderDAL.Data;
using OrderDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestProject
{
    public class ProductsTest
    {
        [Fact]
        public void GetAll_Succes()
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderDALContext>()
                .UseInMemoryDatabase(databaseName: "GetAll_Succes")
                .Options;
            var context = new OrderDALContext(options);
            Product p1 = new();
            p1.Name = "test";
            Product p2 = new();
            p2.Name = "nem";
            context.Products.Add(p1);
            context.Products.Add(p2);
            context.SaveChanges();
            Products prods = new(context);

            // act
            IEnumerable<Product> list = prods.GetAll();
            list.Count();

            // asssert
            Assert.Equal(2, list.Count());
        }

        [Fact]
        public void GetByID_Succes() 
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderDALContext>()
                .UseInMemoryDatabase(databaseName: "GetByID_Succes")
                .Options;
            var context = new OrderDALContext(options);
            Product p1 = new();
            p1.Name = "test";
            Product p2 = new();
            p2.Name = "nem";
            context.Products.Add(p1);
            context.Products.Add(p2);
            context.SaveChanges();
            Products prods = new(context);

            // act
            Product item = prods.GetProduct(2);
            

            // asssert
            Assert.Equal("nem", item.Name);
        }

        [Fact]
        public void GetByID_Failed()
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderDALContext>()
                .UseInMemoryDatabase(databaseName: "GetByID_Failed")
                .Options;
            var context = new OrderDALContext(options);
            Product p1 = new();
            p1.Name = "test";
            Product p2 = new();
            p2.Name = "nem";
            context.Products.Add(p1);
            context.Products.Add(p2);
            context.SaveChanges();
            Products prods = new(context);

            // act
            Product item = prods.GetProduct(3);


            // asssert
            Assert.Null(item);
        }
    }
}
