namespace InventoryManagerment.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    [Table("Refund")]
    public partial class Refund
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string CustomerCode { get; set; }
        public DateTime Time { get; set; }
        public bool Status { get; set; }
        public long UserID { get; set; }
        public string Note { get; set; }
        public bool RefundDelete { get; set; }
    }
}