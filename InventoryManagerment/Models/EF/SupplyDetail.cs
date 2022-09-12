namespace InventoryManagerment.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.ComponentModel;

    [Table("SupplyDetail")]
    public partial class SupplyDetail
    {
        public long ID { get; set; }
        [DisplayName("Giá sản phẩm")]
        public decimal Price { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string ProductCode { get; set; }
        public long SupplierID { get; set; }
        [DisplayName("Đơn vị tính")]
        public long UnitID { get; set; }
    }
}