using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Product product { get; set; }
        public int Amount { get; set; }
        public bool picked { get; set; }
        public int? PickedAmount { get; set; }
    }
}
