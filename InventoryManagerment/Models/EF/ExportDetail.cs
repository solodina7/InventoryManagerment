using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagerment.Models.EF
{
    [Table("ExportDetail")]
    public partial class ExportDetail
    {
        public long ID { get; set; }
        public string ExportCode { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public long Quantity { get; set; }
        public long UnitID { get; set; }
        public bool ExportDetailDelete { get; set; }
    }
}