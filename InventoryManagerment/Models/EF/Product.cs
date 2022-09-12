namespace InventoryManagerment.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }
        public string Code { get; set;}
        [DisplayName("Tên Sản Phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string Name { get; set;}
        [DisplayName("Đơn Vị Tính")]
        [Required(ErrorMessage ="Vui lòng chọn đơn vị tính")]
        public long UnitID { get; set; }
        [DisplayName("Giá Bán")]
        [Required(ErrorMessage = "Vui lòng nhập giá nhập")]
        public decimal Price { get; set; }
        [DisplayName("Số Lượng Tối Thiểu")]
        public long? QuantityAlert { get; set; }
        [DisplayName("Loại Sản Phẩm")]
        public long? CategoryID { get; set; }
        public long? ProductID { get; set; }
        [DisplayName("Cách Thức Đóng Gói")]
        public long? PackageID { get; set; }
        public long Quantity { get; set; }
        public decimal ImportPrice { get; set; }
    }
}