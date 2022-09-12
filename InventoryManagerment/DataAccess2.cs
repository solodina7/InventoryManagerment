using InventoryManagerment.Common;
using InventoryManagerment.Models.WINFORMS;
using InventoryManagerment.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagerment
{
    public class DataAccess2
    {
        BANHANGCONTEXT db;
        public DataAccess2()
        {
            db = new BANHANGCONTEXT();
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //Chức năng sổ xuất và hóa đơn bán
        public IEnumerable<NOTES> ListAllNotesToPagedList(string searchString,string note,DateTime? dateNote,string status,int page, int pageSize)
        {
            string date;
            if (dateNote.HasValue)
            {
                date = dateNote.Value.ToString("'Ngày' dd 'Tháng' MM 'Năm' yyyy");
            }
            else
            {
                date = " ";
            }
            if (!string.IsNullOrEmpty(note))
            {
                note = note.Trim();
            }
            else
            {
                note = " ";
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();
            }
            else
            {
                searchString = " ";
            }
            if (!string.IsNullOrEmpty(status))
            {
                if(status == "Đã Thanh Toán")
                {
                    status = "Đã";
                }
                if(status == "Chưa Thanh Toán (Có HĐ)")
                {
                    status = "Có";
                }
                if(status == "Chưa Thanh Toán (Không HĐ)")
                {
                    status = "Không";
                }
                if(status == "Tất cả")
                {
                    status = " ";
                }
            }
            else
            {
                status = " ";
            }
            var result = from ghichu in db.NOTEs
                         where ghichu.CUSTOMER.Contains(searchString) && ghichu.NOTE.Contains(note) && ghichu.TIME.Contains(date) && ghichu.STATUS.Contains(status)
                         orderby string.Concat(ghichu.TIME.Substring(21, 4), ghichu.TIME.Substring(14, 2), ghichu.TIME.Substring(5, 2), ghichu.TIME.Substring(28, 2), ghichu.TIME.Substring(35, 2), ghichu.TIME.Substring(43, 2)) descending
                         select ghichu;
            return result.ToPagedList(page, pageSize);
        }
        public IEnumerable<BillViewModel> ListAllHoaDonToPagedList(string searchString, string nameProduct,string totalPrice,DateTime? dateBill, int page, int pageSize)
        {
            string date;
            double price;
            if (dateBill.HasValue)
            {
                date = dateBill.Value.ToString("'Ngày' dd 'Tháng' MM 'Năm' yyyy");
            }
            else
            {
                date = "Ngày";
            }
            if(!string.IsNullOrEmpty(totalPrice))
            {
                price = Convert.ToDouble(Functions.RemoveCharacters(totalPrice));
            }
            else
            {
                price = double.MaxValue;
            }
            if (!string.IsNullOrEmpty(nameProduct))
            {
                nameProduct = nameProduct.Trim();
            }
            else
            {
                nameProduct = " "; 
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();
            }
            else
            {
                searchString = " ";
            }
            var ketqua = from bill in db.HOADONBANs
                         join detail in db.CHITIETHOADONs on bill.MAHOADON equals detail.MAHOADON
                         where bill.TENKHACHHANG.Contains(searchString) && detail.TENSANPHAM.Contains(nameProduct) && bill.NGAYBAN.Contains(date) && bill.TONGTIEN <= price
                         orderby string.Concat(bill.NGAYBAN.Substring(21, 4), bill.NGAYBAN.Substring(14, 2), bill.NGAYBAN.Substring(5, 2), bill.NGAYBAN.Substring(28, 2), bill.NGAYBAN.Substring(35, 2), bill.NGAYBAN.Substring(43, 2)) descending
                         group new { bill, detail } by new { bill.MAHOADON } into grp
                         select new BillViewModel()
                         {
                             MAHOADON = grp.Key.MAHOADON,
                             TENSANPHAM = grp.FirstOrDefault().detail.TENSANPHAM,
                             STT = grp.FirstOrDefault().bill.STT,
                             DEPT = grp.FirstOrDefault().bill.DEPT,
                             NGAYBAN = grp.FirstOrDefault().bill.NGAYBAN,
                             TENKHACHHANG = grp.FirstOrDefault().bill.TENKHACHHANG,
                             TONGTIEN = grp.FirstOrDefault().bill.TONGTIEN
                         };
            return ketqua.OrderByDescending(x=>x.STT).ToPagedList(page, pageSize);          
        }
    }
}