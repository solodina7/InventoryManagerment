namespace InventoryManagerment.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        public long ID { get; set; }
        [DisplayName("Tên loại sản phẩm")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}