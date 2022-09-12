using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagerment.Models.EF;

namespace InventoryManagerment.Models
{
    public class SupplierInformation
    {
        public Supplier supllier { get; set; }
        public List<SupplyDetail> listSupply {get;set;}
    }
}