namespace InventoryManagerment.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    [Table("Supplier")]
    public partial class Supplier
    {
        public long ID { get; set; }
        [StringLength(50)]
        [DisplayName("Tên nhà cung cấp")]
        public string Name { get; set; }
        public string Code { get; set; }
    }
}