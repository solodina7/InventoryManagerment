using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagerment.Models.WINFORMS
{
    [Table("CHITIETHOADON")]
    public partial class CHITIETHOADON
    {
        [Key]
        public int ID { get; set; }
        public string MAHOADON { get; set; }
        public string TENSANPHAM { get; set; }
        public string DONVITINH { get; set; }
        public double SOLUONG { get; set; }
        public double GIADONVI { get; set; }
        public double THANHTIEN { get; set; }
    }
}