using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagerment.ViewModel
{
    public class RefundViewModel
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string CustomerName { get; set; }
        public DateTime Time { get; set; }
        public bool Status { get; set; }
        public string NameUser { get; set; }
        public string Note { get; set; }
        public bool RefundDelete { get; set; }
        public decimal TotalPrice { get; set; }
    }
}