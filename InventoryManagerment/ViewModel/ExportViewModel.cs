using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagerment.ViewModel
{
    public class ExportViewModel
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string CustomerName { get; set; }
        public DateTime Time { get; set; }
        public bool Status { get; set; }
        public string NameUser { get; set; }
        public string Delivery { get; set; }
        public string Note { get; set; }
        public bool ExportDelete { get; set; }
        public string ProductCode { get; set; }
        public decimal TotalPrice { get; set; }
    }
}