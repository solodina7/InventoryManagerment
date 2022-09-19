using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagerment.Models
{
    public class ProductModel
    {
        public string SupplierCode { get; set; }
        public DateTime Time { get; set; }
        public string Code { get; set; }
        public string ProductCode { get; set; }
        public string Price { get; set; }
        public long Quantity { get; set; }
        public string Note { get; set; }
        public long UnitID { get; set; }
        public long PackageID { get; set; }
    }
}