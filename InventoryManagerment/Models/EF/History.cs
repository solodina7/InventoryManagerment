namespace InventoryManagerment.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    [Table("History")]
    public partial class History
    {
        public long ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string ActionKey { get; set; }
        public string UserName { get; set; }
        public string Object { get; set; }
        public string ReceiptCode { get; set; }
    }
}