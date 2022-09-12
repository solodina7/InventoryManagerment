using InventoryManagerment.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagerment.ViewModel
{
    public class ReceiptViewModel
    {
        public IEnumerable<RefundViewModel> listRefund { get; set; }
        public IEnumerable<ExportViewModel> listExport { get; set; }
    }
}