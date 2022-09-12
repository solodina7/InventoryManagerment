namespace InventoryManagerment.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    [Table("ImportDetail")]
    public partial class ImportDetail
    {
        public long ID { get; set; }
        public string ImportCode { get; set; }
        public decimal ImportPrice { get; set; }
        [DisplayName("Sản phẩm")]
        public string ProductCode { get; set; }
        [DisplayName("Số lượng")]
        public long Quantity { get; set; }
        public long UnitID { get; set; }
        public long? PackageID { get; set; }
        public bool ImportDetailDelete { get; set; }
    }
}