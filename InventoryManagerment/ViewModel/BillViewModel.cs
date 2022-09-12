using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagerment.ViewModel
{
    public class BillViewModel
    {
        public int STT { get; set; }
        public string MAHOADON { get; set; }
        public string NGAYBAN { get; set; }
        public string TENKHACHHANG { get; set; }
        public double DEPT { get; set; }
        public double TONGTIEN { get; set; }
        public string TENSANPHAM { get; set; }
    }
}