namespace InventoryManagerment.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    [Table("Unit")]
    public partial class Unit
    {
        public long ID { get; set; }
        [StringLength(50)]
        [DisplayName("Đơn vị tính")]
        public string Name { get; set; }
    }
}