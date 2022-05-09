using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDAL.Models;
using OrderDAL.Data;

namespace OrderLogic
{
    public class Products
    {
        OrderDALContext context;
        public Products() 
        {
            context = new(ConfigureSQL.Options);
        }

        public Products(OrderDALContext inputcontext)
        {
            context = inputcontext;
        }

        public IEnumerable<Product> GetAll() 
        {
            
            return context.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return context.Products.Where(p => p.Id == id).FirstOrDefault();
                
        }
    }
}
