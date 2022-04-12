using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopAcc.Models
{
    public class GioHang
    {
        dbShopAccDataContext data = new dbShopAccDataContext();
        public int id { get; set; }
        [Display(Name = "Tên")]
        public string ten { get; set; }
        [Display(Name = "Ánh bìa")]
        public string hinh { get; set; }
        [Display(Name = "Giá bán")]
        public Double gia { get; set; }
        [Display(Name = "Số lượng")]
        public int isSoluong { get; set; }
        [Display(Name = "Thành tiền")]
        public Double dThanhtien
        {
            get { return isSoluong * gia; }
        }
        public GioHang(int id)
        {
            this.id = id;
            Acc acc = data.Accs.Single(n => n.id == id);
            ten = acc.ten;
            hinh = acc.hinh;
            gia = double.Parse(acc.gia.ToString());
            isSoluong = 1;
          
        }




    }
}