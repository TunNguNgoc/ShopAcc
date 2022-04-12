using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace ShopAcc.Controllers
{
    public class ShopAccController : Controller
    {
        // GET: ShopAcc
        dbShopAccDataContext data = new dbShopAccDataContext();

        public ActionResult Acc()
        {
            var all_acc = from s in data.Accs select s;
            return View(all_acc);
        }
    }
}