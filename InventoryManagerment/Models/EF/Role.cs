namespace InventoryManagerment.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    [Table("Role")]
    public partial class Role
    {
        public long ID { get; set; }
        [DisplayName("Tên chức vụ")]
        [StringLength(50)]
        [Required(ErrorMessage ="Vui lòng nhập tên chức vụ")]
        public string Name { get; set; }
    }
}