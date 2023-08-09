using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            Carts = new HashSet<Cart>();
        }
        public OrderDetail(int orderId, int productId, int  dealerId, DateTime orderDate, int quantity, string status)
        {
            OrderId = orderId;
            ProductId = productId;
            DealerId = dealerId;
            OrderDate = orderDate;
            Quantity = quantity;
            Status = status;
          
        }

        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? DealerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? Quantity { get; set; }
        public string? Status { get; set; }

        public virtual Dealer? Dealer { get; set; }
        public virtual Good? Product { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
