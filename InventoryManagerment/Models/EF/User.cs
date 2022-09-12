namespace InventoryManagerment.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }
        [StringLength(50)]
        [DisplayName("Tên Đăng Nhập")]
        public string UserName { get; set; }
        [DisplayName("Mật Khẩu")]
        public string Password { get; set; }
        [DisplayName("Chức Vụ")]
        public long RoleID { get; set; }
        [DisplayName("Tên Người Dùng")]
        public string Name { get; set; }
        [DisplayName("Trạng thái")]
        public bool Status { get; set; }
    }
}