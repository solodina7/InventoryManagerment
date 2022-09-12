using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagerment.Models.WINFORMS
{
    [Table("HOADONBAN")]
    public partial class HOADONBAN
    {
        public int STT { get; set; }
        [Key]
        public string MAHOADON { get; set; }
        public string NGAYBAN { get; set; }
        public string TENKHACHHANG { get; set; }
        public double DEPT { get; set; }
        public double TONGTIEN { get; set; }
    }
}