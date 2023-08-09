using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Cart
    {
        public int Cid { get; set; }
        public int? Pid { get; set; }
        public DateTime? Dateoforder { get; set; }
        public int? Oid { get; set; }

        public virtual OrderDetail? OidNavigation { get; set; }
        public virtual Good? PidNavigation { get; set; }
    }
}
