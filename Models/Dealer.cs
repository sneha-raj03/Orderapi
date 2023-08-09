using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Dealer
    {
        public Dealer()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int DealerId { get; set; }
        public string? DealerName { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
