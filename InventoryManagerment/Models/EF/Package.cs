namespace InventoryManagerment.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    [Table("Package")]
    public partial class Package
    {
        public long ID { get; set; }
        [StringLength(50)]
        [DisplayName("Cách Thức Đóng Gói")]
        [Required(ErrorMessage ="Vui lòng nhập cách thức đóng gói")]
        public string Name { get; set; }
    }
}