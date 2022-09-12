namespace InventoryManagerment.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    [Table("Customer")]
    public partial class Customer
    {
        public long ID { get; set; }
        public string CustomerCode { get; set; }
        [DisplayName("Tên khách hàng")]
        public string Name { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }
    }
}