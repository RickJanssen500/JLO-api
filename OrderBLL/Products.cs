using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderBLL.Models;
using OrderBLL.Data;

namespace OrderBLL
{
    public class Products
    {
        OrderBLLContext context;
        public Products() 
        {
            context = new(ConfigureSQL.Options);
        }

        public Products(OrderBLLContext inputcontext)
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
