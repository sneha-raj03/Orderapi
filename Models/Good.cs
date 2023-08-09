using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Good
    {
        public Good()
        {
            Carts = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
