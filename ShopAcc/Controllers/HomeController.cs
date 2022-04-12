using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopAcc.Models;

namespace ShopAcc.Controllers
{
    public class HomeController : Controller
    {
        dbShopAccDataContext data = new dbShopAccDataContext();


        public ActionResult Index()
        {
            ViewBag.Message = "Your Home page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}