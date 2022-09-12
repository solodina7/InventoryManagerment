using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagerment.Models.EF
{
    public class RefundForm
    {
        public Refund Refund { get; set; }
        public List<RefundDetail> refundDetails { get; set; }
    }
}