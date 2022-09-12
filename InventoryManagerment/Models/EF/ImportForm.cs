using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagerment.Models.EF
{
    public class ImportForm
    {
        public Import Import { get; set; }
        public List<ImportDetail> importDetails {get;set;}
    }
}