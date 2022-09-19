using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagerment.ViewModel
{
    public class ImportModel
    {
        public string Code { get; set; }
        public string ProductName { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
        public string UnitName { get; set; }
        public string PackageName { get; set; }
        public string SupplierName { get; set; }
        public string Time { get; set; }
        public decimal Total { get; set; }
        public string Note { get; set; }
    }
}