using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagerment.Models
{
    public class ListRefund
    {
        public string CustomerCode { get; set; }
        public string NameCustomer { get; set; }
        public string Price { get; set; }
        public DateTime Time { get; set; }
        public string Code { get; set; }
        public string ProductCode { get; set; }
        public long Quantity { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }
        public long UnitID { get; set; }
    }
}