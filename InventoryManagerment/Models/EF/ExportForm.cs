using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagerment.Models.EF
{
    public class ExportForm
    {
        public Export Export { get; set; }
        public List<ExportDetail> exportDetails { get; set; }
    }
}