using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDAL.Models;

namespace OrderDAL.Data
{
    public class OrderDALContext : DbContext
    {
        public OrderDALContext() 
        {
        }
        public OrderDALContext(DbContextOptions<OrderDALContext> options)
            : base(options) 
        { 
           
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
