using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Controllers;
using OrderDAL.Data;
using OrderDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestProject
{
    public class EndpointTest
    {
        [Fact]
        public void GetAll_Succes()
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderDALContext>()
                .UseInMemoryDatabase(databaseName: "GetAll_Succes_End")
                .Options;
            var context = new OrderDALContext(options);
            Product p1 = new();
            p1.Name = "test";
            Product p2 = new();
            p2.Name = "nem";
            context.Products.Add(p1);
            context.Products.Add(p2);
            context.SaveChanges();
            ProductController productController = new();
            productController.products = new(context);

            // act
            ActionResult<IEnumerable<Product>> action = productController.Get();

            // asssert
            var result = action.Result as OkObjectResult;
            IEnumerable<Product> list = (IEnumerable<Product>)result.Value;
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(2, list.Count());

        }

        [Fact]
        public void GetByID_Succes() 
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderDALContext>()
                .UseInMemoryDatabase(databaseName: "GetByID_Succes_End")
                .Options;
            var context = new OrderDALContext(options);
            Product p1 = new();
            p1.Name = "test";
            Product p2 = new();
            p2.Name = "nem";
            context.Products.Add(p1);
            context.Products.Add(p2);
            context.SaveChanges();


            // act



            // asssert
            Assert.True(true);
            
        }

        [Fact]
        public void GetByID_Failed()
        {
            // arrange
            var options = new DbContextOptionsBuilder<OrderDALContext>()
                .UseInMemoryDatabase(databaseName: "GetByID_Failed_End")
                .Options;
            var context = new OrderDALContext(options);
            Product p1 = new();
            p1.Name = "test";
            Product p2 = new();
            p2.Name = "nem";
            context.Products.Add(p1);
            context.Products.Add(p2);
            context.SaveChanges();


            // act



            // asssert
            Assert.True(true);
        }

        [Fact]
        public void ItemCount_Succes()
        {
            // arrange
            
            


            // act



            // asssert
            Assert.True(true);
        }

        [Fact]
        public void GetCart_Succes()
        {
            // arrange




            // act



            // asssert
            Assert.True(true);
        }

        [Fact]
        public void Add_Succes()
        {
            // arrange




            // act



            // asssert
            Assert.True(true);
        }

        [Fact]
        public void CompleteOrder_Succes()
        {
            // arrange




            // act



            // asssert
            Assert.True(true);
        }

        [Fact]
        public void Delete_Succes()
        {
            // arrange




            // act



            // asssert
            Assert.True(true);
        }
    }
}
