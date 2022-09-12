using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagerment.ViewModel
{
    public class ImportViewModel
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public DateTime Time { get; set; }
        public string Note { get; set; }
        public string NameSupplier { get; set; }
        public bool ImportDelete { get; set; }
        public string NameSupply { get; set; }
        public decimal TotalPrice { get; set; }
    }
}