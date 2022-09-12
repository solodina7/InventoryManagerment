namespace InventoryManagerment.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    [Table("Import")]
    public partial class Import
    {
        public long ID { get; set; }
        [DisplayName("Mã phiếu nhập")]
        public string Code { get; set; }
        [DisplayName("Ngày nhập")]
        public DateTime Time { get; set; }
        [DisplayName("Ghi chú")]
        public string Note { get; set; }
        public long SupplierID { get; set; }
        public bool ImportDelete { get; set; }
    }
}