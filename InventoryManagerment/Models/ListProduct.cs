using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagerment.Models
{
    public class ListProduct
    {
        public string Name { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }    
        public string Package { get; set; }
    }
}