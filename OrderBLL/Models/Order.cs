using System;

namespace OrderBLL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? Pickup { get; set; }
        public bool Complete { get; set; }
        public bool picked { get; set; }
    }
}